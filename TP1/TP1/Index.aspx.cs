using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var master = Master as masterpage;
            if (master != null)
                master.SetNomDeLaPage("Index");
        }

        protected void BTN_LogOff_Click(object sender, EventArgs e)
        {
            var master = Master as masterpage;
            if (master != null)
                master.signOut();
        }

        protected void BTN_Profil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profil.aspx");
        }

        protected void BTN_Room_Click(object sender, EventArgs e)
        {
            Response.Redirect("Room.aspx"); 
        }

        protected void BTN_JournalLog_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginsJournal.aspx");
        }

        protected void BTN_ChatRoom_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChatRoom.aspx");
        }

        protected void BTN_ManageThreads_Click(object sender, EventArgs e)
        {
            Response.Redirect("ThreadsManager.aspx");
        }
    }
}