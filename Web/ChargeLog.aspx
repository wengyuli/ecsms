<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChargeLog.aspx.cs" Inherits="ChargeLog" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register assembly="ZLTextBox" namespace="BaseText" tagprefix="cc1" %>
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
            width: 85px;
        }
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">短信充值记录</legend>
        <table class="style1">
            <tr>
                <td class="style2" align="right">
                    选择时间段：</td>
                <td>
                    <cc1:ZLTextBox ID="txtStartDate" runat="server" InputType="date" 
                        IsDisplayTime="True" Width="120px"></cc1:ZLTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtStartDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                    ~
                    <cc1:ZLTextBox ID="txtEndDate" runat="server" InputType="date" 
                        IsDisplayTime="True" Width="120px"></cc1:ZLTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtEndDate" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <asp:Button ID="btnQuery" runat="server" Text="查询" onclick="btnQuery_Click" />
                    <asp:Button ID="btnExport" runat="server" Text="导出" onclick="btnExport_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
 <asp:DataList ID="DataList1" runat="server" Width="100%">
    <HeaderTemplate >
    <table style=" width:100%; border:solid 1px #EDEFEA; text-align:center;" >
    <tr style=" background-color:#98CDFF;">    
    <th>账号</th><th>短信类型</th>
    <th>操作类型</th><th>增减条数</th>
    <th>充值备注</th> 
    <th>分配人</th><th>操作时间</th>
    
     
    </tr>    
    </HeaderTemplate>
    <ItemTemplate>
    <tr>    
    <td><%#Eval("account") %></td><td><%#Public.GetProNameByLetter( Eval("SmsType").ToString())%></td>
    <td><%#Eval("ActType").ToString()=="add"?"充值":"扣值"%></td>
    <td><%#Eval("SmsCount")%></td>
    <td><%#Eval("remark") %></td>
    <td><%#Public.GetUserAccount(int.Parse(Eval("fromuserid").ToString()))%></td>
    
    <td><%#Convert.ToDateTime(Eval("OperTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
    
    </tr>    
    </ItemTemplate>
    <AlternatingItemTemplate>
    <tr style=" background-color:#EDF6FD;">    
<td><%#Eval("account") %></td><td><%#Public.GetProNameByLetter(Eval("SmsType").ToString())%></td>
    <td><%#Eval("ActType").ToString()=="add"?"充值":"扣值"%></td>
    <td><%#Eval("SmsCount")%></td>
    <td><%#Eval("remark") %></td>
    <td><%#Public.GetUserAccount(int.Parse(Eval("fromuserid").ToString()))%></td>
    <td><%#Convert.ToDateTime(Eval("OperTime").ToString()).ToString("yyyy-MM-dd HH:mm:ss")%></td>
    
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
        <br />
        <br />
    
    </fieldset>
    </div>
    </form>
</body>
</html>
