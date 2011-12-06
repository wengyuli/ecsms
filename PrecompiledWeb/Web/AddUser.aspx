<%@ page language="C#" autoeventwireup="true" inherits="AddUser, App_Web_yfwijek1" stylesheettheme="default" %>

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
            width: 125px;
        }
    </style>

    <script src="JavaScript/Validator.js" type="text/javascript"></script>
    <script type="text/javascript">
        function check() {
            var account = document.getElementById("txtAccount").value;
            var pwd1 = document.getElementById("txtPwd1").value;
            var pwd2 = document.getElementById("txtPwd2").value;
            var mobile = document.getElementById("txtMobile").value;
            var tel = document.getElementById("txtTel").value;
            var card = document.getElementById("txtCardNumber").value;
            
            if (account == "") {
                alert("请输入用户名。");
                return false;
            } else if (account.length < 2 || account.length > 15) {
            alert("用户名长度在2-15之间。");
            return false;
            }

            if (pwd1 != pwd2) {
                alert("两次输入密码不一致。");
                return false;
            }

            if (!regIsPhone(mobile)) {
                alert("请输入正确的手机号，如：13899998888");
                return false;
            }

            if (card == "") {
                alert("请填入有效证件号码。");
                return false;
            }
            
            
        }
    </script>
    
</head>
<body style=" font-family:微软雅黑; font-size:12px;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend>新增用户</legend>
    
        <table class="style1">
            <tr>
                <td align="right" class="style2">
                    用户类型：</td>
                <td>
                    <asp:RadioButtonList ID="rbtnRole" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True" Text="集团用户" Value="2"></asp:ListItem>
                        <asp:ListItem Text="个人用户" Value="3"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
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
                <td align="right" class="style2">
                    用户名：</td>
                <td>
                    <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
                    4-15个字<asp:Button ID="btnCheck" runat="server" Text="检查是否有重名" 
                        onclick="btnCheck_Click" />
                    <asp:Label ID="lblShow" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    输入密码：</td>
                <td>
                    <asp:TextBox ID="txtPwd1" TextMode="Password"  runat="server"></asp:TextBox>
                6~15个字符
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    确认密码：</td>
                <td>
                    <asp:TextBox ID="txtPwd2" TextMode="Password" runat="server"></asp:TextBox>
                6~15个字符</td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    手机号：</td>
                <td>
                    <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                    如：13899998888</td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    电话：</td>
                <td>
                    <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                    如：037168888888</td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    公司名称：</td>
                <td>
                    <asp:TextBox ID="txtCompany" runat="server"></asp:TextBox>
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
                <td align="right" class="style2">
                    有效证件号：</td>
                <td>
                    <asp:DropDownList ID="ddlcard" runat="server">
                        <asp:ListItem>身份证号码</asp:ListItem>
                        <asp:ListItem>企业工商注册号</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox>
                    身份证/企业工商注册号</td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    签名：</td>
                <td>
                    <asp:TextBox ID="txtSign" runat="server"></asp:TextBox>
                    如：【商信宝】</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" OnClientClick="return check()" runat="server" Text="保存" onclick="btnSave_Click" />
                    <asp:Button ID="btnBack" PostBackUrl="" runat="server" Text="返回" />
                </td>
            </tr>
        </table>
    
    </fieldset>
    </div>
    </form>
</body>
</html>
