<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlatMax.aspx.cs" Inherits="Admin_PlatMax" %>

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
            width: 133px;
        }
    </style>
</head>
<body style=" font-family:微软雅黑; font-size:12px;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">平台权限设置</legend>
    
    
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
                                        当前平台权限为:</td>
                <td>
                    <asp:TextBox ID="txtPlatCount" runat="server" Width="115px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    用户默认权限：</td>
                <td>
                    <asp:TextBox ID="txtUserMax" runat="server" Width="115px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
        <asp:Button ID="btnSave" runat="server"  
            OnClientClick="javascript:return confirm('你确定更新权限设置么')" Text="更新" 
            onclick="btnSave_Click" />
                </td>
            </tr>
        </table>
        <br />
    
    
    </fieldset>
    </div>
    </form>
</body>
</html>
