using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
    public partial class LoginsJournal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var master = Master as masterpage;
            if (master != null)
                master.SetNomDeLaPage("Journal des visites");
            

            SqlConnection connection = new SqlConnection((String)Application["MainDB"]);

            Page.Application.Lock();

            //String sqlCommand = " SELECT USERID AS ID, CONVERT(VARCHAR(30), LOGINDATE, 0) AS Début, CONVERT(VARCHAR(11), (LOGOUTDATE - LOGINDATE), 8) AS Durée, IPADDRESS AS IP,"
            //                   + " USERNAME AS 'Nom d''usager', FULLNAME AS 'Nom complet', EMAIL as Email, AVATAR AS Avatar "
            //                   + " FROM LOGINS INNER JOIN USERS ON LOGINS.USERID = USERS.ID WHERE USERS.ID = " + MethodesPourBD.TrouverIDUtilisateur(connection, HttpContext.Current.User.Identity.Name)
            //                   + " OR '" + HttpContext.Current.User.Identity.Name + "' = 'admin' ORDER BY Début DESC";

            string sqlCommand = "select u.username as Username, convert(varchar(30), logindate, 0) as 'Date de connexion', CONVERT(VARCHAR(11), (LOGOUTDATE - LOGINDATE), 8) AS Durée "
                              + " from logins inner join users u on logins.userid = u.id " 
                              + " where u.id = " + MethodesPourBD.TrouverIDUtilisateur(connection, HttpContext.Current.User.Identity.Name)
                              + " or '" + HttpContext.Current.User.Identity.Name + "' = 'admin' order by 'Date de connexion' desc";

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