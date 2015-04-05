<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css" />
    <title></title>

    <link href="Main.css" rel="stylesheet" />
    <script src="ClientFormUtilities.js"></script>


     <nav class="navbar navbar-inverse" role="navigation">
        <h2 style="color: white">LogIn
        <a class="navbar-brand navbar-right" href="#">
                </a>
            </h2>
    </nav>



</head>
<body>
    <form id="form1" runat="server">

         <div class="container">

            <div class="row">
            <div class="col-md-5 col-md-offset-2">

            <form class="form-signin">
                <h2 class="form-signin-heading">Please Login</h2>
        
                         <label for="inputNomU" class="sr-only">Username</label>
                         <asp:TextBox type="name" id="TB_Username" class="form-control" placeholder="Nom Usager"  autofocus  runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator
                            ID="RFV_TB_Username"
                            runat="server"
                            Text="Champ requis"
                            ErrorMessage="Nom d'utilisateur obligatoire !"
                            ControlToValidate="TB_Username"
                            ValidationGroup="VG_Login"> 
                        </asp:RequiredFieldValidator>

                        <asp:CustomValidator
                            ID="CV_Username"
                            runat="server"
                            ErrorMessage="Nom d'utilisateur innexistant !"
                            Display="None"
                            ValidationGroup="VG_Login"
                            OnServerValidate="CV_TB_UserName_ServerValidate"> 
                        </asp:CustomValidator>
             
                       <label for="inputPassword" class="sr-only">Password</label>
                        <asp:TextBox type="password" ID="TB_Password" runat="server" class="form-control" placeholder="Password"  autofocus></asp:TextBox>
                        <asp:RequiredFieldValidator
                            ID="RFV_TB_Password"
                            runat="server"
                            Text="Champ requis"
                            ErrorMessage="Mot de passe obligatoire !"
                            ControlToValidate="TB_Password"
                            ValidationGroup="VG_Login"> 
                        </asp:RequiredFieldValidator>

                        <asp:CustomValidator
                            ID="CV_Password"
                            runat="server"
                            ErrorMessage="Mot de passe invalide !"
                            Display="None"
                            ValidationGroup="VG_Login"
                            OnServerValidate="CV_Password_ServerValidate"> 
                        </asp:CustomValidator>


                <div class="center_button">  
                        <asp:Button ID="BTN_Login" runat="server" Text="LogIn" class="btn btn-lg btn-primary btn-block" ValidationGroup="VG_Login" OnClick="BTN_Login_Click" />
               
                        <asp:Button ID="BTN_Inscription" class="btn btn-lg btn-primary btn-block" runat="server" Text="Register"  PostBackUrl="~/Inscription.aspx" />
                
                        <asp:Button ID="BTN_PasswordReminder" class="btn btn-lg btn-primary btn-block" runat="server" Text="Forgot Password" OnClick="BTN_PasswordReminder_Click" />
               
                        <asp:ValidationSummary
                            ID="VGS_Logi"
                            runat="server"
                            ValidationGroup="VG_Login"
                            HeaderText="Erreurs rencontrées : &lt;hr/&gt;" />
                </div>
            </form>
                </div>
                </div>
            
        </div>
                  
    </form>

     <footer id="footer">

    <div class="footer-copyright">
        <div class="container">
            <div class="row">
                <div class="col-md-8 col-md-offset-4">
                    <p>&copy; Copyright 2015 by Dominic Clement and Mélissa Boucher. All Rights Reserved.</p>
                </div>
            </div>
        </div>
    </div>
</footer>
</body>
</html>
