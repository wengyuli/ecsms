<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Admin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <TITLE>管理员登陆</TITLE>
<META http-equiv=Content-Type content="text/html; charset=gb2312">
<LINK href="style.css" type=text/css rel=stylesheet>
<style>
	iframe.myFrame{width: 0px;height:0px;display: none;}
</style>
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
</head>
<body style=" background-color:White; font-size:12px; font-family:微软雅黑;" bgColor=#ffffff leftMargin=0 topMargin=0 marginheight="0" marginwidth="0">
    <form id="form1" runat="server">
    <div>
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
        <TABLE cellSpacing=0 cellPadding=0 align=center border=0 style="height: 47px">
  <TBODY>

  <TR>
    <TD height=25>
      <P align=right>用户名：</P></TD>
    <TD height=25>
      <P align=left><FONT color=#131415>
      
      <input class=smallInput tabindex=1 id="username" 
      style="BORDER-TOP-STYLE: none; BORDER-BOTTOM: rgb(204,204,204) 1px solid; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; width: 80px;" 
      maxLength=40 size=15 name=dlmc runat="server"/> 
      </FONT></P></TD>
    <TD align=middle width=70 rowSpan=2>
      <P>
          <asp:ImageButton TabIndex=3 ImageUrl="login.gif" ID="ImageButton1" 
              OnClientClick=" return chklogin()" runat="server" 
              onclick="ImageButton1_Click" />
       </P></TD></TR>
  <TR>
    <TD height=25>
      <P align=right>密 &nbsp;码：</P></TD>
    <TD height=25>
      <P align=left><FONT color=#131415>
      
      <input class=smallInput tabindex=2 id="password"
      style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; BORDER-LEFT: 0px; BORDER-BOTTOM: rgb(204,204,204) 1px solid; width: 80px;" 
      type=password maxLength=40 size=15 name=password runat="server"/>
      
      </FONT> 
</P></TD></TR></TBODY></TABLE>
    </div>
    </form>
</body>
</html>
