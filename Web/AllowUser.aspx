<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AllowUser.aspx.cs" Inherits="AllowUser" %>

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
            width: 90px;
        }
        .style3
        {
            width: 256px;
        }
        .style4
        {
            width: 69px;
        }
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
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
                    账户名称：</td>
                <td>
                    <asp:Label ID="lblAccount" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    用户类型：</td>
                <td class="style3">
                    <asp:Label ID="lblUserType" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="right" class="style4">
                    归属：</td>
                <td>
                    <asp:Label ID="lblUpUser" runat="server" Text=""></asp:Label>
                    <asp:LinkButton ID="linkChange"  style=" color:Red;" runat="server">[更改]</asp:LinkButton>
                     
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    姓名：</td>
                <td class="style3">
                    <asp:TextBox ID="lblName" runat="server" Text="Label"></asp:TextBox>
                </td>
                <td align="right" class="style4">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnRePwd" runat="server" Visible="false" Text="重置密码" onclick="btnRePwd_Click" />
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
                    <asp:TextBox ID="lblTel" runat="server" Text="Label"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    手机：</td>
                <td class="style3">
                    <asp:TextBox ID="lblMobile" runat="server" Text="Label"></asp:TextBox>
                </td>
                <td align="right" class="style4">
                    邮箱：</td>
                <td>
                    <asp:TextBox ID="lblEmail" runat="server" Text="Label"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    QQ：</td>
                <td class="style3">
                    <asp:TextBox ID="lblqq" runat="server" Text="Label"></asp:TextBox>
                </td>
                <td align="right" class="style4">
                    证件号：</td>
                <td>
                    <asp:Label ID="lblCardNumber" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    公司名称：</td>
                <td class="style3">
                    <asp:Label ID="lblcompanyname" runat="server" Text=""></asp:Label>
                </td>
                <td align="right" class="style4">
                    公司地址：</td>
                <td>
                    <asp:Label ID="lblcompanyaddress" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    所在省市：</td>
                <td class="style3">
                    <asp:Label ID="lblcity" runat="server" Text=""></asp:Label>
                </td>
                <td align="right" class="style4">
                    公司网站：</td>
                <td>
                    <asp:Label ID="lblwebsite" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    试用产品：</td>
                <td class="style3">
                    <asp:Label ID="lblTrySmsType" runat="server" Text="Label"></asp:Label>
                </td>
                <td align="right" class="style4">
                    <asp:Label ID="lblUserMaxCount" runat="server" Text="用户权限："></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtMaxCount" runat="server" Width="100px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                        ControlToValidate="txtMaxCount" ErrorMessage="权限应为正整数" 
                        ValidationExpression="^[1-9]\d*$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    审核状态：</td>
                <td align="left" class="style3">
                    <asp:RadioButtonList ID="rbtnAllow" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="未审核" Value="0"  ></asp:ListItem>
                    <asp:ListItem Text="审核未通过" Value="1"></asp:ListItem>
                    <asp:ListItem Text="审核通过" Value="2"></asp:ListItem>
                    </asp:RadioButtonList>
                    
                </td>
                <td align="right" class="style4">
                    签名开关：</td>
                <td align="left">
                    <asp:RadioButtonList ID="rbtnSign" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1">开放</asp:ListItem>
                        <asp:ListItem Value="0">锁定</asp:ListItem>
                    </asp:RadioButtonList>
                    
                </td>
            </tr>
            <tr align="right">
                <td class="style2">
                    签名：</td>
                <td align="left" class="style3">
                    <asp:TextBox ID="txtSign" runat="server"></asp:TextBox>例：商信宝</td>
                <td align="right" class="style4">
                    消费提醒：</td>
                <td align="left">
                    <asp:TextBox ID="txtAwokeNum" runat="server"></asp:TextBox>设置为0则为关闭提醒
                    
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style3">
    
                    &nbsp;</td>
                <td class="style4">
    
        <asp:Button ID="btnPass" runat="server" Text="保存" onclick="btnPass_Click" />
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
