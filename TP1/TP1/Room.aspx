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

            <asp:Table GridLines="Both" class="table table-striped table-bordered" ID="TB_OnlineUsers" runat="server" >

            </asp:Table>
            <br />
            <div class="container">

            <div class="row">
                <div class="col-md-4 col-md-offset-4">

                    <div style="margin-bottom: 50px">
            <asp:Button ID="BTN_Return" runat="server" CssClass="btn btn-primary btn-block btn-lg raised" Text="Retour" OnClick="BTN_Return_Click" />
                    </div>
                     </div>
                </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>



</asp:Content>