<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TP1.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
  <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Profil" runat="server" Text="Gérer votre profil..." PostBackUrl="~/Profil.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Usagers" runat="server" Text="Usagers en ligne..." PostBackUrl="~/Room.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Journal" runat="server" Text="Journal des visites..." PostBackUrl="~/LoginsJournal.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BTN_LogOff" runat="server" Text="Déconnexion..." OnClick="BTN_LogOff_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
