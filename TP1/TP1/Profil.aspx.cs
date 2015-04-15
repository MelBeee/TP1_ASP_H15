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
         SqlCommand sqlcommand = new SqlCommand("SELECT avatar, username, fullname, email, password from users where username = '" + HttpContext.Current.User.Identity.Name + "'");
         sqlcommand.Connection = connection;
         connection.Open();
         SqlDataReader reader = sqlcommand.ExecuteReader();

         if (reader.Read())
         {
            AfficherImage(reader.GetString(0));
            TB_Username.Text = reader.GetString(1);
            TB_Fullname.Text = reader.GetString(2);
            TB_Email.Text = reader.GetString(3);
            TB_EmailConfirm.Text = reader.GetString(3);
            TB_Password.Text = reader.GetString(4);
            TB_PasswordConfirm.Text = reader.GetString(4);
         }

         reader.Close();
         connection.Close();
      }

      private void AfficherImage(string Path)
      {
         if (Path != "")
            IMG_Avatar.ImageUrl = "Avatars/" + Path + ".png"; // +"?" + DateTime.Now.Millisecond.ToString();
         else
            IMG_Avatar.ImageUrl = "Images/Anonymous.png"; // +"?" + DateTime.Now.Millisecond.ToString();
      }

      private void DeleteImage(String ID)
      {

      }

      private void UpdateCurrent()
      {
         SqlConnection connection = new SqlConnection((String)Application["MainDB"]);
         SqlCommand sqlcommand = new SqlCommand("update users set "
                                                + " avatar =  '"  + IMG_Avatar.ImageUrl   + "' , "
                                                + " username = '" + TB_Username.Text      + "' , "
                                                + " fullname = '" + TB_Fullname.Text      + "' , "
                                                + " email = '"    + TB_Email.Text         + "' , "
                                                + " password = '" + TB_Password.Text      + "' "
                                                + " where username = '" + HttpContext.Current.User.Identity.Name + "'");
         sqlcommand.Connection = connection;
         connection.Open();
         SqlDataReader reader = sqlcommand.ExecuteReader();

         reader.Close();
         connection.Close();
      }

      private bool Verification()
      {
         bool Pareil = true;

         if (TB_Password.Text != TB_PasswordConfirm.Text)
         {
            // LABEL  HEY LES MOT DE PASSE SONT PAS PAREILLE
            Pareil = false;
         }
         else
         {
            if (TB_Password.Text == "")
            {
               // LABEL  HEY LE MOT DE PASSE EST VIDE
               Pareil = false;
            }
            if (TB_PasswordConfirm.Text == "")
            {
               // LABEL  HEY LA CONFIRMATION DU MOT DE PASSE EST VIDE
               Pareil = false;
            }
         }

         if (TB_Email.Text != TB_EmailConfirm.Text)
         {
            // LABEL  HEY LES EMAILS SONT PAS PAREILLE
            Pareil = false;
         }
         else
         {
            if (TB_Email.Text == "")
            {
               // LABEL  HEY LE EMAIL EST VIDE
               Pareil = false;
            }
            if (TB_EmailConfirm.Text == "")
            {
               // LABEL  HEY LA CONFIRMATION DU EMAIL EST VIDE
               Pareil = false;
            }
         }

         if(TB_Username.Text == "")
         {
            // LABEL  HEY LE USERNAME EST VIDE
            Pareil = false;
         }

         if(TB_Fullname.Text == "")
         {
            // LABEL  HEY LE FULLNAME EST VIDE
            Pareil = false;
         }

         return Pareil;
      }

      protected void BTN_Update_Click(object sender, EventArgs e)
      {
         if (Verification())
         {
            UpdateCurrent();
            Response.Redirect("Index.aspx");
         }
      }

   }
}