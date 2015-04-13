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
                else if(Prenom_ID.Text == "")
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

            if(inputEmail.Text != inputEmail_confrim.Text)
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

            if (inputPassword != inputPassword_Con)
            {
                pswd = false;
            }
            else
            {
                pswd = true;
            }
            return pswd;
        }


    }
}