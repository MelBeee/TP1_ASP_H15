using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
   public partial class masterpageInscription : System.Web.UI.MasterPage
   {
      protected void Page_Load(object sender, EventArgs e)
      {

      }
      public void SetNomDeLaPage(String nomPage)
      {
         LB_NomPage.Text = nomPage;
      }
   }
}