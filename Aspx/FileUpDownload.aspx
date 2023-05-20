<%@ Page Language="C#" AutoEventWireup="true" Debug="true" CodeFile="FileUpDownload.aspx.cs" Inherits="Aspx_FileUpDownload" %>

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
        <div class="fileupdown_container">
            <div class="select_info">
                <span>已选：</span>
                <span id="seleted_amount" runat="server"></span>
                <asp:Button ID="Batch_download" CssClass="btn_batch_down" runat="server" Text="批量下载" />
                <span>显示</span>
                <asp:DropDownList ID="ddl_pagesize_gv" runat="server">
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>50</asp:ListItem>
                </asp:DropDownList>
                <asp:Button ID="Btn_upload" CssClass="btn_upload btnn" runat="server" Text="文件上传" OnClick="Btn_upload_Click" />
                <asp:FileUpload ID="FileUpload" CssClass="fileupload" runat="server" />
            </div>

            <%--gridview列表--%>
            <div class="gridview_files">
                <asp:GridView ID="gvResource" runat="server" CssClass="table table-bordered table-striped table-hover" Width="100%" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" AllowPaging="True" PageSize="20" AllowSorting="True">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:CheckBox ID="CheckBox_gvall" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox_gvall_CheckedChanged" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox_gv_item" runat="server" OnCheckedChanged="CheckBox_gv_item_CheckedChanged" AutoPostBack="True" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="文件名" SortExpression="AnnexName">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("AnnexName") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" title="浏览文件" CssClass="d1" runat="server" Font-Bold="False" Font-Size="15px" OnClick="LinkButton1_Click" Text='<%# Eval("Name") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="修改日期" SortExpression="修改日期">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("修改日期") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("修改日期") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="文件类型" SortExpression="文件类型">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("文件类型") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("文件类型") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="大小" SortExpression="大小">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("大小") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("大小") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="下载" SortExpression="下载">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton2" ImageUrl="~/Images/down.png" Width="18px" runat="server" CommandArgument='<%# Eval("Name") %>' OnCommand="ImageButton2_Command" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" />
                    </EmptyDataTemplate>
                    <RowStyle HorizontalAlign="Center" />
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:test01ConnectionString2 %>" SelectCommand="SELECT * FROM [FileInfo]"></asp:SqlDataSource>
            </div>
        </div>
    </form>
</body>
</html>
