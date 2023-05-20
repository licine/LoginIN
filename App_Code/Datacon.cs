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

/// <summary>
/// Class1 的摘要说明
/// </summary>
public class Datacon: System.Web.UI.Page
{
    public Datacon()
	{
    }
    //==================数据库连接===========================
    public SqlConnection getcon()
    {
        string strCon = "Data Source=localhost;Initial Catalog=test01;User ID=sa;PWD=123456;Persist Security Info=True";
        SqlConnection sqlCon = new SqlConnection(strCon);
        return sqlCon;
    }

    public bool eccom(string sqlstr1)
    {
        SqlConnection con = this.getcon();
        con.Open();
        SqlCommand mycommand = new SqlCommand(sqlstr1, con);
        try
        {
            mycommand.ExecuteNonQuery();
            return true;
        }
        catch
        {
            return false;
        }
        finally
        {
            con.Close();
        }
    }
}
