<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="TP1.Profil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css" />
    
    <script src="ClientFormUtilities.js"></script>
    <title></title>
</head>
<body>
    <form id="Profile_page" runat="server">
    <div>
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

                    </form>

                <div class="center_button">
                 <asp:Button ID="BTN_Inscription" class="btn btn-lg btn-primary btn-block" runat="server" Text="Modifier" />
                 <asp:Button ID="BTN_Inscription_Annuler" class="btn btn-lg btn-primary btn-block" runat="server" Text="Annuler"  PostBackUrl="~/Index.aspx" />
               
            </div>

                </div>
                </div>
            
        </div>
    
    </div>
    </form>
</body>
</html>
