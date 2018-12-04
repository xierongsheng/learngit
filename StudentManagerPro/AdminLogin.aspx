<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="StudentManagerPro.AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/login.css" rel="stylesheet" />
    <link href="Styles/reset.css" rel="stylesheet" />
        <script type="text/javascript" src="js/jquery.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
<div class="page">
	<div class="loginwarrp">
		<div class="logo">管理员登陆</div>
        <div class="login_form">
            <ul>
            <li class="login-item">用户名：<asp:TextBox ID="txtUserId"
                runat="server" Width="150px" BackColor="White" BorderStyle="None"></asp:TextBox>
            </li>

				<li class="login-item">
					密&nbsp; &nbsp;码：<asp:TextBox 
                    ID="txtPwd" CssClass="loginItemText" runat="server" TextMode="Password" 
                    Width="150px" BackColor="White" BorderStyle="None"></asp:TextBox>
				</li>
            <li class="login-sub">
                <asp:Button ID="btn_login" runat="server" Text="登陆" Width="75px" OnClick="btn_login_Click" />
                <asp:Button ID="Button1" runat="server" Text="重置" Width="75px" />
            </li> 
                </ul>
            <div>
                            <asp:Literal ID="ltaInfo" runat="server"></asp:Literal>
            </div>
            <div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtUserId" Display="None" ErrorMessage="请输入用户名!"></asp:RequiredFieldValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtPwd" Display="None" ErrorMessage="请输入密码!"></asp:RequiredFieldValidator>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                ShowMessageBox="True" ShowSummary="False" />
            </div>
		</div>
	</div>
</div>
<script type="text/javascript">
    window.onload = function () {
        var config = {
            vx: 4,
            vy: 4,
            height: 2,
            width: 2,
            count: 100,
            color: "121, 162, 185",
            stroke: "100, 200, 180",
            dist: 6000,
            e_dist: 20000,
            max_conn: 10
        }
        CanvasParticle(config);
    }
	</script>
	<script type="text/javascript" src="js/canvas-particle.js"></script>
    </form>
</body>
</html>
