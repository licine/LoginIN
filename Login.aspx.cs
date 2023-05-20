using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    //产生0到100000的随机数
    static Random Rdm = new Random();
    static int iRdm = Rdm.Next(0000, 99999);
    Datacon dataconn = new Datacon();
    static string Email_address;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Btn_login.Focus();
        }
    }

    [Obsolete]
    protected void Btn_login_Click(object sender, EventArgs e)
    {
        string name = txtName.Value.ToString().Trim();
        string pwd = txtPwd.Value.ToString().Trim();
        string pwdd = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd, "MD5");
        SqlConnection con = dataconn.getcon();//连接数据库
        con.Open();//打开数据库
        SqlCommand com = con.CreateCommand();
        com.CommandText = "select count(*) from LoginAccount where username='" + name + "' and pas='" + pwdd + "'";
        int count = Convert.ToInt32(com.ExecuteScalar());
        //对照配置文件来验证密码是否正确，正确返回true 错误返回false
        if (FormsAuthentication.Authenticate(name, pwd) || count > 0)
        {
            //把请求当前Login.aspx 重定向到最初的请求资源（是否长久保存cookie）
            this.Session["username"] = name;
            this.Session.Timeout = 144000;
            FormsAuthentication.RedirectFromLoginPage(name, false);
        }

        //密码不正确
        else
        {
            Response.Write("<script>alert('帐号或密码不正确！')</script>");
        }
        //string pwdd = "111";
        //////将加密后的密码输出(加密方式MD5或者SHA1)
        //Response.Write("<script>alert('"+FormsAuthentication.HashPasswordForStoringInConfigFile(pwdd, "MD5")+"')</script>");
    }

    /// <summary>
    /// 发送验证码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void send_code_Click(object sender, EventArgs e)
    {
        if (email.Value == string.Empty)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "hint", "alert('请输入邮箱');", true);
        }
        else
        {
            Email_address = email.Value;
            SmtpClient client = new SmtpClient("smtp.qq.com", 587);
            MailMessage msg = new MailMessage("884870328@qq.com", Email_address, "验证码", iRdm.ToString());
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential basicAuthenticationInfo =
                new System.Net.NetworkCredential("884870328@qq.com", "sjrgbavcpympbaih");
            client.Credentials = basicAuthenticationInfo;
            client.EnableSsl = true;
            client.Send(msg);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "hint", "alert('发送成功.');", true);
        }
    }


    /// <summary>
    /// 注册
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    [Obsolete]
    protected void Btn_login_up_Click(object sender, EventArgs e)
    {
        if (user_name.Value == string.Empty)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "hint", "alert('请输入用户名');", true);
        }
        else if (pas.Value == string.Empty)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "hint", "alert('请输入密码');", true);
        }
        else if (email.Value == string.Empty)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "hint", "alert('请输入邮箱');", true);
        }
        else if (vertifi_code.Value == string.Empty)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "hint", "alert('请输入验证码');", true);
        }
        else if (vertifi_code.Value != iRdm.ToString())
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "hint", "alert('验证码错误，请重新输入验证码');", true);
        }
        else
        {
            SqlConnection con = dataconn.getcon();//连接数据库
            String pass=FormsAuthentication.HashPasswordForStoringInConfigFile(pas.Value, "MD5");
            try
            {
                con.Open();//打开数据库
                string sql = "insert into LoginAccount values('" + user_name.Value + "','" + pass + "','" + email.Value + "')";
                SqlCommand comm = new SqlCommand();
                comm.Connection = con;
                comm.CommandText = sql;
                int num = comm.ExecuteNonQuery();
                if (num == 1)
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "hint", "alert('注册成功,快快去登录吧.');window.location.href= 'Login.aspx';", true);
                }

            }
            catch (Exception ex)
            {
                string errorInfo = ex.Message.ToString();
                this.ClientScript.RegisterStartupScript(this.GetType(), "script", "<script type='text/javascript'>alert('数据错误：" + errorInfo + "');</script>");

            }
            finally
            {
                con.Close();
            }
        }

    }
}