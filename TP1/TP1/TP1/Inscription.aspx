<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="TP1.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css" />
    <title></title>

     <script type="text/javascript">
     var RecaptchaOptions = {
        theme : 'custom',
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

                <asp:Image ID="IMG_User_Inscription" class=" inscrip_img img-circle " runat="server" ClientIDMode="Static" src="Avatars\DefaultAvatar2.png" />
                 <asp:Button ID="BTN_Choisir_Image" class="btn btn-lg btn-primary btn_chose" runat="server" Text="Choisir" OnClick="BTN_Choisir_Image_Click" />

                <label for="inputNomU" class="sr-only">Username</label>
                <asp:TextBox type="name" id="nom_Usager" class="form-control" placeholder="Nom Usager" autofocus runat="server"></asp:TextBox>
                <label for="inputPrenom" class="sr-only">Prenom</label>
                <asp:TextBox type="name" id="Prenom_ID" class="form-control" placeholder="Prenom" runat="server" ></asp:TextBox>
                <label for="inputNom" class="sr-only">Prenom</label>
                <asp:TextBox type="name" id="Nom_ID" class="form-control" placeholder="Nom"  runat="server"></asp:TextBox>
                 <label for="inputEmail" class="sr-only">Email address</label>
                <asp:TextBox type="email" id="inputEmail" class="form-control" placeholder="Email address" runat="server"></asp:TextBox>
                <label for="inputEmail" class="sr-only">Confirmer Email address</label>
                <asp:TextBox type="email" id="inputEmail_confrim" class="form-control" placeholder="Confirmer Email address"  runat="server"></asp:TextBox>
                <label for="inputPassword" class="sr-only">Password</label>
                <asp:TextBox type="password" id="inputPassword" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                <label for="inputPassword" class="sr-only">Password</label>
                <asp:TextBox type="password" id="inputPassword_Con" data-match="#inputPassword" data-match-error="Whoops, these don't match" class="form-control" placeholder="Confirmer Password" runat="server"></asp:TextBox>

                <form method="post" action="<?php echo $base_url; ?>user/register/check" method="post" class="form-horizontal well" accept-charset="UTF-8">

                    <script type="text/javascript">
                        var RecaptchaOptions = {
                            theme: 'custom',
                            custom_theme_widget: 'recaptcha_widget'
                        };
                    </script>
                    <div id="recaptcha_widget" style="display:none">

                        <div class="control-group">
                            <label class="control-label"></label>
                            <div class="controls">
                                <a id="recaptcha_image" href="#" class="thumbnail"></a>
                                <div class="recaptcha_only_if_incorrect_sol" style="color:red">Incorrect please try again</div>
                            </div>
                        </div>

                           <div class="control-group">
                               <label class="recaptcha_only_if_image control-label">Enter the words above:</label>
                              <label class="recaptcha_only_if_audio control-label">Enter the numbers you hear:</label>

                              <div class="controls">
                                  <div class="input-append">
                                      <input type="text" id="recaptcha_response_field" name="recaptcha_response_field" class="input-recaptcha" />
                                    <a class="btn" href="javascript:Recaptcha.reload()"><i class="icon-refresh">Reload</i></a>
                                      <a class="btn recaptcha_only_if_image" href="javascript:Recaptcha.switch_type('audio')"><i title="Get an audio CAPTCHA" class="icon-headphones"></i></a>
                                      <a class="btn recaptcha_only_if_audio" href="javascript:Recaptcha.switch_type('image')"><i title="Get an image CAPTCHA" class="icon-picture"></i></a>
                                    <a class="btn" href="javascript:Recaptcha.showhelp()"><i class="icon-question-sign"></i></a>
                                  </div>
                              </div>
                        </div>

                    </div>

                    <script type="text/javascript"
                       src="<?php echo $recaptcha_url; ?>">
                    </script>

                    <noscript>
                        <iframe src="<?php echo $recaptcha_noscript_url; ?>"
                           height="300" width="500" frameborder="0"></iframe><br>
                        <textarea name="recaptcha_challenge_field" rows="3" cols="40">
                        </textarea>
                        <input type="hidden" name="recaptcha_response_field"
                           value="manual_challenge">
                      </noscript>
</form>
<script type="text/javascript" src="https://www.google.com/recaptcha/api/challenge?k=6LcrK9cSAAAAALEcjG9gTRPbeA0yAVsKd8sBpFpR"></script>

<noscript>
    <iframe src="<?php echo $recaptcha_noscript_url; ?>"
       height="300" width="500" frameborder="0"></iframe><br>
    <textarea name="recaptcha_challenge_field" rows="3" cols="40">
    </textarea>
    <input type="hidden" name="recaptcha_response_field" value="manual_challenge">
</noscript>

                
            </form>

                <div class="center_button">
                 <asp:Button ID="BTN_Inscription" class="btn btn-lg btn-primary btn-block" runat="server" Text="Inscription" OnClick="BTN_Inscription_Click" />
                 <asp:Button ID="BTN_Inscription_Annuler" class="btn btn-lg btn-primary btn-block" runat="server" Text="Annuler"  PostBackUrl="~/Login.aspx" OnClick="BTN_Inscription_Annuler_Click" />
               
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
