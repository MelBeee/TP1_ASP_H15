<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/masterpage.Master" CodeBehind="Login.aspx.cs" Inherits="TP1.Login"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">
        <div >
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
                            Text="Champ requis"
                            ErrorMessage="Nom d'utilisateur obligatoire !"
                            ControlToValidate="TB_Username"
                            ValidationGroup="VG_Login"> 
                        </asp:RequiredFieldValidator>

                        <asp:CustomValidator
                            ID="CV_Username"
                            runat="server"
                            ErrorMessage="Nom d'utilisateur innexistant !"
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
                        <asp:TextBox ID="TB_Password" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator
                            ID="RFV_TB_Password"
                            runat="server"
                            Text="Champ requis"
                            ErrorMessage="Mot de passe obligatoire !"
                            ControlToValidate="TB_Password"
                            ValidationGroup="VG_Login"> 
                        </asp:RequiredFieldValidator>

                        <asp:CustomValidator
                            ID="CV_Password"
                            runat="server"
                            ErrorMessage="Mot de passe invalide !"
                            Display="None"
                            ValidationGroup="VG_Login"
                            OnServerValidate="CV_Password_ServerValidate"> 
                        </asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BTN_Login" runat="server" Text="Soumettre..." class="submitBTN" ValidationGroup="VG_Login" OnClick="BTN_Login_Click" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BTN_Inscription" class="submitBTN" runat="server" Text="Inscription..."  PostBackUrl="~/Inscription.aspx" />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BTN_PasswordReminder" class="submitBTN" runat="server" Text="Mot de passe oublié..." OnClick="BTN_PasswordReminder_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3" style="text-align: left;">
                        <asp:ValidationSummary
                            ID="VGS_Logi"
                            runat="server"
                            ValidationGroup="VG_Login"
                            HeaderText="Erreurs rencontrées : &lt;hr/&gt;" />
                    </td>
                </tr>
            </table>
        </div>
</asp:Content>
