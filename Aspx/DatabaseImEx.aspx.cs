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
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

public partial class Aspx_DatabaseImEx : System.Web.UI.Page
{
    Datacon dataconn = new Datacon();  //定义数据库操作对象
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

        }
    }

    /// <summary>
    /// 导入数据库
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btn_indatabase_Click(object sender, EventArgs e)
    {

        //try
        //{

        System.Data.DataTable dt = Xsldata();
        if (dt == null)
        {
            return;
        }

        int errorcount = 0;//记录错误信息条数
        int insertcount = 0;//记录插入成功条数

        int updatecount = 0;//记录更新信息条数

        SqlConnection conn = dataconn.getcon();//链接数据库
        conn.Open();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            string Snumber = dt.Rows[i][0].ToString();//dt.Rows[i]["Name"].ToString(); "Name"即为Excel中Name列的表头
            string Sname = dt.Rows[i][1].ToString();
            string Sclass = dt.Rows[i][2].ToString();
            if (Snumber != "" && Sname != "" && Sclass != "")
            {
                SqlCommand selectcmd = new SqlCommand("select count(*) from Student where Snumber='" + Snumber + "' and Sname='" + Sname + "' and Sclass='" + Sclass + "'", conn);
                int count = Convert.ToInt32(selectcmd.ExecuteScalar());
                if (count > 0)
                {
                    updatecount++;
                }
                else
                {
                    SqlCommand insertcmd = new SqlCommand("insert into Student(Snumber,Sname,Sclass) values('" + Snumber + "','" + Sname + "','" + Sclass + "')", conn);
                    insertcmd.ExecuteNonQuery();
                    insertcount++;
                }
            }
            else
            {
                errorcount++;
            }
        }
        SqlDataSource1.SelectCommand = "select * from Student";
        GridView_student.DataSourceID = SqlDataSource1.ID;
        GridView_student.DataBind();
        ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('" + insertcount + "条数据导入成功!" + updatecount + "条数据重复！" + errorcount + "条数据部分信息为空没有导入！" + " ');", true);

        //}
        //catch (Exception ex)
        //{
        //    string errorInfo = ex.Message.ToString();
        //    ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('数据错误：" + errorInfo + "');", true);
        //    //this.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script type='text/javascript'>alert('数据错误：" + errorInfo + "');</script>");
        //}
    }


    /// <summary>
    /// DataTable函数
    /// </summary>
    private System.Data.DataTable Xsldata()
    {
        if (FileUpload.FileName == "")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('请选择文件');", true);
            //this.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script type='text/javascript'>alert('请选择文件');</script>");
            return null;
        }
        string fileExtenSion;
        fileExtenSion = Path.GetExtension(FileUpload.FileName);
        if (fileExtenSion.ToLower() != ".xls" && fileExtenSion.ToLower() != ".xlsx")
        {
            ScriptManager.RegisterStartupScript(Page, typeof(System.Web.UI.Page), "hint", "alert('上传的文件格式不正确');", true);
            //this.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script type='text/javascript'>alert('上传的文件格式不正确');</script>");
            return null;
        }
        //try
        //{
        string FileName = "../files/" + Path.GetFileName(FileUpload.FileName);
        if (File.Exists(Server.MapPath(FileName)))
        {
            File.Delete(Server.MapPath(FileName));
        }
        FileUpload.SaveAs(Server.MapPath(FileName));
        //HDR=Yes，这代表第一行是标题，不做为数据使用 ，如果用HDR=NO，则表示第一行不是标题，做为数据来使用。系统默认的是YES
        string connstr2003 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath(FileName) + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
        string connstr2007 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Server.MapPath(FileName) + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
        OleDbConnection conn;
        if (fileExtenSion.ToLower() == ".xls")
        {
            conn = new OleDbConnection(connstr2003);
        }
        else
        {
            conn = new OleDbConnection(connstr2007);
        }
        conn.Open();
        string sql = "select * from [Sheet1$]";
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        System.Data.DataTable dt = new System.Data.DataTable();
        OleDbDataReader sdr = cmd.ExecuteReader();

        dt.Load(sdr);
        sdr.Close();
        conn.Close();
        //删除服务器里上传的文件
        if (File.Exists(Server.MapPath(FileName)))
        {
            File.Delete(Server.MapPath(FileName));
        }
        return dt;
        //}
        //catch (Exception e)
        //{
        //    return null;
        //}
    }


    /// <summary>
    /// 导出到excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnOutExcel_Click(object sender, EventArgs e)
    {
        DataSet ds = PutInDataSet();
        SaveAsExcel(ds);
    }


    /// <summary>
    /// put data source into dataset
    /// </summary>
    /// <returns>DataSet</returns>
    private static DataSet PutInDataSet()
    {
        string connStr = @"Data Source=localhost;Initial Catalog=test01;User ID=sa;PWD=s;Persist Security Info=True";
        string queryStr = @"SELECT * FROM Student";
        SqlConnection con = new SqlConnection(connStr);
        SqlDataAdapter adapter = new SqlDataAdapter(queryStr, connStr);
        DataSet ds = new DataSet();
        adapter.Fill(ds);
        return ds;
    }


    /// <summary>
    /// save the data as excel file
    /// </summary>
    /// <param name="ds"></param>
    private void SaveAsExcel(DataSet ds)
    {
        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
        if (excelApp != null)
        {
            Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Add(Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//get the sheet index          
            for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
            {
                for (int col = 0; col < ds.Tables[0].Columns.Count; col++)
                {
                    worksheet.Cells[row + 2, col + 1] = ds.Tables[0].Rows[row][col];
                }
            }
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            //worksheet = null;
            //workbook.Close(false, Type.Missing, Type.Missing);
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            //workbook = null;
            //workbook.Close();
            //System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            //workbook = null;
        }
        else
        {
        }

        excelApp.Quit();

        //System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        //excelApp = null;
        //GC.Collect();
        //GC.WaitForPendingFinalizers();
    }


    /// <summary>
    /// 全选复选框
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void CheckBox_gvall_CheckedChanged(object sender, EventArgs e)
    {
        System.Web.UI.WebControls.CheckBox ChkAll = (System.Web.UI.WebControls.CheckBox)sender;
        foreach (GridViewRow gvRow in GridView_student.Rows)
        {
            System.Web.UI.WebControls.CheckBox chkItem = (System.Web.UI.WebControls.CheckBox)gvRow.FindControl("CheckBox_gv_item");
            chkItem.Checked = ChkAll.Checked;
        }
    }
}