<%@ page language="C#" autoeventwireup="true" inherits="Admin_Default, App_Web_vxyct1wx" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>欢迎使用企业短信管理平台</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<link href="css/style.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" type="text/css" href="css/lightbox.css">
<SCRIPT>
    function chklogin() {
        if (document.getElementById("username").value == "") {
            alert("请输入用户名！");
            return false;
        }
        if (document.getElementById("password").value == "") {
            alert("请输入密码！");
            return false;
        }
        
    }
</SCRIPT>

<META content="MSHTML 6.00.2900.3395" name=GENERATOR>
    <style type="text/css">
        #username
        {
            width: 120px;
        }
        #password
        {
            width: 120px;
        }
        #txtCode
        {
            width: 120px;
        }
    </style>
</head>
<body style=" background-color:White; font-size:12px; font-family:微软雅黑;" bgColor=#ffffff leftMargin=0 topMargin=0 marginheight="0" marginwidth="0">
    <form id="form1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="middle"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td height="65" align="center"><table width="542" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td align=right valign="bottom"><div align="center"><img src="img/logo.gif" width="400" height="66"></div></td>
              </tr>
        </table></td>
      </tr>
    </table>
      <table width="100%" height="204" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td align="center" background="img/login_06.gif"><table width="370" height="204" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td height="24" align="center">&nbsp;</td>
              </tr>
              <tr>
                <td align="center">
                <form action="#" ID="login" method="post" onSubmit="return onSubmit();">
                <table  border="0" cellpadding="0" cellspacing="0">
                    
					<tr>
                      <td align="right">
                          登 录 名：
                      </td>
                      <td  align="left">
                            <table border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td ></td>
                            <td>
 
                                <input name="username" id="username" runat="server" type="text" tabindex="1"/>
 
                              </td>
                            <td ></td>
                          </tr>
                      </table>
                      </td>
                            <td  rowspan="2" align="center">
                      <asp:ImageButton  ImageUrl="img/login_14.gif" tabindex="4"  ID="ImageButton2" 
                        OnClientClick=" return chklogin()" runat="server" Width="75px" Height="60px" onclick="ImageButton1_Click" />
                      </td>
                    </tr>
                    <tr>
                      <td align="right">
                          密&nbsp;&nbsp;码：                </td>
                      <td align="left">
                      <table  border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td ></td>
                            <td  >
                            
                            <input  runat="server" name="passwd" id="password" type="password" tabindex="2"></td>
                            
                            <td ></td>
                          </tr>
                      </table>
                      </td>
                    </tr>
                    <tr>
                      <td align="right">
                      验 证 码：
                      </td>
                      <td colspan="2" align="left">
                      <table  border="0" cellpadding="0" cellspacing="0">
                          <tr>
                            <td></td>
                            <td >
                            
                            
                            <input name="checkcode" id="txtCode" runat="server" type="text" tabindex="3"/>
                            
                            </td>
                            <td ></td>
							<td>&nbsp;
							<asp:ImageButton ID="imgValCode" Width="60px" Height="20px" ImageUrl="~/ValeCode.aspx"  runat="server" /></td>
                          </tr>
                      </table>
                      </td>
                    </tr>
					
                    <tr>
                      <td colspan="3" align="center" class="f12">&nbsp;</td>
                    </tr>
                </table>
                </form>
                </td>
              </tr>
              <tr>
                <td height="20" align="center">
                <%--<img src="img/login_20.gif" width="122" height="20" alt="">--%>
                </td>
              </tr>
          </table></td>
        </tr>
      </table></td>
  </tr>
</table>
 


     
    </form>
</body>
</html>
