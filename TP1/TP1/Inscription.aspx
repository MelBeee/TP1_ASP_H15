<%@ Page Title="" Language="C#" MasterPageFile="~/masterpageInscription.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Inscription.aspx.cs" Inherits="TP1.Inscription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="css/style.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">

            <div class="row">
                <div class="col-md-4 col-md-offset-4">

                    <form class="form-signin">
                        <h2 class="form-signin-heading">Please sign in</h2>

                        <asp:Image ID="IMG_Avatar" class=" inscrip_img img-circle " runat="server" ClientIDMode="Static" ImageUrl="~\Avatars\DefaultAvatar2.png" />

                        <asp:FileUpload ID="FU_Avatar" runat="server" ClientIDMode="Static" onchange="PreLoadImage();" />


                        <label for="inputNomU" class="sr-only">Username</label>
                        <asp:TextBox type="name" ID="nom_Usager" class="form-control" placeholder="Nom Usager" autofocus runat="server"></asp:TextBox>
                        <asp:Label ID="LabelUsername_inscr" runat="server" Text=""></asp:Label>

                        <label for="inputPrenom" class="sr-only">Prenom</label>
                        <asp:TextBox type="name" ID="Prenom_ID" class="form-control" placeholder="Prenom" runat="server"></asp:TextBox>
                        <asp:Label ID="LabelPrenom_inscri" runat="server" Text=""></asp:Label>


                        <label for="inputNom" class="sr-only">Prenom</label>
                        <asp:TextBox type="name" ID="Nom_ID" class="form-control" placeholder="Nom" runat="server"></asp:TextBox>
                        <asp:Label ID="LabelNom_inscri" runat="server" Text=""></asp:Label>



                        <label for="inputEmail" class="sr-only">Email address</label>
                        <asp:TextBox type="email" ID="inputEmail" class="form-control" placeholder="Email address" runat="server"></asp:TextBox>
                        <asp:Label ID="LabelEmail_inscri" runat="server" Text=""></asp:Label>

                        <label for="inputEmail" class="sr-only">Confirmer Email address</label>
                        <asp:TextBox type="email" ID="inputEmail_confrim" class="form-control" placeholder="Confirmer Email address" runat="server"></asp:TextBox>
                        <asp:Label ID="LabelEmailConf_inscri" runat="server" Text=""></asp:Label>

                        <label for="inputPassword" class="sr-only">Password</label>
                        <asp:TextBox type="password" ID="inputPassword" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                        <asp:Label ID="LabelPassword_inscri" runat="server" Text=""></asp:Label>



                        <label for="inputPassword" class="sr-only">Password</label>
                        <asp:TextBox type="password" ID="inputPassword_Con" class="form-control" placeholder="Confirmer Password" runat="server"></asp:TextBox>
                        <asp:Label ID="LabelPasswordConf_inscri" runat="server" Text=""></asp:Label>

                        <asp:ScriptManager ID="ScriptManager1" runat="server" />
                        <div>
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <asp:UpdatePanel ID="PN_Captcha" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:ImageButton ID="RegenarateCaptcha" runat="server"
                                                                ImageUrl="~/Images/RegenerateCaptcha.png"
                                                                CausesValidation="False"
                                                                OnClick="RegenarateCaptcha_Click"
                                                                ValidationGroup="Subscribe_Validation"
                                                                Width="48"
                                                                ToolTip="Regénérer le captcha..." />
                                                        </td>
                                                        <td>
                                                            <asp:Image ID="IMGCaptcha" class="captcha" ImageUrl="~/captcha.png" runat="server" />
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
                                        <asp:TextBox ID="TB_Captcha" runat="server" class="form-control" MaxLength="5"></asp:TextBox>
                                        <asp:CustomValidator ID="CV_Captcha" runat="server"
                                            ErrorMessage="Code captcha incorrect!"
                                            ValidationGroup="Subscribe_Validation"
                                            Text="!"
                                            ControlToValidate="TB_Captcha"
                                            OnServerValidate="CV_Captcha_ServerValidate"
                                            ValidateEmptyText="True">
                                        </asp:CustomValidator>
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

                         <asp:Label ID="LabelPassword_pasPareil" runat="server" Text=""></asp:Label>
                         <asp:Label ID="LabelEmail_pasPareil" runat="server" Text=""></asp:Label>


                        <asp:Button ID="BTN_Inscription" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Inscription" OnClick="BTN_Inscription_Click" />
                        <div style="margin-bottom: 50px; margin-top: 10px">
                        <asp:Button ID="BTN_Inscription_Annuler" CssClass="btn btn-primary btn-block btn-lg raised" runat="server" Text="Annuler" PostBackUrl="~/Login.aspx" />
 </div>
                    </form>
                </div>
            </div>
        </div>
</asp:Content>
