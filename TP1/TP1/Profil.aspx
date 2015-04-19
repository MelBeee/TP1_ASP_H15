<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Profil.aspx.cs" Inherits="TP1.Profil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css" />
    <script src="ClientFormUtilities.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div>
            <div class="container">

                <div class="row">
                    <div class="col-md-4 col-md-offset-4">

                        <form class="form-signin">

                            <div class="col-md-4 col-md-offset-4">
                            <h2 class="form-signin-heading user"><asp:Label ID="LB_Username" runat="server" Text=""></asp:Label></h2>
                            </div>

                            <asp:Label ID="LB_ID" type="hidden" runat="server" Text=""></asp:Label>
                            <asp:Image ID="IMG_Avatar" class=" inscrip_img img-circle " runat="server" ClientIDMode="Static"  />
                            <asp:FileUpload ID="FU_Avatar" runat="server" ClientIDMode="Static" onchange="PreLoadImage();" />
                             <asp:Label ID="LabelImage" CssClass="warning" runat="server" Text=""></asp:Label>

                            <label for="inputPrenom" class="sr-only">Prenom</label>
                            <asp:TextBox type="name" ID="TB_Fullname" class="form-control" placeholder="Nom Complet" runat="server"></asp:TextBox>
                            <asp:Label ID="LabelPrenom_inscri" CssClass="warning" runat="server" Text=""></asp:Label>

                            <label for="inputEmail" class="sr-only">Email address</label>
                            <asp:TextBox type="email" ID="TB_Email" class="form-control" placeholder="Email address" runat="server"></asp:TextBox>
                            <asp:Label ID="LabelEmail_inscri" CssClass="warning" runat="server" Text=""></asp:Label>

                            <label for="inputEmail" class="sr-only">Confirmer Email address</label>
                            <asp:TextBox type="email" ID="TB_EmailConfirm" class="form-control" placeholder="Confirmer Email address" runat="server"></asp:TextBox>
                            <asp:Label ID="LabelEmailConf_inscri" CssClass="warning" runat="server" Text=""></asp:Label>

                            <label for="inputPassword" class="sr-only">Password</label>
                            <asp:TextBox type="password" ID="TB_Password" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                            <asp:Label ID="LabelPassword_inscri" CssClass="warning" runat="server" Text=""></asp:Label>

                            <label for="inputPassword" class="sr-only">Password</label>
                            <asp:TextBox type="password" ID="TB_PasswordConfirm" class="form-control" placeholder="Confirmer Password" runat="server"></asp:TextBox>
                            <asp:Label ID="LabelPasswordConf_inscri" CssClass="warning" runat="server" Text=""></asp:Label>

                            <asp:Label ID="LabelPassword_pasPareil" CssClass="warning" runat="server" Text=""></asp:Label>
                            <asp:Label ID="LabelEmail_pasPareil" CssClass="warning" runat="server" Text=""></asp:Label>

                            <asp:Button ID="BTN_Update" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Modifier" OnClick="BTN_Update_Click" />
                            <asp:Button ID="BTN_Inscription_Annuler" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Annuler" PostBackUrl="~/Index.aspx" />
                        </form>
                    </div>
                </div>
            </div>
        </div>

</asp:Content>
