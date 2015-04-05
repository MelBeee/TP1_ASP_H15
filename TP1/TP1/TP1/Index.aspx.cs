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
        static Logs unLog;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                unLog = new Logs((string)Application["MainDB"], this);
                unLog.DateLogin = DateTime.Now;
                unLog.UserID = long.Parse(Session["Selected_ID"].ToString());
                unLog.AdresseIP = GetUserIP();
            }
        }
        protected void BTN_LogOff_Click(object sender, EventArgs e)
        {
            unLog.DateLogout = DateTime.Now;
            unLog.Insert();

            Session["Selected_ID"] = null;
            Session["SelectedUserName"] = null;

            Response.Redirect("Login.aspx");
        }

        public string GetUserIP()
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