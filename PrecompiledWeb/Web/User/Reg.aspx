<%@ page language="C#" autoeventwireup="true" enableeventvalidation="false" inherits="User_Reg, App_Web_qffdja0f" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<HEAD runat="server">
<TITLE>注册</TITLE>
<LINK rel=stylesheet type=text/css href="Img/style.css">
<LINK rel=stylesheet type=text/css href="Img/lightbox.css">


<STYLE type=text/css>
    
    BODY {
	BACKGROUND-COLOR: #97bde0
}
    .style2
    {
    }
    .style3
    {
    }
    
    .style4
    {
        width: 3%;
    }
    .style5
    {
        width: 2%;
    }
    
</STYLE>
 <script src="Ajax.js" type="text/javascript"></script>
 <script type="text/javascript">
     //提交前检查
     function checkall() {
         CheckAccount();
     }
        //检查账户
        function CheckAccount() {
            var account = document.getElementById("txtaccount").value;
            if (account.length<2||account.length>10) {
                document.getElementById("accountwarn").innerHTML = "长度2-10位！";
                document.getElementById("accountwarn").style.color = "red";
            }
            else {
                document.getElementById("accountwarn").innerHTML = "";
                IsExsitAccount(account);
            }   
        }


	//检查密码
        function checkPassword() {
            var pwd = document.getElementById("txtpwd").value;
            var pwdwarn = document.getElementById("pwdwarn");
            if (pwd.length < 6 || pwd.length > 15) {
                pwdwarn.innerHTML = "长度6-15位！";
                pwdwarn.style.color = "red";
            } 
            else {
                pwdwarn.innerHTML = "密码符合要求";
                pwdwarn.style.color = "blue";
		}
	}
	
	//检查重输密码
	function checkRePassword(){
	    var pwd = document.getElementById("txtpwd").value;
	    var pwd2 = document.getElementById("txtpwd2").value;
	    var pwdwarn = document.getElementById("pwd2warn");
	    if (pwd2.length < 6 || pwd2.length > 15) {
	        pwdwarn.innerHTML = "长度6-15位！";
	        pwdwarn.style.color = "red";
	    }
	    else {
	        if (pwd != pwd2) {
	            pwd2warn.innerHTML = "两次输入密码不一致！";
	            pwd2warn.style.color = "red";
	        }
	        else {
	            pwdwarn.innerHTML = "密码符合要求";
	            pwdwarn.style.color = "blue";
	        }
	    }
	}
    //验证邮箱
	function CheckEmail() {
	    var email = document.getElementById("txtemail").value;
	    var pattern = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(\.[a-zA-Z0-9_-])+/;
	    chkFlag = pattern.test(email);
	    if (chkFlag) {
	        document.getElementById("emailspan").innerHTML = "邮箱格式正确！";
	        document.getElementById("emailspan").style.color = "blue";
	    }
	    else {
	        document.getElementById("emailspan").innerHTML = "邮箱格式错误！";
	        document.getElementById("emailspan").style.color = "red";
	    }
	}
	//验证电话
	function CheckTelephone() {
	    var telephone = document.getElementById("txttelephone").value;
	    var pattern = /^[0-9]+[-]?[0-9]+[-]?[0-9]$/;
	    chkFlag = pattern.test(telephone);
	    if (chkFlag) {
	        document.getElementById("telspan").innerHTML = "电话格式正确！";
	        document.getElementById("telspan").style.color = "blue";
	    }
	    else {
	        document.getElementById("telspan").innerHTML = "电话格式错误！";
	        document.getElementById("telspan").style.color = "red";
	    }
	}
	 //验证手机
	function CheckMobile() {
	    var mobile = document.getElementById("txtmobile").value;
	    var pattern = /^(1[0-9][0-9])\d{8}$/;
	    chkFlag = pattern.test(mobile);
	    if (chkFlag) {
	        document.getElementById("mobilespan").innerHTML = "电话格式正确！";
	        document.getElementById("mobilespan").style.color = "blue";
	    }
	    else {
	        document.getElementById("mobilespan").innerHTML = "电话格式错误！";
	        document.getElementById("mobilespan").style.color = "red";
	    }
	}
    
    
    
