<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegForbidWord.aspx.cs" Inherits="Admin_RegForbidWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend>用户名屏蔽词管理</legend>
    
        注册屏蔽词汇：<br />
        <asp:TextBox ID="txtKeys" runat="server" Height="159px" TextMode="MultiLine" 
            Width="100%"></asp:TextBox>
        <br />
        <asp:Button ID="btnSave" runat="server" Text="更新" onclick="btnSave_Click" />
    
    </fieldset>
    </div>
    </form>
</body>
</html>
