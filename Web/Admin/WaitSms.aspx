<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WaitSms.aspx.cs" Inherits="WaitSms_ViewWaitSms" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 745px;
        }
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">当前待发短信</legend>
        <table class="style1">
            <tr>
                <td class="style2">
       目前平台共有待发短信【<asp:Label ID="lblWaitSmsCount" runat="server" Text="0"></asp:Label>】条,
       共有【<asp:Label ID="lblNumbersCount" runat="server" Text="0"></asp:Label>】个号码&nbsp;&nbsp; 
       <asp:Button ID="btnProcessToSuccess" runat="server" Text="批量处理为发送成功" 
                        onclick="btnProcessToSuccess_Click" />
                    <asp:Button ID="btnProcessToWait" runat="server" Text="批量处理为进入发送" 
                        onclick="btnProcessToWait_Click" /> 
                </td>
                <td align="right" id="tdDelPwd" runat="server">
                     请输入删除密码：<asp:TextBox ID="txtDelPwd" runat="server"></asp:TextBox> 
                </td>
            </tr>
        </table>
 <asp:DataList ID="DataList1" runat="server" Width="100%" 
            onitemcommand="DataList1_ItemCommand" 
            onitemdatabound="DataList1_ItemDataBound">
    <HeaderTemplate >
    <table style=" width:100%; border:solid 1px #EDEFEA; text-align:center;" >
    <tr  style=" background-color:#98CDFF;">    
    <th>全选</th>
    <th width="50px">编号</th>
    <th width="50px">用户名</th>
    <th width="70px">短信产品</th> 
    <th>内容缩引</th>
    <th>提交时间</th>
    <th>是否定时</th>  
    <th>定时时间</th>
    <th>发送状态</th>    
    <th>号码数量</th>
    <th> 
        <asp:Label ID="lblExCount" runat="server" Text="体验数量"></asp:Label></th>
    <th>拆分条数</th>
    <th> 
        <asp:Label ID="lblOper" runat="server" Text="操作"></asp:Label></th>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr>    
    <td><asp:CheckBox ID="cbAll"  runat="server"  /></td>
    <td width="50px"><asp:HiddenField Value='<%#Eval("ServerID")%>' ID="hfID" runat="server"/><%#Eval("ServerID")%> </td>
    <td width="50px"><%#Public.GetUserAccount(int.Parse(Eval("userid").ToString()))%></td>
    <td width="70px"><%#Public.GetProNameByLetter(Eval("msgtype").ToString())%></td>
    <td align="left" title='<%#Eval("msgtitle")%>'><%#Eval("msgtitle").ToString().Length > 10 ? Eval("msgtitle").ToString().Substring(0, 10) + "..." : Eval("msgtitle").ToString()%></td>
     
    <td><%#Convert.ToDateTime(Eval("sendtime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
    
    <td><asp:Label runat="server" Text='<%#Eval("timesend").ToString()==""?"否":"是"%>' ID="lblIsTimeSend"></asp:Label> </td>
    <td><%#Eval("timesend").ToString()%></td>
    <td><%#Eval("msgstatus").ToString()=="1"?"已发送":"已提交" %></td>
    <td><%#Eval("NumbersCount")%></td> 
    <td><asp:Label ID="lblExprCount" runat="server" Text='<%#Eval("ExerNumbers")%>'></asp:Label> </td> 
    <td><%#Eval("sendnum") %></td> 
    <td  >
        <a style=" color:Blue;" id="linkOper" runat="server" href='<%#"SmsDetail.aspx?id="+Eval("ServerID") %>' >[处理]</a>
        <asp:LinkButton style=" color:Blue;" ID="LinkButton1" CommandArgument='<%#Eval("ServerID")%>' OnClientClick="javascript:return confirm('确定要删除此待发任务吗么？')" CommandName="delete" runat="server">[删除]</asp:LinkButton> 
    </td>
    </tr>    
    </ItemTemplate>
    <AlternatingItemTemplate>
    <tr style=" background-color:#EDF6FD;">    
    <td><asp:CheckBox ID="cbAll" runat="server"  /></td>
    <td width="50px"><asp:HiddenField Value='<%#Eval("ServerID")%>' ID="hfID" runat="server"/><%#Eval("ServerID")%></td>
    <td width="50px"><%#Public.GetUserAccount(int.Parse(Eval("userid").ToString()))%></td>
    <td width="70px"><%#Public.GetProNameByLetter(Eval("msgtype").ToString())%></td>
    <td align="left" title='<%#Eval("msgtitle")%>'><%#Eval("msgtitle").ToString().Length > 10 ? Eval("msgtitle").ToString().Substring(0, 10) + "..." : Eval("msgtitle").ToString()%></td>
    <td><%#Convert.ToDateTime(Eval("sendtime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
    <td><asp:Label runat="server" Text='<%#Eval("timesend").ToString()==""?"否":"是"%>' ID="lblIsTimeSend"></asp:Label></td>
    <td><%#Eval("timesend").ToString()%></td>
    <td><%#Eval("msgstatus").ToString()=="1"?"已发送":"已提交" %></td>
    <td><%#Eval("NumbersCount")%></td> 
    <td>
        <asp:Label ID="lblExprCount" runat="server" Text='<%#Eval("ExerNumbers")%>'></asp:Label>     
    </td> 
    <td><%#Eval("sendnum") %></td> 
    <td >
        <a style=" color:Blue;" id="linkOper" runat="server" href='<%#"SmsDetail.aspx?id="+Eval("ServerID") %>' >[处理]</a>
        <asp:LinkButton style=" color:Blue;" ID="LinkButton1" CommandArgument='<%#Eval("ServerID")%>' OnClientClick="javascript:return confirm('确定要删除此待发任务吗么？')" CommandName="delete" runat="server">[删除]</asp:LinkButton> 
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
