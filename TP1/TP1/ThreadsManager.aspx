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
            <div class="col-md-4 col-md-offset-4">
                <div class="auto-style3">
                    <label>Liste des discussions</label>

                </div>
                <div>
                <div>
                    <label>Titre : </label>

                    <asp:UpdatePanel ID="UP_Titre" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:TextBox ID="TB_Titre" runat="server"></asp:TextBox>
                            <asp:CustomValidator ID="CV_Titre" runat="server" ErrorMessage="Titre obligatoire" Text="Vide!"
                                ControlToValidate="TB_Titre" OnServerValidate="CV_Titre_ServerValidate" ValidateEmptyText="True" />
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>

                <div>
                    <asp:UpdatePanel ID="UP_List" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:ListBox ID="LB_Thread" runat="server" OnSelectedIndexChanged="LB_Thread_SelectedIndexChanged" Style="height: 250px; width: 165px"></asp:ListBox>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                    </div>

                
                <div class="table table-striped table-bordered conversation-wrap">
                    Qui inviter ?
                <asp:CustomValidator ID="CV_NbreUser" runat="server" Text="Il faut minimum un invité."
                    OnServerValidate="CV_NbreUser_ServerValidate" />

                    <asp:UpdatePanel ID="UP_CBUser" runat="server" UpdateMode="Conditional">
                        <Triggers></Triggers>
                        <ContentTemplate>
                            <asp:CheckBox ID="CB_AllUsers" runat="server" Text="Tous les usagers" OnCheckedChanged="CB_AllUsers_CheckedChanged" />
                            <asp:Table ID="TB_Users" class="table table-striped table-bordered conversation-wrap" runat="server"></asp:Table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                <div>

                <asp:Button ID="BTN_Clear" CssClass="btn btn-primary btn-block btn-lg raised" CausesValidation="false" runat="server" Text="Nouveau" OnClick="BTN_Clear_Click" />

                <asp:UpdatePanel ID="UP_BTNModCre" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button ID="BTN_ModCre" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Créer" OnClick="BTN_ModCre_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:Button ID="BTN_Delete" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Effacer" OnClick="BTN_Delete_Click" />
                <asp:Button ID="BTN_Return" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Retour" OnClick="BTN_Return_Click" />

                    </div>
            </div>
        </div>
    </div>
</asp:Content>
