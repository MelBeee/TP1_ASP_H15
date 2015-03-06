using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace TP1
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            string DB_Path = Server.MapPath(@"~\App_Data\MainBD.mdf");
            // Toutes les Pages (WebForm) pourront accéder à la propriété Application["MaindDB"]
            Application["MainBD"] = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DB_Path + "';Integrated Security=False";
        }
    }
}