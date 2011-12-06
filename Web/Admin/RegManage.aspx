<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegManage.aspx.cs" Inherits="Admin_RegManage" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style=" font-family:微软雅黑; font-size:12px;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend style=" font-family:微软雅黑; font-size:16px; font-weight:bolder;">
        <asp:Label ID="lblUserType" runat="server" Text="注册管理"></asp:Label>
    </legend>
        <asp:Label ID="lblShow" runat="server" Text="暂无未审核的注册用户。"></asp:Label>
 <asp:DataList ID="DataList1" runat="server"  Width="100%" 
            onitemcommand="DataList1_ItemCommand" >
    <HeaderTemplate >
    <table style=" width:100%; border:solid 1px #EDEFEA; text-align:center; " >
    <tr style=" background-color:#98CDFF;">    
    <th>账号</th>
    <th>姓名</th>
    <th>密码</th>   
    <th>手机</th>
    <th>注册时间</th>
    <th>自动发送</th> 
    <th>账户状态</th>
    <th>操作</th>
    </tr>    
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td><%#Eval("account") %></td>
    <td><%#Eval("name") %></td>
    <td><%#Eval("pwd") %></td> 
    <td><%#Eval("mobile") %></td>
    <td><%#Convert.ToDateTime(Eval("startdate").ToString()).ToString("yyyy-MM-dd HH:mm:ss") %></td>
    <td><%#Eval("maxsendnum") %></td> 
    <td><%#Eval("state").ToString()=="2"?"已审核":"未审核" %> </td>
    <td>
    <asp:LinkButton ID="LinkButton2" style=" color:Blue;" OnClientClick="javascript:return confirm('你确定要快速开通此用户吗？')" CommandArgument='<%#Eval("id") %>' CommandName="pass" runat="server">[快速开通]</asp:LinkButton>
    <a style=" color:Blue;" href="UserDetail.aspx?id=<%#Eval("id") %>">[审核]</a>
    <asp:LinkButton style=" color:Blue;" ID="LinkButton1" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('确定要删除么？')" CommandName="delete" runat="server">[删除]</asp:LinkButton> 
    </td>
    </tr>    
    </ItemTemplate>    
    <AlternatingItemTemplate>
    <tr  style=" background-color:#EDF6FD;">
    <td><%#Eval("account") %></td>
    <td><%#Eval("name") %></td>
    <td><%#Eval("pwd") %></td> 
    <td><%#Eval("mobile") %></td>
    <td><%#Convert.ToDateTime(Eval("startdate").ToString()).ToString("yyyy-MM-dd HH:mm:ss") %></td>
    <td><%#Eval("maxsendnum") %></td> 
    <td><%#Eval("state").ToString()=="2"?"已审核":"未审核" %> </td>
    <td>
    <asp:LinkButton style=" color:Blue;" OnClientClick="javascript:return confirm('你确定要快速开通此用户吗？')" CommandArgument='<%#Eval("id") %>' CommandName="pass" runat="server">[快速开通]</asp:LinkButton>
    <a style=" color:Blue;" href="UserDetail.aspx?id=<%#Eval("id") %>">[审核]</a> 
    <asp:LinkButton style=" color:Blue;" ID="LinkButton1" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('删除此用户则对应的短信账户都将被删除，确定要删除么？')" CommandName="delete" runat="server">[删除]</asp:LinkButton> 
    </td>
    </tr> 
    </AlternatingItemTemplate>
    <FooterTemplate>
    </table>
    </FooterTemplate>
    
    </asp:DataList>

    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
         PageSize="20"
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
