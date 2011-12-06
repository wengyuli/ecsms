<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SmsReport.aspx.cs" Inherits="SmsLog_SmsReport" %>
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
    <legend>任务详细记录</legend>
        任务编号：<asp:Label ID="lblTaskId" runat="server" Text=""></asp:Label>
        <%--<span style=" color:Red;">为提高短信发送效率，仅显示前2000条发送报告</span>--%>
        <asp:Button ID="btnBack" runat="server" Text="返回" />
        <asp:Button ID="btnExport" runat="server" Text="导出" onclick="btnExport_Click" />
    <asp:DataList ID="DataList1" runat="server" Width="100%">
    <HeaderTemplate >
    <table style=" width:100%; border:solid 1px #EDEFEA; text-align:center;" >
    <tr  style=" background-color:#98CDFF;">    
    <th>号码</th>
    <th>帐号</th>
    <th>产品类型</th> 
    <th>内容缩引</th>
    <th>发送状态</th>
    <th>号码数量</th>
 
    <th><%=Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)))==0?"体验数量":"" %> </th>
    <th>拆分条数</th>
    <th>发送时间</th> 
    </tr>    
    </HeaderTemplate>
    <ItemTemplate>
    <tr>    
    <td align="center" title='<%#Eval("phonenumber").ToString() %>'><%#Eval("phonenumber").ToString().Length>12?Eval("phonenumber").ToString().Substring(0,12):Eval("phonenumber").ToString()%></td>
    <td align="left"><%#Public.GetUserAccount(int.Parse(Eval("userid").ToString()))%></td>
    <td><%#new ECSMS.BLL.EC_SmsType().GetModel(Eval("msgtype").ToString()).Name %></td>
 
    <td align="left">
        <asp:Label ID="Label1" runat="server" ToolTip='<%#Eval("msgtitle")%>' Text='<%#Eval("msgtitle").ToString().Length > 10 ? Eval("msgtitle").ToString().Substring(0, 10) + "..." : Eval("msgtitle").ToString()%>'></asp:Label>
           </td>
    
    <td><%#(ECSMS.Channel.SmsStatus)Convert.ToInt32(Eval("msgstatus").ToString())%></td>
    <td><%#Eval("NumbersCount")%></td>
 
    <td>
    <%#Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0 ? Eval("ExerNumbers") : ""%>
    </td>
    <td><%#Eval("sendnum") %></td>
    <td><%#Eval("sentTime")%></td>
     
    </tr>    
    </ItemTemplate>
    <AlternatingItemTemplate>
    <tr style=" background-color:#EDF6FD;">    
<td align="center" title='<%#Eval("phonenumber").ToString() %>'><%#Eval("phonenumber").ToString().Length>12?Eval("phonenumber").ToString().Substring(0,12):Eval("phonenumber").ToString()%></td>
    <td align="left"><%#Public.GetUserAccount(int.Parse(Eval("userid").ToString()))%></td>
    <td><%#new ECSMS.BLL.EC_SmsType().GetModel(Eval("msgtype").ToString()).Name%></td>
 
    <td align="left">
        <asp:Label ID="Label1" runat="server" ToolTip='<%#Eval("msgtitle")%>' Text='<%#Eval("msgtitle").ToString().Length > 10 ? Eval("msgtitle").ToString().Substring(0, 10) + "..." : Eval("msgtitle").ToString()%>'></asp:Label>
           </td>
    
    <td><%#(ECSMS.Channel.SmsStatus)Convert.ToInt32(Eval("msgstatus").ToString())%></td>
    <td><%#Eval("NumbersCount")%></td>
 
    <td>
    <%#Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0 ? Eval("ExerNumbers") : ""%>
    </td>
    <td><%#Eval("sendnum") %></td>
    <td><%#Eval("sentTime")%></td>
    
    </tr> 
    </AlternatingItemTemplate>
    <FooterTemplate>
    </table>
    </FooterTemplate>
    
    </asp:DataList>
        
    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" 
         PageSize="16"
         FirstPageText="首页"
         LastPageText="末页"
         NextPageText="下一页"
         PrevPageText="上一页" 
         Font-Size="12px"          
         OnPageChanging="AspNetPager1_PageChanging" LayoutType="Table">
    </webdiyer:AspNetPager>
     
        
    
    
    
    </fieldset>
    </div>
    </form>
</body>
</html>
