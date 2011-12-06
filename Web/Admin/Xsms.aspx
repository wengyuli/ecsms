<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Xsms.aspx.cs" Inherits="Admin_Xsms" %>
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
    <legend style="font-size:14px; font-weight:bold;">当前需求短信</legend>
       目前平台共有需求短信任务【<asp:Label ID="lblWaitSmsCount" runat="server" Text="0"></asp:Label>】个
        <asp:DataList ID="DataList1" runat="server" Width="100%">
    <HeaderTemplate >
    <table style=" width:100%; border:solid 1px #EDEFEA; text-align:center;" >
    <tr  style=" background-color:#98CDFF;">    
    <th>编号</th>
    <th>用户名</th> 
    <th>内容缩引</th>
    <th>提交时间</th>  
    <th>发送状态</th>    
    <th>号码数量</th> 
    <th>操作</th>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>    
    <td><%#Eval("ServerID").ToString()%></td>
    <td><%#Public.GetUserAccount(int.Parse(Eval("userid").ToString()))%></td> 
    <td align="left"><%#Eval("msgtitle").ToString().Length > 10 ? Eval("msgtitle").ToString().Substring(0, 10) + "..." : Eval("msgtitle").ToString()%></td>
    <td><%#Convert.ToDateTime(Eval("sendtime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
    <td><%#Eval("msgstatus").ToString()=="1"?"已发送":"已提交" %></td>
    <td><%#Eval("NumbersCount")%></td> 
    <td>
        <asp:LinkButton ID="LinkButton1" style=" color:Blue;" PostBackUrl='<%#"SmsDetail.aspx?id="+Eval("ServerID") %>' runat="server">[处理]</asp:LinkButton></td>
    </tr>    
    </ItemTemplate>
    <AlternatingItemTemplate>
    <tr style=" background-color:#EDF6FD;">    
    <td><%#Eval("ServerID").ToString()%></td>
    <td><%#Public.GetUserName(int.Parse(Eval("userid").ToString()))%></td> 
    <td align="left"><%#Eval("msgtitle").ToString().Length > 10 ? Eval("msgtitle").ToString().Substring(0, 10) + "..." : Eval("msgtitle").ToString()%></td>
    <td><%#Convert.ToDateTime(Eval("sendtime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
    <td><%#Eval("msgstatus").ToString()=="1"?"已发送":"已提交" %></td>
    <td><%#Eval("NumbersCount")%></td> 
    <td>
        <asp:LinkButton ID="LinkButton1" style=" color:Blue;" PostBackUrl='<%#"SmsDetail.aspx?id="+Eval("ServerID") %>' runat="server">[处理]</asp:LinkButton></td>
    
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
