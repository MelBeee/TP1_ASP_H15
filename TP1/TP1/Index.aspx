<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TP1.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">

        <div class="row">
            <div class="col-md-4 col-md-offset-4">

                <form class="form-signin">
                    <asp:Button ID="BTN_Profil" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Gérer votre profil" OnClick="BTN_Profil_Click" />
                    <asp:Button ID="BTN_JournalLog" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Journal des visites" OnClick="BTN_JournalLog_Click" />
                    <asp:Button ID="BTN_ManageThreads" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Gérer mes discussions" OnClick="BTN_ManageThreads_Click" />
                    <asp:Button ID="BTN_ChatRoom" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Salle de discussion" OnClick="BTN_ChatRoom_Click" />
                    <asp:Button ID="BTN_Room" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Usagers en ligne" OnClick="BTN_Room_Click" />
                    <asp:Button ID="BTN_LogOff" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Déconnexion" OnClick="BTN_LogOff_Click" />
                </form>
            </div>

        </div>

       

</asp:Content>

