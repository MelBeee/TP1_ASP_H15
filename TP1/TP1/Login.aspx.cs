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
                Users utilisateur = new Users((string)Application["MainDB"], this);
                Session["Selected_ID"] = utilisateur.getID(TB_Username.Text);
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
            Users utilisateur = new Users((string)Application["MainDB"], this);
            if (TB_Username.Text == "")
                Response.Write("Le nom d'usager est vide.");
            else if (!utilisateur.Exist(TB_Username.Text))
                Response.Write("Le nom d'usager n'existe pas.");
            else
            {
                Email email = new Email();

                // Vous devez avoir un compte gmail
                email.From = "tp1aspemailsender@gmail.com";
                email.Password = "melissa1dominic";
                email.SenderName = "Melissa et Dominic";

                email.Host = "smtp.gmail.com";
                email.HostPort = 587;
                email.SSLSecurity = true;

                email.To = utilisateur.GetEmail(utilisateur.getID(TB_Username.Text));
                email.Subject = "Mot de passe oublié";
                email.Body = " Bonjour " + TB_Username.Text  + "" +
                             ". Vous avez demandé un courriel pour vous rappelez de votre mot de passe. " +
                             " Si ce n'est pas le cas, ignorez ce courriel. " + 
                             " Votre mot de passe est : " + utilisateur.GetPassword(utilisateur.getID(TB_Username.Text)) +
                             " Bonne journée !";
                email.Body = email.Body.Replace("@", "@" + Environment.NewLine);

                if (email.Send())
                {
                    Response.Write("Courriel envoyé.");
                }
                else
                    Response.Write("Une erreur a stoppé l'envoi du courriel.");
            }
        }

        protected void CV_TB_UserName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Users utilisateur = new Users((string)Application["MainDB"], this);
            args.IsValid = utilisateur.Exist(TB_Username.Text);
            if (TB_Username.Text == "")
            {
                TB_Username.BackColor = System.Drawing.Color.FromArgb(51, 122, 183);
                args.IsValid = false;
            }
            else
            {
                TB_Username.BackColor = System.Drawing.Color.White;
                args.IsValid = true;
            }
        }

        protected void CV_Password_ServerValidate(object source, ServerValidateEventArgs args)
        {
            Users utilisateur = new Users((string)Application["MainDB"], this);
            args.IsValid = utilisateur.Valid(TB_Username.Text, TB_Password.Text);
            if (TB_Password.Text == "")
            {
                TB_Password.BackColor = System.Drawing.Color.FromArgb(51, 122, 183);
                args.IsValid = false;
            }
            else
            {
                TB_Password.BackColor = System.Drawing.Color.White;
                args.IsValid = true;
            }
        }
    }
}