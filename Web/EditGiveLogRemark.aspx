<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditGiveLogRemark.aspx.cs" Inherits="EditGiveLogRemark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改充值备注</title>
    <script type="text/javascript">
        function editOK(str) {
            alert("充值备注已经成功改为【" + str + "】，请在刷新页面后查看最新备注。");
            //window.opener.window.location.reload();
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        编号：<asp:Label ID="lblID" runat="server" Text=""></asp:Label>
        <br />
        原 备 注：<asp:Label ID="lblRemark" runat="server" Text=""></asp:Label>
        
        <br />
        修 改 为：<br />
        <asp:TextBox ID="txtRemark" runat="server" Width="315px" Height="84px" 
            TextMode="MultiLine"></asp:TextBox>
        <br />
        （此备注下级用户可见）<br />
        <span style=" font-size:12px; color:Red;">暂未收款，现金付讫，活动赠送，支付宝款，<br />
        银行转款，记帐后付，它因充值，平台扣值等</span> <br />
        <asp:Button ID="btnSave" runat="server" Text="更新备注" onclick="btnSave_Click" />
        <asp:Button ID="Button2" runat="server" OnClientClick=" return window.close();" Text="关闭窗口" />
    
    </div>
    </form>
</body>
</html>
