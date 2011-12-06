<%@ page language="C#" autoeventwireup="true" inherits="ReceiveLog, App_Web_d4hqyjws" stylesheettheme="default" %>
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
    <legend style="font-size:14px; font-weight:bold;">短信接收日志</legend>

                    共有【<asp:Label ID="lblCount" runat="server" Text="0"></asp:Label>】
        条记录&nbsp;&nbsp;&nbsp; 

                    请输入查询关键字：<asp:TextBox ID="txtKey" runat="server" 
            Width="171px"></asp:TextBox>

                    <asp:Button ID="btnQuery" runat="server" Text="查询" onclick="btnQuery_Click" />
                     
                    <asp:Button ID="btnExport" runat="server" onclick="btnExport_Click" Text="导出" />

            <asp:Label ID="lblDelPwd" runat="server" Visible="false" Text="删除密码："></asp:Label>
        <asp:TextBox ID="txtDelPwd" TextMode="Password" runat="server" Visible="false"></asp:TextBox>
    
        <asp:Label ID="lbltype" runat="server" Text="" Visible="false"></asp:Label>
        
        
        
    <asp:DataList ID="DataList1" runat="server" Width="100%" 
            onitemcommand="DataList1_ItemCommand" onitemdatabound="DataList1_ItemDataBound">
    <HeaderTemplate >
    <table style=" width:100%; border:solid 1px #EDEFEA; text-align:center;" >
     <tr  style=" background-color:#98CDFF;">     
    <th>编号</th>
    <th>回复号码</th>
    <th>接收人帐号</th>
    <th>短信内容</th>
    <th>接收时间</th>   
    <th>操作</th> 
    </tr>    
    </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td><%#Eval("msgindex") %></td>
    <td><%#Eval("phonenumber") %></td>
    <td><%#GetAccountById(int.Parse(Eval("MsgStatus").ToString()))%></td>
    <td title='<%#Eval("msgtilte")%>'><%#Eval("msgtilte").ToString().Length>20?Eval("msgtilte").ToString().Substring(0,20)+"...":Eval("msgtilte") %></td>     
    <td><%#Convert.ToDateTime(Eval("RecvTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
    <td>
    <asp:LinkButton ID="lbtnDel" CommandName="del"  OnClientClick="javascript:return confirm('你确定要删除此条记录吗？')" CommandArgument='<%#Eval("msgindex")%>' runat="server">[删除]</asp:LinkButton>
    </td>
    </tr>    
    </ItemTemplate>
    <AlternatingItemTemplate>
    <tr style=" background-color:#EDF6FD;">    
    <td><%#Eval("msgindex") %></td>
    <td><%#Eval("phonenumber") %></td>
    <td><%#GetAccountById(int.Parse(Eval("MsgStatus").ToString()))%></td>
    <td title='<%#Eval("msgtilte")%>'><%#Eval("msgtilte").ToString().Length>20?Eval("msgtilte").ToString().Substring(0,20)+"...":Eval("msgtilte") %></td>
    <td><%#Convert.ToDateTime(Eval("RecvTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
    <td>
    <asp:LinkButton ID="lbtnDel" CommandName="del"  OnClientClick="javascript:return confirm('你确定要删除此条记录吗？')" CommandArgument='<%#Eval("msgindex")%>' runat="server">[删除]</asp:LinkButton>
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
