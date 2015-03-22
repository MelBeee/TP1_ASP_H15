using System;
using System.Collections.Generic;
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
            ListUsers();
        }

        public void ListUsers()
        {
            string UserID = Session["Selected_ID"].ToString();
            
            // Création d'une nouvelle instance de Users (reliée à la table MainDB.Users)
            Logs users = new Logs((String)Application["MainDB"], this);
            if(users.GetUsername(Session["Selected_ID"].ToString()) == "admin")
            {
                UserID = "admin";
            }
            users.MakeGridView(PN_Users, "LoginsJournal.aspx", UserID);
        }

        protected void BTN_Retour_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
        }
    }
}