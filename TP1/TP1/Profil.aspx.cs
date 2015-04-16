using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
   public partial class Profil : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         var master = Master as masterpage;
         if (master != null)
            master.SetNomDeLaPage("Profil");

         if (!Page.IsPostBack)
            LoadForm();
      }

      private void LoadForm()
      {
         InsererInformationDansTextBox();
      }

      private void InsererInformationDansTextBox()
      {
         SqlConnection connection = new SqlConnection((String)Application["MainDB"]);
         SqlCommand sqlcommand = new SqlCommand("SELECT avatar, fullname, email, password from users where username = '" + HttpContext.Current.User.Identity.Name + "'");
         sqlcommand.Connection = connection;
         connection.Open();
         SqlDataReader reader = sqlcommand.ExecuteReader();

         if (reader.Read())
         {
            AfficherImage(reader.GetString(0));
            LB_Username.Text = HttpContext.Current.User.Identity.Name;
            TB_Fullname.Text = reader.GetString(1);
            TB_Email.Text = reader.GetString(2);
            TB_EmailConfirm.Text = reader.GetString(2);
            TB_Password.Text = reader.GetString(3);
            TB_PasswordConfirm.Text = reader.GetString(3);
         }

         reader.Close();
         connection.Close();
      }

      private void AfficherImage(string Path)
      {
         if (Path != "")
            IMG_Avatar.ImageUrl = @"~\Avatars\" + Path + ".png";
         else
            IMG_Avatar.ImageUrl = @"~\Images\Anonymous.png";
      }

      private void UpdateCurrent()
      {
         SqlConnection connection = new SqlConnection((String)Application["MainDB"]);
         GestionAvatar();
         SqlCommand sqlcommand = new SqlCommand("update users set "
                                                + " avatar =  '" + IMG_Avatar.ImageUrl + "' , "
                                                + " fullname = '" + TB_Fullname.Text + "' , "
                                                + " email = '" + TB_Email.Text + "' , "
                                                + " password = '" + TB_Password.Text + "' "
                                                + " where username = '" + HttpContext.Current.User.Identity.Name + "'");
         sqlcommand.Connection = connection;
         connection.Open();
         SqlDataReader reader = sqlcommand.ExecuteReader();

         reader.Close();
         connection.Close();
      }

      private void DeleteImage(String ID)
      {
         if (File.Exists(Server.MapPath(ID)))
         {
            File.Delete(Server.MapPath(ID));
         }
      }

      private void GestionAvatar()
      {
         if (FU_Avatar.FileName != "")
         {
            String Avatar_Path = "";
            String avatar_ID = "";
            DeleteImage(IMG_Avatar.ImageUrl);
            avatar_ID = Guid.NewGuid().ToString();
            Avatar_Path = Server.MapPath(@"~\Avatars\") + avatar_ID + ".png";
            FU_Avatar.SaveAs(Avatar_Path);
            IMG_Avatar.ImageUrl = avatar_ID;
         }
      }

      private bool Verification()
      {
         bool Pareil = true;

         if (TB_Password.Text != TB_PasswordConfirm.Text)
         {
            // LABEL  HEY LES MOT DE PASSE SONT PAS PAREILLE
            LabelPassword_pasPareil.Text = "Les Passwords ne sont pas les mêmes.";
            Pareil = false;
         }
         else
         {
            if (TB_Password.Text == "")
            {
               // LABEL  HEY LE MOT DE PASSE EST VIDE
               LabelPassword_inscri.Text = "Password requis.";
               Pareil = false;
            }
            if (TB_PasswordConfirm.Text == "")
            {
               // LABEL  HEY LA CONFIRMATION DU MOT DE PASSE EST VIDE
               LabelPasswordConf_inscri.Text = "Confirmation de Password requis.";
               Pareil = false;
            }
         }

         if (TB_Email.Text != TB_EmailConfirm.Text)
         {
            // LABEL  HEY LES EMAILS SONT PAS PAREILLE
            LabelEmail_pasPareil.Text = "Les emails ne sont pas les mêmes.";
            Pareil = false;
         }
         else
         {
            if (TB_Email.Text == "")
            {
               // LABEL  HEY LE EMAIL EST VIDE
               LabelEmail_inscri.Text = "Email requis.";
               Pareil = false;
            }
            if (TB_EmailConfirm.Text == "")
            {
               // LABEL  HEY LA CONFIRMATION DU EMAIL EST VIDE
               LabelEmailConf_inscri.Text = "Confirmation de Email requis.";
               Pareil = false;
            }
         }

         if (TB_Fullname.Text == "")
         {
            // LABEL  HEY LE FULLNAME EST VIDE
            LabelPrenom_inscri.Text = "Nom Complet requis.";
            Pareil = false;
         }

         if (IMG_Avatar.ImageUrl == "")
         {
            // LABEL  MET UNE IMAGE CRISSE
            LabelImage.Text = "Vous devez choisir une image.";
            Pareil = false;
         }

         return Pareil;
      }

      private void ResetLabel()
      {
         LabelPassword_pasPareil.Text = "";
         LabelPassword_inscri.Text = "";
         LabelPasswordConf_inscri.Text = "";
         LabelEmail_pasPareil.Text = "";
         LabelEmail_inscri.Text = "";
         LabelEmailConf_inscri.Text = "";
         LabelPrenom_inscri.Text = "";
         LabelImage.Text = "";
      }

      protected void BTN_Update_Click(object sender, EventArgs e)
      {
         ResetLabel();
         if (Verification())
         {
            UpdateCurrent();
            Response.Redirect("Index.aspx");
         }
      }

   }
}