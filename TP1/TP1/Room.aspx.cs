using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
    public partial class Room : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           var master = Master as masterpage;
           if (master != null)
              master.SetNomDeLaPage("Usagers en ligne");

           SqlConnection connection = new SqlConnection((String)Application["MainDB"]);

           Page.Application.Lock();

           string sqlCommand = " select id as 'En Ligne', username as 'Nom d'utilisateur', fullname as 'Nom Complet', email as Email, avatar as Avatar "
                             + " from users ";

           SqlDataAdapter sda = new SqlDataAdapter(sqlCommand, (String)Application["MainDB"]);
           ContentPlaceHolder CPH_content = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
           MethodesPourBD.AppendToTable(TB_Log, sda, true);

           Page.Application.UnLock();
        }

        protected void BTN_Return_Click(object sender, EventArgs e)
        {
           Response.Redirect("Index.aspx");
        }
        protected void RefreshPanel_Tick(object sender, EventArgs e)
        {
        }

    }
}