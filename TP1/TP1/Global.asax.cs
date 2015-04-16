using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;

namespace TP1
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            string DB_Path = Server.MapPath(@"~\App_Data\MainDB.mdf");
            // Toutes les Pages (WebForm) pourront accéder à la propriété Application["MainDB"]
            Application["MainDB"] = @"Data Source=(LocalDB)\v11.0;AttachDbFilename='" + DB_Path + "';Integrated Security=True";
            Application["SessionTimeout"] = 5.0;

            Application["OnlineUsers"] = new List<long>();
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["Timeout"] = DateTime.Now;
            Session["EssaieDeConnexion"] = 0;
        }

        protected void Session_End(object sender, EventArgs e)
        {
            if (Session["isAuthenticated"] != null && (bool)Session["isAuthenticated"])
            {
                Page pg = (Page)Session["Page"];

                Logs loginTable = new Logs((String)Application["MainDB"], pg);

                SqlConnection connection = new SqlConnection((String)Application["MainDB"]);
                
                pg.Application.Lock();

                loginTable.InsertRecord(MethodesPourBD.TrouverIDUtilisateur(connection, HttpContext.Current.User.Identity.Name), (DateTime)Session["SessionStartTime"], DateTime.Now, TrouverIPAdresseUtilisateur());

                pg.Application.UnLock();

                if (((List<long>)Application["OnlineUsers"]).Contains(MethodesPourBD.TrouverIDUtilisateur(connection, HttpContext.Current.User.Identity.Name)))
                {
                    ((List<long>)Application["OnlineUsers"]).Remove(MethodesPourBD.TrouverIDUtilisateur(connection, HttpContext.Current.User.Identity.Name));
                }

                Session["isAuthenticated"] = false;
                FormsAuthentication.SignOut();
                Response.Redirect("Login.aspx");
            }
        }
        public string TrouverIPAdresseUtilisateur()
        {
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipList))
                return ipList.Split(',')[0];
            string ipAddress = Request.ServerVariables["REMOTE_ADDR"];
            if (ipAddress == "::1") // local host
                ipAddress = "127.0.0.1";
            return ipAddress;
        }
    }
}