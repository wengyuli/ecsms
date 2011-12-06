<%@ page language="C#" autoeventwireup="true" inherits="AccountInfo, App_Web_cvevhsvk" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 73%;
            height: 316px;
        }
        .style2
        {
            width: 106px;
        }
        .style3
        {
            width: 90px;
        }
        .style4
        {
            width: 117px;
        }
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">查看账户信息</legend>
   

    <div>

 
        <table class="style1" >
            <tr>
                <td align="right" class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td align="right" class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    用户类型：</td>
                <td class="style3">
                    <asp:Label ID="lblUserType" runat="server" Text="Label"></asp:Label>&nbsp;</td>
                <td align="right" class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    账号：</td>
                <td class="style3">
                    <asp:Label ID="lblAccount" runat="server" Text="Label"></asp:Label>&nbsp;</td>
                <td align="right" class="style4">
    姓名：</td>
                <td>
                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" class="style2">
    性别：</td>
                <td class="style3">
                    <asp:Label ID="lblSex" runat="server" Text="Label"></asp:Label></td>
                <td align="right" class="style4">
    电话：</td>
                <td>
                    <asp:Label ID="lblTelephone" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" class="style2">
    手机：</td>
                <td class="style3">
                    <asp:Label ID="lblMobile" runat="server" Text="Label"></asp:Label></td>
                <td align="right" class="style4">
    EMAIL：</td>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" class="style2">
    FAX：</td>
                <td class="style3">
                    <asp:Label ID="lblFax" runat="server" Text="Label"></asp:Label></td>
                <td align="right" class="style4">
    邮编：</td>
                <td>
                    <asp:Label ID="lblPostCode" runat="server" Text="Label"></asp:Label>
    
    
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
    QQ：</td>
                <td class="style3">
                    <asp:Label ID="lblQQ" runat="server" Text="Label"></asp:Label></td>
                <td align="right" class="style4">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style2">
    公司名称：</td>
                <td class="style3">
                    <asp:Label ID="lblCompanyName" runat="server" Text="Label"></asp:Label></td>
                <td align="right" class="style4">
    公司地址：</td>
                <td>
                    <asp:Label ID="lblCompanyAddress" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" class="style2">
    公司所在地：</td>
                <td class="style3">
                    <asp:Label ID="lblCity" runat="server" Text="Label"></asp:Label></td>
                <td align="right" class="style4">
    网站：</td>
                <td>
                    <asp:Label ID="lblWebsite" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    提醒额度：</td>
                <td class="style3">
                    <asp:Label ID="lblawoke" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="right" class="style4">
                    签名：</td>
                <td>
                    <asp:Label ID="lblsign" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" class="style2">
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
        <asp:Button ID="Button1" runat="server" PostBackUrl="~/Account/AccountEdit.aspx" Text="修改账户信息" />

                </td>
                <td>

        <asp:Button ID="btnModifyPwd" runat="server" onclick="btnModifyPwd_Click" 
            Text="修改密码" />

 
                </td>
            </tr>
        </table>
        </div>
  </fieldset>    

    </form>
</body>
</html>
