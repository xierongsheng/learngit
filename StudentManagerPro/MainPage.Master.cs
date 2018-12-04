using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagerPro
{
    public partial class MainPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //判断用户是否登录
            if (Session["CurrentUser"] == null)
            {
                Response.Redirect("~/AdminLogin.aspx");
            }
            else
            {
                //显示登录用户信息
                SysAdmin objAdmin = (SysAdmin)Session["CurrentUser"];
                this.ltaUserName.Text = "欢迎您：&nbsp;" + objAdmin.AdminName;
            }
        }
    }
}