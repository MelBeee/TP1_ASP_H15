<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <link href="Main.css" rel="stylesheet" />
    <script src="ClientFormUtilities.js"></script>
</head>
<body>
    <div class="main">
        <form name="aspnetForm" method="post" action="Login.aspx" id="aspnetForm" runat="server">

            <div class="mainHeader">
                <table>
                    <tr>
                        <td>
                            <h2>
                                <span>Login...</span>
                            </h2>
                        </td>
                        <td>
                            <div>
                                <span class="UserFullName">Anonymous</span>
                                <br />
                            </div>
                        </td>
                        <td>
                            <%--Image avatar--%>
                        </td>
                    </tr>
                </table>
            </div>
            <hr />

            <div class="form">
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LB_Username" runat="server" Text="Nom d'usager"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox type="text" ID="TB_Username" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LB_Password" runat="server" Text="Mot de passe"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TB_Password" runat="server" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button type="submit" ID="BTN_Login" Text="Connexion..." runat="server" value="Connexion..." class="submitBTN" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button type="submit" ID="BTN_Subscribe" Text="Inscription..." runat="server" value="Inscription..." class="submitBTN" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button type="submit" ID="BTN_Forgotten" Text="Mot de passe oublié..." runat="server" value="Mot de passe oublié..." class="submitBTN" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: left"></td>
                    </tr>
                </table>
            </div>
        </form>
    </div>
</body>
</html>
