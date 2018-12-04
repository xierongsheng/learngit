<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true"
    CodeBehind="ScoreManage.aspx.cs" Inherits="StudentManagerPro.Score.ScoreManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/ScoreManage.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="QueryDiv">
        请选择要查询的班级：<asp:DropDownList ID="ddlClass" Width="120px" runat="server">
        </asp:DropDownList>
        <asp:Button ID="btnQuery" runat="server" Text="提交查询" 
            onclick="btnQuery_Click"  />
    </div>
    <div id="ScoreListDiv">
        <asp:GridView ID="gvScoreList" CssClass="ScoreTable" runat="server" 
            AutoGenerateColumns="False" onrowdatabound="gvScoreList_RowDataBound" CellPadding="4" ForeColor="#333333" GridLines="None" Height="188px" Width="923px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="StudentName" HeaderText="学员姓名" />
                <asp:BoundField DataField="Gender" HeaderText="性别" />
                <asp:BoundField DataField="ClassName" HeaderText="所在班级" />
                <asp:BoundField DataField="CSharp" HeaderText="C#成绩" />
                <asp:BoundField DataField="SQLServerDB" HeaderText="数据库成绩" />
                <asp:HyperLinkField HeaderText="学员信息" DataNavigateUrlFields="StudentId" 
                    DataNavigateUrlFormatString="~/Student/StudentDetail.aspx?StudentId={0}" 
                    Target="_blank" Text="详细信息" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div>
</asp:Content>
