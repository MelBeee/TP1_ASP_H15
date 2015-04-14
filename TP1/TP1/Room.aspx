<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="TP1.Room" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
    <hr/>
    <asp:Timer runat="server" ID="RefreshUsers" Interval="3000" OnTick="RefreshUsers_Tick"></asp:Timer>
    <asp:UpdatePanel ID="UPN_OnlineUsers" runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="RefreshUsers" EventName="Tick" />
        </Triggers>
        <ContentTemplate>
            <asp:Table GridLines="Both" ID="TB_OnlineUsers" runat="server" >
            </asp:Table>
            <br />
            <asp:Button ID="BTN_Return" runat="server" Text="Retour..." OnClick="BTN_Return_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>