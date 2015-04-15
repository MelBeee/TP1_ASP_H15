<%@ Page Title="" Language="C#" MasterPageFile="~/masterpage.Master" AutoEventWireup="true" CodeBehind="ChatRoom.aspx.cs" Inherits="TP1.ChatRoom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

            <div class="row">
                <div class="col-md-3 col-md-offset-2">

    <asp:Image ID="IMG_Construct" CssClass="img2" runat="server" ClientIDMode="Static" ImageUrl="~\Images\under_construction.png" />
                    </div>
                </div>
        </div>

    <div class="container">

            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div style="margin-bottom: 50px">
            <asp:Button ID="BTN_Return" runat="server" CssClass="btn btn-primary btn-block btn-lg raised" Text="Retour" PostBackUrl="~/Index.aspx" />
                    </div>
                    </div>
                </div>
                </div>
</asp:Content>
