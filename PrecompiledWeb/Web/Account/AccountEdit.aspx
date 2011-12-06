<%@ page language="C#" autoeventwireup="true" inherits="AccountEdit, App_Web_cvevhsvk" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style3
        {
            width: 117px;
        }
        .style4
        {
            width: 150px;
        }
        .style5
        {
            width: 73px;
        }
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">修改账户信息</legend>
    
 
    <table cellSpacing="0"  cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" align="right" class="style3">
		&nbsp;</td>
	<td height="25" align="left" class="style4">
		&nbsp;</td>
	<td height="25" align="right" class="style5">
		&nbsp;</td>
	<td height="25" width="*" align="left">
		&nbsp;</td></tr>
	<tr>
	<td height="25" align="right" class="style3">
		账号：
	</td>
	<td height="25" align="left" class="style4">
		<asp:TextBox id="txtAccount" Enabled="false" runat="server" Width="150px"></asp:TextBox>
	</td>
	<td height="25" align="right" class="style5">
		&nbsp;</td>
	<td height="25" width="*" align="left">
		&nbsp;</td></tr>
	<tr>
	<td height="25" align="right" class="style3">
		角色：
	</td>
	<td height="25" align="left" class="style4">
		<asp:TextBox id="txtRole" Enabled="false" runat="server" Width="150px"></asp:TextBox>
	</td>
	<td height="25" align="right" class="style5">
		审核状态：
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtState" Enabled="false" runat="server" Width="126px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" class="style3">
		&nbsp;</td>
	<td height="25" align="left" class="style4">
		&nbsp;</td>
	<td height="25" align="right" class="style5">
		&nbsp;</td>
	<td height="25" width="*" align="left">
		&nbsp;</td></tr>
	<tr>
	<td height="25" align="right" class="style3">
		真实姓名：</td>
	<td height="25" align="left" class="style4">
		<asp:TextBox id="txtName" runat="server" Width="150px"></asp:TextBox>
	</td>
	<td height="25" align="right" class="style5">
		有效证件号：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtYxzj" runat="server"></asp:TextBox>
        </td></tr>
	<tr>
	<td height="25" align="right" class="style3">
		&nbsp;性别：
	</td>
	<td height="25" align="left" class="style4">
        <asp:DropDownList ID="ddlSex" runat="server">
        <asp:ListItem Text="男" Value="0"></asp:ListItem>
        <asp:ListItem Text="女" Value="1"></asp:ListItem>
        </asp:DropDownList>
	</td>
	<td height="25" align="right" class="style5">
		固定电话：
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtTelephone" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" class="style3">
		手机：
	</td>
	<td height="25" align="left" class="style4">
		<asp:TextBox id="txtMobile" runat="server" Width="150px"></asp:TextBox>
	</td>
	<td height="25" align="right" class="style5">
		电子邮件：
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtEmail" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" class="style3">
		传真：
	</td>
	<td height="25" align="left" class="style4">
		<asp:TextBox id="txtFax" runat="server" Width="150px"></asp:TextBox>
	</td>
	<td height="25" align="right" class="style5">
		邮编：
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtPostCode" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" class="style3">
		QQ：
	</td>
	<td height="25" align="left" class="style4">
		<asp:TextBox id="txtQQ" runat="server" Width="150px"></asp:TextBox>
	</td>
	<td height="25" align="right" class="style5">
		&nbsp;</td>
	<td height="25" width="*" align="left">
		&nbsp;</td></tr>
	<tr>
	<td height="25" align="right" class="style3">
		公司名称：
	</td>
	<td height="25" align="left" class="style4">
		<asp:TextBox id="txtCompanyName" runat="server" Width="200px"></asp:TextBox>
	</td>
	<td height="25" align="right" class="style5">
		所在省市：</td>
	<td height="25" width="*" align="left">
        <asp:DropDownList ID="ddlProvince" AutoPostBack="true" runat="server" 
            onselectedindexchanged="ddlProvince_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="ddlCity" runat="server">
        </asp:DropDownList>
	</td></tr>
	<tr>
	<td height="25" align="right" class="style3">
		公司详细地址：
	</td>
	<td height="25" align="left" class="style4">
		<asp:TextBox id="txtCompanyAddress" runat="server" Width="200px"></asp:TextBox>
	</td>
	<td height="25" align="right" class="style5">
		公司网址：
	</td>
	<td height="25" width="*" align="left">
		<asp:TextBox id="txtWebSite" runat="server" Width="200px"></asp:TextBox>
	</td></tr>
	<tr>
	<td height="25" align="right" class="style3">
		&nbsp;</td>
	<td height="25" align="left" class="style4">
		&nbsp;</td>
	<td height="25" align="right" class="style5">
		&nbsp;</td>
	<td height="25" width="*" align="left">
		&nbsp;</td></tr>
	<tr>
	<td height="25" align="right" class="style3">
		短信提醒额度：
	</td>
	<td height="25" align="left" class="style4">
		<asp:TextBox id="txtAwokeNum" runat="server" Width="102px"></asp:TextBox><br />
	    0为关闭</td>
	<td height="25" align="right" class="style5">
		签名：</td>
	<td height="25" width="*" align="left">
		<asp:TextBox ID="txtSign" runat="server" Width="127px"></asp:TextBox>
	    完整签名如：商信宝</td></tr>
	<tr>
	<td height="25" align="center" class="style3">
		&nbsp;</td>
	<td style=" color:Red;" height="25" align="left" class="style4">
		短信提醒额度指一次发送的条数超出某个值后短信平台会提醒用户</td>
	<td height="25" align="left" class="style5">
		&nbsp;</td>
	<td style=" color:Red;" height="25" width="*" align="left">
		签名是指在短信后面的后缀，一般附在短信内容的后面。如：春节好.....【商信宝】</td></tr>

	<td height="25" colspan="4" align="center" style="">

	    代理请务必完善所有个人资料，签名暂可为空</td>
	    </tr>
        <tr>

	<td height="25" colspan="4" align="center">
		<asp:Button ID="btnAdd" runat="server" Text="提交" OnClick="btnAdd_Click" ></asp:Button>

	    <asp:Button ID="Button1" runat="server" 
            PostBackUrl="~/Account/AccountInfo.aspx" Text="返回" />

	        </td>
	    </tr>
</table>
</fieldset>
    </div>
    </form>
</body>
</html>
