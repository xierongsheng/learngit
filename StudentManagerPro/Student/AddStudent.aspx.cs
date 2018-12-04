using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagerPro.Students
{
    public partial class AddStudent : System.Web.UI.Page
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
            this.ltaMsg.Text = "";//literal控件（用于实现脚本提示）
        }
        //添加新学员
        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            //【1】判断验证码是否正确
            if (this.txtValidateCode.Text.Trim() != Session["CheckCode"].ToString())
            {
                this.ltaMsg.Text = "<script type='text/javascript'>alert('验证码不正确！')</script>";
                return;
            }
            //【2】判断身份证号是否已经存在
            StudentDao objStudentDao = new StudentDao();
            if (objStudentDao.IsIdNoExisted(this.txtStuIdNo.Text.Trim()))
            {
                this.ltaMsg.Text = "<script type='text/javascript'>alert('身份证号已经被其他学员使用！')</script>";
                return;
            }
            //【3】封装学员对象
            Student objNewStudent = new Student();
            objNewStudent.StudentName = this.txtStuName.Text.Trim();
            objNewStudent.Gender = this.ddlGender.SelectedItem.Text.Trim();
            objNewStudent.Birthday = Convert.ToDateTime(this.txtStuBirthday.Text.Trim());
            objNewStudent.ClassId = Convert.ToInt32(this.ddlClass.SelectedValue);
            objNewStudent.PhoneNumber = this.txtPhoneNumber.Text.Trim();
            objNewStudent.StudentIdNo = this.txtStuIdNo.Text.Trim();
            objNewStudent.StudentAddress = this.txtStuAddress.Text.Trim();
            //【4】保存到数据库
            try
            {
                int newStudentId = objStudentDao.AddStudent(objNewStudent);//执行添加，并返回当前学员的学号
                if (newStudentId > 0)//跳转到上传头像页面
                    Response.Redirect("~/Student/UpLoadImage.aspx?Id=" + newStudentId);
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script type='text/javascript'>alert('" + ex.Message + "')</script>";
            }
        }
    }
}