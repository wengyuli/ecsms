<%@ page language="C#" autoeventwireup="true" inherits="PwdModify, App_Web_cvevhsvk" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 118px;
            margin-left: 31px;
        }
        .style2
        {
            width: 123px;
        }
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div style="height: 222px; width: 100%">
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">个人密码修改</legend>
    
 
    
        <table class="style1">
            <tr>
                <td align="right" class="style2">
    
        原密码:</td>
                <td>
                    <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
        新密码:</td>
                <td>
                    <asp:TextBox ID="txtNewPwd1" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
        重复新密码:</td>
                <td>
                    <asp:TextBox ID="txtNewPwd2" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="修改" />
                    <asp:Button ID="btnCancel" runat="server" 
                        PostBackUrl="~/Account/AccountInfo.aspx" Text="返回" />
                </td>
            </tr>
        </table>
        </fieldset>
        <fieldset runat="server" id="divadminpwd" visible="false">
        <legend style="font-size:14px; font-weight:bold;">删除密码修改</legend>
        <table class="style1">
            <tr>
                <td align="right" class="style2">
    
        原密码:</td>
                <td>
                    <asp:TextBox ID="txtDelPwd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
        新密码:</td>
                <td>
                    <asp:TextBox ID="txtDelPwd1" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
        重复新密码:</td>
                <td>
                    <asp:TextBox ID="txtDelPwd2" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnModify" runat="server" Text="修改" onclick="btnModify_Click" />

                </td>
            </tr>
        </table>
        </fieldset>
    </div>
    </form>
</body>
</html>
