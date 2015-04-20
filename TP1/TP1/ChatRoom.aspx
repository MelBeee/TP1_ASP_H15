<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="TP1.ChatRoom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css" />
    <script src="jquery-1.11.2.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" ClientIDMode="Static">
    <hr />
    <asp:Timer runat="server" ID="RefreshChat" Interval="3000" OnTick="RefreshChat_Tick"></asp:Timer>
    <asp:Timer runat="server" ID="RefreshUsers" Interval="3000" OnTick="RefreshUsers_Tick"></asp:Timer>
    <table>
        <div style="margin-left: 50px">
        <tr>
            <td><b style="font-size: xx-large; width:20%; text-align:center;">Discussions</b></td>
            <td colspan="2" class="conversation-wrap col-lg-3" style="width:60%;">
                <asp:UpdatePanel ID="UPN_Creator" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <b style="font-size: xx-large;">
                            <asp:Label ID="LBL_Titre_Convo" runat="server"></asp:Label></b>
                        <i style="font-size: small;">
                            <asp:Label ID="LBL_Creator" runat="server" Width="300px"></asp:Label></i>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td><b style="font-size: xx-large; width:20%; text-align:center;">Utilisateurs</b></td>
        </tr>
            </div>
        <tr>
            <td>
                <asp:UpdatePanel ID="UPN_ConvoList" runat="server">
                    <Triggers>
                    </Triggers>
                    <ContentTemplate>
                        <div id="DIV_ConvoList" style="overflow: auto; border: thin solid black; height: 200px; width: 278px; display: inline-block; text-align: center;">
                            <asp:Table ID="TB_ConvoList"  runat="server" Width="250px">
                            </asp:Table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="border-style: solid;">
                <asp:UpdatePanel ID="UPN_Chat" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="RefreshChat" EventName="Tick" />
                    </Triggers>
                    <ContentTemplate>
                        <div id="DIV_Chat" style="overflow: auto; height: 200px; width: 765px">
                            <asp:Table GridLines="Horizontal" class="table table-striped table-bordered" ID="TB_Chat" runat="server" Width="746px">
                            </asp:Table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td style="border-style:none">
                <asp:UpdatePanel ID="UPN_OnlineUsers" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="RefreshUsers" EventName="Tick" />
                    </Triggers>
                    <ContentTemplate>
                        <div id="DIV_OnlineUsers" style="overflow: auto; height: 200px; border-width: thin; border-style: solid;">
                            <asp:Table GridLines="Both" class="table table-striped table-bordered" ID="TB_UserList" runat="server"></asp:Table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="1"></td>
            <td style="vertical-align: top; text-align: center">
                <asp:UpdatePanel ID="UPN_BTN_Send" runat="server" UpdateMode="Conditional">
                    <Triggers>
                    </Triggers>
                    <ContentTemplate>
                        <asp:TextBox ID="TBX_ChatInput" TextMode="MultiLine" Rows="3" Columns="50" runat="server" onkeyup="char = (event.which || event.keyCode); if (char == 13) document.getElementById('BTN_Send').click();" Height="96px"></asp:TextBox>
                        <br />
                        <div class="col-md-4 col-md-offset-4">
                            <asp:Button ID="BTN_Send" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Envoyer" OnClick="BTN_Send_Click" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
            <td></td>
        </tr>
    </table>
    <hr />
    <div class="col-md-4 col-md-offset-4">
        <asp:Button ID="BTN_Return" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Retour" OnClick="BTN_Return_Click" />
    </div>
    <script type="text/javascript">

        // It is important to place this JavaScript code after ScriptManager1
        var xPos1, yPos1, xPos2, yPos2, xPos3, yPos3;
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        function BeginRequestHandler(sender, args) {
            if ($get('DIV_Chat') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPos1 = $get('DIV_Chat').scrollLeft;
                yPos1 = $get('DIV_Chat').scrollTop;
            }

            if ($get('DIV_OnlineUsers') != null) {
                // Get X and Y positions of scrollbar before the partial postback
                xPos2 = $get('DIV_OnlineUsers').scrollLeft;
                yPos2 = $get('DIV_OnlineUsers').scrollTop;
            }

            if ($get('DIV_ConvoList') != null) {

                // Get X and Y positions of scrollbar before the partial postback
                xPos3 = $get('DIV_ConvoList').scrollLeft;
                yPos3 = $get('DIV_ConvoList').scrollTop;
            }
        }

        function EndRequestHandler(sender, args) {
            if ($get('DIV_Chat') != null) {
                // Set X and Y positions back to the scrollbar  after partial postback
                $get('DIV_Chat').scrollLeft = xPos1;
                $get('DIV_Chat').scrollTop = yPos1;
            }

            if ($get('DIV_OnlineUsers') != null) {
                // Set X and Y positions back to the scrollbar  after partial postback
                $get('DIV_OnlineUsers').scrollLeft = xPos2;
                $get('DIV_OnlineUsers').scrollTop = yPos2;
            }
            if ($get('DIV_ConvoList') != null) {
                // Set X and Y positions back to the scrollbar  after partial postback
                $get('DIV_ConvoList').scrollLeft = xPos3;
                $get('DIV_ConvoList').scrollTop = yPos3;
            }
        }
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
    </script>
</asp:Content>
