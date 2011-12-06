<%@ page language="C#" autoeventwireup="true" inherits="AgentAdd, App_Web_yfwijek1" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 321px;
        }
        .style2
        {
            height: 26px;
        }
        .style3
        {
            width: 133px;
        }
        .style4
        {
            height: 26px;
            width: 133px;
        }
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">添加代理</legend>
    
    
        <table class="style1">
            <tr>
                <td align="right" class="style3">
                    省市：</td>
                <td>
                    <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlProvince_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlCity" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    账户：</td>
                <td>
                    <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
                    <asp:Button ID="Button1" runat="server" Text="检查是否有重名" 
                        onclick="Button1_Click" />4-15个字<asp:Label ID="lblShow" runat="server" 
                        Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    密码：</td>
                <td>
                    <asp:TextBox ID="txtPwd1" TextMode="Password" runat="server"></asp:TextBox>
                6~15个字符</td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    确认密码：</td>
                <td>
                    <asp:TextBox ID="txtPwd2" TextMode="Password" runat="server"></asp:TextBox>
                6~15个字符</td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    手机号：</td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                    如：13899998888</td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    电话号码：</td>
                <td>
                    <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                    如：037168888888</td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    短信签名：</td>
                <td>
                    <asp:TextBox ID="txtSign" runat="server" Width="128px"></asp:TextBox>
                    例:【商信宝】</td>
            </tr>
            <tr>
                <td align="right" class="style4">
                    公司：</td>
                <td class="style2">
                    <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    姓名：</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    有效证件号：</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>身份证号码</asp:ListItem>
                        <asp:ListItem>企业工商注册号</asp:ListItem>
                    </asp:DropDownList>
&nbsp; <asp:TextBox ID="TextBox1" runat="server" Width="193px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    <br />
                </td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="添加" onclick="btnAdd_Click" />
                    <asp:Button ID="btnBack" ValidationGroup="2" runat="server"
                        Text="返回" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    
    </fieldset>
    
    
    </div>
    </form>
</body>
</html>
