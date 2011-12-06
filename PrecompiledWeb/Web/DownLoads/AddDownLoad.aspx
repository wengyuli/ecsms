<%@ page language="C#" autoeventwireup="true" inherits="Admin_DownLoad, App_Web_phsuf21d" stylesheettheme="default" %>
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
    <legend style="font-size:14px; font-weight:bold;">浏览下载软件</legend>
    <asp:DataList ID="DataList1" Width="100%" runat="server"
 DataKeyField="Id"  OnDeleteCommand="dlDel">
 <HeaderTemplate>
    <table width="100%" style=" text-align:center;">
     <tr  style=" background-color:#98CDFF;">  
    <th>编号</th>
    <th>显示名称</th>    
    <th>文件全名</th>
    <th>文件说明</th>
    <th>扣费说明</th>
    <th>操作</th>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr align="center">
    <td>  <%#Eval("Id") %></td>
    <td><%#Eval("showname") %></td>
    <td><%#Eval("fullfilename") %></td>
    <td title='<%#Eval("Remark") %>'><%#Eval("Remark").ToString().Length>10?Eval("Remark").ToString().Substring(0,10)+"...":Eval("Remark").ToString()%></td>
    <td><%#Eval("price").ToString().Replace("A", Public.GetProNameByLetter("A")).Replace("B", Public.GetProNameByLetter("B")).Replace("C", Public.GetProNameByLetter("C")).Replace("D", Public.GetProNameByLetter("D")).Replace("E", Public.GetProNameByLetter("E"))%></td>
    <td>
    <asp:LinkButton ID="lbtnDel" runat="server" CommandName="Delete" CommandArgument='<%#Eval("Id") %>' OnClientClick="javascript:return confirm('你确定要删除么？')">[删除]</asp:LinkButton>
    </td>
    </tr>    
    </ItemTemplate>
    <AlternatingItemTemplate>
    <tr style=" background-color:#EDF6FD;" align="center">    
    <td><%#Eval("Id") %></td>
    <td><%#Eval("showname") %></td>
    <td><%#Eval("fullfilename") %></td>
    <td title='<%#Eval("Remark") %>'><%#Eval("Remark").ToString().Length>10?Eval("Remark").ToString().Substring(0,10)+"...":Eval("Remark").ToString()%></td>
    <td><%#Eval("price").ToString().Replace("A", Public.GetProNameByLetter("A")).Replace("B", Public.GetProNameByLetter("B")).Replace("C", Public.GetProNameByLetter("C")).Replace("D", Public.GetProNameByLetter("D")).Replace("E", Public.GetProNameByLetter("E"))%></td>
    <td>
    <asp:LinkButton ID="lbtnDel" runat="server" CommandName="Delete" CommandArgument='<%#Eval("Id") %>' OnClientClick="javascript:return confirm('你确定要删除么？')">[删除]</asp:LinkButton>
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
     <legend style="font-size:14px; font-weight:bold;">添加下载软件</legend>
     
     
       
        <table class="style1">
            
            <tr>
                <td align="right" class="style3">
                    显示名称:</td>
                <td class="style2">
                    <asp:TextBox ID="txtShowName" runat="server"></asp:TextBox>
                    如:号码魔方</td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    选择文件:</td>
                <td class="style2">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    上传rar,doc,xls,txt等格式</td>
            </tr>
            <tr>
                <td align="right" valign="top" class="style3">
                    文件说明:</td>
                <td class="style2">
                    <asp:TextBox ID="txtRemark" runat="server" Height="46px" TextMode="MultiLine" 
                        Width="371px"></asp:TextBox>
                    如:号码魔方适用于大批量处理号码。</td>
            </tr>
            <tr>
            <td colspan="2">
            售价：<br />
            <table>
            <tr><td align="right">3G直告：</td><td><asp:TextBox ID="txtA" Text="0" runat="server"></asp:TextBox>条</td><td>
                &nbsp;</td></tr>
            <tr><td align="right">企信通：</td><td colspan="2"><asp:TextBox ID="txtB" Text="0" runat="server"></asp:TextBox>条</td></tr>
            <tr><td align="right">会员通：</td><td colspan="2"><asp:TextBox ID="txtC" Text="0" runat="server"></asp:TextBox>条</td></tr>
            <tr><td align="right">准  告：</td><td colspan="2"><asp:TextBox ID="txtD" Text="0" runat="server"></asp:TextBox>条</td></tr>
            <tr><td align="right">闪  信：</td><td colspan="2"><asp:TextBox ID="txtE" Text="0" runat="server"></asp:TextBox>条</td></tr>
            </table>      
            </td> 
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style2">
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="添加" />
                </td>
            </tr>
        </table>
        
        </fieldset> 
    </div>
    </form>
</body>
</html>
