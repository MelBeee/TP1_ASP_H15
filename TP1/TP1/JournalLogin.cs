using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1
{
    public class JournalLogin : SqlExpressUtilities.SqlExpressWrapper
    {
        public long ID { get; set; }
        public int UserID { get; set; }
        public DateTime LoginDate { get; set; }
        public DateTime LogoutDate { get; set; }
        public String IPAdress { get; set; }
        public JournalLogin(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "LOGINS";
        }

        public override void GetValues()
        {
            ID = long.Parse(this["ID"]);
            UserID = int.Parse(this["UserID"]);
            LoginDate = DateTime.Parse(this["LoginDate"]);
            LogoutDate = DateTime.Parse(this["LogoutDate"]);
            IPAdress = this["IPAdress"];
        }

        public override void InitColumnsVisibility()
        {
            base.InitColumnsVisibility();
            SetColumnVisibility("ID", false);
            SetColumnVisibility("IPAdress", false);
        }

        public override void InitColumnsTitles()
        {
            SetColumnTitle("UserID", "Nom d'utilisateur");
            SetColumnTitle("LoginDate", "Date de connexion");
            SetColumnTitle("LogoutDate", "Durée de la session");
        }

        public override void Insert()
        {
            InsertRecord(UserID, LoginDate, LogoutDate, IPAdress);
        }

        public override void Update()
        {
            UpdateRecord(ID, UserID, LoginDate, LogoutDate, IPAdress);
        }
    }
}