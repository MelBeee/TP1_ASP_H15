using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
    public partial class Login : System.Web.UI.Page
    {
        Users user;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTN_Login_Click(object sender, EventArgs e)
        {
            if(user.BonPassWordEtUsername(TB_Password.Text, TB_Username.Text))
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                ClientAlert(this, "Mot de passe ou nom d'utilisateur non concordant");
            }
        }

        protected void BTN_Forgotten_Click(object sender, EventArgs e)
        {
            if(user.BonUsername(TB_Username.Text))
            {
                EnvoyerPasswordEmail(user);
            }
            else
            {
                ClientAlert(this, "Username non existant");
            }
        }

        public string GetUserIP()
        {
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipList))
                return ipList.Split(',')[0];
            string ipAddress = Request.ServerVariables["REMOTE_ADDR"];
            if (ipAddress == "::1") // local host
                ipAddress = "127.0.0.1";
            return ipAddress;
        }

        private void EnvoyerPasswordEmail(Users connexion)
        {
            // Nouvel objet EMail
            Email eMail = new Email();

            // Mon adresse, mon mot de passe, Nom de provenance
            eMail.From = "melbeee@gmail.com";
            eMail.Password = "asdf1234";
            eMail.SenderName = "admin";

            // Chourot Stuff, Security Related 
            eMail.Host = "smtp.gmail.com";
            eMail.HostPort = 587;
            eMail.SSLSecurity = true;
            //eMail.to = Email associer au contenu du textbox username
            eMail.To = connexion.Email;
            eMail.Subject = "Voici votre nouveau mot de passe";
            //Generation d'un nombre random [0-1m] comme mot de passe
            Random rnd = new Random();
            int pass = rnd.Next(1000000);
            connexion.Password = pass.ToString();
            connexion.Update();
            // contenu du mail
            eMail.Body = "Votre nouveau mot de passe est " + pass + ". Bonne journee!!";
            // Verification
            if (eMail.Send())
            {
                ClientAlert(this, "This eMail has been sent with success!");
                TB_Username.Text = "";
                TB_Password.Text = "";
            }
            else
                ClientAlert(this, "An error occured while sendind this eMail!!!");

        }
        public static void ClientAlert(System.Web.UI.Page page, string message)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "alert", "alert('" + message + "');", true);
        }
    }
}