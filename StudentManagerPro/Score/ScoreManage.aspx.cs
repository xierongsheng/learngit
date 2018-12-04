using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagerPro.Score
{
    public partial class ScoreManage : System.Web.UI.Page
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
        }
        //按照班级查询
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            this.gvScoreList.DataSource = 
                new ScoreListDao().GetSCoreList(this.ddlClass.SelectedItem.Text.Trim());
            this.gvScoreList.DataBind();
        }
        //实现光棒效果
        protected void gvScoreList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover",
                    "currentcolor=this.style.backgroundColor;this.style.backgroundColor='#6699ff'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=currentcolor");
            }
        }
    }
}