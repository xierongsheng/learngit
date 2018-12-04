<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentDetail.aspx.cs"
    Inherits="StudentManagerPro.Students.StudentDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/StudentDetail.css" rel="stylesheet" type="text/css" />
    
    <script language="javascript" type="text/javascript">

        function btnClose_onclick() {
            window.close();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
<div class="page">
	<div class="loginwarrp">
		<div class="logo">
            <asp:Label ID="msg_name" runat="server" Text=""></asp:Label></div>
        <div class="login_form">
<table class="StuTable">
                <tr>
                    <td colspan="2">
                        <asp:Image ID="imgStudent" runat="server" Height="128px" Width="116px" 
                            ImageUrl="~/Images/defaultImg.png" />
                    </td>
                </tr>
                <tr>
                    <td>
                        学生学号：
                    </td>
                    <td>
                        <asp:Literal ID="ltaStudentId" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        学生姓名：
                    </td>
                    <td>
                        <asp:Literal ID="ltaStudentName" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        学生性别：
                    </td>
                    <td>
                        <asp:Literal ID="ltaGender" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        出生日期：
                    </td>
                    <td>
                        <asp:Literal ID="ltaBirthday" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        所在班级：
                    </td>
                    <td>
                        <asp:Literal ID="ltaClass" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        身份证号：
                    </td>
                    <td>
                        <asp:Literal ID="ltaStudentIdNo" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        联系电话：
                    </td>
                    <td>
                        <asp:Literal ID="ltaPhoneNumber" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        家庭住址：
                    </td>
                    <td>

                        <asp:Literal ID="ltaAddress" runat="server"></asp:Literal>
                    </td>
                </tr>
                 <tr>
                 
                </tr>
            </table>
          <ul>
       <li class="login-sub">          
            <input id="btnClose" type="button" value="关闭窗口"  onclick="btnClose_onclick()" />  
            </li> 
              </ul>
		</div>
	</div>
</div>
    </form>
</body>
</html>
