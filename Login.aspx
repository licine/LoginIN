<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <title>登录页面</title>
    <link rel="stylesheet" href="assets/login_style.css" />
    <link rel="stylesheet" href="assets/iconfont/iconfont.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class='container' id='container'>
            <div class="form-container sign-in-container">
                <!-- 登陆 -->
                <div class="form">
                    <h1>用户登陆</h1>
                    <div class="social-container">
                        <a href="#" class="social"><i class="iconfont icon-qq"></i></a>
                        <a href="#" class="social"><i class="iconfont icon-weixin"></i></a>
                        <a href="#" class="social"><i class="iconfont icon-weibo-copy"></i></a>
                        <a href="#" class="social"><i class="iconfont icon-github"></i></a>
                    </div>
                    <span>您可以选择以上几种方式登陆您的账户!</span>
                    <input id="txtName" runat="server" type="text" placeholder="用户名" />
                    <input id="txtPwd" runat="server" type="password" placeholder="密码" />
                    <a href="Aspx/ForgetPas.aspx" target="_blank">忘记密码?</a>
                    <asp:Button ID="Btn_login" runat="server" CssClass="ghost btn_login" Text="登录" OnClick="Btn_login_Click" />
                </div>
            </div>
            <!-- 侧边栏内容 -->
            <div class="overlay-container">
                <div class="overlay">
                    <div class="overlay-panel overlay-left">
                        <h1>已有帐号？</h1>
                        <p>亲爱的快快点我去进行登陆吧。</p>
                        <button type="button" class='ghost' id="signIn">登陆</button>
                    </div>
                    <div class="overlay-panel overlay-right">
                        <h1>没有帐号？</h1>
                        <p>点击注册去注册一个属于你的账号吧。</p>
                        <button type="button" class='ghost' id="signUp">注册</button>
                    </div>
                </div>
            </div>
            <div class="form-container sign-up-container">
                <!-- 注册 -->
                <div class="form">
                    <h1>用户注册</h1>
                    <div class="social-container">
                        <a href="#" class="social"><i class="iconfont icon-qq"></i></a>
                        <a href="#" class="social"><i class="iconfont icon-weixin"></i></a>
                        <a href="#" class="social"><i class="iconfont icon-weibo-copy"></i></a>
                        <a href="#" class="social"><i class="iconfont icon-github"></i></a>
                    </div>
                    <span>您可以选择以上几种方式注册一个您的账户!</span>
                    <input runat="server" id="user_name" type="text" placeholder="用户名" />
                    <input runat="server" id="pas" type="password" placeholder="密码" />
                    <input runat="server" id="email" type="email" placeholder="邮箱" />
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel runat="server" Style="width: 100%;">
                        <ContentTemplate>
                            <asp:Button ID="send_code" CssClass="ghost" runat="server" type="button" Text="发送验证码" OnClick="send_code_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <input runat="server" id="vertifi_code" type="text" placeholder="验证码" />
                    <asp:UpdatePanel runat="server" Style="width: 100%; text-align: center;">
                        <ContentTemplate>
                            <asp:Button ID="Btn_login_up" CssClass="ghost" runat="server" Text="注册" OnClick="Btn_login_up_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
    <script src="Js/Login_index.js"></script>
</body>
</html>
