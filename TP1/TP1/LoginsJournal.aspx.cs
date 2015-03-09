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
            string IDConnection = ""; // A MODIFIER CLAIREMENT
            string Username = ""; // A MODIFIER CLAIREMENT
            JournalLogin tableLogin = new JournalLogin((string)Application["MainBD"], this);
            if (Username == "admin")   
                tableLogin.SelectAll();
            else
                tableLogin.SelectByFieldName("UserID", IDConnection);

            tableLogin.MakeGridView(PN_GridView, "LoginsJournal.aspx");
        }
    }
}