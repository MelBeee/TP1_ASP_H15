﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

        public Users(String connexionString, System.Web.UI.Page Page)
            : base(connexionString, Page)
        {
            SQLTableName = "users";
        }
        public override void GetValues()
        {
            ID = long.Parse(FieldsValues[0]);
            FullName = FieldsValues[1];
            UserName = FieldsValues[2];
            Password = FieldsValues[3];
            Email = FieldsValues[4];
            Avatar = FieldsValues[5];
        }

        public override void InitVisibility()
        {
            base.InitVisibility();
            SetVisibility(5, false);
        }

        public override void Insert()
        {
            InsertRecord(FullName, UserName, Password, Email, Avatar);
        }
        public override void Update()
        {
            UpdateRecord(ID, FullName, UserName, Password, Email, Avatar);
        }

        public bool Exist(String userName)
        {
            QuerySQL("SELECT * FROM " + SQLTableName + " WHERE USERNAME = '" + userName + "'");
            if (reader.HasRows)
            {
                Next();
                GetValues();
                return true;
            }
            else
                return false;
        }

        public bool Valid(String userName, string Password)
        {
            QuerySQL("SELECT * FROM " + SQLTableName + " WHERE USERNAME = '" + userName + "' AND PASSWORD = '" + Password + "'");
            if (reader.HasRows)
            {
                Next();
                GetValues();
                return true;
            }
            else
                return false;
        }

        public List<string> LoadFields(string ID)
        {
            List<string> Fields = new List<string>();
            QuerySQL("SELECT * FROM " + SQLTableName + " WHERE ID =" + ID);
            if (reader.Read())
            {
                Fields.Add(reader.GetString(1));
                Fields.Add(reader.GetString(2));
                Fields.Add(reader.GetString(3));
                Fields.Add(reader.GetString(4));
                Fields.Add(reader.GetString(5));
            }
            return Fields;
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
   }
}