using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginSample
{
	public partial class UserDetails : System.Web.UI.Page
	{
		static string apiPassword = "";
		string FirstName = "";
		string LastName = "";
		string Emailid = "";
		string Phone = "";
		static string userId = "";
        static string userEmail = "";
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!Page.IsPostBack)
			{ 
				if(Session["ParkingPandaData"]!=null)
				{
					JObject myValues = JObject.Parse(Session["ParkingPandaData"].ToString());
					apiPassword = (string)myValues["data"]["apiPassword"];
					userId = (string)myValues["data"]["id"];
                    userEmail = (string)myValues["data"]["email"];

					txtFirstName.Text = (string)myValues["data"]["firstName"];
					txtLastName.Text = (string)myValues["data"]["lastName"];
					txtEmailId.Text = (string)myValues["data"]["email"];
					txtPhone.Text = (string)myValues["data"]["phone"];				
				}
			}
		}		
		protected void btnLogout_Click(object sender, EventArgs e)
		{
			Session["ParkingPandaData"] = null;
			Server.Transfer("SignIn.aspx");
		}
		protected void btnEditPP_Click(object sender, EventArgs e)
		{
            SetReadOnly(false);
			btnEditPP.Visible = false;
			btnSubmitCancel.Visible = true;
		}
		protected void btnSave_Click(object sender, EventArgs e)
		{
            string updatedParkingPandaResponse="";
            string parkingPandaUrl = ConfigurationManager.ConnectionStrings["parkingPandaUrl"].ConnectionString+"/"+userId;
            var serializer = new JavaScriptSerializer();
            string jsonString = serializer.Serialize(new
            {
                email = txtEmailId.Text,
                firstName = txtFirstName.Text,
                lastName = txtLastName.Text,
                phone = txtPhone.Text
            });

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(parkingPandaUrl);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            string userNameAndPassword = userEmail+":"+apiPassword;
            httpWebRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(userNameAndPassword));
            httpWebRequest.ContentLength = jsonString.Length;

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(jsonString);
            }
            try
            {
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                   updatedParkingPandaResponse = streamReader.ReadToEnd();
                }
            }
            catch(WebException ex)
            {
                Console.Out.WriteLine(ex.Message); 
            }
            Session["ParkingPandaData"] = updatedParkingPandaResponse;
            SetReadOnly(true);
            btnEditPP.Visible = true;
            btnSubmitCancel.Visible = false;
		}
		protected void btnCancel_Click(object sender, EventArgs e)
		{
            SetReadOnly(true);
			btnEditPP.Visible = true;
			btnSubmitCancel.Visible = false;
        }		
        public void SetReadOnly(bool isReadOnly)
        {
            txtFirstName.ReadOnly = isReadOnly;
            txtLastName.ReadOnly = isReadOnly;
            txtEmailId.ReadOnly = isReadOnly;
            txtPhone.ReadOnly = isReadOnly;            
        }
	}
}