
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

public partial class Aspx_FileUpDownload : System.Web.UI.Page
{
    Datacon dataconn = new Datacon();  //定义数据库操作对象
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Session["1"] = "1";
        if (!Page.IsPostBack)
        {
            int idx = 1;
            //foreach (GridViewRow gvRow in gvResource.Rows)
            //{
            //    System.Web.UI.WebControls.Label lebelItem = (System.Web.UI.WebControls.Label)gvRow.FindControl("Label_gv_item_number");
            //    lebelItem.Text = idx.ToString();
            //    idx++;
            //}
            ddl_pagesize_gv.SelectedValue = "20";
            //gvResource.PageSize = 1;
            //seleted_amount.InnerText = "123";
        }

    }

    /// <summary>
    /// 文件上传
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_upload_Click(object sender, EventArgs e)
    {
        //try
        //{
        //取出所选文件的本地路径
        string fullFileName = this.FileUpload.PostedFile.FileName;
        //从路径中截取出文件名
        string fileName = fullFileName.Substring(fullFileName.LastIndexOf("\\") + 1);
        //限定上传文件的格式
        string type = fullFileName.Substring(fullFileName.LastIndexOf(".") + 1);
        if (type == "doc" || type == "docx" || type == "xls" || type == "xlsx" || type == "ppt" || type == "pptx" || type == "pdf" || type == "jpg" || type == "bmp" || type == "gif" || type == "png" || type == "txt" || type == "zip" || type == "rar")
        {
            //将文件保存在服务器中根目录下的files文件夹中
            string saveFileName = Server.MapPath("/files") + "\\" + fileName;
            FileUpload.PostedFile.SaveAs(saveFileName);
            ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('文件上传成功.');", true);
            SqlDataSource2.SelectCommand = "select * from FileInfo";
            gvResource.DataSourceID = SqlDataSource2.ID;
            gvResource.DataBind();

            //向数据库中存储相应通知的附件的目录
            BLL.news.InsertAnnexBLL insertAnnex = new BLL.news.InsertAnnexBLL();
            AnnexEntity annex = new AnnexEntity();     //创建附件的实体
            annex.Name = fileName;               //附件名
            insertAnnex.InsertAnnex(annex);         //将实体存入数据库（其实就是讲实体的这些属性insert到数据库中的过程，具体BLL层和DAL层的代码这里不再多说）
        }
        else
        {
            ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('请选择正确的格式.');", true);
        }
        //}
        //catch (Exception ex)
        //{
        //    string errorInfo = ex.Message.ToString();
        //    ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('上传失败.');", true);
        //}
    }

    /// <summary>
    /// 全选复选框
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox_gvall_CheckedChanged(object sender, EventArgs e)
    {

        int count = 0;
        System.Web.UI.WebControls.CheckBox ChkAll = (System.Web.UI.WebControls.CheckBox)sender;
        foreach (GridViewRow gvRow in gvResource.Rows)
        {
            System.Web.UI.WebControls.CheckBox chkItem = (System.Web.UI.WebControls.CheckBox)gvRow.FindControl("CheckBox_gv_item");
            chkItem.Checked = ChkAll.Checked;
            if (chkItem.Checked)
            {
                count++;
            }
        }
        seleted_amount.InnerText = count.ToString().Trim();
    }

    /// <summary>
    /// 文件下载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton2_Command(object sender, CommandEventArgs e)
    {

        string rootpath = Server.MapPath("../files/");
        // 定义文件名  
        string fileName = e.CommandArgument.ToString();
        // 获取文件在服务器的地址  
        string url = rootpath + fileName;

        // 判断传输地址是否为空  
        if (url == "")
        {
            // 提示“该文件暂不提供下载”  
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script defer>alert('该文件暂不提供下载！');</script>");
            return;
        }
        // 判断获取的是否为地址，而非文件名  
        if (url.IndexOf("\\") > -1)
        {
            // 获取文件名  
            fileName = url.Substring(url.LastIndexOf("\\") + 1);
        }
        else
        {
            // url为文件名时，直接获取文件名  
            fileName = url;
        }
        // 以字符流的方式下载文件  
        FileStream fileStream = new FileStream(@url, FileMode.Open);
        byte[] bytes = new byte[(int)fileStream.Length];
        fileStream.Read(bytes, 0, bytes.Length);
        fileStream.Close();
        Response.ContentType = "application/octet-stream";

        // 通知浏览器下载 
        Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }

    /// <summary>
    /// 文件浏览
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string filename = ((System.Web.UI.WebControls.LinkButton)sender).Text.Trim();
        string root_directory = Server.MapPath("../files/");
        //ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('" + root_directory + "')", true);

        //文件位置
        //string FilePath = (root_directory + "//files//dem01.doc");
        string FilePath = root_directory + filename;

        //指定转换后的pdf文件存储路径
        string savepath = System.Web.Hosting.HostingEnvironment.MapPath("/temporaryFiles/temp1" + ".pdf");

        //使用Asponse.word的方法进行转换
        Aspose.Words.Document doc = new Aspose.Words.Document(FilePath);
        doc.Save(savepath, Aspose.Words.SaveFormat.Pdf);
        //直接读取文件流到浏览器展示
        FileStream fs = new FileStream(savepath, FileMode.Open);
        byte[] buffer = new byte[fs.Length];
        fs.Seek(0, SeekOrigin.Begin);
        fs.Read(buffer, 0, buffer.Length);
        fs.Flush();
        fs.Close();
        string FileName = "../temporaryFiles/temp1.pdf";
        if (File.Exists(Server.MapPath(FileName)))
        {
            File.Delete(Server.MapPath(FileName));
        }

        //context.Response.ContentType = "application/PDF";
        //context.Response.BinaryWrite(buffer);
        //context.Response.Flush();
        //context.Response.End();
        Response.ContentType = "application/PDF";
        Response.BinaryWrite(buffer);
        Response.Flush();
        Response.End();
    }

    /// <summary>
    /// 已选个数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox_gv_item_CheckedChanged(object sender, EventArgs e)
    {
        int count = 0;
        foreach (GridViewRow gvRow in gvResource.Rows)
        {
            System.Web.UI.WebControls.CheckBox chkItem = (System.Web.UI.WebControls.CheckBox)gvRow.FindControl("CheckBox_gv_item");
            if (chkItem.Checked)
            {
                count++;
            }
        }
        seleted_amount.InnerText = count.ToString();
    }
}