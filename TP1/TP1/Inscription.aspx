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

            <asp:ScriptManager ID="ScriptManager1" runat="server"/>
        <div>
            <table>
                <tr>    
                    <td colspan="2">
                        <asp:UpdatePanel ID="PN_Captcha" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:ImageButton    ID="RegenarateCaptcha" runat="server" 
                                                        ImageUrl="~/Images/RegenerateCaptcha.png" 
                                                        CausesValidation="False" 
                                                        onclick="RegenarateCaptcha_Click" 
                                                        ValidationGroup="Subscribe_Validation" 
                                                        width="48"
                                                        ToolTip="Regénérer le captcha..." />  
                                    </td>
                                    <td>
                                        <asp:Image ID="IMGCaptcha" imageurl="~/captcha.png" runat="server" />
                                    </td>
                                </tr>
                        </table>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>      
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="TB_Captcha" runat="server" MaxLength="5" ></asp:TextBox>
                        <asp:CustomValidator  ID="CV_Captcha" runat="server" 
                                                ErrorMessage="Code captcha incorrect!" 
                                                ValidationGroup="Subscribe_Validation"
                                                Text="!" 
                                                ControlToValidate="TB_Captcha" 
                                                onservervalidate="CV_Captcha_ServerValidate" 
                                                ValidateEmptyText="True"></asp:CustomValidator>
                    </td>
                </tr>
                <tr>
                   <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="BTN_Submit" runat="server"
                                    Text="Soumettre ..."
                                    ValidationGroup="Subscribe_Validation"
                                    OnClick="BTN_Submit_Click" />
                </tr>
            </table>
        </div>
        <asp:ValidationSummary ID="Subscribe_Validation" runat="server" ValidationGroup="Subscribe_Validation" />


        </div>
        
        
        
    </form>
</body>
</html>
