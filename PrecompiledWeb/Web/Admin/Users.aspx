<%@ page language="C#" autoeventwireup="true" inherits="Admin_Users, App_Web_2qvchb0s" stylesheettheme="default" %>
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
    <legend style=" font-family:微软雅黑; font-size:16px; font-weight:bolder;">
        <asp:Label ID="lblUserType" runat="server" Text=""></asp:Label>
    </legend>
    
<table width="100%">
            <tr>
                <td>
   <asp:Button ID="Button1" runat="server" PostBackUrl="~/AgentAdd.aspx" Text="添加代理" />
                    <asp:Button ID="Button2" runat="server" PostBackUrl="~/AddUser.aspx" Text="添加客户" />
        <asp:TextBox ID="txtType" Visible="false" runat="server"></asp:TextBox>
                    <asp:TextBox ID="txtKeyWord" runat="server"></asp:TextBox>
                    <asp:Button ID="btnQueryUser" runat="server" Text="查找" 
                        onclick="btnQueryUser_Click" />
                    <asp:Button ID="btnExport" runat="server" Text="导出" onclick="btnExport_Click" />
                </td>
                <td align="right">
                    <span style=" color:Red;">   删除/导出密码:</span><asp:TextBox TextMode="Password" ID="txtDeletePwd" runat="server"></asp:TextBox>
       
                </td>
            </tr> 
        </table> 
        共有【<asp:Label ID="lblCount" runat="server" Text="0"></asp:Label>】条记录
 <asp:DataList ID="DataList1" runat="server"  Width="100%" 
            onitemcommand="DataList1_ItemCommand">
    <HeaderTemplate >
    <table style=" width:100%; border:solid 1px #EDEFEA; text-align:center; " >
    <tr style=" background-color:#98CDFF;">    
    <th>账号</th>
    <th>姓名</th>
    <th>密码</th>   
    <th>手机</th>
    <th>余额</th>
    <th>归属</th>
    <th>用户级别</th>
    <th>注册时间</th>
    <th>自动发送</th> 
    <th>账户状态</th>
    <th>锁定</th>
    <th>操作</th>
    </tr>    
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td title='<%#Eval("account").ToString()%>'><%#Eval("account").ToString().Length > 6 ? Eval("account").ToString().Substring(0, 6)+".." : Eval("account").ToString()%></td>
    <td><%#Eval("name") %></td>
    <td><%#Eval("pwd") %></td> 
    <td><%#Eval("mobile") %></td>
    <td title='<%#Public.GetUserLeaveSms(int.Parse(Eval("id").ToString()))%>'><%#Public.GetUserLeaveSms(int.Parse(Eval("id").ToString())).Length > 6 ? Public.GetUserLeaveSms(int.Parse(Eval("id").ToString())).Substring(0, 6) + ".." : Public.GetUserLeaveSms(int.Parse(Eval("id").ToString()))%></td>
    <td><%#Public.GetUserAccount(int.Parse(Eval("userid").ToString())) %></td>
    <td><%# GetRoleName(int.Parse(Eval("role").ToString()))%></td>
    <td><%#Eval("startdate").ToString()==""?"":Convert.ToDateTime(Eval("startdate").ToString()).ToString("yyyy-MM-dd")%></td>
    <td><%#Eval("maxsendnum") %></td> 
    <td><%#Eval("state").ToString()=="2"?"审核通过":"未审核" %> </td>
    <td><%#Eval("IsLock").ToString() == "0" ? "<img title='未锁定' src='../img/validate_success.gif'>" : "<img title='已锁定' src='../img/validate_error.gif'>"%> </td>
    <td style=" color:Blue;">
 
    <asp:LinkButton ID="LinkButton3" ForeColor="Blue" PostBackUrl='<%#"~/AllowUser.aspx?id="+Eval("id") %>' runat="server">[修改]</asp:LinkButton>
    <asp:LinkButton ID="LinkButton4" ForeColor="Blue" PostBackUrl='<%#"~/sms/GiveSms.aspx?id="+Eval("id") %>' runat="server">[充值]</asp:LinkButton>
    <asp:LinkButton style=" color:Blue;" ID="LinkButton1" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('删除此用户则对应的短信账户都将被删除，确定要删除么？')" CommandName="delete" runat="server">[删除]</asp:LinkButton>
    <asp:LinkButton style=" color:Blue;" ID="LinkButton2" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('你确定要更改此用户的锁定状态吗？')" CommandName="lock" runat="server"><%#Eval("IsLock").ToString()=="0"?"[锁定]":"[解锁]" %></asp:LinkButton>
    </td>
    </tr>    
    </ItemTemplate>    
    <AlternatingItemTemplate>
    <tr style=" background-color:#EDF6FD;">    
        <td title='<%#Eval("account").ToString()%>'><%#Eval("account").ToString().Length > 6 ? Eval("account").ToString().Substring(0, 6)+".." : Eval("account").ToString()%></td>
    <td><%#Eval("name") %></td>
    <td><%#Eval("pwd") %></td> 
    <td><%#Eval("mobile") %></td>
    <td title='<%#Public.GetUserLeaveSms(int.Parse(Eval("id").ToString()))%>'><%#Public.GetUserLeaveSms(int.Parse(Eval("id").ToString())).Length > 6 ? Public.GetUserLeaveSms(int.Parse(Eval("id").ToString())).Substring(0, 6) + ".." : Public.GetUserLeaveSms(int.Parse(Eval("id").ToString()))%></td>
    <td><%#Public.GetUserAccount(int.Parse(Eval("userid").ToString())) %></td>
    <td><%# GetRoleName(int.Parse(Eval("role").ToString()))%></td>
    <td><%#Eval("startdate").ToString() == "" ? "" : Convert.ToDateTime(Eval("startdate").ToString()).ToString("yyyy-MM-dd")%></td>
    <td><%#Eval("maxsendnum") %></td> 
    <td><%#Eval("state").ToString()=="2"?"审核通过":"未审核" %> </td>
    <td><%#Eval("IsLock").ToString() == "0" ? "<img title='未锁定' src='../img/validate_success.gif'>" : "<img title='已锁定' src='../img/validate_error.gif'>"%> </td>
    <td style=" color:Blue;">
    <asp:LinkButton ID="LinkButton3" ForeColor="Blue" PostBackUrl='<%#"~/AllowUser.aspx?id="+Eval("id") %>' runat="server">[修改]</asp:LinkButton>
    <asp:LinkButton ID="LinkButton4" ForeColor="Blue" PostBackUrl='<%#"~/sms/GiveSms.aspx?id="+Eval("id") %>' runat="server">[充值]</asp:LinkButton>
 
    <asp:LinkButton style=" color:Blue;" ID="LinkButton1" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('删除此用户则对应的短信账户都将被删除，确定要删除么？')" CommandName="delete" runat="server">[删除]</asp:LinkButton>
    <asp:LinkButton style=" color:Blue;" ID="LinkButton2" CommandArgument='<%#Eval("id") %>' OnClientClick="javascript:return confirm('你确定要更改此用户的锁定状态吗？')" CommandName="lock" runat="server"><%#Eval("IsLock").ToString()=="0"?"[锁定]":"[解锁]" %></asp:LinkButton>
    </td>
    </tr> 
    </AlternatingItemTemplate>
    <FooterTemplate>
    </table>
    </FooterTemplate>
    
    </asp:DataList>

    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
         PageSize="15"
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
