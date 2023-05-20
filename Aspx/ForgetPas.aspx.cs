using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgetPas : System.Web.UI.Page
{
    Datacon dataconn = new Datacon();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void Btn_next_Click(object sender, EventArgs e)
    {
        SqlConnection con = dataconn.getcon();//连接数据库
        if (for_username.Value == string.Empty)
        {
            username_empty_hint.InnerText = "请输入用户名";
        }
        if (Vertify_hidd.Value == "false")
        {
            vertif_hint.InnerText = "滑动验证失败";
            vertif_hint.Style["color"] = "red";
        }
        if (for_username.Value != string.Empty && Vertify_hidd.Value != "false")
        {
            //try
            //{
            con.Open();//打开数据库
            string sql = "select * from LoginAccount where username = '" + for_username.Value+ "'";
            SqlCommand comm = new SqlCommand();
            comm.Connection = con;
            comm.CommandText = sql;
            int count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                safe_verti.Style["display"] = "none";
                modi_pas.Style["display"] = "block";
            }
            else
            {
                Response.Write("<script>alert('用户名输入错误')</script>");
            }

            //}
            //catch (Exception ex)
            //{
            //string errorInfo = ex.Message.ToString();
            //this.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script type='text/javascript'>alert('数据错误：" + errorInfo + "');</script>");

            //}
            //finally
            //{
            con.Close();
            //}
        }

    }

    protected void Btn_confirm_Click(object sender, EventArgs e)
    {
        modi_pas.Style["display"] = "none";
        modi_succ.Style["display"] = "block";
    }
}