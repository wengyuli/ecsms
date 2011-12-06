<%@ page language="C#" autoeventwireup="true" inherits="BlackNumbers, App_Web_yfwijek1" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
        <fieldset>
    <legend style="font-size:14px; font-weight:bold;">浏览黑名单</legend>
            <table class="style1">
                <tr>
                    <td align="right" valign="top">
                        黑名单:</td>
                    <td>
            <asp:TextBox ID="txtBlackNumbers" runat="server" Height="153px" TextMode="MultiLine" 
                            Width="293px"></asp:TextBox>
        
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="更新" />
                    </td>
                </tr>
            </table>
        
        </fieldset> 
    </div>
    </form>
</body>
</html>
