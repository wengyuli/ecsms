<%@ page language="C#" autoeventwireup="true" inherits="FindPwd, App_Web_cvevhsvk" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 199px;
        }
        .style3
        {
            width: 199px;
            height: 19px;
        }
        .style4
        {
            height: 19px;
        }
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div style=" position:relative; width:419px; height:307px; ">
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">找回密码</legend>
        <br />
    密码找回
 
        <table class="style1">
            <tr>
                <td align="right" class="style2">
                    &nbsp;</td>
                <td>
        <asp:Label ID="lblUserId" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3" align="right">
                    用户名:</td>
                <td class="style4">
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="2">
        <asp:Button ID="Button1" runat="server" Text="找回密码" onclick="Button1_Click" />
                </td>
            </tr>
        </table>
        <br />
        找回密码这个功能将会发送您的密码到您注册时用的手机上！<br />
    </fieldset>
    
    
    </div>
    </form>
</body>
</html>