</script>
</HEAD>
<body style=" font-size:12px; font-family:微软雅黑;">
<form id="form1" runat="server">

<center>
<TABLE 
style="BORDER-BOTTOM: #6694bd 1px solid; BORDER-LEFT: #6694bd 1px solid; PADDING-BOTTOM: 0px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; BORDER-TOP: #6694bd 0px solid; BORDER-RIGHT: #6694bd 1px solid; PADDING-TOP: 0px" 
cellSpacing=0 width=750 bgColor=#ffffff>
  <TBODY>
  <TR>
    <TD>
      <TABLE cellSpacing=0 width=740>
        <TBODY>
        <TR>
          <TD height=19 vAlign=bottom width=297 align=left><IMG 
            src="Img/y_13.gif" width=119 height=12></TD>
          <TD width=437>　</TD></TR></TBODY></TABLE>
      <TABLE border=0 cellSpacing=0 cellPadding=0>
        <TBODY>
        <TR>
          <TD align=left><IMG src="Img/z_02.jpg" width=739 
        height=87></TD></TR></TBODY></TABLE>
      <TABLE 
      style="BORDER-BOTTOM: #6694bd 1px solid; BORDER-LEFT: #6694bd 1px solid; BACKGROUND: #e9f0f9; BORDER-TOP: #6694bd 0px solid; BORDER-RIGHT: #6694bd 1px solid" 
      cellSpacing=0 width=739>
        <TBODY>
        <TR>
          <TD height=52 align=middle><IMG src="Img/y_14.gif" width=85 
            height=36><IMG src="Img/y_18.gif" width=165 height=36><IMG 
            src="Img/y_16.gif" width=165 height=36><IMG 
            src="Img/y_20.gif" width=115 height=36></TD></TR></TBODY></TABLE>
      <TABLE 
      style="BORDER-BOTTOM: #6694bd 1px solid; BORDER-LEFT: #6694bd 1px solid; BORDER-TOP: #6694bd 0px solid; BORDER-RIGHT: #6694bd 1px solid" 
      cellSpacing=0 width=739>
        <TBODY>
        <TR>
          <TD align=middle><BR>
            <TABLE class="tbl01 gray2" cellSpacing=1 width=710>
              <TBODY>
              <TR>
                <TH 
                style="BORDER-BOTTOM: #f3f7fd 1px solid; TEXT-ALIGN: left; BORDER-LEFT: #f3f7fd 1px solid; HEIGHT: 26px; BORDER-TOP: #f3f7fd 1px solid; BORDER-RIGHT: #f3f7fd 1px solid" 
                colSpan=2><IMG hspace=5 src="Img/x_00.gif" width=11 
                  height=11>用户基本资料</TH></TR>
                  <TR>
                <TD class=ticketname height=50 width=130>用户类型*</TD>
                <TD>
                  <TABLE cellSpacing=0 width="98%">
                    <TBODY>
                    <TR>
                      <TD id=TD1 class="style2" align="left">
                          
                          <asp:RadioButtonList RepeatDirection="Horizontal" ID="rbtnRole" runat="server" 
                              RepeatLayout="Flow">
                          <asp:ListItem Text="集团用户" Selected="True" Value="2"></asp:ListItem>
                          <asp:ListItem Text="个人用户" Value="3"></asp:ListItem>
                          </asp:RadioButtonList>
                       <span style=" color:Red;">多个部门使用请选择集团用户</span></TD>
                        </TR></TBODY></TABLE></TD></TR>
                  <TR>
                <TD class=ticketname height=50 width=130>注册需求*</TD>
                <TD>
                  <TABLE cellSpacing=0 width="98%">
                    <TBODY>
                    <TR>
                      <TD id=TD5 class="style3" align="left">
                          
                          <asp:CheckBoxList ID="cbRegFor" runat="server" RepeatDirection="Horizontal" 
                              Width="428px" RepeatLayout="Flow">
                              <asp:ListItem Value="A">会员服务</asp:ListItem>
                              <asp:ListItem Value="B">促销广告</asp:ListItem>
                              <asp:ListItem Value="C">商业调查</asp:ListItem>
                              <asp:ListItem Value="D">通知公告</asp:ListItem>
                          </asp:CheckBoxList>
                        </TD>
                        </TR></TBODY></TABLE></TD></TR>
                  <TR>
                <TD class=ticketname height=50 width=130>试用产品*</TD>
                <TD>
                  <TABLE cellSpacing=0 width="98%">
                    <TBODY>
                    <TR>
                      <TD id=TD3 class="style2" align="left">
                          
                          <asp:CheckBoxList ID="cbTrySmsType" runat="server" RepeatDirection="Horizontal" 
                              RepeatLayout="Flow">
                          <asp:ListItem Text="3G直告" Value="A"></asp:ListItem>
                          <asp:ListItem Text="企信通" Value="B"></asp:ListItem>
                          <asp:ListItem Text="会员通" Value="C"></asp:ListItem>
                          <asp:ListItem Text="准告" Value="D"></asp:ListItem>
                          <asp:ListItem Text="闪信" Value="E"></asp:ListItem>
                          </asp:CheckBoxList>
                        </TD>
                        </TR></TBODY></TABLE></TD></TR>
              <TR>
                <TD class=ticketname height=50 width=130>客户登录名*</TD>
                <TD>
                  <TABLE cellSpacing=0 width="98%">
                    <TBODY>
                    <TR>
                      <TD id=success_username class="style4" align="left">
                          <asp:TextBox id="txtaccount" runat="server" Width="210px"></asp:TextBox><span style=" font-size:11px;"> 2-10个字符,汉字数字英文均可</span>
		                    
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                              ControlToValidate="txtaccount" ErrorMessage="*"></asp:RequiredFieldValidator>
		                    

              
              <span id="accountwarn" style=" font-size:11px;" ></span></TD></TR></TBODY></TABLE></TD></TR>
              
              <TR>
                <TD class=ticketname height=50 width=130>输入密码*</TD>
                <TD>
                  <TABLE cellSpacing=0 width="98%">
                    <TBODY>
                    <TR>
                      <TD id=success_password class="style4" align="left">
                      
                      <asp:TextBox id="txtpwd" runat="server" TextMode="Password" Width="210px"></asp:TextBox> <span style=" font-size:11px;">请不要使用过于简单的密码</span>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                              ControlToValidate="txtpwd" ErrorMessage="*"></asp:RequiredFieldValidator>

              <span id="pwdwarn" style=" font-size:11px;" ></span>
              
              </TD></TR></TBODY></TABLE></TD></TR>
              <TR>
                <TD class=ticketname height=50 width=130>确认密码*</TD>
                <TD>
                  <TABLE cellSpacing=0 width="98%">
                    <TBODY>
                    <TR>
                      <TD id=success_repassword class="style5" align="left">
                      
                      <asp:TextBox id="txtpwd2" runat="server" TextMode="Password" Width="210px"></asp:TextBox>
                      
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                              ControlToValidate="txtpwd2" ErrorMessage="*"></asp:RequiredFieldValidator>

                
                <span id="pwd2warn" style=" font-size:11px" ></span>
                
                </TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
            <DIV class=blank8></DIV>
            <TABLE class="tbl01 gray2" cellSpacing=1 width=710>
              <TBODY>
              <TR>
                <TH 
                style="BORDER-BOTTOM: #f3f7fd 1px solid; TEXT-ALIGN: left; BORDER-LEFT: #f3f7fd 1px solid; HEIGHT: 26px; BORDER-TOP: #f3f7fd 1px solid; BORDER-RIGHT: #f3f7fd 1px solid"><IMG 
                  hspace=5 src="Img/x_00.gif" width=11 
