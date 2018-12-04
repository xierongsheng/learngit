﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePwd.aspx.cs" Inherits="StudentManagerPro.ChangePwd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/ChangePwd.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
 <div class="page">
	<div class="loginwarrp">
		<div class="logo">管理员密码修改</div>
        <div class="login_form">
               <div id="loginInput">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtNewPwd" Display="None" ErrorMessage="请输入新密码!"></asp:RequiredFieldValidator>
            <div class="loginItem">
                <ul>
            <li class="login-item">
                原密码：<asp:TextBox ID="txtOldPwd" 
                    runat="server" TextMode="Password" Width="150px"></asp:TextBox>
            </li>
                 
				<li class="login-item">
					新密码：<asp:TextBox ID="txtNewPwd" 
                    CssClass="loginItemText" runat="server" TextMode="Password" Width="150px"></asp:TextBox>
				</li>
            <li class="login-sub">
           <asp:Button ID="btnChangePwd" runat="server" Text="修改密码" onclick="btnChangePwd_Click" 
                    />
            </li> 
                       </ul>
            <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" />
                <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
            </div>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtOldPwd" Display="None" ErrorMessage="请输入原密码!"></asp:RequiredFieldValidator>
          
        </div>
            </div>

		</div>
	</div>
</div>
    </form>
</body>
</html>