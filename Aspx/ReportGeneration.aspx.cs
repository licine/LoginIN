using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using Aspose.Words;
using Word = Microsoft.Office.Interop.Word;
public partial class Aspx_ReportGeneration : System.Web.UI.Page
{
    Datacon dataconn = new Datacon();  //定义数据库操作对象
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }

    /// <summary>
    /// word标签插入表格
    /// </summary>
    protected void table()
    {
        //Object table = "table";//插入表格，注意已打开word文档中标签的位置，因为word中插入表格是挤占原有的位置，并非换行再插入
        //Word.Range srange = bm.Range;
        //Word.Table ta = doc.Tables.Add(srange, 5, 5, ref nothing, ref nothing);
        //for (int i = 1; i <= 5; i++)
        //{
        //    for (int j = 1; j <= 5; j++)
        //    {
        //        ta.Cell(i, j).Range.Text = "第" + i + "行" + "第" + j + "列";
        //    }
        //}
    }

    /// <summary>
    /// 生成成绩单word文档
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Btn_create_word_Click(object sender, EventArgs e)
    {
        //Word._Application app = new Microsoft.Office.Interop.Word.ApplicationClass();//注意如果添加的是Office2010引用，是Word._Application，不是Word.Application，调用的是接口
        //Word._Document doc = null;
        //Object nothing = System.Reflection.Missing.Value;//Word中的null非C#中的null，得装换
        //string rootpath = Server.MapPath("../files/");
        //Object filename = Server.MapPath("../files/Template.docx");//服务器中要打开的文档
        //doc = app.Documents.Open(ref filename, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);
        bool flag = true;
        foreach (GridViewRow gvRow in GridView_report.Rows)
        {
            System.Web.UI.WebControls.CheckBox cbSel = (System.Web.UI.WebControls.CheckBox)gvRow.FindControl("CheckBox_gv_item");
            if (cbSel.Checked)
            {
                flag = false;
                string name = gvRow.Cells[2].Text.ToString().Trim();
                string datastructure_score = gvRow.Cells[4].Text.ToString().Trim();
                string c_score = gvRow.Cells[5].Text.ToString().Trim();
                string java_score = gvRow.Cells[6].Text.ToString().Trim();
                string linux_score = gvRow.Cells[7].Text.ToString().Trim();
                Word._Application app = new Microsoft.Office.Interop.Word.ApplicationClass();//注意如果添加的是Office2010引用，是Word._Application，不是Word.Application，调用的是接口
                Word._Document doc = null;
                Object nothing = System.Reflection.Missing.Value;//Word中的null非C#中的null，得装换
                string rootpath = Server.MapPath("../files/");
                Object filename = Server.MapPath("../files/Template.docx");//服务器中要打开的文档
                doc = app.Documents.Open(ref filename, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);
                foreach (Word.Bookmark bm in doc.Bookmarks)//遍历已经打开的Word文档中的标签，插入我们的数据
                {
                    if (bm.Name == "name")
                    {
                        bm.Range.Text = name;
                    }
                    if (bm.Name == "数据结构_score")
                    {

                        bm.Range.Text = datastructure_score;

                    }
                    if (bm.Name == "c_score")
                    {
                        bm.Range.Text = c_score;
                    }
                    if (bm.Name == "java_score")
                    {
                        bm.Range.Text = java_score;
                    }
                    if (bm.Name == "linux_score")
                    {
                        bm.Range.Text = linux_score;
                    }
                }
                //ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('文件生成成功.');", true);
                //关闭word，程序最好try...catch一下，因为IO流操作，如果程序出错，数据就会写到已经打开的word文档中，不会导出新的文档 
                //Directory.CreateDirectory("C:/CNSI"); //创建文件所在目录
                filename = Server.MapPath("../files/report_card.docx");
                doc.SaveAs(ref filename, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);
                doc.Close(ref nothing, ref nothing, ref nothing);
                app.Quit(ref nothing, ref nothing, ref nothing);
                string filepath = rootpath + "report_card.docx";
                Download_report(filepath);
                //Response.Write("< script language=javascript>mainnav.location.reload(true); < /script>");
            }

        }
        if (flag)
        {
            Response.Write("<script>alert('请选择学生！')</script>");
        }
        //doc.Close(ref nothing, ref nothing, ref nothing);
        //app.Quit(ref nothing, ref nothing, ref nothing);

        //foreach (Word.Bookmark bm in doc.Bookmarks)//遍历已经打开的Word文档中的标签，插入我们的数据
        //{
        //    if (bm.Name == "name")
        //    {
        //        bm.Range.Text = "一一";
        //    }
        //    if (bm.Name == "数据结构_score")
        //    {

        //        bm.Range.Text = "99";

        //    }
        //    if (bm.Name == "c_score")
        //    {
        //        bm.Range.Text = "99";
        //    }
        //    if (bm.Name == "java_score")
        //    {
        //        bm.Range.Text = "99";
        //    }
        //    if (bm.Name == "linux_score")
        //    {
        //        bm.Range.Text = "99";
        //    }
        //}
        ////ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('文件生成成功.');", true);
        ////关闭word，程序最好try...catch一下，因为IO流操作，如果程序出错，数据就会写到已经打开的word文档中，不会导出新的文档 
        ////Directory.CreateDirectory("C:/CNSI"); //创建文件所在目录
        //filename = Server.MapPath("../files/report_card.docx");
        //doc.SaveAs(ref filename, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);
        //doc.Close(ref nothing, ref nothing, ref nothing);
        //app.Quit(ref nothing, ref nothing, ref nothing);
        //string filepath = rootpath + "report_card.docx";
        //Download_report(filepath);
        //string FileName = "../files/report_card.docx";
        //if (File.Exists(Server.MapPath(FileName)))
        //{
        //    File.Delete(Server.MapPath(FileName));
        //}
    }

    /// <summary>
    /// 成绩单下载
    /// </summary>
    /// <param name="filepath"></param>
    protected void Download_report(string filepath)
    {
        // 获取文件在服务器的地址  
        string url = filepath;
        string fileName;
        fileName = url.Substring(url.LastIndexOf("\\") + 1);


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
        //string FileName = "../files/report_card.docx";
        //if (File.Exists(Server.MapPath(FileName)))
        //{
        //    File.Delete(Server.MapPath(FileName));
        //}
    }

    /// <summary>
    /// 全选复选框
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox_gvall_CheckedChanged(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.CheckBox ChkAll = (System.Web.UI.WebControls.CheckBox)sender;
        foreach (GridViewRow gvRow in GridView_report.Rows)
        {
            //CheckBox cbSel = (CheckBox)gvRow.FindControl("CheckBox_gv_item");
            //if (cbSel.Checked)
            //string text=gvRow.Cells[1].Text;
            System.Web.UI.WebControls.CheckBox chkItem = (System.Web.UI.WebControls.CheckBox)gvRow.FindControl("CheckBox_gv_item");
            chkItem.Checked = ChkAll.Checked;
        }
    }

    protected void card_Click(object sender, EventArgs e)
    {
        bool flag = true;
        foreach (GridViewRow gvRow in GridView_report.Rows)
        {
            System.Web.UI.WebControls.CheckBox cbSel = (System.Web.UI.WebControls.CheckBox)gvRow.FindControl("CheckBox_gv_item");
            if (cbSel.Checked)
            {
                flag = false;
                string name = gvRow.Cells[2].Text.ToString().Trim();
                string datastructure_score = gvRow.Cells[4].Text.ToString().Trim();
                string c_score = gvRow.Cells[5].Text.ToString().Trim();
                string java_score = gvRow.Cells[6].Text.ToString().Trim();
                string linux_score = gvRow.Cells[7].Text.ToString().Trim();
                Word._Application app = new Microsoft.Office.Interop.Word.ApplicationClass();//注意如果添加的是Office2010引用，是Word._Application，不是Word.Application，调用的是接口
                Word._Document doc = null;
                Object nothing = System.Reflection.Missing.Value;//Word中的null非C#中的null，得装换
                string rootpath = Server.MapPath("../files/");
                Object filename = Server.MapPath("../files/cardtemp.docx");//服务器中要打开的文档
                doc = app.Documents.Open(ref filename, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);
                foreach (Word.Bookmark bm in doc.Bookmarks)//遍历已经打开的Word文档中的标签，插入我们的数据
                {
                    if (bm.Name == "name")
                    {
                        bm.Range.Text = name;
                    }
                }
                //ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('文件生成成功.');", true);
                //关闭word，程序最好try...catch一下，因为IO流操作，如果程序出错，数据就会写到已经打开的word文档中，不会导出新的文档 
                //Directory.CreateDirectory("C:/CNSI"); //创建文件所在目录
                filename = Server.MapPath("../files/card.docx");
                doc.SaveAs(ref filename, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing, ref nothing);
                doc.Close(ref nothing, ref nothing, ref nothing);
                app.Quit(ref nothing, ref nothing, ref nothing);
                string filepath = rootpath + "card.docx";
                Download_report(filepath);
                //Response.Write("< script language=javascript>mainnav.location.reload(true); < /script>");
            }

        }
        if (flag)
        {
            Response.Write("<script>alert('请选择学生！')</script>");
        }
    }
}