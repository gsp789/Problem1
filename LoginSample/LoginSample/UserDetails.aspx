<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="UserDetails.aspx.cs" Inherits="LoginSample.UserDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>UserDetails</title>
    <link rel="stylesheet" href="css/bootstrap.min.css" />
</head>

<body>
    <form id="form1" runat="server">
  <nav class="navbar navbar-default">
  <div class="container-fluid">
    <div class="navbar-header">
        <a id="lnkLogo" class="navbar-brand unvisible" href="./"><img id="imgLogo" src="Images/parkingpanda.png" alt="Parking Panda Logo" width="150" height="35"></a>
      </div>
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1"> 
      <ul class="nav navbar-nav navbar-right">
          <br />
          <asp:Button  runat="server" class="btn btn-sm btn-primary btn-block" Text="Logout" ID="btnLogout" OnClick="btnLogout_Click" ></asp:Button>
      </ul>
    </div>
  </div>
</nav>        
        <div class="container">
            <div class="row">
                <div class="col-md-3">
                    <h4 class="form-signin-heading">User Details</h4>
                    <asp:Label for="lblFirstName"  runat="server" Text="FirstName"></asp:Label>
                    <asp:TextBox id="txtFirstName" runat="server" class="form-control" required autofocus ReadOnly="True"/>
                    <asp:Label for="lblLastName"  runat="server" Text="LastName"></asp:Label>
                    <asp:TextBox id="txtLastName" runat="server" class="form-control" required ReadOnly="True" />
                    <asp:Label for="lblEmailId"  runat="server" Text="Email"></asp:Label>
                    <asp:TextBox id="txtEmailId" runat="server" class="form-control" required autofocus ReadOnly="True"/>
                    <asp:Label for="lblPhone"  runat="server" Text="Phone"></asp:Label>
                    <asp:TextBox id="txtPhone" runat="server" class="form-control" required autofocus ReadOnly="True"/>
                    <br />
                    <asp:Button id="btnEditPP" runat="server" class="btn btn-sm btn-primary btn-block" Text="Edit User" OnClick="btnEditPP_Click" />
                    <br />
                    <div id="btnSubmitCancel" runat="server" visible="false">
                        <asp:Button runat="server" id="btnSave" class="btn btn-sm btn-primary btn-block" Text="Save" OnClick="btnSave_Click" ></asp:Button>
                    <asp:Button runat="server" id="btnCancel" class="btn btn-sm btn-primary btn-block" Text="Cancel" OnClick="btnCancel_Click" ></asp:Button>
                    </div>                    
                </div>
                
            </div>
            
        </div>
    
    </form>
</body>
</html>