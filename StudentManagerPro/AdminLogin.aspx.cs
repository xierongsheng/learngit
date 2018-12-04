using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagerPro
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //用户登录
        protected void btn_login_Click(object sender, EventArgs e)
        {
                //封装用户名和密码
                SysAdmin objAdmin = new SysAdmin()
                {
                    LoginId = Convert.ToInt16(this.txtUserId.Text.Trim()),
                    LoginPwd = this.txtPwd.Text.Trim()
                };
                try
                {
                    objAdmin = new AdminDao().AdminLogin(objAdmin);//根据用户名或密码查询
                    if (objAdmin == null)//提示用户登录名或密码
                    {
                        this.ltaInfo.Text = "<script type='text/javascript'>alert('用户名或密码错误！')</script>";
                    }
                    else//保存用户对象，并跳转到首页
                    {
                        Session["CurrentUser"] = objAdmin;
                        Response.Redirect("~/Default.aspx");
                    }
                }
                catch (Exception ex)
                {
                    this.ltaInfo.Text = "<script type='text/javascript'>alert('" + ex.Message + "')</script>";
                }
            }
        }
}