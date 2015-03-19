using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP1
{
    public class Users : SqlExpressUtilities.SqlExpressWrapper
    {
        public long ID { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Fullname { get; set; }
        public String Email { get; set; }
        public String Avatar { get; set; }

        public Users(String connexionString, System.Web.UI.Page page)
            : base(connexionString, page)
        {
            SQLTableName = "USERS";
        }

        public override void GetValues()
        {
            ID = long.Parse(this["ID"]);
            Username = this["USERNAME"];
            Password = this["PASSWORD"];
            Fullname = this["FULLNAME"];
            Email = this["EMAIL"];
            Avatar = this["AVATAR"];
        }

        public override void InitColumnsVisibility()
        {
            base.InitColumnsVisibility();
            SetColumnVisibility("ID", false);
            SetColumnVisibility("PASSWORD", false);
        }

        public override void InitColumnsTitles()
        {
            base.InitColumnsTitles();
            SetColumnTitle("USERNAME", "Username");
            SetColumnTitle("FULLNAME", "Nom complet");
            SetColumnTitle("EMAIL", "Email");
            SetColumnTitle("AVATAR", "Avatar");
        }

        public override void InitCellsContentDelegate()
        {
            base.InitCellsContentDelegate();
            SetCellContentDelegate("AVATAR", ContentDelegateAvatar);
        }

        public override void Insert()
        {
            InsertRecord(Username, Password, Fullname, Email, Avatar);
        }

        System.Web.UI.WebControls.WebControl ContentDelegateAvatar()
        {
            System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
            if (Avatar != "")
            {
                img.ImageUrl = "~/Avatars/" + Avatar + ".png";
            }
            else
            {
                img.ImageUrl = "~/Images/Anonymous.png";
            }
            img.Height = img.Width = 40;
            return img;
        }

        public bool BonPassWordEtUsername(string password, string username)
        {
            bool oui = false;

            if(QuerySQL("select * from users where username = '" + username + "' and password = '" + password + "'") >= 1)
            {
                oui = true; 
            }
            return oui;
        }

        public bool BonUsername(string username)
        {
            bool oui = false;
            if(QuerySQL("select * from users where username = '" + username + "'") >= 1)
            {
                oui = true;
            }
            return oui;
        }




        //public string GetEmailFromUsers(String Username)
        //{
        //    QuerySQL("SELECT EMAIL FROM " + SQLTableName + " WHERE USERNAME = '" + Username + "'");
        //    reader.Read();
        //    return reader.GetString(0);
        //}

        //public string GetPasswordFromUsers(String Username)
        //{
        //    QuerySQL("SELECT PASSWORD FROM " + SQLTableName + " WHERE USERNAME = '" + Username + "'");
        //    reader.Read();
        //    return reader.GetString(0);
        //}

        //public bool SelectByUserName(String USERNAME)
        //{
        //    string sql = "SELECT * FROM " + SQLTableName + " WHERE USERNAME = '" + USERNAME + "'";
        //    QuerySQL(sql);
        //    if (reader.HasRows)
        //        Next();
        //    return reader.HasRows;
        //}

        public override void Update()
        {
            UpdateRecord(ID, Username, Password, Fullname, Email, Avatar);
        }
    }
}