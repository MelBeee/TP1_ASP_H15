﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace TP1
{
    public partial class masterpage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated && !(Request.Url.ToString().Contains("Login.aspx") || Request.Url.ToString().Contains("Inscription.aspx")))
            {
                SqlConnection connection = new SqlConnection((String)Application["MainDB"]);
                Page.Application.Lock();

                IMG_User.ImageUrl = MethodesPourBD.TrouverAvatar(connection, HttpContext.Current.User.Identity.Name);

                Page.Application.UnLock();
                LB_User.Text = MethodesPourBD.TrouverNomComplet(connection, HttpContext.Current.User.Identity.Name);
            }

            if (!Page.IsPostBack)
            {
                Session["Timeout"] = DateTime.Now;
                HttpCookie authCookie = FormsAuthentication.GetAuthCookie(HttpContext.Current.User.Identity.Name, false);
                authCookie.Expires = DateTime.Now.AddMinutes((double)Application["SessionTimeout"]);
                Response.Cookies.Add(authCookie);
            }
        }

        public void SetNomDeLaPage(String nomPage)
        {
            LB_NomPage.Text = nomPage;
        }

        protected void SessionTimeout_Tick(object sender, EventArgs e)
        {
            if (((DateTime)Session["Timeout"]).AddMinutes(Session.Timeout) < DateTime.Now &&
               !(Request.Url.ToString().Contains("Login.aspx") || Request.Url.ToString().Contains("Inscription.aspx")))
                signOut();

            if (HttpContext.Current.Request.Cookies[".ASPTrucMuch"] == null &&
               !(Request.Url.ToString().Contains("Login.aspx") || Request.Url.ToString().Contains("Inscription.aspx")))
            {
                signOut();
            }

            LB_Timeout.Text = DateTime.Now.AddMinutes((double)Application["SessionTimeout"]).ToLongTimeString();
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

        public void signOut()
        {
            Logs loginTable = new Logs((String)Application["MainDB"], Page);

            SqlConnection connection = new SqlConnection((String)Application["MainDB"]);
            Page.Application.Lock();

            loginTable.InsertRecord(MethodesPourBD.TrouverIDUtilisateur(connection, HttpContext.Current.User.Identity.Name), (DateTime)Session["SessionStartTime"], DateTime.Now, GetUserIP());

            Page.Application.UnLock();
            LB_User.Text = HttpContext.Current.User.Identity.Name;

            if (((List<long>)Application["OnlineUsers"]).Contains(MethodesPourBD.TrouverIDUtilisateur(connection, HttpContext.Current.User.Identity.Name)))
            {
                ((List<long>)Application["OnlineUsers"]).Remove(MethodesPourBD.TrouverIDUtilisateur(connection, HttpContext.Current.User.Identity.Name));
            }

            Session["isAuthenticated"] = false;
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }
    }
}