<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TP1.Index" MasterPageFile="masterpage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contain" runat="server">
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
</asp:Content>