<%@ page language="C#" autoeventwireup="true" inherits="DownLoads_DownPriceFiles, App_Web_phsuf21d" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblId" runat="server" Text="0" Visible="false"></asp:Label>
        
        
        <br />
        <table class="style1">
            <tr>
                <td class="style2" colspan="2">
        下载资料信息：</td>
            </tr>
            <tr>
                <td class="style5">
        软件名称：</td>
                <td>
                    <asp:Label ID="lblRemark" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3" valign="top">
        扣费说明：</td>
                <td class="style4" valign="top">
                    <asp:Label ID="lblPrice" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6" valign="top">
                    您的余额：</td>
                <td class="style7" valign="top">
                    <asp:Label ID="lblLeaveNum" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style3" valign="top">
                    扣值产品：</td>
                <td class="style4" valign="top">
                    <asp:DropDownList ID="ddlPro" runat="server">
                        <asp:ListItem Value="A" Selected="True">3G直告</asp:ListItem>
                        <asp:ListItem Value="B">企信通</asp:ListItem>
                        <asp:ListItem Value="C">会员通</asp:ListItem>
                        <asp:ListItem Value="D">准告</asp:ListItem>
                        <asp:ListItem Value="E">闪信</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3" valign="top">
                    &nbsp;</td>
                <td class="style4" valign="top">
                    <asp:Button ID="btnDown" runat="server" Text="下载" onclick="btnDown_Click" />
                </td>
            </tr>
        </table>
        
        
        <br />
        <br />
        <asp:Label ID="lblDownLink" Font-Size="20px" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        
        
    </div>
    </form>
</body>
</html>
