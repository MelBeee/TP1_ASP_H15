<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="ThreadsManager.aspx.cs" Inherits="TP1.ThreadsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css" />  
    <script src="ClientFormUtilities.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <table class="MainTable">
        <tr>
            <td class="auto-style3">
                <label>Liste des discussions</label>
                <hr />
            </td>
            <td class="auto-style5" rowspan="2" style="border: thin solid #000000">
                <label>Titre : </label>
               
                <br />
                <br />
                <asp:UpdatePanel ID="UP_Titre" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="TB_Titre" runat="server"></asp:TextBox>
                        <asp:CustomValidator ID="CV_Titre" runat="server" ErrorMessage="Titre obligatoire" Text="Vide!"
                            ControlToValidate="TB_Titre" OnServerValidate="CV_Titre_ServerValidate" ValidateEmptyText="True" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
            </td>
        </tr>
        <tr>
            <td rowspan="4">
                <asp:UpdatePanel ID="UP_List" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:ListBox ID="LB_Thread" runat="server" OnSelectedIndexChanged="LB_Thread_SelectedIndexChanged" Style="height: 250px; width: 165px"></asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" rowspan="2" style="border-style: solid; border-width: thin">Qui inviter ?<br />
                <asp:CustomValidator ID="CV_NbreUser" runat="server" Text="Il faut minimum un invité."
                    OnServerValidate="CV_NbreUser_ServerValidate" />
                <br />
                <asp:UpdatePanel ID="UP_CBUser" runat="server" UpdateMode="Conditional">
                    <Triggers></Triggers>
                    <ContentTemplate>
                        <asp:CheckBox ID="CB_AllUsers" runat="server" Text="Tous les usagers" OnCheckedChanged="CB_AllUsers_CheckedChanged" />
                        <asp:Table ID="TB_Users" runat="server"></asp:Table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <hr />
                <asp:Button ID="BTN_Clear" CssClass="btn btn-primary btn-block btn-lg raised" CausesValidation="false"  runat="server" Text="Nouveau" OnClick="BTN_Clear_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UP_BTNModCre" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button ID="BTN_ModCre" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Créer" OnClick="BTN_ModCre_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                 <asp:Button ID="BTN_Delete" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Effacer" OnClick="BTN_Delete_Click" />
            </td>
        </tr>
    </table>
    <asp:Button ID="BTN_Return" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Retour" OnClick="BTN_Return_Click" />

</asp:Content>
