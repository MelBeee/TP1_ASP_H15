﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTN_Login_Click(object sender, EventArgs e)
        {
            if(TB_Username.Text == "")
            {

            }
            if(TB_Password.Text == "")
            {

            }
        }

        //protected void CV_TB_Username_ServerValidate(object source, ServerValidateEventArgs args)
        //{

        //}

        //protected void CV_TB_Password_ServerValidate(object source, ServerValidateEventArgs args)
        //{

        //}
    }
}