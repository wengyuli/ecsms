<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendLog.aspx.cs" Inherits="SendLog" %>
<%@ Register assembly="ZLTextBox" namespace="BaseText" tagprefix="cc1" %>
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
    <legend style="font-size:14px; font-weight:bold;">短信发送日志</legend>
        <asp:Label ID="lblKeyWords" runat="server" Text="关键字："></asp:Label><asp:TextBox ID="txtContentKey" Width="100px" ToolTip="内容、编号 支持模糊查询" runat="server"></asp:TextBox>
&nbsp;<asp:Label ID="lblPhoneKey" runat="server" Text="手机号："></asp:Label><asp:TextBox ID="txtPhoneKey" Width="100px" ToolTip="支持模糊查询" runat="server"></asp:TextBox>
&nbsp;时间段：                   
         <cc1:ZLTextBox ID="txtStartDate" ToolTip="点击选择时间，支持到小时、分钟、秒" runat="server" InputType="date" 
                        IsDisplayTime="True" Width="120px"></cc1:ZLTextBox> 
        ~<cc1:ZLTextBox ID="txtEndDate" ToolTip="点击选择时间，支持到小时、分钟、秒"  runat="server" InputType="date" 
                        IsDisplayTime="True" Width="120px"></cc1:ZLTextBox> 
        <asp:Button ID="btnQuery" runat="server" Text="查询" ToolTip="默认查询最近2000条记录" onclick="btnQuery_Click" />
        <asp:Button ID="btnExport" runat="server" Text="导出" onclick="btnExport_Click" />
        <hr />
    <asp:Label ID="lbltype" runat="server" Visible="false" Text="Label"></asp:Label>
        <asp:Label ID="lblShow" runat="server" Text=""></asp:Label>
    【<asp:Label ID="lblCount" runat="server" Text="0"></asp:Label>】条<asp:Label 
            ID="lblTotalSmsCount" runat="server" Text=""></asp:Label>
            
        <asp:Label ID="lblDelPwd" runat="server" Visible="false" Text="删除密码："></asp:Label>
        <asp:TextBox ID="txtDelPwd" runat="server" TextMode="Password" Visible="false"></asp:TextBox>
    <asp:DataList ID="DataList1" runat="server" Width="100%" 
            onitemdatabound="DataList1_ItemDataBound"
            onitemcommand="DataList1_ItemCommand"> 
    <HeaderTemplate >
    <table style=" width:100%; border:solid 1px #EDEFEA; text-align:center;" >
    <tr  style=" background-color:#98CDFF;">    
    <th>任务编号</th>
    <th>帐号</th>
    <th>产品类型</th> 
    <th>内容缩引</th>
    <th>是否定时</th>
    <th>定时时间</th> 
    <th>发送状态</th>
    <th>号码数量</th>
    <th><%=Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)))==0?"体验数量":"" %> </th>
    <th>拆分条数</th>
    <th>发送时间</th>
    <th></th>  
    </tr>    
    </HeaderTemplate>
    <ItemTemplate>
    <tr>    
    <td align="left">
    <%#Eval("serverid")%>
    </td>
    <td align="left">
    <%#Public.GetUserAccount(int.Parse(Eval("userid").ToString()))%>
    </td>
    <td>
    <%#new ECSMS.BLL.EC_SmsType().GetModel(Eval("msgtype").ToString()).Name %>
    </td>
 
    <td align="left">
    <asp:Label ID="Label1" runat="server" ToolTip='<%#Eval("msgtitle")%>' Text='<%#Eval("msgtitle").ToString().Length > 10 ? Eval("msgtitle").ToString().Substring(0, 10) + "..." : Eval("msgtitle").ToString()%>'></asp:Label>
    </td>
    <td><%#Eval("timesend").ToString()==""?"否":"是"%></td>
    <td><%#Eval("timesend").ToString()%></td>
    <td>
    <%#(ECSMS.Channel.SmsStatus)Convert.ToInt32(Eval("msgstatus").ToString())%>
    </td>
    <td>
    <%#Eval("NumbersCount")%>
    </td> 
    <td>
    <%#Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0 ? Eval("ExerNumbers") : ""%>
    </td>
    <td>
    <%#Eval("sendnum") %>
    </td>
    <td><%#Eval("senttime").ToString()==""?"":Convert.ToDateTime(Eval("sentTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
    
    <td>
    <a id="aoperate" runat="server" visible="false" href='<%#"smsreport.aspx?returnurl=sendlog.aspx-"+this.lbltype.Text+"&taskid="+Eval("serverid")%>'>[详细]</a>
    <asp:LinkButton ID="lbtnDel" CommandName="del" Visible="false"  OnClientClick="javascript:return confirm('你确定要删除此条记录吗？')" CommandArgument='<%#Eval("serverid")%>' runat="server">[删除]</asp:LinkButton>
    </td>
    </tr>    
    </ItemTemplate>    
    <AlternatingItemTemplate>
    <tr style=" background-color:#EDF6FD;">    
    <td align="left">
    <%#Eval("serverid")%>
    </td>
    <td align="left">
    <%#Public.GetUserAccount(int.Parse(Eval("userid").ToString()))%>
    </td>
    <td>
    <%#new ECSMS.BLL.EC_SmsType().GetModel(Eval("msgtype").ToString()).Name%>
    </td>
 
    <td align="left">
    <asp:Label ID="Label1" runat="server" ToolTip='<%#Eval("msgtitle")%>' Text='<%#Eval("msgtitle").ToString().Length > 10 ? Eval("msgtitle").ToString().Substring(0, 10) + "..." : Eval("msgtitle").ToString()%>'></asp:Label>
    </td>
    <td><%#Eval("timesend").ToString()==""?"否":"是"%></td>
    <td><%#Eval("timesend").ToString()%></td>
    <td>
    <%#(ECSMS.Channel.SmsStatus)Convert.ToInt32(Eval("msgstatus").ToString())%>
    </td>
    <td>
    <%#Eval("NumbersCount")%>
    </td> 
    <td>
    <%#Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0 ? Eval("ExerNumbers") : ""%>
    </td>
    <td>
    <%#Eval("sendnum") %>
    </td>
    <td><%#Eval("senttime").ToString() == "" ? "" : Convert.ToDateTime(Eval("sentTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
    
    <td>
    <a id="aoperate" runat="server" visible="false" href='<%#"smsreport.aspx?returnurl=sendlog.aspx-"+this.lbltype.Text+"&taskid="+Eval("ServerID")%>'>[详细]</a>
    <asp:LinkButton ID="lbtnDel" CommandName="del" Visible="false"  OnClientClick="javascript:return confirm('你确定要删除此条记录吗？')" CommandArgument='<%#Eval("ServerID")%>' runat="server">[删除]</asp:LinkButton>
    </td>
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
         OnPageChanging="AspNetPager1_PageChanging">
    </webdiyer:AspNetPager>
    </fieldset>
    </div>
    </form>
</body>
</html>
