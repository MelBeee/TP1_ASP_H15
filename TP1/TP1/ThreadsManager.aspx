<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="ThreadsManager.aspx.cs" Inherits="TP1.ThreadsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <style>
        Listview {
            height: 50%;
        }

        .MainTable {
            background-color: lightgray;
            padding: 5px;
            margin: auto;
        }

        .auto-style2 {
            width: 100px;
        }

        .auto-style3 {
            height: 27px;
        }

        .auto-style4 {
            width: 100px;
            height: 27px;
        }

        .auto-style5 {
            width: 218px;
        }
    </style>
    <table class="MainTable">
        <tr>
            <td class="auto-style3">
                <label>Liste de mes discussions:</label>
                <hr />
            </td>
            <td class="auto-style4"></td>
            <td class="auto-style5" rowspan="2" style="border: thin solid #000000">
                <label>Titre de la discussion</label>
                :
               
                <br />
                <br />
                <asp:UpdatePanel ID="UPN_Titre_Discussion" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="TBX_TitreDiscussion" runat="server"></asp:TextBox>
                        <asp:CustomValidator ID="CVal_TitreDiscussion" runat="server" ErrorMessage="Le titre ne peut pas être vide!" Text="Vide!"
                            ControlToValidate="TBX_TitreDiscussion" OnServerValidate="CVal_TitreDiscussion_ServerValidate" ValidateEmptyText="True" />
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
            </td>
        </tr>
        <tr>
            <td rowspan="4">
                <asp:UpdatePanel ID="UPN_Thread_List" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:ListBox ID="LB_Thread_List" runat="server" OnSelectedIndexChanged="LB_Thread_List_SelectedIndexChanged" Style="height: 250px; width: 165px"></asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style5" rowspan="2" style="border-style: solid; border-width: thin">Qui inviter ?<br />
                <asp:CustomValidator ID="CV_AuMoinsUnInvite" runat="server" Text="Il faut au moins un invité!"
                    OnServerValidate="CV_AuMoinsUnInvite_ServerValidate" />
                <br />
                <asp:UpdatePanel ID="UPN_UsersCheckboxes" runat="server" UpdateMode="Conditional">
                    <Triggers></Triggers>
                    <ContentTemplate>
                        <asp:CheckBox ID="CBOX_AllUsers" runat="server" Text="Tous les usagers" OnCheckedChanged="CBOX_AllUsers_CheckedChanged" />
                        <asp:Table ID="TB_AllExistingUsers" runat="server"></asp:Table>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td>
                <hr />
                <asp:Button ID="BTN_Clear" CssClass="btn btn-primary btn-block btn-lg raised" CausesValidation="false"  runat="server" Text="Nouveau" OnClick="BTN_Clear_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UPN_BTN_Send_Or_Create" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button ID="BTN_Modify_Or_Create" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Créer" OnClick="BTN_Modify_Or_Create_Click" />
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
    <asp:Button ID="BTN_Return" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Retour" OnClick="BTT_Return_Click" />



</asp:Content>
