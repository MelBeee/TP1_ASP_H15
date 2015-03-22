<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="TP1.Room" MasterPageFile="~/masterpage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1"
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="En ligne" DataField="ID" SortExpression="ID" />
            <asp:BoundField HeaderText="Nom d'usager" DataField="Username" SortExpression="Username" />
            <asp:BoundField HeaderText="Nom complet" DataField="Fullname" SortExpression="Fullname" />
            <asp:BoundField HeaderText="Adresse courriel" DataField="Email" SortExpression="Email" />
            <asp:BoundField HeaderText="Avatar" DataField="Avatar" SortExpression="Avatar" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"
        SelectCommand="SELECT [ID], [Username], [Fullname], [Email], [Avatar] FROM [users]"
        ConnectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\MainDB.mdf;Integrated Security=True" ProviderName="System.Data.SqlClient" />
    <asp:Button ID="BTN_Retour" runat="server" Text="Retour..." PostBackUrl="~/Index.aspx" />
</asp:Content>
