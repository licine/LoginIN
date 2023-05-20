using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

public class AnnexEntity
{
    public static int i = 0;
 
    public string Name { get; set; }
    public string date_changed { get; set; }
    public string file_type { get; set; }
    public string size { get; set; }

    static Datacon dataconn = new Datacon();


    /// <summary>
    /// 向数据库中存储文件
    /// </summary>
    /// <param name="AnnexID"></param>
    /// <param name="AnnexName"></param>
    /// <param name="AnnexContent"></param>
    /// <param name="NoticeId"></param>
    /// <returns></returns>
    public static int InsertAnnex(string Name)
    {
        SqlConnection con = dataconn.getcon();//连接数据库
        
        con.Open();//打开数据库
        string sql = "insert into FileInfo values('" + Name.ToString() + "','2022/11/11','word文档','54KB')";
        SqlCommand comm = new SqlCommand();
        comm.Connection = con;
        comm.CommandText = sql;
        int num = comm.ExecuteNonQuery();    
        con.Close();
        return num;
    }

}