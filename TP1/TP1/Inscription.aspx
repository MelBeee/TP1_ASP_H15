<%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="false" CodeBehind="Inscription.aspx.cs" Inherits="TP1.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css" />
    
    <script src="ClientFormUtilities.js"></script>
    <title></title>

     <script type="text/javascript" >

         var RecaptchaOptions = {
             theme: 'custom',
             custom_theme_widget: 'recaptcha_widget'
         };
     </script>       

    <nav class="navbar navbar-inverse" role="navigation">
        <h2 style="color: white">Inscription
    </nav>
</head>
<body>
    <form id="form1" runat="server">


        <div class="container">

            <div class="row">
            <div class="col-md-4 col-md-offset-4">

            <form class="form-signin">
                <h2 class="form-signin-heading">Please sign in</h2>

                <asp:Image ID="IMG_Avatar" class=" inscrip_img img-circle " runat="server" ClientIDMode="Static"  ImageUrl="~\Avatars\DefaultAvatar2.png" />

                <asp:FileUpload ID="FU_Avatar" runat="server" ClientIDMode="Static" onchange="PreLoadImage();"/>


                <label for="inputNomU" class="sr-only">Username</label>
                <asp:TextBox type="name" id="nom_Usager" class="form-control" placeholder="Nom Usager" autofocus runat="server"></asp:TextBox>
                 <asp:Label ID="LabelUsername_inscr" runat="server" Text=""></asp:Label>

                <label for="inputPrenom" class="sr-only">Prenom</label>
                <asp:TextBox type="name" id="Prenom_ID" class="form-control" placeholder="Prenom" runat="server" ></asp:TextBox>
                 <asp:Label ID="LabelPrenom_inscri" runat="server" Text=""></asp:Label>

                
                <label for="inputNom" class="sr-only">Prenom</label>
                <asp:TextBox type="name" id="Nom_ID" class="form-control" placeholder="Nom"  runat="server"></asp:TextBox>
                <asp:Label ID="LabelNom_inscri" runat="server" Text=""></asp:Label>

               

                 <label for="inputEmail" class="sr-only">Email address</label>
                <asp:TextBox type="email" id="inputEmail" class="form-control" placeholder="Email address" runat="server"></asp:TextBox>
                <asp:Label ID="LabelEmail_inscri" runat="server" Text=""></asp:Label>

                <label for="inputEmail" class="sr-only">Confirmer Email address</label>
                <asp:TextBox type="email" id="inputEmail_confrim" class="form-control" placeholder="Confirmer Email address"  runat="server"></asp:TextBox>
                <asp:Label ID="LabelEmailConf_inscri" runat="server" Text=""></asp:Label>
                
                <label for="inputPassword" class="sr-only">Password</label>
                <asp:TextBox type="password" id="inputPassword" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                <asp:Label ID="LabelPassword_inscri" runat="server" Text=""></asp:Label>
                
              

                <label for="inputPassword" class="sr-only">Password</label>
                <asp:TextBox type="password" id="inputPassword_Con" class="form-control" placeholder="Confirmer Password" runat="server"></asp:TextBox>
                <asp:Label ID="LabelPasswordConf_inscri" runat="server" Text=""></asp:Label>

                <asp:ScriptManager ID="ScriptManager1" runat="server"/>
        <div>
            <table>
                <tr>    
                    <td colspan="2">
                        <asp:UpdatePanel ID="PN_Captcha" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton    ID="RegenarateCaptcha" runat="server" 
                                                        ImageUrl="~/Images/RegenerateCaptcha.png" 
                                                        CausesValidation="False" 
                                                        onclick ="RegenarateCaptcha_Click"
                                                        ValidationGroup="Subscribe_Validation" 
                                                        width="48"
                                                        ToolTip="Regénérer le captcha..." />  
                                    </td>
                                    <td>
                                        <asp:Image ID="IMGCaptcha" imageurl="~/captcha.png" runat="server" />
                                    </td>
                                </tr>
                        </table>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>      
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TB_Captcha" runat="server" MaxLength="5" ></asp:TextBox>
                        <asp:CustomValidator    ID="CV_Captcha" runat="server" 
                                                ErrorMessage="Code captcha incorrect!" 
                                                ValidationGroup="Subscribe_Validation"
                                                Text="!" 
                                                ControlToValidate="TB_Captcha" 
                                                onservervalidate="CV_Captcha_ServerValidate" 
                                                ValidateEmptyText="True">
                                                </asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="BTN_Submit" runat="server"
                                    Text="Soumettre ..."
                                    ValidationGroup="Subscribe_Validation"
                                    OnClick="BTN_Submit_Click" />
                </tr>
            </table>
        </div>
        <asp:ValidationSummary ID="Subscribe_Validation" runat="server" ValidationGroup="Subscribe_Validation" />

                
            </form>

                <div class="center_button">
                 <asp:Button ID="BTN_Inscription" class="btn btn-lg btn-primary btn-block" runat="server" Text="Inscription" OnClick="BTN_Inscription_Click"/>
                 <asp:Button ID="BTN_Inscription_Annuler" class="btn btn-lg btn-primary btn-block" runat="server" Text="Annuler"  PostBackUrl="~/Login.aspx" />
               
            </div>

                </div>
                </div>
            
        </div>
        <!-- /container -->

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
