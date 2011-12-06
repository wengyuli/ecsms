<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserManage.aspx.cs" Inherits="UserManage" %>
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
    <legend style="font-size:14px; font-weight:bold;">
        <asp:Label ID="lblTitle" runat="server" Text="用户管理"></asp:Label>
     
    
    </legend>    
    
        <asp:Button ID="btnNewAgent" Visible="false" PostBackUrl="~/AgentAdd.aspx" runat="server" Text="新增代理" />
        <asp:Button ID="btnNewUser" Visible="false" PostBackUrl="~/AddUser.aspx" runat="server" Text="新增用户" />
        总共：【<asp:Label ID="lblTotalUserCount" runat="server" Text="0"></asp:Label>】<asp:TextBox 
            ID="txtSearchText" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="查询" />
&nbsp;<asp:DataList ID="DataList1" runat="server"  Width="100%" 
            onitemcommand="DataList1_ItemCommand">
    <HeaderTemplate >
    <table style=" width:100%; border:solid 1px #EDEFEA; text-align:center; " >
    <tr style=" background-color:#98CDFF;">        
    <th>账号</th>
    <th>姓名</th>  
    <th>电话</th> 
    <th>手机</th>
    <th>余额</th>
    <th>归属</th>
    <th>注册时间</th>
    
    <th>用户类型</th>
    <th>账户状态</th>
    <th>操    作</th>
    </tr>    
    </HeaderTemplate>
    <ItemTemplate>
    <tr>    
    <td title='<%#Eval("account").ToString()%>'><%#Eval("account").ToString().Length > 6 ? Eval("account").ToString().Substring(0,6) : Eval("account").ToString()%></td>
    <td><%#Eval("name") %></td>
    <td><%#Eval("telephone") %></td>
    <td><%#Eval("mobile") %></td>
    
    <td title='<%#Public.GetUserLeaveSms(int.Parse(Eval("id").ToString()))%>'><%#Public.GetUserLeaveSms(int.Parse(Eval("id").ToString())).Length > 6 ? Public.GetUserLeaveSms(int.Parse(Eval("id").ToString())).Substring(0, 6) + ".." : Public.GetUserLeaveSms(int.Parse(Eval("id").ToString()))%></td>
    <td><%#Public.GetUserAccount(int.Parse(Eval("userid").ToString())) %></td>
    <td><%#Convert.ToDateTime(Eval("startdate").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
    
    <td><%# GetRoleName(int.Parse(Eval("role").ToString()))%></td> 
    <td><%#Eval("state").ToString()=="2"?"已审核":"未审核" %> </td>
    <td>
      <asp:LinkButton ID="linkPass" style=" color:Blue;" PostBackUrl='<%#"AllowUser.aspx?id="+Eval("id") %>' runat="server">[修改]</asp:LinkButton>
    <asp:LinkButton ID="LinkButton1" style=" color:Blue;" PostBackUrl='<%#"~/sms/GiveSms.aspx?id="+Eval("id") %>' runat="server">[充值]</asp:LinkButton>
        <asp:LinkButton ID="lbtnRePwd" style=" color:Blue;" OnClientClick="javascript:return confirm('你确定要重置此用户密码吗？')" CommandArgument='<%#Eval("id") %>' CommandName="repwd" runat="server">[密码重置]</asp:LinkButton>
    </td>
    </tr>    
    </ItemTemplate>
    <AlternatingItemTemplate>
    <tr style=" background-color:#EDF6FD;">    
<td title='<%#Eval("account").ToString()%>'><%#Eval("account").ToString().Length > 6 ? Eval("account").ToString().Substring(0,6) : Eval("account").ToString()%></td>
    <td><%#Eval("name") %></td>
    <td><%#Eval("telephone") %></td>
    <td><%#Eval("mobile") %></td>
    
    <td title='<%#Public.GetUserLeaveSms(int.Parse(Eval("id").ToString()))%>'><%#Public.GetUserLeaveSms(int.Parse(Eval("id").ToString())).Length > 6 ? Public.GetUserLeaveSms(int.Parse(Eval("id").ToString())).Substring(0, 6) + ".." : Public.GetUserLeaveSms(int.Parse(Eval("id").ToString()))%></td>
    <td><%#Public.GetUserAccount(int.Parse(Eval("userid").ToString())) %></td>
     
    <td><%#Convert.ToDateTime(Eval("startdate").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
    
    <td><%# GetRoleName(int.Parse(Eval("role").ToString()))%></td> 
    <td><%#Eval("state").ToString()=="2"?"已审核":"未审核" %> </td>
    <td>
    <asp:LinkButton ID="linkPass" style=" color:Blue;" PostBackUrl='<%#"AllowUser.aspx?id="+Eval("id") %>' runat="server">[修改]</asp:LinkButton>
    <asp:LinkButton ID="LinkButton1" style=" color:Blue;" PostBackUrl='<%#"~/sms/GiveSms.aspx?id="+Eval("id") %>' runat="server">[充值]</asp:LinkButton>
        <asp:LinkButton ID="lbtnRePwd" style=" color:Blue;" OnClientClick="javascript:return confirm('你确定要重置此用户密码吗？')" CommandArgument='<%#Eval("id") %>' CommandName="repwd" runat="server">[密码重置]</asp:LinkButton>
    </td>
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
