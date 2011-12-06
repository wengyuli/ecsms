<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script type="text/javascript">
    function onload() {
        window.parent.location = "right.aspx";
    }
</script>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div style="height: 193px; width: 379px; margin-left: 261px; margin-top: 162px;">
    
        <br />
        <asp:Button ID="Button1" runat="server" PostBackUrl="~/User/Login.aspx" Text="客户登录" />
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" PostBackUrl="~/agent/Login.aspx" Text="代理登录" />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" PostBackUrl="~/Admin/1-2-4-5/6-;-7/Login.aspx" Text="管理员登录" />
        <br />
        <br />
        
        </div>
    </form>
</body>
</html>