height=11>公司信息</TH></TR>
              <TR>
                <TD>
                  <DIV class=blank8></DIV>
                  <DIV class=blank8></DIV>
                  <TABLE class=borderK1 cellSpacing=0 width="87%">
                    <TBODY>
                    <TR>
                      <TD style="BACKGROUND: #e9f0f9">
                        <DIV class=blank8></DIV>
                        <DIV class=blank8></DIV>
                        <TABLE class=tbl03 cellSpacing=0 width="96%">
                          <TBODY>
                          <TR>
                            <TD width="18%">公司名称</TD>
                            <TD width="68%" align=left>
                            
                            <asp:TextBox id="txtcompanyname" runat="server" Width="200px"></asp:TextBox>
                            
                            </TD>
                            <TD width="14%" align="left" rowspan="5">&nbsp;&nbsp;&nbsp;&nbsp; 
                                完整的企业全称和详细的公司地址方便我们给您邮寄礼品</TD></TR>
                          <TR>
                            <TD>公司地址</TD>
                            <TD align=left>
                            
                            <asp:DropDownList ID="ddlProvince" runat="server">
                            </asp:DropDownList>
                            
                            <asp:DropDownList ID="ddlCity" runat="server" >
                            </asp:DropDownList>
                            
                               </TD>
                              </TR>
                          <TR>
                            <TD>详细地址</TD>
                            <TD align=left>
                            
                            <asp:TextBox id="txtcompanyaddress" runat="server" Width="350px"></asp:TextBox>
                            
                            </TD>
                              </TR>
                          <TR>
                            <TD>邮政编码 </TD>
                            <TD align=left>
                            
                            <asp:TextBox id="txtpostcode" runat="server" Width="106px"></asp:TextBox>
                            
                            </TD>
                              </TR>
                          <TR>
                            <TD>公司网址 </TD>
                            <TD align=left>
                            
                            <asp:TextBox id="txtwebsite" runat="server" Width="222px"></asp:TextBox>
                            
                            </TD>
                              </TR></TBODY></TABLE>
                        <DIV class=blank8></DIV>
                        <DIV class=blank8></DIV></TD></TR></TBODY></TABLE>
                  <DIV class=blank8></DIV>
                  <DIV class=blank8></DIV></TD></TR></TBODY></TABLE><BR>
            <DIV class=blank8></DIV>
            <TABLE class="tbl01 gray2" cellSpacing=1 width=710>
              <TBODY>
              <TR>
                <TH 
                style="BORDER-BOTTOM: #f3f7fd 1px solid; TEXT-ALIGN: left; BORDER-LEFT: #f3f7fd 1px solid; HEIGHT: 26px; BORDER-TOP: #f3f7fd 1px solid; BORDER-RIGHT: #f3f7fd 1px solid"><IMG 
                  hspace=5 src="Img/x_00.gif" width=11 
              height=11>联系人信息</TH></TR>
              <TR>
                <TD>
                  <DIV class=blank8></DIV>
                  <DIV class=blank8></DIV>
                  <TABLE class=borderK1 cellSpacing=0 width="87%">
                    <TBODY>
                    <TR>
                      <TD style="BACKGROUND: #e9f0f9">
                        <DIV class=blank8></DIV>
                        <DIV class=blank8></DIV>
                        <TABLE class=tbl03 cellSpacing=0 width="90%">
                          <TBODY>
                          <TR>
                            <TD width="18%">真实姓名*</TD>
                            <TD width="68%" align=left>
                            
                            <asp:TextBox id="txtname" runat="server" Width="141px"></asp:TextBox>
                            
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                    ControlToValidate="txtname" ErrorMessage="*"></asp:RequiredFieldValidator>
                            
                            </TD>
                            <TD width="14%"></TD></TR>
                          <TR>
                            <TD>用户性别*</TD>
                            <TD align=left>
                            
                            <asp:DropDownList ID="ddlsex" runat="server">
                            <asp:ListItem Text="男" Value="0"></asp:ListItem>
                            <asp:ListItem Text="女" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                             
                            <TD></TD></TR>
                          <TR>
                            <TD>有效证件号*</TD>
                            <TD align=left>
                            
                            <asp:TextBox id="txtCard" runat="server" Width="178px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                    ControlToValidate="txtCard" ErrorMessage="*"></asp:RequiredFieldValidator>
                            身份证/企业工商注册号</TD>
                            <TD> </TD></TR>
                          <TR>
                            <TD>手机号码*</TD>
                            <TD align=left>                         
                            
                            
                            <asp:TextBox id="txtmobile" ToolTip="例:138********" runat="server" Width="140px"></asp:TextBox>
                <span style=" font-size:11px;">例:138********</span> 
                            <span id="mobilespan" style=" font-size:11px;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                                    ControlToValidate="txtmobile" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </span></TD>
                            <TD></TD></TR>
                          <TR>
                            <TD>邮件地址*</TD>
                            <TD align=left>
                            
                             <asp:TextBox id="txtemail" runat="server" ToolTip="推荐注册139邮箱" Width="177px"></asp:TextBox>
                            <span style=" font-size:11px;">推荐注册<a target="_blank" href="http://mail.139.com/">139邮箱</a></span> 
                               
                               <span id="emailspan" style=" font-size:11px;">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                                    ControlToValidate="txtemail" ErrorMessage="*"></asp:RequiredFieldValidator>
                                </span></TD>
                            <TD></TD></TR>
                          <TR>
                            <TD>固定电话</TD>
                            <TD align=left>
                            
                                 <asp:TextBox ToolTip="例:0371612345678" id="txttelephone" runat="server" Width="140px"></asp:TextBox>
                                 <span  style=" font-size:11px;">例:0371612345678</span>
                            <span id="telspan" style=" font-size:11px;"> </span>
                              </TD>
                            <TD></TD></TR>
                          <TR>
                            <TD>传真号码 </TD>
                            <TD align=left>
                            
                            <asp:TextBox id="txtfax" runat="server" Width="140px"></asp:TextBox>
                            
                            </TD>
                            <TD></TD></TR>
                          <TR>
                            <TD>QQ 号码 </TD>
                            <TD align=left>
                            
                            <asp:TextBox id="txtqq" runat="server" Width="109px"></asp:TextBox>
                            
                            </TD>
                            <TD></TD></TR>
                          <TR>
                            <TD> </TD>
                            <TD align=left>
                            
                             </TD>
                            <TD></TD></TR></TBODY></TABLE>
                        <DIV class=blank8></DIV>
                        <DIV class=blank8></DIV></TD></TR></TBODY></TABLE>
                  <div id="divWarn"></div>
                   </TD></TR></TBODY></TABLE>
            <TABLE border=0 cellSpacing=0 cellPadding=0 width=299 height=42>
              <TBODY>
              <TR>
                <TD align=middle>
                <asp:Button ID="btnAdd" runat="server" Text="注册" OnClientClick="return checkall()" 
                        onclick="btnAdd_Click" ></asp:Button>
                    <asp:Button ID="Button1" runat="server" PostBackUrl="~/User/Login.aspx" 
                        Text="返回" />
                </TD>
                <TD align=middle></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>
      <DIV class=blank8></DIV></TD></TR></TBODY></TABLE>
<TABLE cellSpacing=5 width=750 bgColor=#6593bc>
  <TBODY>
  <TR>
    <TD style="COLOR: #fff">Copyright @2010-2012 商信宝</TD></TR></TBODY></TABLE></center>

</form>
</BODY>
</HTML>
