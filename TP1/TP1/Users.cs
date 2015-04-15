using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace TP1
{
   public class Users : SqlExpressUtilities.SqlExpressWrapper
   {
         public long ID { get; set; }
        public String FullName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public String Avatar { get; set; }
        public Char Connecter { get; set; }

        public Users(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "users";
        }
        public override void GetValues()
        {
            ID = long.Parse(this["ID"]);
            FullName = this["FullName"];
            UserName = this["UserName"];
            Password = this["Password"];
            Email = this["Email"];
            Avatar = this["Avatar"];
            Connecter = char.Parse(this["Connecte"]);
        }

        public override void InitColumnsVisibility()
        {
            base.InitColumnsVisibility();
            SetColumnVisibility("Avatar", false);
            SetColumnVisibility("Connecte", false);
        }

        public override void InitCellsContentDelegate()
        {
            base.InitCellsContentDelegate();
        }

        public override void InitColumnsSortEnable()
        {
            base.InitColumnsSortEnable();
        }

        public override void InitColumnsTitles()
        {
            base.InitColumnsTitles();
            SetColumnTitle("ID", "ID");
            SetColumnTitle("FullName", "Nom complet");
            SetColumnTitle("UserName", "Nom d'utilisateur");
            SetColumnTitle("Password", "Mot de passe");
            SetColumnTitle("Email", "Email");
        }

        public override void Insert()
        {
            InsertRecord(FullName, UserName, Password, Email, Avatar, Connecter);
        }
        public override void Update()
        {
            UpdateRecord(ID, FullName, UserName, Password, Email, Avatar, Connecter);
        }
   }
}