using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace TP1
{
   public partial class Inscription : System.Web.UI.Page
   {
      public bool inscription = true;

      protected void Page_Load(object sender, EventArgs e)
      {
         var master = Master as masterpageInscription;
         if (master != null)
            master.SetNomDeLaPage("Inscription");

         if (!Page.IsPostBack)
         {
            Session["captcha"] = BuildCaptcha();
         }
      }

      private void InsererInformationDansTextBox()
      {
         SqlConnection connection = new SqlConnection((String)Application["MainDB"]);
         SqlCommand sqlcommand = new SqlCommand("insert into users (avatar, username, fullname, email, password) values ('" +
                                                IMG_Avatar.ImageUrl + "', '" +
                                                nom_Usager.Text + "', '" +
                                                Prenom_ID.Text + " " + Nom_ID.Text + "', '" +
                                                inputEmail.Text + "', '" +
                                                inputPassword.Text + "') ");

         sqlcommand.Connection = connection;
         connection.Open();
         SqlDataReader reader = sqlcommand.ExecuteReader();

         reader.Close();
         connection.Close();
      }

      protected void BTN_Inscription_Click(object sender, EventArgs e)
      {
         if (Page.IsValid)
         {
            Session["message"] = "(Inscription réussie - complétez maintenant votre profil...)";

            if (nom_Usager.Text == "")
            {
               LabelUsername_inscr.Text = "Nom d'usager requis.";
               inscription = false;
            }
            if (Prenom_ID.Text == "")
            {
               LabelPrenom_inscri.Text = "Prenom requis.";
               inscription = false;
            }
            if (Nom_ID.Text == "")
            {
               LabelNom_inscri.Text = "Nom requis.";
               inscription = false;
            }
            if (inputEmail.Text == "")
            {
               LabelEmail_inscri.Text = "Email requis.";
               inscription = false;
            }
            if (inputEmail_confrim.Text == "")
            {
               LabelEmailConf_inscri.Text = "Confirmation de Email requis.";
               inscription = false;
            }
            if (inputPassword.Text == "")
            {
               LabelPassword_inscri.Text = "Password requis.";
               inscription = false;
            }
            if (inputPassword_Con.Text == "")
            {
               LabelPasswordConf_inscri.Text = "Confirmation de Password requis.";
               inscription = false;
            }

            if (Email_Valide() == true && Password_Valide() == true && inscription == true)
            {
               AddPersonneFormData();
               Response.Redirect("Login.aspx");
            }
         }
      }
      protected void AddPersonneFormData()
      {
         String avatar_ID = "";
         if (FU_Avatar.FileName != "")
         {
            String Avatar_Path = "";

            avatar_ID = Guid.NewGuid().ToString();
            Avatar_Path = Server.MapPath(@"~\Avatars\") + avatar_ID + ".png";
            FU_Avatar.SaveAs(Avatar_Path);
         }

         InsererInformationDansTextBox();
      }
      public bool Email_Valide()
      {
         bool EmailVal = true;

         if (inputEmail.Text != inputEmail_confrim.Text)
         {
            EmailVal = false;
         }

         return EmailVal;
      }
      public bool Password_Valide()
      {
         bool pswd = true;

         if (inputPassword.Text != inputPassword_Con.Text)
         {
            pswd = false;
         }

         return pswd;
      }
      Random random = new Random();
      char RandomChar()
      {
         // les lettres comportant des ambiguïtées ne sont pas dans la liste
         // exmple: 0 et O ont été retirés
         string chars = "abcdefghkmnpqrstuvwvxyzABCDEFGHKMNPQRSTUVWXYZ23456789";
         return chars[random.Next(0, chars.Length)];
      }

      Color RandomColor(int min, int max)
      {
         return Color.FromArgb(255, random.Next(min, max), random.Next(min, max), random.Next(min, max));
      }

      string Captcha()
      {
         string captcha = "";

         for (int i = 0; i < 5; i++)
            captcha += RandomChar();
         return captcha;//.ToLower();
      }

      string BuildCaptcha()
      {
         int width = 200;
         int height = 70;
         Bitmap bitmap = new Bitmap(width, height);
         Graphics DC = Graphics.FromImage(bitmap);
         SolidBrush brush = new SolidBrush(RandomColor(0, 127));
         SolidBrush pen = new SolidBrush(RandomColor(172, 255));
         DC.FillRectangle(brush, 0, 0, 200, 100);
         Font font = new Font("Snap ITC", 32, FontStyle.Regular);
         PointF location = new PointF(5f, 5f);
         DC.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
         string captcha = Captcha();
         DC.DrawString(captcha, font, pen, location);

         // noise generation
         for (int i = 0; i < 5000; i++)
         {
            bitmap.SetPixel(random.Next(0, width), random.Next(0, height), RandomColor(127, 255));
         }
         bitmap.Save(Server.MapPath("Captcha.png"), ImageFormat.Png);
         return captcha;
      }

      protected void RegenarateCaptcha_Click(object sender, ImageClickEventArgs e)
      {
         Session["captcha"] = BuildCaptcha();
         // + DateTime.Now.ToString() pour forcer le fureteur recharger le fichier
         IMGCaptcha.ImageUrl = "~/Captcha.png?ID=" + DateTime.Now.ToString();
         PN_Captcha.Update();
      }
      protected void BTN_Submit_Click(object sender, EventArgs e)
      {

      }
      protected void CV_Captcha_ServerValidate(object source, ServerValidateEventArgs args)
      {
         args.IsValid = (TB_Captcha.Text == (string)Session["captcha"]);
      }


   }
}