
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using Aspose.Words;
using Word = Microsoft.Office.Interop.Word;
public partial class HomePage : System.Web.UI.Page
{
    Datacon dataconn = new Datacon();  //定义数据库操作对象

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            //int idx = 1;
            //foreach (GridViewRow gvRow in gvResource.Rows)
            //{
            //    System.Web.UI.WebControls.Label lebelItem = (System.Web.UI.WebControls.Label)gvRow.FindControl("Label_gv_item_number");
            //    lebelItem.Text = idx.ToString();
            //    idx++;
            //}
            //ddl_pagesize_gv.SelectedValue = "20";
            //gvResource.PageSize = 1;
            //seleted_amount.InnerText = "123";
        }

    }


    ///// <summary>
    ///// 创建文件夹
    ///// </summary>
    ///// <param name="Path"></param>
    //protected void FolderCreate(string Path)
    //{
    //    // 判断目标目录是否存在如果不存在则新建之   
    //    if (!Directory.Exists(Path))
    //        Directory.CreateDirectory(Path);
    //}


    ///// <summary>
    ///// 导入数据库
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void btn_indatabase_Click(object sender, EventArgs e)
    //{

    //    //try
    //    //{

    //    System.Data.DataTable dt = Xsldata();
    //    if (dt == null)
    //    {
    //        return;
    //    }

    //    int errorcount = 0;//记录错误信息条数
    //    int insertcount = 0;//记录插入成功条数

    //    int updatecount = 0;//记录更新信息条数

    //    SqlConnection conn = dataconn.getcon();//链接数据库
    //    conn.Open();

    //    for (int i = 0; i < dt.Rows.Count; i++)
    //    {
    //        string Name = dt.Rows[i][0].ToString();//dt.Rows[i]["Name"].ToString(); "Name"即为Excel中Name列的表头
    //        string Sex = dt.Rows[i][1].ToString();
    //        string Age = dt.Rows[i][2].ToString();
    //        string Address = dt.Rows[i][3].ToString();
    //        if (Name != "" && Sex != "" && Age != "" && Address != "")
    //        {
    //            SqlCommand selectcmd = new SqlCommand("select count(*) from Table_1 where a='" + Name + "' and b='" + Sex + "' and c='" + Age + "' and d='" + Address + "'", conn);
    //            int count = Convert.ToInt32(selectcmd.ExecuteScalar());
    //            if (count > 0)
    //            {
    //                updatecount++;
    //            }
    //            else
    //            {
    //                SqlCommand insertcmd = new SqlCommand("insert into Table_1 values('" + Name + "','" + Sex + "','" + Age + "','" + Address + "')", conn);
    //                insertcmd.ExecuteNonQuery();
    //                insertcount++;
    //            }
    //        }
    //        else
    //        {
    //            errorcount++;
    //        }
    //    }
    //    ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('" + insertcount + "条数据导入成功!" + updatecount + "条数据重复！" + errorcount + "条数据部分信息为空没有导入！" + " ');", true);

    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    string errorInfo = ex.Message.ToString();
    //    //    ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('数据错误：" + errorInfo + "');", true);
    //    //    //this.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script type='text/javascript'>alert('数据错误：" + errorInfo + "');</script>");
    //    //}
    //}


    ///// <summary>
    ///// DataTable函数
    ///// </summary>
    //private System.Data.DataTable Xsldata()
    //{
    //    if (FileUpload.FileName == "")
    //    {
    //        ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('请选择文件');", true);
    //        //this.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script type='text/javascript'>alert('请选择文件');</script>");
    //        return null;
    //    }
    //    string fileExtenSion;
    //    fileExtenSion = Path.GetExtension(FileUpload.FileName);
    //    if (fileExtenSion.ToLower() != ".xls" && fileExtenSion.ToLower() != ".xlsx")
    //    {
    //        ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('上传的文件格式不正确');", true);
    //        //this.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script type='text/javascript'>alert('上传的文件格式不正确');</script>");
    //        return null;
    //    }
    //    //try
    //    //{
    //    string FileName = "../files/" + Path.GetFileName(FileUpload.FileName);
    //    if (File.Exists(Server.MapPath(FileName)))
    //    {
    //        File.Delete(Server.MapPath(FileName));
    //    }
    //    FileUpload.SaveAs(Server.MapPath(FileName));
    //    //HDR=Yes，这代表第一行是标题，不做为数据使用 ，如果用HDR=NO，则表示第一行不是标题，做为数据来使用。系统默认的是YES
    //    string connstr2003 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath(FileName) + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
    //    string connstr2007 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(FileName) + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
    //    OleDbConnection conn;
    //    if (fileExtenSion.ToLower() == ".xls")
    //    {
    //        conn = new OleDbConnection(connstr2003);
    //    }
    //    else
    //    {
    //        conn = new OleDbConnection(connstr2007);
    //    }
    //    conn.Open();
    //    string sql = "select * from [Sheet1$]";
    //    OleDbCommand cmd = new OleDbCommand(sql, conn);
    //    System.Data.DataTable dt = new System.Data.DataTable();
    //    OleDbDataReader sdr = cmd.ExecuteReader();

    //    dt.Load(sdr);
    //    sdr.Close();
    //    conn.Close();
    //    //删除服务器里上传的文件
    //    if (File.Exists(Server.MapPath(FileName)))
    //    {
    //        File.Delete(Server.MapPath(FileName));
    //    }
    //    return dt;
    //    //}
    //    //catch (Exception e)
    //    //{
    //    //    return null;
    //    //}
    //}


    ///// <summary>
    ///// 导出到excel
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void BtnOutExcel_Click(object sender, EventArgs e)
    //{
    //    DataSet ds = PutInDataSet();
    //    SaveAsExcel(ds);
    //}


    ///// <summary>
    ///// put data source into dataset
    ///// </summary>
    ///// <returns>DataSet</returns>
    //private static DataSet PutInDataSet()
    //{
    //    string connStr = @"Data Source=localhost;Initial Catalog=test01;User ID=sa;PWD=s;Persist Security Info=True";
    //    string queryStr = @"SELECT * FROM Table_1";
    //    SqlConnection con = new SqlConnection(connStr);
    //    SqlDataAdapter adapter = new SqlDataAdapter(queryStr, connStr);
    //    DataSet ds = new DataSet();
    //    adapter.Fill(ds);
    //    return ds;
    //}


    ///// <summary>
    ///// save the data as excel file
    ///// </summary>
    ///// <param name="ds"></param>
    //private void SaveAsExcel(DataSet ds)
    //{
    //    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
    //    if (excelApp != null)
    //    {
    //        Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add(Missing.Value);
    //        Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//get the sheet index          
    //        for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
    //        {
    //            for (int col = 0; col < ds.Tables[0].Columns.Count; col++)
    //            {
    //                worksheet.Cells[row + 2, col + 1] = ds.Tables[0].Rows[row][col];
    //            }
    //        }
    //    }
    //    else
    //    {
    //    }
    //    excelApp.Quit();
    //}


    ///// <summary>
    ///// 生成成绩单word文档
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void Btn_create_word_Click(object sender, EventArgs e)
    //{
    //    Word._Application app = new Microsoft.Office.Interop.Word.ApplicationClass();//注意如果添加的是Office2010引用，是Word._Application，不是Word.Application，调用的是接口
    //    Word._Document doc = null;
    //    Object nothing = System.Reflection.Missing.Value;//Word中的null非C#中的null，得装换
    //    Object filename = Server.MapPath("../files/template.docx");//服务器中要打开的文档
    //    doc = app.Documents.Open(ref filename, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);
    //    foreach (Word.Bookmark bm in doc.Bookmarks)//遍历已经打开的Word文档中的标签，插入我们的数据
    //    {
    //        if (bm.Name == "name")
    //        {
    //            bm.Range.Text = "一一";
    //        }
    //        if (bm.Name == "score")
    //        {
    //            //Object table = "table";//插入表格，注意已打开word文档中标签的位置，因为word中插入表格是挤占原有的位置，并非换行再插入
    //            //Word.Range srange = bm.Range;
    //            //Word.Table ta = doc.Tables.Add(srange, 5, 5, ref nothing, ref nothing);
    //            //for (int i = 1; i <= 5; i++)
    //            //{
    //            //    for (int j = 1; j <= 5; j++)
    //            //    {
    //            //        ta.Cell(i, j).Range.Text = "第" + i + "行" + "第" + j + "列";
    //            //    }
    //            //}
    //            bm.Range.Text = "99";

    //        }
    //    }
    //    ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('文件生成成功.');", true);
    //    //关闭word，程序最好try...catch一下，因为IO流操作，如果程序出错，数据就会写到已经打开的word文档中，不会导出新的文档 
    //    //Directory.CreateDirectory("C:/CNSI"); //创建文件所在目录
    //    filename = Server.MapPath("../files/report_card.docx");
    //    doc.SaveAs(ref filename, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);
    //    doc.Close(ref nothing, ref nothing, ref nothing);
    //    app.Quit(ref nothing, ref nothing, ref nothing);
    //}


    ///// <summary>
    ///// 文件上传
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void Btn_upload_Click(object sender, EventArgs e)
    //{
    //    //try
    //    //{
    //    //取出所选文件的本地路径
    //    string fullFileName = this.FileUpload.PostedFile.FileName;
    //    //从路径中截取出文件名
    //    string fileName = fullFileName.Substring(fullFileName.LastIndexOf("\\") + 1);
    //    //限定上传文件的格式
    //    string type = fullFileName.Substring(fullFileName.LastIndexOf(".") + 1);
    //    if (type == "doc" || type == "docx" || type == "xls" || type == "xlsx" || type == "ppt" || type == "pptx" || type == "pdf" || type == "jpg" || type == "bmp" || type == "gif" || type == "png" || type == "txt" || type == "zip" || type == "rar")
    //    {
    //        //将文件保存在服务器中根目录下的files文件夹中
    //        string saveFileName = Server.MapPath("/files") + "\\" + fileName;
    //        FileUpload.PostedFile.SaveAs(saveFileName);
    //        ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('文件上传成功.');", true);
    //        SqlDataSource2.SelectCommand = "select * from FileInfo";
    //        gvResource.DataSourceID = SqlDataSource2.ID;
    //        gvResource.DataBind();

    //        //向数据库中存储相应通知的附件的目录
    //        BLL.news.InsertAnnexBLL insertAnnex = new BLL.news.InsertAnnexBLL();
    //        AnnexEntity annex = new AnnexEntity();     //创建附件的实体
    //        annex.Name = fileName;               //附件名
    //        insertAnnex.InsertAnnex(annex);         //将实体存入数据库（其实就是讲实体的这些属性insert到数据库中的过程，具体BLL层和DAL层的代码这里不再多说）
    //    }
    //    else
    //    {
    //        ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('请选择正确的格式.');", true);
    //    }
    //    //}
    //    //catch (Exception ex)
    //    //{
    //    //    string errorInfo = ex.Message.ToString();
    //    //    ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('上传失败.');", true);
    //    //}
    //}

    ///// <summary>
    ///// 全选复选框
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void CheckBox_gvall_CheckedChanged(object sender, EventArgs e)
    //{
    //    System.Web.UI.WebControls.CheckBox ChkAll = (System.Web.UI.WebControls.CheckBox)sender;
    //    foreach (GridViewRow gvRow in gvResource.Rows)
    //    {
    //        System.Web.UI.WebControls.CheckBox chkItem = (System.Web.UI.WebControls.CheckBox)gvRow.FindControl("CheckBox_gv_item");
    //        chkItem.Checked = ChkAll.Checked;
    //    }
    //}

    ///// <summary>
    ///// 文件下载
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void ImageButton2_Command(object sender, CommandEventArgs e)
    //{

    //    string rootpath = Server.MapPath("../files/");
    //    // 定义文件名  
    //    string fileName = e.CommandArgument.ToString();
    //    // 获取文件在服务器的地址  
    //    string url = rootpath + fileName;

    //    // 判断传输地址是否为空  
    //    if (url == "")
    //    {
    //        // 提示“该文件暂不提供下载”  
    //        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script defer>alert('该文件暂不提供下载！');</script>");
    //        return;
    //    }
    //    // 判断获取的是否为地址，而非文件名  
    //    if (url.IndexOf("\\") > -1)
    //    {
    //        // 获取文件名  
    //        fileName = url.Substring(url.LastIndexOf("\\") + 1);
    //    }
    //    else
    //    {
    //        // url为文件名时，直接获取文件名  
    //        fileName = url;
    //    }
    //    // 以字符流的方式下载文件  
    //    FileStream fileStream = new FileStream(@url, FileMode.Open);
    //    byte[] bytes = new byte[(int)fileStream.Length];
    //    fileStream.Read(bytes, 0, bytes.Length);
    //    fileStream.Close();
    //    Response.ContentType = "application/octet-stream";

    //    // 通知浏览器下载 
    //    Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
    //    Response.BinaryWrite(bytes);
    //    Response.Flush();
    //    Response.End();
    //}

    ///// <summary>
    ///// 文件浏览
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //protected void LinkButton1_Click(object sender, EventArgs e)
    //{
    //    string filename = ((System.Web.UI.WebControls.LinkButton)sender).Text.Trim();
    //    string root_directory = Server.MapPath("../files/");
    //    //ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('" + root_directory + "')", true);

    //    //文件位置
    //    //string FilePath = (root_directory + "//files//dem01.doc");
    //    string FilePath = root_directory + filename;

    //    //指定转换后的pdf文件存储路径
    //    string savepath = System.Web.Hosting.HostingEnvironment.MapPath("/temporaryFiles/temp1" + ".pdf");

    //    //使用Asponse.word的方法进行转换
    //    Aspose.Words.Document doc = new Aspose.Words.Document(FilePath);
    //    doc.Save(savepath, Aspose.Words.SaveFormat.Pdf);
    //    //直接读取文件流到浏览器展示
    //    FileStream fs = new FileStream(savepath, FileMode.Open);
    //    byte[] buffer = new byte[fs.Length];
    //    fs.Seek(0, SeekOrigin.Begin);
    //    fs.Read(buffer, 0, buffer.Length);
    //    fs.Flush();
    //    fs.Close();
    //    string FileName = "../temporaryFiles/temp1.pdf";
    //    if (File.Exists(Server.MapPath(FileName)))
    //    {
    //        File.Delete(Server.MapPath(FileName));
    //    }

    //    //context.Response.ContentType = "application/PDF";
    //    //context.Response.BinaryWrite(buffer);
    //    //context.Response.Flush();
    //    //context.Response.End();
    //    Response.ContentType = "application/PDF";
    //    Response.BinaryWrite(buffer);
    //    Response.Flush();
    //    Response.End();
    //}
}