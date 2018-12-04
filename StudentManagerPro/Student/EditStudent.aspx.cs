using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagerPro.Students
{
    public partial class EditStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //【1】显示班级下拉框
                this.ddlClass.DataSource = new StudentClassDao().GetAllClasses();
                this.ddlClass.DataTextField = "ClassName";
                this.ddlClass.DataValueField = "ClassId";
                this.ddlClass.DataBind();
                this.ltaMsg.Text = "";
                //【2】根据ID查询学员信息
                string studentId = Request.QueryString["StudentId"].ToString();
                StudentExt objStu = new StudentDao().GetStudentById(studentId);
                //【3】显示学员信息
                this.ltaStudentId.Text = objStu.StudentId.ToString();
                this.txtStuName.Text = objStu.StudentName;
                this.txtStuIdNo.Text = objStu.StudentIdNo;
                this.txtPhoneNumber.Text = objStu.PhoneNumber;
                this.txtStuAddress.Text = objStu.StudentAddress;
                this.ddlClass.SelectedValue = objStu.ClassId.ToString();
                this.ddlGender.Text = objStu.Gender;
                this.txtStuBirthday.Text = objStu.Birthday.ToShortDateString();
            }
        }
        //提交修改
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //【1】判断身份证号是否已经被其他学员使用
            StudentDao objStudentDao = new StudentDao();
            if (objStudentDao.IsIdNoExisted(this.txtStuIdNo.Text.Trim(), this.ltaStudentId.Text))
            {
                this.ltaMsg.Text = "<script type='text/javascript'>alert('身份证号已经被其他学员使用！')</script>";
                return;
            }
            //【2】封装学员对象
            Student objStudent = new Student();
            objStudent.StudentId = Convert.ToInt32(this.ltaStudentId.Text);
            objStudent.StudentName = this.txtStuName.Text.Trim();
            objStudent.Gender = this.ddlGender.SelectedItem.Text.Trim();
            objStudent.Birthday = Convert.ToDateTime(this.txtStuBirthday.Text.Trim());
            objStudent.ClassId = Convert.ToInt32(this.ddlClass.SelectedValue);
            objStudent.PhoneNumber = this.txtPhoneNumber.Text.Trim();
            objStudent.StudentIdNo = this.txtStuIdNo.Text.Trim();
            objStudent.StudentAddress = this.txtStuAddress.Text.Trim();
            //【3】保存到数据库
            try
            {
                int result = new StudentDao().ModifyStudent(objStudent);//执行修改
                if (result > 0)//跳转到上传头像页面              
                    Response.Redirect("~/Student/UpLoadImage.aspx?IsModify=1&Id=" + this.ltaStudentId.Text);
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script type='text/javascript'>alert('" + ex.Message + "')</script>";
            }
        }
    }
}