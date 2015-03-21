using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TP1
{
    public partial class Login : System.Web.UI.Page
    {
        private static int essaieDeConnexion { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["CurrentUser"] = new Users((string)Application["MainDB"], this);
                Session["UserValid"] = false;
                Session["Selected_UserName"] = "Anonymous";
            }
        }

        protected void BTN_Login_Click(object sender, EventArgs e)
        {
            essaieDeConnexion++;
            if (Page.IsValid)
            {
                Users personnes = new Users((string)Application["MainDB"], this);
                Session["Selected_ID"] = personnes.getID(TB_Username.Text);
                Session["Selected_UserName"] = TB_Username.Text;
                Session["UserValid"] = true;
                Response.Redirect("Index.aspx");
            }
            else if (essaieDeConnexion >= 3)
            {
                Session.Timeout = 5;
            }
        }


        protected void BTN_PasswordReminder_Click(object sender, EventArgs e)
        {
            Users personnes = new Users((string)Application["MainDB"], this);
            if (TB_Username.Text == "")
                Response.Write("Le nom d'usager est vide.");
            else if (!personnes.Exist(TB_Username.Text))
                Response.Write("Le nom d'usager n'existe pas.");
            else
            {
                Email eMail = new Email();

                // Vous devez avoir un compte gmail
                eMail.From = "mel.beee@gmail.com";
                eMail.Password = "MelBeee";
                eMail.SenderName = "MelBeee";

                eMail.Host = "smtp.gmail.com";
                eMail.HostPort = 587;
                eMail.SSLSecurity = true;

                eMail.To = personnes.GetEmail(personnes.getID(TB_Username.Text));
                eMail.Subject = "Mot de passe oublié";
                eMail.Body = "Votre mot de passe est : " + personnes.GetPassword(personnes.getID(TB_Username.Text));

                if (eMail.Send())
                {
                    Response.Write("Courriel envoyé.");
                }
                else
                    Response.Write("Une erreur a stoppé l'envoi du courriel.");
            }
        }

        protected void CV_TB_UserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Users personnes = new Users((string)Application["MainDB"], this);
            args.IsValid = personnes.Exist(TB_Username.Text);
        }

        protected void CV_Password_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Users personnes = new Users((string)Application["MainDB"], this);
            args.IsValid = personnes.Valid(TB_Username.Text, TB_Password.Text);

        }
    }
}