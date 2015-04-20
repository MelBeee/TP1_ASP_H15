<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="ThreadsManager.aspx.cs" Inherits="TP1.ThreadsManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/style2.css" />
    <script src="ClientFormUtilities.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-4 ">
                <table>
                    <tr>
                        <td>
                            <div style="text-align: center; width: 400px;">
                                <div style="padding: 10px;">
                                    <b style="font-size: large; width: 20%; text-align: center;">Liste des discussions existantes</b>
                                </div>
                                <asp:UpdatePanel ID="UP_List" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:ListBox ID="LB_Thread" runat="server" OnSelectedIndexChanged="LB_Thread_SelectedIndexChanged" Style="height: 400px; width: 300px"></asp:ListBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </td>
                        <td style="padding-left: 15px; padding-right: 15px;"></td>
                        <td>
                            <div style="text-align: center; padding: 10px;">
                                <b style="font-size: large; width: 20%; text-align: center;">Créer/Modifier une discussion</b>

                                <div>
                                    <asp:UpdatePanel ID="UP_Titre" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div style="padding: 5px; text-align: center;">
                                                <i style="font-size: medium; width: 20%; text-align: center;">Titre</i>
                                            </div>
                                            <asp:TextBox ID="TB_Titre" runat="server" Width="300px"></asp:TextBox>
                                            <asp:Label ID="Valid_Titre" runat="server" CssClass="warning"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                            <div style="padding: 5px; text-align: center;">
                                <i style="font-size: medium; width: 20%; text-align: center;">Qui inviter ?</i>
                            </div>
                            <div class="table table-striped table-bordered conversation-wrap">
                                <asp:UpdatePanel ID="UP_CBUser" runat="server" UpdateMode="Conditional">
                                    <Triggers></Triggers>
                                    <ContentTemplate>
                                        <div style="text-align: center;">
                                            <asp:Label ID="Valid_Users" runat="server" CssClass="warning"></asp:Label><hr style="height: 1px;">
                                            <asp:CheckBox ID="CB_AllUsers" runat="server" Text="Tous les usagers" OnCheckedChanged="CB_AllUsers_CheckedChanged" />
                                            <asp:Table ID="TB_Users" class="table table-striped table-bordered conversation-wrap" runat="server"></asp:Table>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </td>
                    </tr>
                </table>

                <div>
                    <div style="padding-top: 30px;">
                        <asp:Button ID="BTN_Clear" CssClass="btn btn-primary btn-block btn-lg raised" CausesValidation="false" runat="server" Text="Nouveau" OnClick="BTN_Clear_Click" />
                        <asp:UpdatePanel ID="UP_BTNModCre" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Button ID="BTN_ModCre" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Créer" OnClick="BTN_ModCre_Click" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:Button ID="BTN_Delete" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Effacer" OnClick="BTN_Delete_Click" />
                    </div>

                    <div style="padding-top: 15px;">
                        <asp:Button ID="BTN_Return" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Retour" OnClick="BTN_Return_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
