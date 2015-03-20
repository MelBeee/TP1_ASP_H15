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

      //public override void InitColumnsVisibility()
      //{
      //   base.InitColumnsVisibility();
      //   SetColumnVisibility("ID", false);
      //   SetColumnVisibility("PASSWORD", false);
      //}

      //public override void InitColumnsTitles()
      //{
      //   base.InitColumnsTitles();
      //   SetColumnTitle("USERNAME", "Username");
      //   SetColumnTitle("FULLNAME", "Nom complet");
      //   SetColumnTitle("EMAIL", "Email");
      //   SetColumnTitle("AVATAR", "Avatar");
      //}

      //public override void InitCellsContentDelegate()
      //{
      //   base.InitCellsContentDelegate();
      //   SetCellContentDelegate("AVATAR", ContentDelegateAvatar);
      //}

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

      public bool Exist(String userName)
      {
         bool existe = false;
         QuerySQL("SELECT * FROM " + SQLTableName + " WHERE USERNAME = '" + userName + "'");
         if (reader.HasRows)
         {
            Next();
            GetValues();
            existe = true;
         }

         return existe;
      }

      public bool Valid(String userName, string Password)
      {
         bool valide = false;
         QuerySQL("SELECT * FROM " + SQLTableName + " WHERE USERNAME = '" + userName + "' AND PASSWORD = '" + Password + "'");
         if (reader.HasRows)
         {
            Next();
            GetValues();
            valide = true;
         }

         return valide;
      }

      public string GetAvatar(string ID)
      {
         QuerySQL("Select Avatar FROM " + SQLTableName + " Where ID = " + ID);
         if (reader.Read())
         {
            string read = reader.GetString(0);
            QuerySQL("SELECT * FROM " + SQLTableName + " WHERE ID = " + ID);
            return read;
         }

         return "";
      }

      public string GetEmail(string ID)
      {
         QuerySQL("Select Email FROM " + SQLTableName + " Where ID = " + ID);
         if (reader.Read())
         {
            string read = reader.GetString(0);
            QuerySQL("SELECT * FROM " + SQLTableName + " WHERE ID = " + ID);
            return read;
         }

         return "";
      }

      public string GetPassword(string ID)
      {
         QuerySQL("Select Password FROM " + SQLTableName + " Where ID = " + ID);
         if (reader.Read())
         {
            string read = reader.GetString(0);
            QuerySQL("SELECT * FROM " + SQLTableName + " WHERE ID = " + ID);
            return read;
         }

         return "";
      }

      public override void Update()
      {
         UpdateRecord(ID, Username, Password, Fullname, Email, Avatar);
      }
   }
}