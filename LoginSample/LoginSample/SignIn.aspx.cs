using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.Configuration;
namespace LoginSample
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
        }     
    
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            HttpWebResponse parkingPandaWebResponse = null;
            try
            {
                string parkingPandaUrl = ConfigurationManager.ConnectionStrings["parkingPandaUrl"].ConnectionString+"?authType=basic&includeCreditCards=false";
                WebRequest parkingPandaWebRequest = WebRequest.Create(parkingPandaUrl);
                //WebRequest parkingPandaWebRequest = WebRequest.Create(@"http://dev.parkingpanda.com/api/v2/users?authType=basic&includeCreditCards=false");
                parkingPandaWebRequest.Method = "GET";
                string userNamePassword = txtEmail.Text.Trim() + ":" + txtPassword.Text.Trim();
                parkingPandaWebRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(userNamePassword));

                parkingPandaWebResponse = parkingPandaWebRequest.GetResponse() as HttpWebResponse;

                var temp = parkingPandaWebResponse.GetResponseStream();
                StreamReader sr = new StreamReader(temp);
                string sample = sr.ReadToEnd();

                Session["ParkingPandaData"] = sample;
                Server.Transfer("UserDetails.aspx");
            }
            catch(WebException ex)
            {
                lblError.Visible = true;
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    parkingPandaWebResponse = (HttpWebResponse)ex.Response;

                    Console.Write("Errorcode: {0}", (int)parkingPandaWebResponse.StatusCode);
                }
                else
                {
                    Console.Write("Error: {0}", ex.Status);
                }

            }
        }

    }
}