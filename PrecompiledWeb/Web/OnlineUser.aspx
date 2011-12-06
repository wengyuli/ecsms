<%@ page language="C#" autoeventwireup="true" inherits="OnlineUser, App_Web_yfwijek1" stylesheettheme="default" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">在线用户列表</legend>

    当前在线用户共有【<asp:Label ID="lblCount" runat="server" Text="0"></asp:Label>】个<br />
 
    <asp:DataList ID="DataList1" runat="server" Width="100%">
    <HeaderTemplate >
    <table style=" width:100%; border:solid 1px #EDEFEA; text-align:center; " >
    <tr style=" background-color:#98CDFF;">    
    <th>编    号</th>
    <th>用户类型</th>
    <th>用户账号</th>
    <th>用户姓名</th>  
    <th align="left">账户余额</th>
    <th>公司名称</th>
    <th>账户状态</th>
    </tr>    
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td><%#Eval("id") %></td>
    <td><%#Eval("role").ToString()=="2"?"集团用户":"个人用户" %></td>
    <td><%#Eval("account") %></td>
    <td><%#Eval("name") %></td>
    <td align="left"><%# Public.GetUserLeaveSms( int.Parse(Eval("id").ToString())) %></td>
    <td><%#Eval("companyname").ToString().Length > 10 ? Eval("companyname").ToString().Substring(0, 10) + "..." : Eval("companyname").ToString()%></td>
    <td>
        <asp:Label ID="lblPass" runat="server" Text='<%#Eval("state").ToString()=="2"?"已审核":"未审核" %>'></asp:Label> </td>
    <td>
    </tr>    
    </ItemTemplate>
     <AlternatingItemTemplate>
    <tr style=" background-color:#EDF6FD;">    
<td><%#Eval("id") %></td>
    <td><%#Eval("role").ToString()=="2"?"集团用户":"个人用户" %></td>
    <td><%#Eval("account") %></td>
    <td><%#Eval("name") %></td>
    <td align="left"><%# Public.GetUserLeaveSms( int.Parse(Eval("id").ToString())) %></td>
    <td><%#Eval("companyname") %></td>
    <td>
        <asp:Label ID="lblPass" runat="server" Text='<%#Eval("state").ToString()=="2"?"已审核":"未审核" %>'></asp:Label> </td>
    <td>
    </tr> 
    </AlternatingItemTemplate>
    <FooterTemplate>
    </table>
    </FooterTemplate>
    
    </asp:DataList>

    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
         PageSize="10"
         FirstPageText="首页"
         LastPageText="末页"
         NextPageText="下一页"
         PrevPageText="上一页" 
         Font-Size="12px"          
         OnPageChanging="AspNetPager1_PageChanging">
    </webdiyer:AspNetPager>
    </fieldset>
    
    </div>
    </form>
</body>
</html>
