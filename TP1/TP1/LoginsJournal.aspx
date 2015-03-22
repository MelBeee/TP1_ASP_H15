<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginsJournal.aspx.cs" Inherits="TP1.LoginsJournal" MasterPageFile="masterpage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">
    <div>
        <asp:Panel ID="PN_Users" runat="server"></asp:Panel>
        <asp:Button ID="BTN_Retour" runat="server" Text="Retour..." OnClick="BTN_Retour_Click" PostBackUrl="~/Index.aspx" />
    </div>
</asp:Content>





