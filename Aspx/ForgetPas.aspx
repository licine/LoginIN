<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgetPas.aspx.cs" Inherits="ForgetPas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <%--<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>--%>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!-- 最新版本的 Bootstrap 核心 CSS 文件 -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../assets/forgot_validate_drge.css" />
    <title>密码管理</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="for_container">
            <input id="Vertify_hidd" type="hidden" runat="server" value=""/>
            <%--头部--%>
            <div id="header">
                <span class="text_forgetpas">重置密码</span>
                <a class="text_nav" href="../Login.aspx">登录/注册</a>
            </div>
            <%--内容--%>
            <div id="content">
                <%--安全验证--%>
                <div id="safe_verti" runat="server" class="container_safe">
                    <p class="info_text">请输入你需要找回登录密码的用户名</p>
                    <div class="username_container">
                        <span class="text username">用户名：</span>
                        <input id="for_username" runat="server" class="input_text" type="text" placeholder="用户名" />
                        <div id="username_empty_hint" runat="server"></div>
                    </div>                    
                    <p id="vertif_hint" class="info_text2" runat="server">为了您的账户安全，请进行安全校验</p>
                    <div id="dragContainer">
                        <!-- 容器初始背景 -->
                        <div id="dragBg"></div>
                        <!-- 绿色背景 -->
                        <div id="dragText"></div>
                        <!-- 滑块容器文字 -->
                        <div id="dragHandler" class="dragHandlerBg"></div>
                    </div><!-- 滑块  滑块初始化背景-->
                    <br/>
                    <asp:Button ID="Btn_next" runat="server" CssClass="confirm first" Text="确定" OnClick="Btn_next_Click" />
                </div>
                <%--修改密码--%>
                <div id="modi_pas" runat="server" class="update_pas_container">
                    <div class="">
                        <span class="text">用户名：</span>
                        <input type="text" class="text_default" placeholder="用户名" />
                    </div>
                    <br/>
                    <div class="update_pas">
                        <span class="text">邮箱：</span>
                        <input type="email" class="text_default" placeholder="邮箱" />
                    </div>
                    <br/>      
                    <div class="">
                        <span class="text">验证码：</span>
                        <input type="text" placeholder="验证码" />
                        <asp:Button ID="Button1" runat="server" CssClass="confirm" Text="获取验证码" />
                    </div>
                    <br/>
                    <div class="update_pas">
                        <span class="text">新的密码：</span>
                        <input type="password" placeholder="密码" />
                    </div>
                    <br/>
                    <div class="update_pas">
                        <span class="text">确认新的密码：</span>
                        <input type="password" placeholder="确认密码" />
                    </div>
                    <br/>
                    <div class="">
                        <asp:Button ID="Btn_confirm" runat="server" CssClass="confirm" Text="确认" OnClick="Btn_confirm_Click" />
                    </div>
                </div>
                <%--修改成功--%>
                <div id="modi_succ" runat="server" class="update_success">
                    <div class="forgot_image">
                        <img class="img" src="../Images/right.png"/>
                    </div>
                    <div class="txtcontainer">
                        <p>重置成功，请牢记新的登陆密码</p>
                    </div>
                    <div class="relogin">
                        <a class="lasta" href="../Login.aspx">重新登录</a>
                    </div>
                </div>

            </div>
        </div>
    </form>
    <script src="../Js/forget_validate_drge.js"></script>
</body>
</html>
