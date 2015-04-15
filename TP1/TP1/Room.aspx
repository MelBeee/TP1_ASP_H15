<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="TP1.Room" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
    <asp:Timer runat="server" ID="RefreshUsers" Interval="3000" OnTick="RefreshUsers_Tick"></asp:Timer>
    <asp:UpdatePanel ID="UPN_OnlineUsers" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="RefreshUsers" EventName="Tick" />
        </Triggers>
        <ContentTemplate>
            <asp:Table GridLines="Both" class="table table-striped table-bordered" ID="TB_OnlineUsers" runat="server">
            </asp:Table>
            <br />
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-md-offset-4">
                        <asp:Button ID="BTN_Return" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Retour" OnClick="BTN_Return_Click" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
