using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagerPro.Students
{
    public partial class StudentDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {              
                //根据ID查询学员信息
                string studentId = Request.QueryString["StudentId"].ToString();               
                StudentExt objStu = new StudentDao().GetStudentById(studentId);
                //显示学员信息
                this.msg_name.Text = objStu.StudentName+"的详细信息";
                this.ltaStudentId.Text = objStu.StudentId.ToString();
                this.ltaStudentName.Text = objStu.StudentName;
                this.ltaStudentIdNo.Text = objStu.StudentIdNo;
                this.ltaPhoneNumber.Text = objStu.PhoneNumber;
                this.ltaAddress.Text = objStu.StudentAddress;
                this.ltaClass.Text = objStu.ClassName;
                this.ltaGender.Text = objStu.Gender;
                this.ltaBirthday.Text = objStu.Birthday.ToShortDateString();
                this.imgStudent.ImageUrl = "~/Images/Student/" + studentId + ".PNG";
            }
        }
    }
}