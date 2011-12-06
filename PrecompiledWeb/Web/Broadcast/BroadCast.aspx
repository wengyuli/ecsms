<%@ page language="C#" autoeventwireup="true" inherits="BroadCast, App_Web_oelrauyu" stylesheettheme="default" %>
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
    <legend style="font-size:14px; font-weight:bold;">公告管理</legend>
    
    <asp:DataList ID="DataList1" runat="server"
 DataKeyField="Id"  OnDeleteCommand="dlDel" OnEditCommand="dlEdit" Width="100%">
 <HeaderTemplate>
    <table width="100%">
    <tr align="center" style=" background-color:#98CDFF;">   
    <th>编号</th>
    <th>公告标题</th>    
    <th>发布人</th>
    <th>操作</th>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr align="center">
    <td><%#Eval("Id") %></td>
    <td title='<%#Eval("content") %>' style=" text-decoration:underline;"><%#Eval("title").ToString().Length > 10 ? Eval("title").ToString().Substring(0, 10) + "..." : Eval("title")%></td>
    <td><%#Eval("showname") %></td>
    <td> 
    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit">[编辑]</asp:LinkButton>
    <asp:LinkButton ID="lbtnDel" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('你确定要删除么？')">[删除]</asp:LinkButton>
    
    </td>
    </tr>    
    </ItemTemplate>
    <AlternatingItemTemplate>
    <tr style=" background-color:#EDF6FD;" align="center">    
<td><%#Eval("Id") %></td>
    <td title='<%#Eval("content") %>' style=" text-decoration:underline;"><%#Eval("title").ToString().Length > 10 ? Eval("title").ToString().Substring(0, 10) + "..." : Eval("title")%></td>
    <td><%#Eval("showname") %></td>
    <td> 
    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="edit">[编辑]</asp:LinkButton>
    <asp:LinkButton ID="lbtnDel" runat="server" CommandName="Delete" OnClientClick="javascript:return confirm('你确定要删除么？')">[删除]</asp:LinkButton>
    
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
    <br />
        <asp:Label ID="lblId" runat="server" Text="" Visible="false"></asp:Label>
    <table class="style1">
        <tr>
            <td align="right" class="style2">
                标题:</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" Width="290px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" valign="top" class="style2">
                内容:</td>
            <td>
                <asp:TextBox ID="txtContent" runat="server" Height="117px" TextMode="MultiLine" 
                    Width="564px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" class="style2">
                署名:</td>
            <td>
                <asp:TextBox ID="txtShowName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="添加公告" />
                <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Visible="false" Text="取消" />
            </td>
        </tr>
    </table>
    </fieldset>
    </div>
    </form>
</body>
</html>
