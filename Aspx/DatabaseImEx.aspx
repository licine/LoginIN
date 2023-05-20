<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="DatabaseImEx.aspx.cs" Inherits="Aspx_DatabaseImEx" %>

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
        <div class="database_imex_comtainer">
            <div class="select_info">
                <asp:FileUpload ID="FileUpload" CssClass="fileupload" runat="server" />
                <asp:Button ID="btn_indatabase" CssClass="btn_indatabase btn btnn" runat="server" OnClick="btn_indatabase_Click" Text="导入数据库" />
                <asp:Button ID="BtnOutExcel" CssClass="btn_toexcel btn btnn" runat="server" OnClick="BtnOutExcel_Click" Text="导出到excel" />
            </div>
            <div class="gridview_files">
                <asp:GridView ID="GridView_student" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" CssClass="table table-bordered table-striped table-hover" Width="100%" AllowPaging="True" PageSize="20" AllowSorting="True">
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
                        <asp:TemplateField HeaderText="学号" SortExpression="Snumber">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Snumber") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Snumber") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="姓名" SortExpression="Sname">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Sname") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("Sname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="班级" SortExpression="Sclass">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Sclass") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("Sclass") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:test01ConnectionString3 %>" SelectCommand="SELECT [Snumber], [Sname], [Sclass] FROM [Student]"></asp:SqlDataSource>
            </div>

        </div>
    </form>
</body>
</html>
