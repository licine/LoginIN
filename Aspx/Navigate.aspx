<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Navigate.aspx.cs" Inherits="Aspx_Navigate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" href="../assets/Navigate.css" />
    <title></title>
    <style>
        html, body {
            height: 100%;
        }

        #username {
            font-family: "Microsoft Yahei UI","Microsoft Yahei",Verdana,Simsun,"Segoe UI","Segoe UI Web Regular","Segoe UI Symbol","Helvetica Neue","BBAlpha Sans","S60 Sans",Arial,sans-serif;
            font-size: 13px;
            padding-left: 12px;
            padding-right: .8rem;
            padding-top:1rem;
        }

        .username_container {
            position: absolute;
            top: -0.5rem;
            right: 10rem;
            display: flex;
            flex-direction:row;
            justify-content: center;
            align-items: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <nav class="nav_container">
            <img src="https://webgradients.com/img/other/logos/itmeo_logo.png" style="width: 5rem; margin-right: 5rem;" />
            <a href="DatabaseImEx.aspx" target="mainnav">数据导入/导出</a>
            <a href="FileUpDownload.aspx" target="mainnav">文件上传/下载</a>
            <a href="ReportGeneration.aspx" target="mainnav">成绩单生成</a>
            <a href="ReportGeneration.aspx" target="mainnav">贺年卡生成</a>
            <div class="username_container">
                <span id="username" runat="server"></span>
                <img src="../Images/account.png" style="width: 1.5rem; padding-top: 1rem;" />
            </div>
        </nav>


    </form>
</body>
</html>
