<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Admin_Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>商信宝短信平台后台管理系统</title>
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
       
    </script>
    
    <style type="text/css">
        .menu_title{ color:Black; font-family:黑体; font-size:14px; font-weight:bold; margin-top:5px; line-height:25px; vertical-align:top; cursor:pointer; font-size:13px; background-image:url('Img/menu_bt.jpg'); width:100%; height:22px;}
        .menu_body{ font-size:13px; color:Black; width:100%; cursor:pointer; text-align:left; margin-left:18px;
        }
        #left a{ cursor:pointer; color:#003366; text-decoration:none; margin-top:10px;}
        #left a:hover{ color:Blue; text-decoration:underline; font-size:15px; }
       
        #container{  font-size:12px; font-family:微软雅黑; width:100%;}
        #top{ width:100%; height:56px; background-image:url(Img/header_bg.jpg); color: #FFFFFF; font-family: 微软雅黑; font-size:36px; font-weight: bold;}
        #main{ width:100%; height:650px;}
        #left{  position:absolute; left:0px; top:60px; width:150px; height:100%; background-color:#E3EFFB;}
        #right{  height:100%; width:88%; position:absolute; left:150px; top:60px; text-align:left;}
    </style>
    
</head>
<body style=" margin:0px 0px 0px 0px;background-color:#E8F1FA; font-size:12px; text-align:center; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div id="container">
        
        <div id="top">            
            <span style="margin-left: 120px">商信宝短信平台管理系统</span> 
        </div>
        <div id="main">
        
        <div id="left">
         
              <a onclick="Change('../Account/SMSAccount.aspx')" style=" font-size:16px; color:Black; cursor:pointer;"> 后台首页 </a>
              <asp:LinkButton ID="lbtnQuit" style=" color:Black; font-size:16px; text-decoration:none;" runat="server" 
                    onclick="lbtnQuit_Click">退出系统</asp:LinkButton>
                    
                    <div class='menu_title'>短信管理</div>
                    <div class='menu_body'>
                        <img src="Img/menu_icon.gif" /><a onclick="Change('WaitSms.aspx')"> 待发短信 </a><br />
                        <img src="Img/menu_icon.gif" /><a onclick="Change('xSms.aspx')"> 需求短信 </a><br />              
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../SmsLog/SendLog.aspx?type=all')"> 发送日志 </a><br />
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../SmsLog/ReceiveLog.aspx?type=all')"> 接收日志 </a>
                    </div>  
                    
                    <div class='menu_title'>客户管理</div>
                    <div class='menu_body'>
                        <img src="Img/menu_icon.gif" /><a onclick="Change('users.aspx?type=user')"> 客户管理 </a><br />
                        <img src="Img/menu_icon.gif" /><a onclick="Change('users.aspx?type=agent')"> 代理管理 </a><br />
                        <img src="Img/menu_icon.gif" /><a onclick="Change('RegManage.aspx')"> 注册管理 </a><br /> 
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../OnlineUser.aspx')"> 在线客户 </a> 
                    </div>  
                    
                    <div class='menu_title'>系统管理</div>
                    <div class='menu_body'>
                    <img src="Img/menu_icon.gif" /><a onclick="Change('../broadcast/broadcast.aspx')"> 公告管理 </a><br />
                     <img src="Img/menu_icon.gif" /><a onclick="Change('ProChannelConfig.aspx')"> 产品配置 </a><br />
                         <img src="Img/menu_icon.gif" /><a onclick="Change('ChannelConf.aspx')"> 接口管理 </a><br />
                        <img src="Img/menu_icon.gif" /><a onclick="Change('PlatMax.aspx')"> 平台权限 </a><br />                       
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../Account/PwdModify.aspx')"> 修改密码 </a><br />
                           <img src="Img/menu_icon.gif" /><a onclick="Change('SpSegment.aspx')"> 号段管理 </a>        <br />                 
                         <img src="Img/menu_icon.gif" /><a onclick="Change('../Advice/AdviceList.aspx')"> 投诉建议</a><br />
                         <img src="Img/menu_icon.gif" /><a onclick="Change('RegForbidWord.aspx')"> 注册禁用词</a>
  
                       
                    </div> 
                    
                    <div class='menu_title'> 财务管理 </div>
                    <div class='menu_body'>
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../giveLog.aspx')"> 充值查询</a><br />
                        <img src="Img/menu_icon.gif" /><a onclick="Change('TotalLeaveCount.aspx')"> 销售查询 </a><br />
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../Bank.aspx')"> 银行账户 </a><br />
                        <img src="Img/menu_icon.gif" /><a onclick="Change('')"> 网银账户 </a><br />                        
                    </div>                         
                    
                    <div class='menu_title'>资源管理</div>
                    <div class='menu_body'>
                        
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../DownLoads/AddDownLoad.aspx')"> 下载管理 </a><br />
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../Contact/AdminContactList.aspx')"> 平台名片夹</a><br />
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../Phrase/CommonPhrases.aspx')"> 公共短语库 </a><br />
                        <img src="Img/menu_icon.gif" /><a onclick="Change('../numbers/addbase.aspx')"> 公共数据库 </a>
                    </div>          
        </div>
        
        <div id="right">
            <iframe id="frame" height="100%" width="100%" src="../account/smsaccount.aspx" align='left' marginwidth='0' marginheight='0' hspace='0' vspace='0' frameborder='0' scrolling='auto'></iframe>
        </div>
        
        </div>
    </div>
    </form>
</body>
</html>
