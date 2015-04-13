<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TP1.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <table>
        <tr>
            <td>
                <asp:Button ID="BTN_Profil" runat="server" Text="Gérer votre profil..." OnClick="BTN_Profil_Click" /></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="BTN_JournalLog" runat="server" Text="Journal des visites..." OnClick="BTN_JournalLog_Click" /></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="BTN_ManageThreads" runat="server" Text="Gérer mes discussions..." OnClick="BTN_ManageThreads_Click" /></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="BTN_ChatRoom" runat="server" Text="Salle de discussion..." OnClick="BTN_ChatRoom_Click" /></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="BTN_Room" runat="server" Text="Usagers en ligne..." OnClick="BTN_Room_Click" /></td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="BTN_LogOff" runat="server" Text="Déconnexion..." OnClick="BTN_LogOff_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

