<%@ page language="C#" autoeventwireup="true" inherits="Admin_Index, App_Web_vxyct1wx" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>商信宝客户支撑后台</title>
        <script src="../JavaScript/jquery.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $(document).ready(function() {
            $("#left div.menu_title").click(function() {
                $(this).next("div.menu_body").slideToggle(50).siblings("div.menu_body").slideUp("fast");
            });
        });
 
        function Change(url) {
            document.all.frame.src = url;
        }
        function tabit(tabName, btnId, tabNumber, styleName) {
            for (i = 0; i < tabNumber; i++) {
                document.getElementById(tabName + "_div" + i).style.display = "none";
                document.getElementById(tabName + "_btn" + i).className = styleName + "_b";
            };
            document.getElementById(tabName + "_div" + btnId).style.display = "";
            document.getElementById(tabName + "_btn" + btnId).className = styleName + "_a";
        };
        function onMOvr(index) {
            if (index == 1) {
                tabit('tab04', index, 8, 'btn2');
            } else if (index == 2) {
                tabit('tab04', index, 8, 'btn2');
            } else if (index == 3) {
                tabit('tab04', index, 8, 'btn2');
            } else if (index == 4) {
                tabit('tab04', index, 8, 'btn2');
            } else if (index == 5) {
                tabit('tab04', index, 8, 'btn2');
            } else if (index == 6) {
                tabit('tab04', index, 8, 'btn2');
            } else {
                tabit('tab04', index, 8, 'btn2');
            }
        } 
    </script>
    
    <style type="text/css">
        .menu_title 
        { 
            margin-top:5px; 
            line-height:25px; 
            vertical-align:top; 
            cursor:pointer; 
            font-size:13px; 
            background-image:url('Img/menu_bt.jpg'); 
            width:150px; 
            height:22px;
            }
        .menu_body 
        {
            font-size:13px; 
            color:Black; 
            width:100%; 
            cursor:pointer; 
            text-align:center; 
        }
        .left a 
        {
            cursor:pointer; 
            line-height:25px;
             color:#003366; 
             text-decoration:none; 
             margin-top:10px;}
        .left a:hover 
        {
            color:Blue; 
            text-decoration:underline;
            }
        .divBody {text-align:center; width:100%;}
        
        .top{width:100%; height:147px;}        
        .banner { width:100%; height:77px; background-image:url(../Img/indextop.gif);   }
        .navi {width:100%; height:70px; background-image:url('Img/z_01.jpg');    }
        /*导航条开始*/
.pad2{padding:2px;}

