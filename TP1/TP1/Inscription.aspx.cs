using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

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

         IMG_Avatar.ImageUrl = @"~\Images\Anonymous.png";
      }

      private void InsererInformationDansBD()
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
         LabelUsername_inscr.Text = "";
         LabelPrenom_inscri.Text = "";
         LabelNom_inscri.Text = "";
         LabelEmail_inscri.Text = "";
         LabelEmailConf_inscri.Text = "";
         LabelPassword_inscri.Text = "";
         LabelPasswordConf_inscri.Text = "";
         LabelEmail_pasPareil.Text = "";
         LabelPassword_pasPareil.Text = "";
         LB_CapchaIncorrecte.Text = "";

         if (Page.IsValid)
         {
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
            if (IMG_Avatar.ImageUrl == "")
            {
               // LABEL  MET UNE IMAGE CRISSE
               inscription = false;
            }

            if (Email_Valide() && Password_Valide() && inscription && CapchaValide())
            {
               AddPersonneFormData();
               Response.Redirect("Login.aspx");
            }
         }
      }
      private void DeleteImage(String ID)
      {
        // File.Delete(Server.MapPath(ID));
      }
      protected void AddPersonneFormData()
      {
         if (FU_Avatar.FileName != "")
         {
            String Avatar_Path = "";
            String avatar_ID = "";
           // DeleteImage(IMG_Avatar.ImageUrl);
            avatar_ID = Guid.NewGuid().ToString();
            Avatar_Path = Server.MapPath(@"~\Avatars\") + avatar_ID + ".png";
            FU_Avatar.SaveAs(Avatar_Path);
            IMG_Avatar.ImageUrl = avatar_ID;
         }

         InsererInformationDansBD();
      }

      public bool CapchaValide()
      {
         bool capcha = true;

         if(TB_Captcha.Text != (string)Session["captcha"])
         {
            capcha = false;
            LB_CapchaIncorrecte.Text = "Le captcha ne correspond pas.";
         }

         return capcha;
      }

      public bool Email_Valide()
      {
         bool EmailVal = true;

         if (inputEmail.Text != inputEmail_confrim.Text)
         {
            EmailVal = false;
            LabelEmail_pasPareil.Text = "Les emails ne sont pas les mêmes.";
         }

         return EmailVal;
      }
      public bool Password_Valide()
      {
         bool pswd = true;

         if (inputPassword.Text != inputPassword_Con.Text)
         {
            pswd = false;
            LabelPassword_pasPareil.Text = "Les Passwords ne sont pas les mêmes.";
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
   }
}