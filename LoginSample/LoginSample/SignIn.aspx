<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="LoginSample.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>SignIn</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-lg-3"></div>
                <div class="col-md-3">
                    <form class="form-signin">
                        <h4 class="form-signin-heading">Please sign into ParkingPanda</h4>
                        <br />
                        <asp:Label for="inputEmail" runat="server">Email address</asp:Label>
                        <asp:TextBox type="email" id="txtEmail" runat="server" class="form-control" placeholder="Email " required autofocus/>
                        <asp:Label for="inputPassword" runat="server" >Password</asp:Label>
                        <asp:TextBox type="password" runat="server" id="txtPassword" class="form-control" placeholder="Password" required/>
                        <div class="checkbox">
                          <asp:Label ID="lblError" runat="server" BackColor="#CC0000" ForeColor="White" Text="Invalid EmailId/Password" Visible="false" ></asp:Label>
                        </div>
                        <asp:Button runat="server" id="btnSubmit" class="btn btn-sm btn-primary btn-block" Text="Sign in" OnClick="btnSubmit_Click"></asp:Button>
                    </form>
                </div>
                
            </div>
        </div>
    </form>
</body>
</html>