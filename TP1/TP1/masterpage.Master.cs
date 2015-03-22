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
          LB_NomPage.Text = Path.GetFileName(Request.PhysicalPath).Substring(0, Path.GetFileName(Request.PhysicalPath).Length - 5);
      }
      protected void SetAvatarUser()
      {
          String avatar_ID = "";
          if (Session["Avatar"] != null)
          {
              avatar_ID = Session["Avatar"].ToString();
          }
          else
          {
              avatar_ID = "Anonymous";
          }
          IMG_User.ImageUrl = @"~\Avatars\" + avatar_ID + ".png";

      }
      protected void SetNomUser()
      {
          if (Session["FullName"] != null)
          {
              LB_User.Text = Session["FullName"].ToString();
          }
          else
          {
              LB_User.Text = "";
          }   
      }
   }
}