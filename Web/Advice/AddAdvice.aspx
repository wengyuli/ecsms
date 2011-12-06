<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAdvice.aspx.cs" Inherits="Advice_AddAdvice" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 
    <style type="text/css">
        .style2
        {
            width: 422px;
        }
    </style>
 
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend>投诉建议</legend>
    
    <table cellSpacing="0" cellPadding="0" border="0" 
            style="height: 267px; width: 56%; margin-right: 0px">
	<tr>
	<td align="left" class="style3">
		<br />
        <br />
        温馨提示:您可以对短信平台使用过程中遇到的问题或者服务<br />
        <br />
        提出建议或者投诉，我们会及时处理，谢谢！<br />
        <br />
		投诉建议内容
	:</td></tr>
	<tr>
	<td height="25" align="left" class="style2">
		<asp:TextBox id="txtContent" runat="server" Width="397px" Height="155px" 
            TextMode="MultiLine" style="margin-left: 0px"></asp:TextBox>
	</td>
	    </tr>
	<tr>
	<td height="25" align="left" class="style2">
		例：【&#39;投诉&#39;客服1&#39;，投诉内容:客户服务的不满意。】</td>
	    </tr>
	<tr>
	<td height="25" align="right">
       
        <asp:Label ID="lblUserId" runat="server" Visible="false"></asp:Label>
        <asp:Button ID="btnAdd" runat="server" Text="提交" OnClick="btnAdd_Click" 
            Width="65px" ></asp:Button>
	    <asp:Button ID="Button1" runat="server" PostBackUrl="~/DownLoads/DownLoad.aspx" 
            Text="返回" Width="65px" />
</td>
	    </tr>
</table>
</fieldset>
    </div>
    </form>
</body>
</html>
