<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="TP1.Room" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
  <form id="form1" runat="server">
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
      <asp:Button ID="BTN_Retour" runat="server" Text="Retour..." PostBackUrl="~/Index.aspx"/>
  </form>
</body>
</html>
