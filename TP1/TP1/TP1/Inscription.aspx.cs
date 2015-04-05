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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTN_Choisir_Image_Click(object sender, EventArgs e)
        {

        }

        protected void BTN_Inscription_Annuler_Click(object sender, EventArgs e)
        {

        }

        protected void BTN_Inscription_Click(object sender, EventArgs e)
        {
            try
            {
                if (Email_Valide() == true && Password_Valide() == true)
                {
                    Username = nom_Usager.Text;
                    Nom = Nom_ID.Text;
                    Prenom = Prenom_ID.Text;
                    Email = inputEmail.Text;
                    Password = inputPassword.Text;
                }

            }
            catch (Exception ex)
            {

            }

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