<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP1.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <asp:Panel ID="Main_Panel" runat="server" >
        <table>
            <tr>
                <td>
                    <asp:Label ID="LB_Username" runat="server" Text="Nom d'utilisateur :"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TB_Username" runat="server"></asp:TextBox>
                    <asp:CustomValidator ID="CV_Username" Text="Vide!" runat="server" ControlToValidate="TB_Password" ValidateEmptyText="true" OnServerValidate="CV_Username_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LB_Password" runat="server" Text="Password : "></asp:Label></td>
                <td>
                    <asp:TextBox ID="TB_Password" runat="server" type="password"></asp:TextBox>
                    <asp:CustomValidator ID="CV_Password" Text="Vide!" runat="server" ControlToValidate="TB_Password" ValidateEmptyText="true" OnServerValidate="CV_Password_ServerValidate"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BTN_Login" runat="server" CssClass="Button" Text="Connexion..." OnClick="BTN_Login_Click" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BTN_Inscription" runat="server" CssClass="Button" Text="Inscription..." OnClick="BTN_Inscription_Click" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BTN_ForgotPassword" runat="server" CssClass="Button" Text="Mot de passe oublié..." OnClick="BTN_PasswordReminder_Click" /></td>
            </tr>
        </table>
        <asp:ValidationSummary ID="Login_Validation" runat="server" />

    </asp:Panel>
</asp:Content>

