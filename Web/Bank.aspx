<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bank.aspx.cs" Inherits="Bank" %>
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
    <legend style="font-size:14px; font-weight:bold;">浏览银行账户</legend>
    <asp:DataList ID="DataList1" runat="server"
 DataKeyField="Id"  OnDeleteCommand="dlDel" Width="100%">
 <HeaderTemplate>
    <table width="100%">
    <tr align="center"  style=" background-color:#98CDFF;">   
    <th>图标</th>
    <th>银行名称</th>    
    <th>银行卡号</th>
    <th>开户姓名</th>
    <th>备注</th>
    <th>操作</th>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr align="center">
    <td>  
    <img alt=""   height="45px" src='<%#Eval("IconUrl") %>' />
    </td>    
    <td><%#Eval("bankname") %></td>
    <td><%#Eval("bankaccount") %></td>
    <td><%#Eval("name") %></td>
    <td title="<%#Eval("remark")%>"><%#Eval("remark").ToString().Length>8?Eval("remark").ToString().Substring(0,8)+"...":Eval("remark")  %></td>
    <td>
    <asp:LinkButton ID="lbtnDel" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="Delete" OnClientClick="javascript:return confirm('你确定要删除么？')">[删除]</asp:LinkButton>
    </td>
    </tr>    
    </ItemTemplate>
    <AlternatingItemTemplate>
    <tr style=" background-color:#EDF6FD;" align="center">    
<td>  
    <img alt=""   height="45px" src='<%#Eval("IconUrl") %>' />
    </td>    
    <td><%#Eval("bankname") %></td>
    <td><%#Eval("bankaccount") %></td>
    <td><%#Eval("name") %></td>
    <td title="<%#Eval("remark")%>"><%#Eval("remark").ToString().Length>8?Eval("remark").ToString().Substring(0,8)+"...":Eval("remark")  %></td>
    <td>
    <asp:LinkButton ID="lbtnDel" runat="server" CommandArgument='<%#Eval("Id") %>' CommandName="Delete" OnClientClick="javascript:return confirm('你确定要删除么？')">[删除]</asp:LinkButton>
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
     
     <fieldset>
     <legend style="font-size:14px; font-weight:bold;">添加银行账号</legend>
     
     
       
        <table>
            
            <tr>
                <td align="right">
                    银行名称：</td>
                <td>                    
                    <asp:DropDownList ID="ddlBankName" runat="server">
                        <asp:ListItem>中国银行</asp:ListItem>
                        <asp:ListItem>中国农业银行</asp:ListItem>
                        <asp:ListItem>中国工商银行</asp:ListItem>
                        <asp:ListItem>中国建设银行</asp:ListItem>
                        <asp:ListItem>交通银行</asp:ListItem>
                        <asp:ListItem>招商银行</asp:ListItem>
                        <asp:ListItem>中信银行</asp:ListItem>
                        <asp:ListItem>兴业银行</asp:ListItem>
                        <asp:ListItem>民生银行</asp:ListItem>
                        <asp:ListItem>上海浦东发展银行</asp:ListItem>
                        <asp:ListItem>淘宝网账户</asp:ListItem>
                        <asp:ListItem>支付宝账户</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    银行账号：</td>
                <td>
                    <asp:TextBox ID="txtAccount" runat="server"></asp:TextBox>
                    如：6225 7600 8888 8888</td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    开户姓名：</td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                    如：张三</td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    付款地址：</td>
                <td>
                    <asp:TextBox ID="txtPayUrl" runat="server" Width="227px"></asp:TextBox>
                    如：http://www.icbc.com.cn/icbc/</td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    备注：</td>
                <td>
                    <asp:TextBox ID="txtRemark" runat="server" Height="64px" TextMode="MultiLine" 
                        Width="178px"></asp:TextBox>
                    如：有没有手续费、费率多少等等</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="添加" />
                </td>
            </tr>
        </table>
        
        </fieldset> 
    </div>
    </form>
</body>
</html>
