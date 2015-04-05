using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace TP1
{
   public partial class masterpage : System.Web.UI.MasterPage
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         SetPageTitre();
         SetAvatarUser();
         SetNomUser();
      }
      protected void SetPageTitre()
      {
         LB_NomPage.Text = ""; // get un nom de chaque winform
      }
      protected void SetAvatarUser()
      {
         IMG_User.ImageUrl = ""; // get un path d'image de la bd si session est !null else image de base 
      }
      protected void SetNomUser()
      {
         LB_User.Text = "";  // get un nom d'user de la bd si session !null else pas de nom
      }
   }
}