<%@ page language="C#" autoeventwireup="true" inherits="TestWebservice, App_Web_yfwijek1" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="Repeater1" runat="server">
        <HeaderTemplate>
        <table>
        <tr><td>姓名</td><td>年龄</td></tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr><td><%#Eval("name") %></td><td><%#Eval("age") %></td></tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
        <tr><td><%#Eval("name") %></td><td><%#Eval("age") %></td></tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
        </table>
        </FooterTemplate>
        </asp:Repeater>













    </div>
    </form>
</body>
</html>
