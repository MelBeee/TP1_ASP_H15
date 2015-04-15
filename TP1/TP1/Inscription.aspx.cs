using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace TP1
{
    public partial class Inscription : System.Web.UI.Page
    {

        public string Username;
        public string Nom;
        public string Prenom;
        public string Email;
        public string Password;
        public bool inscription = true;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Session["captcha"] = BuildCaptcha();
            }
        }
        protected void BTN_Inscription_Click(object sender, EventArgs e)
        {
            try
            {
                if (nom_Usager.Text == "")
                {
                    LabelUsername_inscr.Text = "Nom d'usager requis.";
                    inscription = false;
                }
                else if (Prenom_ID.Text == "")
                {
                    LabelPrenom_inscri.Text = "Prenom requis.";
                    inscription = false;
                }
                else if (Nom_ID.Text == "")
                {
                    LabelNom_inscri.Text = "Nom requis.";
                    inscription = false;
                }
                else if (inputEmail.Text == "")
                {
                    LabelEmail_inscri.Text = "Email requis.";
                    inscription = false;
                }
                else if (inputEmail_confrim.Text == "")
                {
                    LabelEmailConf_inscri.Text = "Confirmation de Email requis.";
                    inscription = false;
                }
                else if (inputPassword.Text == "")
                {
                    LabelPassword_inscri.Text = "Password requis.";
                    inscription = false;
                }
                else if (inputPassword_Con.Text == "")
                {
                    LabelPasswordConf_inscri.Text = "Confirmation de Password requis.";
                    inscription = false;
                }

                if (Email_Valide() == true && Password_Valide() == true && inscription == true)
                {
                    AddPersonneFormData();
                }

            }
            catch (Exception ex)
            {

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

            Users personne = new Users((String)Application["MainDB"], this);
            personne.FullName = Prenom_ID.Text + Nom_ID.Text;
            personne.UserName = nom_Usager.Text;
            personne.Password = inputPassword.Text;
            personne.Email = inputEmail.Text;
            personne.Avatar = avatar_ID;
            personne.Insert();
        }
        public bool Email_Valide()
        {
            bool EmailVal = false;

            if (inputEmail.Text != inputEmail_confrim.Text)
            {
                EmailVal = false;
            }
            else
            {
                EmailVal = true;
            }
            return EmailVal;
        }
        public bool Password_Valide()
        {
            bool pswd = false;

            if (inputPassword.Text != inputPassword_Con.Text)
            {
                pswd = false;
            }
            else
            {
                pswd = true;
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
            if (Page.IsValid)
            {
                Session["message"] = "(Inscription réussie - complétez maintenant votre profil...)";
            }
        }
        protected void CV_Captcha_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (TB_Captcha.Text == (string)Session["captcha"]);
        } 


    }
}