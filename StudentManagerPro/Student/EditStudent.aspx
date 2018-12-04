﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true"
    CodeBehind="EditStudent.aspx.cs" Inherits="StudentManagerPro.Students.EditStudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/AddStudent.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../JS/My97DatePicker/WdatePicker.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="StuInfoTable">
        <caption>
            第一步：修改学生基本信息</caption>
              <tr>
            <td>
                学生编号：
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
                <asp:TextBox ID="txtStuName" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtStuName" ErrorMessage="请填写学员姓名!" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                学生性别：
            </td>
            <td>
                <asp:DropDownList ID="ddlGender" runat="server">
                    <asp:ListItem>男</asp:ListItem>
                    <asp:ListItem>女</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                出生日期：
            </td>
            <td>
                <asp:TextBox ID="txtStuBirthday"  onClick="WdatePicker()" runat="server" Width="100px"></asp:TextBox>
                (请点击文本框选择日期)<asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                    runat="server" ControlToValidate="txtStuBirthday" ErrorMessage="请选择日期!" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                所在班级：
            </td>
            <td>
                <asp:DropDownList ID="ddlClass" Width="100px" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                身份证号：
            </td>
            <td>
                <asp:TextBox ID="txtStuIdNo" runat="server" Width="150px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtStuIdNo" Display="Dynamic" ErrorMessage="请填写身份证号！" 
                    ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="txtStuIdNo" Display="Dynamic" ErrorMessage="身份证号不符合要求！" 
                    ForeColor="Red" ValidationExpression="\d{17}[\d|X]|\d{15}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                联系电话：
            </td>
            <td>
                <asp:TextBox ID="txtPhoneNumber" runat="server" Width="320px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                家庭住址：
            </td>
            <td>
                <asp:TextBox ID="txtStuAddress" runat="server" Width="320px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnEditStudent" runat="server" Text="提交到数据库" 
                    OnClick="btnSubmit_Click" />
                <asp:Literal ID="ltaMsg" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
