﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TP1.Login" %>

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

            <div class="form">
       <table>
                <tr>
                    <td>
                        <asp:Label for="TB_Username" runat="server" Text="Nom d'usager"></asp:Label>

                    </td>
                    <td>
                        <asp:TextBox ID="TB_Username" runat="server" ></asp:TextBox>
                        <asp:RequiredFieldValidator
                            ID="RFV_TB_Username"
                            runat="server"
                            Text="Vide!"
                            ErrorMessage="Le nom d'usager est vide!"
                            ControlToValidate="TB_Username"
                            ValidationGroup="VG_Login"> 
                        </asp:RequiredFieldValidator>

                        <asp:CustomValidator
                            ID="CV_Username"
                            runat="server"
                            ErrorMessage="Ce nom d'usager n'existe pas!"
                            Display="None"
                            ValidationGroup="VG_Login"
                            OnServerValidate="CV_TB_UserName_ServerValidate"> 
                        </asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label for="TB_Password" runat="server" Text="Mot de passe"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="TB_Password" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator
                            ID="RFV_TB_Password"
                            runat="server"
                            Text="Vide!"
                            ErrorMessage="Le mot de passe est vide!"
                            ControlToValidate="TB_Password"
                            ValidationGroup="VG_Login"> 
                        </asp:RequiredFieldValidator>

                        <asp:CustomValidator
                            ID="CV_Password"
                            runat="server"
                            ErrorMessage="Le mot de passe n'est pas valide."
                            Display="None"
                            ValidationGroup="VG_Login"
                            OnServerValidate="CV_Password_ServerValidate"> 
                        </asp:CustomValidator>
                    </td>
                </tr>
                    <tr>
                        <td>
                            <asp:Button type="submit" ID="BTN_Login" Text="Connexion..." runat="server" value="Connexion..." class="submitBTN" OnClick="BTN_Login_Click"  />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button type="submit" ID="BTN_Subscribe" Text="Inscription..." runat="server" value="Inscription..." class="submitBTN" PostBackUrl="~/Inscription.aspx" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button type="submit" ID="BTN_Forgotten" Text="Mot de passe oublié..." runat="server" value="Mot de passe oublié..." class="submitBTN" OnClick="BTN_Forgotten_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </div>
</body>
</html>
