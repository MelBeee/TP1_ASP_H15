using System;
using System.Collections.Generic;
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
            Users tableUtilisateurs = new Users((string)Application["MainBD"], this);
            tableUtilisateurs.SelectAll();
            tableUtilisateurs.MakeGridView(PN_GridView, "Room.aspx");
        }
    }
}