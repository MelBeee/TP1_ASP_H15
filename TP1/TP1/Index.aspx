<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TP1.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
     <link rel="stylesheet" href="css/style.css" />
    <title></title>
</head>
<body>
  <form id="form1" runat="server">
        <div class="container">
            <table>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Profil" runat="server" Text="Gérer votre profil..." class="btn btn-lg btn-primary btn-block" PostBackUrl="~/Profil.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Usagers" runat="server" Text="Usagers en ligne..."  class="btn btn-lg btn-primary btn-block" PostBackUrl="~/Room.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BTN_Journal" runat="server" Text="Journal des visites..."  class="btn btn-lg btn-primary btn-block" PostBackUrl="~/LoginsJournal.aspx" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="BTN_LogOff" runat="server" Text="Déconnexion..."   class="btn btn-lg btn-primary btn-block" OnClick="BTN_LogOff_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
