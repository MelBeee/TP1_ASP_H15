<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="LoginsJournal.aspx.cs" Inherits="TP1.LoginsJournal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <asp:Timer runat="server" ID="RefreshPanel" Interval="3000" OnTick="RefreshPanel_Tick"></asp:Timer>

    <asp:UpdatePanel runat="server">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="RefreshPanel" EventName="Tick" />
        </Triggers>
        <ContentTemplate>
            <asp:Table ID="TB_Log" class="table table-striped table-bordered" runat="server"></asp:Table>
        </ContentTemplate>
    </asp:UpdatePanel>

            <div class="container">

        <div class="row">
            <div class="col-md-4 col-md-offset-4">

    <asp:Button ID="BTN_Return" runat="server" CssClass="btn btn-primary btn-block btn-lg raised" Text="Retour" OnClick="BTN_Return_Click" />
                </div>
            </div>
                </div>
</asp:Content>



	
