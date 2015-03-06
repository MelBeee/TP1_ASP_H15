using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1
{
    public class Users : SqlExpressUtilities.SqlExpressWrapper
    {
        public long ID { get; set; }
        public String Name { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Avatar { get; set; }
        public Users(String connexionString, System.Web.UI.Page Page) 
            : base(connexionString, Page)
        {
            SQLTableName = "USERS";
        }

        public override void GetValues()
        {
            ID = long.Parse(this["ID"]);
            Name = this["FullName"];
            Username = this["Username"];
            Password = this["Password"];
            Email = this["Email"];
            Avatar = this["Avatar"];
        }

        public override void InitColumnsVisibility()
        {
            base.InitColumnsVisibility();
            SetColumnVisibility("Password", false);
            SetColumnVisibility("Avatar", false);
            SetColumnVisibility("ID", false);
        }

        public override void InitColumnsSortEnable()
        {
            base.InitColumnsSortEnable();
        }

        public override void InitColumnsTitles()
        {
            base.InitColumnsTitles();
            SetColumnTitle("FullName", "Nom Complet");
            SetColumnTitle("Username", "Nom d'utilisateur");
            SetColumnTitle("Email", "Adresse courriel");
        }

        public override void Insert()
        {
            InsertRecord(Name, Username, Password, Email, Avatar);
        }

        public override void Update()
        {
            UpdateRecord(ID, Name, Username, Password, Email, Avatar);
        }
    }
}