<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="IE=edge" http-equiv="X-UA-Compatible">
    <META http-equiv="content-type" content="text/html; charset=gb2312">
    <title>财政辅助决策系统-登录</title>
     <link href="CSS/login.css" rel="stylesheet" />
    <link href="lib/ligerUI/skins/ext/css/ligerui-dialog.css" rel="stylesheet" />
    <script src="lib/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="lib/ligerUI/js/plugins/ligerDialog.js" type="text/javascript"></script>
    <script src="JS/jquery.md5.js" type="text/javascript"></script>
    <script src="JS/Garfield.js" type="text/javascript"></script>
    <script src="JS/login.js" type="text/javascript"></script>
   
    <script type="text/javascript">
        if (top.location != self.location) top.location = self.location;
    </script>
</head>
<body style="overflow:hidden">
        <div class="pagewrap">
        <div class="main">
            <div class="header"></div>
            <div class="content">
            <!--<div class="con_left"></div>-->
            <div class="con_right">
                    <div class="con_r_top">
					<a href="javascript:;" class="left" style="color: rgb(51, 51, 51); border-bottom: 2px solid rgb(46, 85, 142);">用户登录</a>
					<a href="javascript:;" class="right" style="color: rgb(153, 153, 153); border-bottom: 2px solid rgb(222, 222, 222);">扫码登录</a>
					</div>
                    <ul>
                        <li class="con_r_left" style="display: block;">
                        <div class="user">
                        <div><span class="user-icon"></span>
                            <input type="text" id="T_uid" name="T_uid" placeholder="　输入账号" value="">
					    </div>

                        <div><span class="mima-icon"></span>
                            <input type="password" id="T_pwd" name="T_pwd" placeholder="　输入密码" value="">
					    </div>
						
						<div><span class="yzmz-icon"></span>
                            <input id="T_validate" type="text" name="T_validate" placeholder="　验证码" value="" style=" width:150px;">　　
							<img id="validate" onclick="this.src=this.src+'?'" src="ValidateCode.aspx" style="cursor: pointer; border: 1px solid #ddd" alt="看不清楚，换一张" title="看不清楚，换一张" />
                        </div>						
						                                
                   </div><br>
                        <button id="login" type="button">登 录</button>
                        </li>
                        <li class="con_r_right" style="display: none;">
                            <div class="erweima">
                                <div class="qrcode">
                                    <div id="output" style="width: 100%; position: relative">
                                        <img src="../Reports/img/2weima.jpg" style="width: 174px; height: 174px"></div>                                    
                                </div>
                             </div>
                            <div style="height: 70px">
                                <p>微信扫码 安全便捷</p>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
