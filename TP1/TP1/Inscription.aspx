<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="TP1.Inscription" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Inscription...</div>

        <div>
        <p>
            <asp:Label ID="LB_NomComplet" runat="server" Text="Nom au complet "></asp:Label>
            <asp:TextBox ID="TB_NomComplet" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LB_NomUsager" runat="server" Text="Nom d'usager "></asp:Label>
            <asp:TextBox ID="TB_NomUsager" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LB_MotsDePasse" runat="server" Text="Mot de passe "></asp:Label>
            <asp:TextBox ID="TB_Password" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LB_ConfirmPassword" runat="server" Text="Confirmation du mot de passe "></asp:Label>
            <asp:TextBox ID="TB_ConfirmPassword" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LB_Email" runat="server" Text="Adresse de courriel "></asp:Label>
            <asp:TextBox ID="TB_Email" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="LB_ConfirmEmail" runat="server" Text="Confirmation de l'adresse de courriel  "></asp:Label>
            <asp:TextBox ID="TB_ConfirmEmail" runat="server"></asp:TextBox>
        </p>

            <asp:Button ID="BTN_Inscription" runat="server" Text="S'inscrire..." Width="98px" />
            <asp:Button ID="BTN_Annuler" runat="server" Text="Annuler..." Width="98px" />

            <input type="button" class="AvatarBrowseButton" id="uploadTrigger" onclick="document.getElementById('FU_Avatar').click();" value="Choisir...">

        </div>
        
        
        
    </form>
</body>
</html>
