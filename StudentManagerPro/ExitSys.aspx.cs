﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagerPro
{
    public partial class ExitSys : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //取消当前会话
            Session.Abandon();
            //跳转到登录页面
            Response.Redirect("~/AdminLogin.aspx");
        }
    }
}