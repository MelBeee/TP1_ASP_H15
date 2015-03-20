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
      Users user;
      int nbreDeTentative = 0;
      protected void Page_Load(object sender, EventArgs e)
      {
         if (!Page.IsPostBack)
         {
            Session["CurrentUser"] = new Users((string)Application["MainBaseDonnee"], this);
            Session["UserValid"] = false;
            Session["Selected_UserName"] = "Inconnu";
         }
      }


      protected void BTN_Login_Click(object sender, EventArgs e)
      {
         nbreDeTentative++;
         if (Page.IsValid)
         {
            Users utilisateur = new Users((string)Application["MainBaseDonnee"], this);
            Session["Selected_ID"] = utilisateur.getID(TB_Username.Text);
            Session["Selected_UserName"] = TB_Username.Text;
            Session["UserValid"] = true;
            Response.Redirect("Index.aspx");
         }
         else if (nbreDeTentative >= 3)
         {
            Session.Timeout = 5;
         }
      }

      protected void CV_TB_UserName_ServerValidate(object source, ServerValidateEventArgs args)
      {
         Users utilisateur = new Users((string)Application["MainBaseDonnee"], this);
         args.IsValid = utilisateur.Exist(TB_Username.Text);
      }

      protected void CV_Password_ServerValidate(object source, ServerValidateEventArgs args)
      {
         Users utilisateur = new Users((string)Application["MainBaseDonnee"], this);
         args.IsValid = utilisateur.Valid(TB_Username.Text, TB_Password.Text);

      }

      protected void BTN_Forgotten_Click(object sender, EventArgs e)
      {
         Users utilisateur = new Users((string)Application["MainBaseDonnee"], this);
         if (TB_Username.Text == "")
            Response.Write("Nom d'utilisateur obligatoire");
         else if (!utilisateur.Exist(TB_Username.Text))
            Response.Write("Nom d'utilisateur innexistant");
         else
         {
            Email eMail = new Email();

            // Vous devez avoir un compte gmail
            eMail.From = "unTravailASP@gmail.com";
            eMail.Password = "asdf1234";
            eMail.SenderName = "admin";

            eMail.Host = "smtp.gmail.com";
            eMail.HostPort = 587;
            eMail.SSLSecurity = true;

            eMail.To = utilisateur.GetEmail(utilisateur.getID(TB_Username.Text));
            eMail.Subject = "Password recover";
            eMail.Body = "Votre mot de passe est : " + utilisateur.GetPassword(utilisateur.getID(TB_Username.Text));

            if (eMail.Send())
            {
               Response.Write("Email a bien été envoyé");
            }
            else
               Response.Write("Un probleme a été détecté à l'envoi du email.");
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


      public static void ClientAlert(System.Web.UI.Page page, string message)
      {
         page.ClientScript.RegisterStartupScript(page.GetType(), "alert", "alert('" + message + "');", true);
      }
   }




}