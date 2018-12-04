using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace StudentManagerPro.Students
{
    public partial class StudentManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //显示班级下拉框
                this.ddlClass.DataSource = new StudentClassDao().GetAllClasses();
                this.ddlClass.DataTextField = "ClassName";
                this.ddlClass.DataValueField = "ClassId";
                this.ddlClass.DataBind();
            }
            this.ltaMsg.Text = "";//清除以前的脚本，避免每次弹出消息框
        }
        //绑定查询结果
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            this.dlStuInfo.DataSource =
                new StudentDao().GetStudentByClass(this.ddlClass.SelectedItem.Text.Trim());
            this.dlStuInfo.DataBind();
        }
        //删除学员
        protected void btnDel_Click(object sender, EventArgs e)
        {
            //【1】获取要删除的学员编号
            string studentId = ((LinkButton)sender).CommandArgument;
            try
            {
                //【2】执行删除
                int result = new StudentDao().DeleteStudentById(studentId);
                if (result == 1)
                {
                    //【3】同时删除服务器上的学员照片
                    File.Delete(Server.MapPath("~/Images/Student/" + studentId + ".png"));
                    //【4】同步刷新显示
                    btnQuery_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script type='text/javascript'>alert('" + ex.Message + "')</script>";
            }
        }
    }
}