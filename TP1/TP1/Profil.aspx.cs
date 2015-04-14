using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
    public partial class Profil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!Page.IsPostBack)
              LoadForm();
        }
        private void InsertValuesInForm(Users personne)
        {
           nom_Usager.Text = personne.UserName;
           NomComp_ID.Text = personne.FullName;
           inputEmail.Text = personne.Email;
           inputPassword.Text = personne.Password;
        }
        private void LoadForm()
        {
           if (Session["Selected_ID"] != null)
           {
              // Création d'une nouvelle instance de PersonnesTable (reliée à la table MainDB.Personnes)
              Users personne = new Users((String)Application["MainDB"], this);
              // Conserver dans l'objet session afin qu'au prochain postback on puisse y référer
              Session["Personne"] = personne;
              if (personne.SelectByID((String)Session["Selected_ID"]))
              {
                 LB_ID.Text = (String)Session["Selected_ID"];
                 InsertValuesInForm(personne);
                 if (personne.Avatar != "")
                    IMG_Avatar.ImageUrl = "Avatars/" + personne.Avatar + ".png"; // +"?" + DateTime.Now.Millisecond.ToString();
                 else
                    IMG_Avatar.ImageUrl = "Images/Anonymous.png"; // +"?" + DateTime.Now.Millisecond.ToString();
              }
           }
        }
        private void DeleteCurrent()
        {
           DeleteImage(((Users)Session["Personne"]).Avatar);
           ((Users)Session["Personne"]).DeleteRecordByID((String)Session["Selected_ID"]);
           Session["Personne"] = null;
           Session["Selected_ID"] = null;
        }
        private void DeleteImage(String ID)
        {
           //File.Delete(Server.MapPath(@"~\Avatars\") + ID + ".png");
        }

        private void GetFormValues(Users personne)
        {
           personne.FullName = NomComp_ID.Text;
           personne.UserName = nom_Usager.Text;
           personne.Password = inputPassword.Text;
           personne.Email = inputEmail.Text;
        }

        private void UpdateCurrent()
        {
           if ((Session["Selected_ID"] != null) && (Session["Personne"] != null))
           {
              Users personne = (Users)Session["Personne"];
              GetFormValues(personne);

              if (FU_Avatar.FileName != "")
              {
                 String Avatar_Path = "";
                 String avatar_ID = "";
                 DeleteImage(personne.Avatar);
                 avatar_ID = Guid.NewGuid().ToString();
                 Avatar_Path = Server.MapPath(@"~\Avatars\") + avatar_ID + ".png";
                 FU_Avatar.SaveAs(Avatar_Path);
                 personne.Avatar = avatar_ID;
              }

              personne.Update();
              Session["Personne"] = null;
              Session["Selected_ID"] = null;
           }
           Response.Redirect("ListerPersonnes.aspx");
        }

        protected void BTN_Update_Click(object sender, EventArgs e)
        {
           if (Page.IsValid)
           {
              UpdateCurrent();
              Response.Redirect("ListerPersonnes.aspx");
           }
        }
        protected void BTN_Delete_Click(object sender, EventArgs e)
        {
           DeleteCurrent();
           Response.Redirect("ListerPersonnes.aspx");
        }

        protected void BTN_Cancel_Click(object sender, EventArgs e)
        {
           Session["Personne"] = null;
           Session["Selected_ID"] = null;
           Response.Redirect("ListerPersonnes.aspx");
        }
    }
}