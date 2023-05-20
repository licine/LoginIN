<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportGeneration.aspx.cs" Inherits="Aspx_ReportGeneration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link href="../bootstrap-3.4.1-dist/css/bootstrap.css" rel="stylesheet" />
    <link href="../assets/HomePage.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="report_container">
            <div class="select_info">
                <asp:Button ID="Btn_create_word" CssClass="btn_getword btn btnn" runat="server" OnClick="Btn_create_word_Click" Text="导出成绩单" />
                <asp:Button ID="card" CssClass="btn_getword btn btnn" runat="server" Text="生成贺年卡" OnClick="card_Click" />
            </div>
            <div class="grid_gradereport">
                <asp:GridView ID="GridView_report" runat="server"  CssClass="table table-bordered table-striped table-hover" Width="100%" AllowPaging="True" PageSize="20" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:TemplateField HeaderText="全选">
                            <HeaderTemplate>
                                <asp:CheckBox ID="CheckBox_gvall" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox_gvall_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox_gv_item" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle Width="50px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Snumber" HeaderText="学号" SortExpression="Snumber" />
                        <asp:BoundField DataField="Sname" HeaderText="姓名" SortExpression="Sname" />
                        <asp:BoundField DataField="Sclass" HeaderText="班级" SortExpression="Sclass" />
                        <asp:BoundField DataField="数据结构" HeaderText="数据结构" SortExpression="数据结构" />
                        <asp:BoundField DataField="c" HeaderText="c" SortExpression="c" />
                        <asp:BoundField DataField="java" HeaderText="java" SortExpression="java" />
                        <asp:BoundField DataField="linux" HeaderText="linux" SortExpression="linux" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:test01ConnectionString4 %>" SelectCommand="SELECT [Snumber], [Sname], [Sclass], [数据结构], [c], [java], [linux] FROM [Student]"></asp:SqlDataSource>

            </div>

        </div>
    </form>
</body>
</html>
