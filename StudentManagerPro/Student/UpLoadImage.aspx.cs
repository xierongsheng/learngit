using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagerPro.Students
{
    public partial class UpLoadImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //保存学生编号，将作为图片文件名
                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("~/ErrorPage.htm");
                }
                ViewState["StudentId"] = Request.QueryString["Id"];
                //如果是修改头像则显示原头像
                if (Request.QueryString["IsModify"] == "1")
                {
                    this.stuImage.ImageUrl = "~/Images/Student/" + Request.QueryString["Id"] + ".png";
                }
            }
            this.ltaMsg.Text = "";
        }
        //上传照片
        protected void btnUpLoadImage_Click(object sender, EventArgs e)
        {
            //【1】判断是否有文件
            if (!this.fulStuImage.HasFile) return;
            //【2】获取文件大小,判断文件大小是否符合要求
            double fileLength = this.fulStuImage.FileContent.Length / (1024.0 * 1024.0);
            if (fileLength > 1.0)//判断文件大小是否符合要求
            {
                this.ltaMsg.Text = "<script type='text/javascript'>alert('图片最大不能超过1M')</script>";
                return;
            }
            //【3】获取图片文件名，并修改成规范的文件名
            string fileName = this.fulStuImage.FileName;
            if (fileName.Substring(fileName.LastIndexOf(".")).ToLower() != ".png")
            {  //判断文件名是否是png文件（防止前台JS验证失效）
                this.ltaMsg.Text = "<script type='text/javascript'>alert('图片必须是png格式！')</script>";
                return;
            }
            fileName = ViewState["StudentId"].ToString() + ".png";  //修改文件名          
            //【4】上传图片文件
            try
            {
                string path = Server.MapPath("~/Images/Student");//获取服务器文件夹路径
                this.fulStuImage.SaveAs(path + "/" + fileName);//开始上传
                if (Request.QueryString["IsModify"] == "1") //判断是否为修改头像
                    this.ltaMsg.Text = "<script type='text/javascript'>alert('图片修改成功！');location='StudentManage.aspx'</script>";
                else
                    this.ltaMsg.Text = "<script type='text/javascript'>alert('图片上传成功！');location='AddStudent.aspx'</script>";
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script type='text/javascript'>alert('图片上传失败！" + ex.Message + "')</script>";
            }
        }
    }
}