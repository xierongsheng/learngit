using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagerPro
{
    public partial class ChangePwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //判断用户是否登录
            {
                if (Session["CurrentUser"] == null)
                    Response.Redirect("~/AdminLogin.aspx");
            }
        }
        //修改登录密码
        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            if (((SysAdmin)Session["CurrentUser"]).LoginPwd !=
                this.txtOldPwd.Text.Trim())
            {
                this.ltaMsg.Text = "<script type='text/javascript'>alert('原密码不正确！')</script>";
                return;
            }
            AdminDao objAdminDao = new AdminDao();
            SysAdmin objAdmin = new SysAdmin()
            {
                LoginId = ((SysAdmin)Session["CurrentUser"]).LoginId,
                LoginPwd = this.txtNewPwd.Text.Trim()
            };
            try
            {
                objAdminDao.ModifyPwd(objAdmin);//修改密码
                this.ltaMsg.Text =
                    "<script type='text/javascript'>alert('用户密码修改成功！');location='../Default.aspx'</script>";
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script type='text/javascript'>alert('" + ex.Message + "')</script>";
            }
        }
    }
}