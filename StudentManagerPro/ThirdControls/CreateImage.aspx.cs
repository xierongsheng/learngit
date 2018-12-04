using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

/// <summary>
/// CreateImage 的摘要说明。
/// </summary>
public partial class CreateImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["CheckCode"] = RndNum(4);
        CreateImages(Session["CheckCode"].ToString());
    }
    private void CreateImages(string checkCode)
    {
        int iwidth = (int)(checkCode.Length * 13);
        System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 23);
        Graphics grap = Graphics.FromImage(image);
        grap.Clear(Color.White);
        //定义颜色
        Color[] c = { Color.Black, Color.Red, Color.DarkBlue, Color.Green, Color.Orange, Color.Brown, Color.DarkCyan, Color.Purple };
        //定义字体 
        string[] font = { "Verdana", "Microsoft Sans Serif", "Comic Sans MS", "Arial", "宋体" };
        Random rand = new Random();
        //随机输出噪点
        for (int i = 0; i < 100; i++)
        {
            int x = rand.Next(image.Width);
            int y = rand.Next(image.Height);
            grap.DrawRectangle(new Pen(Color.LightGray, 0), x, y, 1, 1);
        }

        //输出不同字体和颜色的验证码字符
        for (int i = 0; i < checkCode.Length; i++)
        {
            int cindex = rand.Next(7);
            int findex = rand.Next(5);

            Font f = new System.Drawing.Font(font[findex], 12, System.Drawing.FontStyle.Bold);
            Brush b = new System.Drawing.SolidBrush(c[cindex]);
            int ii = 4;
            if ((i + 1) % 2 == 0)
            {
                ii = 2;
            }
            grap.DrawString(checkCode.Substring(i, 1), f, b, 3 + (i * 12), ii);
        }
        //画一个边框
        grap.DrawRectangle(new Pen(Color.Black, 0), 0, 0, image.Width - 1, image.Height - 1);

        //输出到浏览器
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        Response.ClearContent();
        Response.ContentType = "image/gif";
        Response.BinaryWrite(ms.ToArray());
        grap.Dispose();
        image.Dispose();
    }

    private string RndNum(int VcodeNum)
    {
        string Vchar = "0,1,2,3,4,5,6,7,8,9";
        string[] VcArray = Vchar.Split(',');
        string VNum = "";
        int temp = -1;

        Random rand = new Random();
        for (int i = 1; i < VcodeNum + 1; i++)
        {
            if (temp != -1)
            {
                rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));
            }
            int t = rand.Next(VcArray.Length);
            if (temp != -1 && temp == t)
            {
                return RndNum(VcodeNum);
            }
            temp = t;
            VNum += VcArray[t];
        }
        return VNum;
    }
}
