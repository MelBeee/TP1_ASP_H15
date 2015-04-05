<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginsJournal.aspx.cs" Inherits="TP1.LoginsJournal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="PN_Users" runat="server"></asp:Panel>
        <asp:Button ID="BTN_Retour" runat="server" Text="Retour..." OnClick="BTN_Retour_Click" PostBackUrl="~/Index.aspx" />
    </div>
    </form>
</body>
</html>




	
