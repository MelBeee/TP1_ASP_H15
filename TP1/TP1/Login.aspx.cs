using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
   public partial class Login : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         var master = Master as masterpage;
         if (master != null)
            master.SetNomDeLaPage("Login");
      }

      protected void BTN_Inscription_Click(object sender, EventArgs e)
      {
         Response.Redirect("Inscription.aspx");
      }

      protected void BTN_Login_Click(object sender, EventArgs e)
      {
         SqlConnection connection = new SqlConnection((String)Application["MainDB"]);

         if (Page.IsValid)
         {
            if (!((List<long>)Application["OnlineUsers"]).Contains(MethodesPourBD.TrouverIDUtilisateur(connection, TB_Username.Text)))
            {
               ((List<long>)Application["OnlineUsers"]).Add(MethodesPourBD.TrouverIDUtilisateur(connection, TB_Username.Text));
            }

            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(TB_Username.Text, true);
            authCookie.Expires = DateTime.Now.AddMinutes((double)Application["SessionTimeout"]);
            Response.Cookies.Add(authCookie);
            Session["isAuthenticated"] = true;
            Session["SessionStartTime"] = DateTime.Now;
            Response.Redirect("Index.aspx");
         }
      }

      public void ConnecterUtilisateurTableUser()
      {
         SqlConnection connection = new SqlConnection((String)Application["MainDB"]);
         SqlCommand sqlcommand = new SqlCommand(" update users set "
                                              + " connecte = '1' "
                                              + " where username = '" + HttpContext.Current.User.Identity.Name + "'");
         sqlcommand.Connection = connection;
         connection.Open();
         SqlDataReader reader = sqlcommand.ExecuteReader();

         reader.Close();
         connection.Close();
      }

      protected void BTN_PasswordReminder_Click(object sender, EventArgs e)
      {
         Page.Application.Lock();

         SqlDataReader reader = null;

         SqlConnection connection = new SqlConnection((String)Application["MainDB"]);
         bool existe = MethodesPourBD.NomUtilisateurExiste(connection, TB_Username.Text);

         connection.Open();

         if (existe)
         {
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = connection;
            sqlcommand.CommandText = "SELECT EMAIL, PASSWORD FROM USERS WHERE USERNAME = '" + TB_Username.Text + "'";
            reader = sqlcommand.ExecuteReader();
         }

         if (reader != null)
         {
            reader.Read();

            Email eMail = new Email();

            // Vous devez avoir un compte gmail
            eMail.From = "tp1aspemailsender@gmail.com";
            eMail.Password = "melissa1dominic";
            eMail.SenderName = "Melissa et Dominic";

            eMail.Host = "smtp.gmail.com";
            eMail.HostPort = 587;
            eMail.SSLSecurity = true;

            eMail.To = reader.GetString(0);
            eMail.Subject = "Rappel de Mot de Passe";
            eMail.Body = "Votre mot de passe est le suivant : "
                        + reader.GetString(1)
                        + "<br/><br/> Attention de ne pas oublier trop souvent ! <br/> "
                        + "Melissa et Dominic";

            if (eMail.Send())
               ClientAlert(this, "Le Email a été envoyé avec succès!");
            else
               ClientAlert(this, "Échec de l'envoi du Email!");
         }
         else
         {
            ClientAlert(this, "Le nom d'utilisateur n'existe pas!");
         }
         connection.Close();

         Page.Application.UnLock();
      }

      public static void ClientAlert(System.Web.UI.Page page, string message)
      {
         page.ClientScript.RegisterStartupScript(page.GetType(), "alert", "alert('" + message + "');", true);
      }

      bool NomUtilisateurValide;

      protected void CV_Password_ServerValidate(object source, ServerValidateEventArgs args)
      {
         bool bonPassword = false;

         Page.Application.Lock();

         if (NomUtilisateurValide)
         {
            SqlConnection connection = new SqlConnection((String)Application["MainDB"]);
            SqlCommand sqlcommand = new SqlCommand("SELECT PASSWORD FROM USERS WHERE USERNAME = '" + TB_Username.Text + "'");
            sqlcommand.Connection = connection;
            connection.Open();
            SqlDataReader reader = sqlcommand.ExecuteReader();

            reader.Read();

            if (reader.GetString(0) == TB_Password.Text)
            {
               args.IsValid = true;
               bonPassword = true;
            }

            reader.Close();
            connection.Close();
         }

         if (TB_Password.Text == "")
         {
            args.IsValid = false;
            CV_Password.ErrorMessage = "Mot de passe requis";
            CV_Password.Text = "Vide!";
         }
         else if (!bonPassword)
         {
            args.IsValid = false;
            CV_Password.ErrorMessage = "Le mot de passe est incorrect!";
            CV_Password.Text = "Mauvais!";
         }

         Page.Application.UnLock();
      }

      protected void CV_Username_ServerValidate(object source, ServerValidateEventArgs args)
      {
         Page.Application.Lock();

         SqlConnection connection = new SqlConnection((String)Application["MainDB"]);

         if (TB_Username.Text == "")
         {
            args.IsValid = false;
            NomUtilisateurValide = false;
            CV_Username.ErrorMessage = "Nom d'usager requis";
            CV_Username.Text = "Vide!";
         }
         else if (!MethodesPourBD.NomUtilisateurExiste(connection, TB_Username.Text))
         {
            args.IsValid = false;
            NomUtilisateurValide = false;
            CV_Username.ErrorMessage = "Cet usager n'existe pas!";
            CV_Username.Text = "Mauvais!";
         }
         else
         {
            args.IsValid = true;
            NomUtilisateurValide = true;
         }

         Page.Application.UnLock();
      }
   }
}