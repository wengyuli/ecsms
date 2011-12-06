<%@ page language="C#" autoeventwireup="true" inherits="Admin_UserDetail, App_Web_2qvchb0s" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">修改用户</legend>
        <br />
        <table class="style1">
            <tr>
                <td align="right" class="style2">
                    用户编号：</td>
                <td class="style3">
                    <asp:Label ID="lblUserId" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="right" class="style4">
                    用户类型：</td>
                <td>
                    <asp:Label ID="lblUserType" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    账户名称：</td>
                <td class="style3">
                    <asp:Label ID="lblAccount" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="right" class="style4">
                    姓名：</td>
                <td>
                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    性别：</td>
                <td class="style3">
                    <asp:Label ID="lblSex" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="right" class="style4">
                    电话：</td>
                <td>
                    <asp:Label ID="lblTel" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    手机：</td>
                <td class="style3">
                    <asp:Label ID="lblMobile" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="right" class="style4">
                    邮箱：</td>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    QQ：</td>
                <td class="style3">
                    <asp:Label ID="lblqq" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="right" class="style4">
                    有效证件号：</td>
                <td>
                    <asp:Label ID="lblExNumber" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    公司名称：</td>
                <td class="style3">
                    <asp:Label ID="lblcompanyname" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="right" class="style4">
                    公司地址：</td>
                <td>
                    <asp:Label ID="lblcompanyaddress" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    所在省市：</td>
                <td class="style3">
                    <asp:Label ID="lblcity" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="right" class="style4">
                    公司网站：</td>
                <td>
                    <asp:Label ID="lblwebsite" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    试用产品：</td>
                <td class="style3">
                    <asp:Label ID="lblTrySmsType" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="right" class="style4">
                    <asp:Label ID="lblUserMax" runat="server" Text="用户权限："></asp:Label></td>
                <td>
                    <asp:Label ID="lblUserMaxCount" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    签名：</td>
                <td align="left" class="style3">
                    <asp:Label ID="lblSign" runat="server" Text=""></asp:Label>
                    
                </td>
                <td align="right" class="style4">
                    签名开关：</td>
                <td align="left">
                    <asp:Label ID="lblSignLock" runat="server" Text=""></asp:Label>
                    
                </td>
            </tr>
            <tr align="right">
                <td class="style2">
                    消费提醒：</td>
                <td align="left" class="style3">
                    <asp:Label ID="lblAwokenum" runat="server" Text=""></asp:Label>
                </td>
                <td align="right" class="style4">
                    审核状态：</td>
                <td align="left">
                    <asp:Label ID="lblIsPass" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
    
                    &nbsp;</td>
                <td class="style4">
    
        <asp:Button ID="btnPass" runat="server" Text="审核通过" onclick="btnPass_Click" />
                </td>
                <td>
    
        <asp:Button ID="btnBack" runat="server" Text="返回" ValidationGroup="6"/>
                </td>
            </tr>
        </table>
        <br />
    
    </fieldset>
    </div>
    </form>
</body>
</html>
