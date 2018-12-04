<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true"
    CodeBehind="UpLoadImage.aspx.cs" Inherits="StudentManagerPro.Students.UpLoadImage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AddStudent.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        //检查上传图片是否是.PNG格式
        function CheckImg(FileUpload) {
            var fuvalue = FileUpload.value;
            fuvalue = fuvalue.toLowerCase().substr(fuvalue.lastIndexOf("."));
            if (fuvalue != ".png") {
                FileUpload.value = "";
                alert("上传的图片仅支持PNG格式！");
            }
            else {
                //同步显示选择的图片
                var stuImage = document.getElementById("<%=stuImage.ClientID%>");
                stuImage.src = FileUpload.value;
            }
        }
        //检查用户是否选择照片
        function CheckIsChoseImage() {
            var fulImage = document.getElementById("<%=fulStuImage.ClientID%>");          
            if (fulImage.value == "") {
                alert("请首先选择图片！");
                return false;
            } else return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="StuInfoTable">
        <caption>
            第二步：上传学员照片</caption>
        <tr>
            <td colspan="2">
                <asp:Image ID="stuImage" runat="server" Height="128px" Width="116px" ImageUrl="~/Images/defaultImg.png" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:FileUpload ID="fulStuImage" onchange="CheckImg(this)" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnUpLoadImage" OnClientClick="return CheckIsChoseImage()" 
                runat="server" 
                    Text="上传照片" OnClick="btnUpLoadImage_Click" />
            </td>
        </tr>
    </table>
    <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
</asp:Content>
