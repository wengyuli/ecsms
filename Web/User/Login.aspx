<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Agent_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html;charset=gb2312" />
	<title>商信宝平台--你的得力助手</title>
	<meta content="商信宝商务短信，郑州短信平台，郑州短信群发，郑州短信群发软件，郑州短信群发公司，郑州短信群发业务，郑州短信群发软件" name="keywords">
	<meta content="企业短信群发首选品牌,移动联通电信直连网关，内嵌CRM客户管理系统，5年稳定运行已服务上万家企业，无使用期限，欢迎免费试用！0371-66222261。name="description">
	<meta name="robots" content="index, follow" />
	<meta name="googlebot" content="index, follow" />
	
	<link href="css/style_100106.css" rel="stylesheet" type="text/css" />
	
<script type="text/javascript">
<!--
    var gIEVersion = ""; //浏览器名字
    var gVersionNum = 0; //浏览器版本号
    
    function checklogin() {
        if (document.getElementById("iptUser").value == "") {
            document.getElementById("error_div").innerHTML = "请输入您的用户名";
            document.getElementById("iptUser").focus();
            return false;
        }
        if (document.getElementById("iptPwd").value == "") {
            document.getElementById("error_div").innerHTML = "请输入您的密码";
            document.getElementById("iptPwd").focus();
            return false;
        }
    }
    
    
    function fCheck() {
        var bOk = false;
        var s = "";
        var fm = document.form;
        s = fm.style.value;

        fm.user.value = fTrim(fm.user.value); //Trim the input value.
        if (!fCheckCookie()) {
            return false;
        }
        if (fm.user.value == "") {
            document.getElementById("error_div").innerHTML = "请输入你的用户名";
            fm.user.focus();
            return false;
        }

        if (fm.password.value.length == "") {
            document.getElementById("error_div").innerHTML = "请输入你的密码";
            fm.password.focus();
            return false;
        }
    }

    function fTrim(str) {
        return str.replace(/(^\s*)|(\s*$)/g, "");
    }

    function fGetIEVersion() {
        var IEAppName = window.navigator.appName; 					//得到当前浏览器的名.
        var IEversion = window.navigator.appVersion; 				//得到当前浏览器的版本说明
        if (IEAppName.indexOf("Microsoft") < 0) {
            gIEVersion = IEAppName;
            return 0;
        }
        var isOpera = window.navigator.userAgent.indexOf("Opera") > -1;
        if (isOpera) {
            gIEVersion = "Opera";
            return 0;
        }

        var k = IEversion.indexOf("MSIE"); 				//查找IE的版本号
        if (k >= 0) {
            k += 4;
            var j = IEversion.indexOf(";", k);
            if (j < 0) {
                j = IEversion.length - 1;
            }
            IEversion = IEversion.substring(k, j) * 1; 			//得到IE的版本号，并且数字化
            gIEVersion = "MSIE: " + IEversion;
            if (IEversion >= 6) {										//如果版本号6.0以上，
                return 6;
            } else if (IEversion >= 5.5 && IEversion < 6) {
                return 5.5;
            } else if (IEversion >= 5 && IEversion < 5.5) {
                return 5;
            }
            else {
                return 0;
            }
        } else {
            gIEVersion = window.navigator.appVersion;
            return 0;
        }
    }
    gVersionNum = fGetIEVersion();

    function Cookie(document, name, domain) {
        this.$document = document;
        this.$name = name;
        this.$expiration = new Date(2099, 12, 31);
        this.$domain = domain;
        this.data = null;
    }
    Cookie.prototype.store = function() {
        var cookieval = "";
        if (this.data != null) {
            for (var i = 0; i < this.data.length; i++) {
                cookieval += this.data[i].join(":") + "&";
            }
        }
        if (cookieval != "" && cookieval.charAt(cookieval.length - 1) == "&")
            cookieval = cookieval.substring(0, cookieval.length - 1);
        var cookie = this.$name + "=" + cookieval + ";expires=" + this.$expiration.toGMTString() + ";domain=" + this.$domain;
        window.document.cookie = cookie;
        var cookie = "NETEASE_SSN=" + document.getElementsByName("user")[0].value + ";expires=" + this.$expiration.toGMTString() + ";domain=" + this.$domain;
        window.document.cookie = cookie;
    }
    Cookie.prototype.load = function() {
        var allcookies = this.$document.cookie;
        if (allcookies == "") return false;
        var start = allcookies.indexOf(this.$name + "=");
        if (start == -1) return false;
        start += this.$name.length + 1;
        var end = allcookies.indexOf(";", start);
        if (end == -1) end = allcookies.length;
        var cookieval = allcookies.substring(start, end);
        var a = cookieval.split("&");
        for (var i = 0; i < a.length; i++)
            a[i] = a[i].split(':');
        //用户名:风格:安全
        this.data = a;
        return true;
    }
    Cookie.prototype.setVals = function(a, flag) {
        if (this.data == null) {
            if (flag) {
                this.data = [];
                this.data[0] = a;
            }
        }
        else {
            this.data[0][0] = a[0];
            if (flag)
                return;
            else
                this.data = null;
        }
    }


    //*** For Login UserName.
    function fInitUser() {
        var fm = window.document.form;
        var name = "";
        if (visitordata.data != null) {
            name = visitordata.data[0][0];
            //fm.remUser.checked = true;
            fm.autocomplete = "on";
        } else {
            fm.autocomplete = "off";
            //fm.remUser.checked = getCookie("ntes_mail_noremember")!="true";
        }


        if (name != "") {
            fm.user.value = name;
            fm.password.focus();
        } else {
            fm.user.focus();
        }
    }
    function fCheckCookie() {
        var secure = document.getElementsByName("secure");
        var cookieEnabled = (navigator.cookieEnabled) ? true : false;
        if (typeof navigator.cookieEnabled == "undefined" && !cookieEnabled) {
            document.cookie = "testcookie";
            cookieEnabled = (document.cookie == "testcookie") ? true : false;
            document.cookie = "";
        }
        if (secure.length > 0) {
            if (secure[0].checked && !cookieEnabled) {
                window.alert("您好，您的浏览器设置禁止使用cookie。您登录邮箱时选中了“增强安全性”选项，该选项要求浏览器启用cookie设置。\n\n您可以选择以下的其中一个方法登录邮箱:\n1:设置您的浏览器，启用cookie设置，再重新登录。\n2:或者登录时取消选中“增强安全性”选项，但是您的登录安全性将会降低。");
                return false;
            }
        }
        return true;
    }
    function fSetLogType() {
        var logType = getCookie("logType");
        var login_select = document.getElementById("login_select");
        if (logType == "dm" || logType == "dm3") {
            login_select.selectedIndex = 1;
        } else if (logType == "js3") {
            login_select.selectedIndex = 2;
        } else if (logType == "jy" || logType == "jy3") {
            login_select.selectedIndex = 3;
        } else {
            login_select.selectedIndex = 0;
        }
    }
    function getCookie(name) {
        var search = name + "="
        if (document.cookie.length > 0) {
            offset = document.cookie.indexOf(search)
            if (offset != -1) {
                offset += search.length
                end = document.cookie.indexOf(";", offset)
                if (end == -1) end = document.cookie.length
                return unescape(document.cookie.substring(offset, end))
            }
            else return ""
        }
    }
    function saveLoginType() {
        var login_select = document.getElementById("login_select");
        var sType = "";
        switch (login_select.selectedIndex) {
            case 0:
                sType = "df";
                break;
            case 1:
                sType = "dm3";
                break;
            case 2:
                sType = "js3";
                break;
            case 3:
                sType = "jy3";
                break;
            default:
                sType = "dm3";
        }
        document.cookie = "logType=" + sType + ";expires=" + (new Date(2099, 12, 31)).toGMTString() + ";domain=126.com";
    }
    var gAppName, gVersion;
    function fVoidIE5() {
        fGetUserAgen();
        if (gAppName == "msie" && gVersion < 6) {
            var obj = document.getElementById("secure");
            obj.checked = false;
            obj.disabled = true;
        }
    }
    function fGetUserAgen() {
        var sUserAgent = window.navigator.userAgent;
        var sAppName = "";
        var sVersion = "";
        if (sUserAgent.indexOf("MSIE") > -1) {
            sAppName = "msie";
            sVersion = sUserAgent.replace(/.+MSIE/gi, "").replace(/;.+/gi, "") - 0;
        } else if (sUserAgent.toUpperCase().indexOf("FIREFOX") > -1) {
            sAppName = "firefox";
            sVersion = sUserAgent.replace(/.+Firefox\//gi, "").replace(/\(.*\)/g, "") - 0;
        } else if (sUserAgent.toUpperCase().indexOf("NETSCAPE") > -1) {
            sAppName = "netscape";
            sVersion = sUserAgent.replace(/.+NETSCAPE\//gi, "").replace(/\(.*\)/g, "") - 0;
        }
        gAppName = sAppName; // 浏览器类型
        gVersion = sVersion; // 版本号
    } 
    function $(id) { return document.getElementById(id);}
    


 

 
 
//-->
</SCRIPT>
</head>
<body style=" margin:0px 0px 0px 0px; font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server" >
    <div class="page" id="divPage">
	<div class="head">
		<a href="javascript:;" title="设置商信宝为浏览器首页" onClick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.ecsms.com.cn');">设为主页</a> | <a href="http://www.chinamobile.com" target="_blank">中国移动</a> | <a href="http://www.chinaunicom.com.cn" target="_blank">中国联通</a> | <a href="http://http://www.chinatelecom.com.cn" target="_blank">中国电信</a> | <a href="http://www.ecsms.com.cn" target="_blank">帮助</a>
	    </div>
	<div class="content">
		<div class="logo">
			<img src="Img/logo.gif" alt="商信宝" width="150" height="46" />
		</div>
		<div class="login">
			<h3>登陆</h3> 

				<div class="fi">
					<label class="lb">用户名</label>
					<input id="iptUser" name="user" runat="server" type="text" class="ipt-t no-ime" onfocus="this.className+=' ipt-t-focus'" onblur="this.className='ipt-t no-ime'" tabindex="1" />
			  </div>
			  <div class="fi">
					<label class="lb">密　码</label>
					<input id="iptPwd" type="password" runat="server" class="ipt-t" onfocus="this.className+=' ipt-t-focus'" onblur="this.className='ipt-t no-ime'" name="password" tabindex="2" maxlength="20" />
			    </div>
				<div class="fi">
					<label class="lb">用　户</label>
                    <asp:DropDownList ID="ddlRole" runat="server" TabIndex="4">
                    <asp:ListItem Text="集团用户" Value="2"></asp:ListItem>
                    <asp:ListItem Text="个人用户" Selected="True" Value="3"></asp:ListItem>
                    </asp:DropDownList>
				  
				</div>
            	<div class="fi">
            	<table>
            	<tr>
            	<td><label class="lb">验证码</label></td>
            	<td><asp:TextBox ID="txtCode" Width="80px" TabIndex="5" class="ipt-t" onfocus="this.className+=' ipt-t-focus'" onblur="this.className='ipt-t no-ime'" runat="server"></asp:TextBox></td>
            	<td>&nbsp;&nbsp;<asp:Image ID="imgValCode" Width="60px" ImageUrl="~/ValeCode.aspx"  runat="server" /><span style=" color:Gray;">不区分大小写</span> 	<label class="ssl" for="secure"></label></td>
            	</tr>
            	</table>                
				
				
		        
		        </div>
				<div class="fi fi-btn">
					<asp:Button Text="登　录" TabIndex="6"  
					style=" background-color:#DFEBE1; width:100px; height:30px; text-align:center; font-size:16px; cursor:pointer;" 
                    onclick="btnLogin_Click"  OnClientClick="return checklogin()" runat="server"/>
					
					<span class="err" id="error_div"></span>
                    
				</div>
				<div class="fi fi-nolb">
				<div style=" visibility:hidden;">
				 </div>
				</div>

			<div class="reg">
				<span>还没有商信宝账号？</span>
				<a tabindex="8" class="btn" href="agreement.aspx" id="lnkReg">免费注册</a>
			</div>
		</div>
		<div class="intro" id="divIntro">

			<div class="introtxt introtxt-1">
				<ul>
					<li>公司有多个部门，一个集团帐户即可轻松管理！</li>
					<li>“CRM”客户管理系统，管理客户会员轻松便捷！</li>
					<li>客户建档、群发信息、活动通知...商信宝轻松帮您搞定！</li>
				</ul>
			</div>

			<div class="introtxt introtxt-2"><div id="autoLoginDiv"></div>
				<ul>
					<br>
					<br>
					<li>万家客户多年信赖，稳定运行品质保障！</li>
					<li>全网覆盖便捷高效、助力企业移动信息化！</li>
				</ul>
			</div>

			<div class="introtxt introtxt-3">
				<ul>
                                    <br>
					<li>公司有多个部门，一个集团帐户即可轻松管理！</li>
					<li>“CRM”客户管理系统，管理客户会员轻松便捷！</li>
					<li>客户建档、群发信息、活动通知...商信宝轻松帮您搞定！</li>
				</ul>
			</div>

			<div class="introtxt introtxt-4">
				<ul>
					<br>
					<br>
					<li>万家客户多年信赖，稳定运行品质保障！</li>
					<li>全网覆盖便捷高效、助力企业移动信息化！</li>
				</ul>
			</div>

			<div class="introtxt introtxt-5">
				<ul>
                                        <br>
					<li>公司有多个部门，一个集团帐户即可轻松管理！</li>
					<li>“CRM”客户管理系统，管理客户会员轻松便捷！</li>
					<li>客户建档、群发信息、活动通知...商信宝轻松帮您搞定！</li>
				</ul>
			</div>

			<div class="introtxt introtxt-6">
				<ul>
					<br>
					<br>
					<li>万家客户多年信赖，稳定运行品质保障！</li>
					<li>全网覆盖便捷高效、助力企业移动信息化！</li>
				</ul>
			</div>

			<div class="introtxt introtxt-7">
				<ul>
                                        <br>
					<li>公司有多个部门，一个集团帐户即可轻松管理！</li>
					<li>“CRM”客户管理系统，管理客户会员轻松便捷！</li>
					<li>客户建档、群发信息、活动通知...商信宝轻松帮您搞定！</li>
				</ul>
			</div>
		</div>
  </div>
	<div class="footer">
		<div class="zxdt">
			<h3>便捷信息</h3>
			<ul>
				<li><a href="http://www.cmca.org.cn" target="_blank">中国移动通信联合会</a>
				</li>
				<li><a href="http://www.ec.com.cn" target="_blank">中国国际电子商务网</a>
				</li>
				<li><a href="http://www.12114.org.cn" target="_blank">12114信息名址</a>
				</li>
			</ul>
			<span class="end"></span>
		</div>
		<div class="copyright">
			<div class="inner">
				<div align="center"><span class="footertxt"><a href="javascript:;" title="设置商信宝平台为浏览器首页" onClick="this.style.behavior='url(#default#homepage)';this.setHomePage('http://www.ecsms.com.cn');">设为主页</a><a href="http://www.ecsms.com.cn" target="_blank">关于商信宝</a><a href="http://www.ecsms.com.cn" target="_blank">官方网站</a><a href="http://www.ecsms.com.cn" target="_blank">举报违法信息</a><a href="http://www.ecsms.com.cn" target="_blank">客户服务</a><br/>
                      <span>商信宝版权所有 &copy; 2010-2012</span></span></div><script src="http://s20.cnzz.com/stat.php?id=3084216&web_id=3084216&show=pic1" language="JavaScript"></script>
			</div>
		</div>
	</div>
</div>
<script type="text/javascript">
    var bgimg = [];
    bgimg[0] = "1"; /* logo1 */
    bgimg[1] = "2"; /* logo2 */
    bgimg[2] = "3"; /* logo3 */
    bgimg[3] = "4"; /* logo4 */
    bgimg[4] = "5"; /* logo5 */
    bgimg[5] = "6"; /* logo6 */
    bgimg[6] = "7"; /* logo7 */

    $("divIntro").className = "intro intro-" + bgimg[Math.floor(bgimg.length * Math.random())];

    window.onresize = function() {
        var minh = 720;
        var minw = 960;
        $("divPage").style.height = document.documentElement.offsetHeight < minh ? minh + "px" : "100%";
        $("divPage").style.width = document.documentElement.offsetWidth < minw ? minw + "px" : "auto";
    }

    window.onresize();

    if ($("iptUser").value == "") {
        $("iptUser").focus();
    } else {
        $("iptPwd").focus();
    }

</script>
    </form>
</body>
 
</html>
