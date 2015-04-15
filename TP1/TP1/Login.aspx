<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" enableEventValidation="false" CodeBehind="Login.aspx.cs" Inherits="TP1.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="row">
            <div class="col-md-4 col-md-offset-4">

                <form class="form-signin">
                    <h2 class="form-signin-heading">Please sign in</h2>

                    <asp:Panel ID="Main_Panel" runat="server">

                        
                        <label for="inputNomU" class="sr-only">Username</label>
                        <asp:TextBox type="name" ID="TB_Username" class="form-control" placeholder="Nom Usager" autofocus runat="server"></asp:TextBox>
                        <asp:CustomValidator ID="CV_Username" Text="Vide!" runat="server" ControlToValidate="TB_Password" ValidateEmptyText="true" OnServerValidate="CV_Username_ServerValidate"></asp:CustomValidator>

                        <label for="inputPassword" class="sr-only">Password</label>
                        <asp:TextBox type="password" id="TB_Password" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                        <asp:CustomValidator ID="CV_Password" Text="Vide!" runat="server" ControlToValidate="TB_Password" ValidateEmptyText="true" OnServerValidate="CV_Password_ServerValidate"></asp:CustomValidator>

                        <asp:Button ID="BTN_Login" runat="server" CssClass="Button" Text="Connexion..." OnClick="BTN_Login_Click" /></td>

                    <asp:Button ID="BTN_Inscription" runat="server" CssClass="Button" Text="Inscription..." OnClick="BTN_Inscription_Click" /></td>

                    <asp:Button ID="BTN_ForgotPassword" runat="server" CssClass="Button" Text="Mot de passe oublié..." OnClick="BTN_PasswordReminder_Click" /></td>

        <asp:ValidationSummary ID="Login_Validation" runat="server" />

                    </asp:Panel>
                </form>
            </div>

        </div>
    </div>
</asp:Content>