.btn2_b{width:94px;text-align:center;font-size:16px;height:34px;line-height:34px;background:url(img/z_02.gif) right no-repeat;display:block;float:left;}
.btn2_a{width:94px;text-align:center;background:url(img/z_01.gif);font-size:16px;color:#1C4360;padding-top:7px;line-height:27px;height:27px;display:block;cursor:pointer;float:left;}

.btn3_b{width:92px;text-align:center;font-size:12px;height:30px;line-height:30px;background:url(img/y_06.gif) right no-repeat;display:block;float:left;color:#3B658A;}
body {padding:0;margin:0px;background:#fff;text-align:center;color:#1C4360;}
h1, h2, h3, h4, h5, h6, form, div, p, i, img, ul, li, ol, table, tr, td, fieldset, label, legend {margin:0px;padding:0px;}
/*导航条结束*/
        .container { width:100%; height:550px;  }
        .left{width:15%; height:100%; float:left; background-color:#C6E4FF; border:solid 1px #6593BC;} 
        .right{width:84%; height:100%; float:right; background-color:White; border:solid 1px #6593BC;} 
        
        .foot{text-align:center; width:100%; margin-top:5px; border-color:#6593BC; border-style:solid; border-width:1px; background-color:#F2F6FA;}
   
    </style>
    
</head>
<body style=" font-size:12px; font-family:微软雅黑; text-align:center; background-color:#B5CFE8;">
    <form id="form1" runat="server">
    <div class="divBody">
    
        <div class="top" >  
                 <div class="banner">
                 
                 </div>
                 
                 <div class="navi">     
                         <table width="100%" height="70" cellspacing="0" background="img/z_01.jpg"  style="text-align:left; font-family:微软雅黑; font-weight:bold; color:#1C4360; font-size:16px; cursor:pointer;">
  <tr>
    <td align="left" valign="top" style="padding-left:140px;">
    
    	<table  cellspacing="0">
      <tr>
        <td id="tab04_btn0" class="btn2_a" onmouseover="onMOvr(0);" onclick="window.location.href='index.aspx'">首 页</td>
        <td id="tab04_btn1" class="btn2_b" onmouseover="onMOvr(1);">3G直告</td>
        <td id="tab04_btn2" class="btn2_b" onmouseover="onMOvr(2);">企信通</td>
        <td id="tab04_btn3" class="btn2_b" onmouseover="onMOvr(3);">会员通</td>
        <td id="tab04_btn4" class="btn2_b" onmouseover="onMOvr(4);">准告</td>
        <td id="tab04_btn5" class="btn2_b" onmouseover="onMOvr(5);">闪信</td>
        <td id="tab04_btn6" class="btn2_b" onmouseover="onMOvr(6);">需求发送</td>
        <td id="tab04_btn7" class="btn2_b" onmouseover="onMOvr(7);">
        <asp:LinkButton ID="btnQuit" Font-Overline="false" Font-Size="16px" ForeColor="#1C4360"  
                                         runat="server" onclick="btnQuit_Click">退出</asp:LinkButton>
        </td>
      </tr>
      <tr>
        <td align="left" class="pad2"><!--导航层1开始-->
		<div id="tab04_div0" style="position:absolute; z-index:1;text-align:left;">
		</div><!--导航层1结束--></td>
        <td align="left" class="pad2"><!--导航层2开始-->
	<div id="tab04_div1" style="position:absolute; z-index:2;text-align:left;display:none;">
		
		<table  cellspacing="0">
      <tr>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../sms/SendSms.aspx?type=A')"><img src="img/y_08.gif" align="absmiddle" hspace="5" />发3G直告</td>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../smslog/SendLog.aspx?type=A')"><img src="img/y_09.gif" align="absmiddle" hspace="5" /> 发件箱</td>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../smslog/ReceiveLog.aspx?type=A')"><img src="img/y_10.gif" align="absmiddle" hspace="5" /> 收件箱</td>
      </tr>
    </table>
		</div><!--导航层2结束--></td>
        <td align="left" class="pad2"><!--导航层3开始-->
	<div id="tab04_div2" style="position:absolute; z-index:2;text-align:left;display:none;">
		
		<table  cellspacing="0">
      <tr>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../sms/SendSms.aspx?type=B')"><img src="img/y_08.gif" align="absmiddle" hspace="5" />发送企信通</td>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../smslog/SendLog.aspx?type=B')"><img src="img/y_09.gif" align="absmiddle" hspace="5" /> 发件箱</td>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../smslog/ReceiveLog.aspx?type=B')"><img src="img/y_10.gif" align="absmiddle" hspace="5" /> 收件箱</td>
      </tr>
    </table>
		</div><!--导航层3结束--></td>
        <td align="left" class="pad2"><!--导航层4开始-->
	<div id="tab04_div3" style="position:absolute; z-index:2;text-align:left;display:none;">
		
		<table  cellspacing="0">
      <tr>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../sms/SendSms.aspx?type=C')"><img src="img/y_08.gif" align="absmiddle" hspace="5" />发送会员通</td>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../smslog/SendLog.aspx?type=C')"><img src="img/y_09.gif" align="absmiddle" hspace="5" /> 发件箱</td>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../smslog/ReceiveLog.aspx?type=C')"><img src="img/y_10.gif" align="absmiddle" hspace="5" /> 收件箱</td>
      </tr>
    </table>
		</div><!--导航层4结束--></td>
        <td align="left" class="pad2"><!--导航层5开始-->
	<div id="tab04_div4" style="position:absolute; z-index:2;text-align:left;display:none;">
		
		<table  cellspacing="0">
      <tr>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../sms/SendSms.aspx?type=D')"><img src="img/y_08.gif" align="absmiddle" hspace="5" />发送准告</td>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../smslog/SendLog.aspx?type=D')"><img src="img/y_09.gif" align="absmiddle" hspace="5" /> 发件箱</td>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../smslog/ReceiveLog.aspx?type=D')"><img src="img/y_10.gif" align="absmiddle" hspace="5" /> 收件箱</td>
      </tr>
    </table>
		</div><!--导航层5结束--></td>
        <td align="left" class="pad2"><!--导航层6开始-->
	<div id="tab04_div5" style="position:absolute; z-index:2;text-align:left;display:none;">
		
		<table  cellspacing="0">
      <tr>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../sms/SendSms.aspx?type=E')"><img src="img/y_08.gif" align="absmiddle" hspace="5" />发送闪信</td>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../smslog/SendLog.aspx?type=E')"><img src="img/y_09.gif" align="absmiddle" hspace="5" /> 发件箱</td>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../smslog/ReceiveLog.aspx?type=E')"><img src="img/y_10.gif" align="absmiddle" hspace="5" /> 收件箱</td>
      </tr>
    </table>
		</div><!--导航层6结束--></td>
        <td align="left" class="pad2"><!--导航层7开始-->
	<div id="tab04_div6" style="position:absolute; z-index:2;text-align:left;display:none;">
		
		<table  cellspacing="0">
      <tr>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../sms/SendXSms.aspx')"><img src="img/y_08.gif" align="absmiddle" hspace="5" />需求发送</td>
        <td class="btn3_b" onmouseover="this.style.backgroundImage='url(img/y_07.gif)';this.style.cursor='pointer';"   onMouseOut="this.style.backgroundImage='url(img/y_06.gif)'" onclick="Change('../smslog/SendLog.aspx?type=X')"><img src="img/y_09.gif" align="absmiddle" hspace="5" /> 发件箱</td>
      </tr>
    </table>
		</div><!--导航层7结束--></td>
        <td align="left" class="pad2"><!--导航层8开始-->
		<div id="tab04_div7" style="position:absolute; z-index:1;text-align:left;">
		</div><!--导航层8结束--></td>
      </tr>
    </table>
    
    </td>
  </tr>
</table>               
                 </div>     
           </div>
        
        <div class="container">
            <div class="left" id="left">
              
                    <div class='menu_title'>账户管理</div>
                    <div class='menu_body'>
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../Account/AccountInfo.aspx')"> 账户信息 </a><br />
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../Account/PwdModify.aspx')"> 修改密码 </a><br />
                    </div>
                     
                    <div class='menu_title'>用户管理</div>
                    <div class='menu_body'>
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../UserManage.aspx?type=agent')"> 代理管理 </a><br />
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../UserManage.aspx?type=user')"> 用户管理 </a>
                    </div>              
                    
                    <div class='menu_title'>短信管理</div>
                    <div class='menu_body'>
                        <div id="divWaitSms" runat="server"><img src="Img/menu_icon.gif" /><a onclick="Change('../admin/WaitSms.aspx')"> 待发短信 </a><br /></div>
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../smslog/SendLog.aspx?type=myuser')"> 发送记录 </a><br />
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../smslog/ReceiveLog.aspx?type=myuser')"> 接收记录 </a><br />
                    </div>
                    
                    <div class='menu_title'>资源管理</div>
                    <div class='menu_body'>
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../Contact/ContactList.aspx')"> 我的名片夹</a>
                    <br /><img src="Img/menu_icon.gif" /><a onclick="Change('../Phrase/CommonPhrases.aspx')"> 我的短语库 </a>
                    <br /><img src="Img/menu_icon.gif" /><a onclick="Change('../numbers/addbase.aspx')"> 我的数据库 </a>
                    <br /><img src="Img/menu_icon.gif" /><a onclick="Change('../DownLoads/DownLoad.aspx')"> 系统辅助服务 </a>
                    </div>
  
                                
                    <div class='menu_title'> 财务管理 </div>
                    <div class='menu_body'>
                    <img src="Img/menu_icon.gif" /><a onclick="Change('../chargelog.aspx')"> 充值记录 </a><br />
                    <img src="Img/menu_icon.gif" /><a onclick="Change('../givelog.aspx')"> 分配记录 </a><br />
                    <img src="Img/menu_icon.gif" /><a onclick="Change('')"> 网银接口 </a> <br />
                    <img src="Img/menu_icon.gif" /><a onclick="Change('../Bank.aspx')"> 银行账户 </a><br />
                    <img src="Img/menu_icon.gif" /><a onclick="Change('../upinfo.aspx')"> 上级信息 </a> 
                    </div>
                    
                    
 
            </div>
            
            
            <div class="right">
                <div id="divWelcome" style=" text-align:left;  width:100%; height:30px; color:#1C4360; font-size:14px; font-family:微软雅黑; letter-spacing:5px;">
                      <span style=" font-weight:bold; font-size:15px; margin-left:15px;">  尊敬的<% =Public.GetUserAccount(int.Parse(Public.GetUserId(this.Page))) %>，欢迎使用商信宝短信平台！</span> 
                </div>
                <div style=" margin-left:15px;">
                <iframe id="frame" height="520px" width="100%" src="../Account/SMSAccount.aspx" align='left' marginwidth='0' marginheight='0' hspace='0' vspace='0' frameborder='0' scrolling='auto'></iframe>
                </div>
            </div>
        </div>
        
        <div class="foot">
           <br /><br />
           Copyright @2010-2012 商信宝  <br /><br /> 
 
        </div>
    </div>
    </form>
</body>
</html>
