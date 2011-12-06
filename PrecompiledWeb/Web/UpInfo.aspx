<%@ page language="C#" autoeventwireup="true" inherits="UpInfo, App_Web_yfwijek1" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> 
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">上级代理信息</legend>
    
        <table style=" width:100%">
            <tr>
                <td align="right" class="style2">
                    姓名:</td>
                <td>
                    <asp:Label ID="lblName" runat="server" Text="无"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    电话:</td>
                <td>
                    <asp:Label ID="lblTel" runat="server" Text="无"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    手机:</td>
                <td>
                    <asp:Label ID="lblMobile" runat="server" Text="无"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    公司名称:</td>
                <td>
                    <asp:Label ID="lblCompanyName" runat="server" Text="无"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    &nbsp;</td>
                <td>
                    银行账户信息:</td>
            </tr>
            <tr>
                <td align="right" class="style2" valign="top">
                    &nbsp;</td>
                <td>
                    
                    <br />
                    
<asp:DataList ID="DataList1" Width="100%" runat="server" >
 <HeaderTemplate>
    <table width="100%">
    <tr  style=" background-color:#98CDFF;">   
    <th>图标</th>
    <th>银行名称</th>    
    <th>银行卡号</th>
    <th>开户姓名</th>
    <th>操作</th>
    </tr>
    </HeaderTemplate>
    <ItemTemplate>
    <tr align="center">
    <td><img  height="45px" alt="" src='<%#Eval("IconUrl") %>' /></td>
    <td><%#Eval("bankname") %></td>
    <td><%#Eval("bankaccount") %></td>
    <td><%#Eval("name") %></td>
    <td>
    <a href='<%#Eval("payurl") %>' target="_blank">[付款]</a>
    </td>
    </tr>    
    </ItemTemplate>
    <AlternatingItemTemplate>
    <tr style=" background-color:#EDF6FD;" align="center">    
<td><img height="45px" alt="" src='<%#Eval("IconUrl") %>' /></td>
    <td><%#Eval("bankname") %></td>
    <td><%#Eval("bankaccount") %></td>
    <td><%#Eval("name") %></td>
    <td>
    <a href='<%#Eval("payurl") %>' target="_blank">[付款]</a>
    </td>
    </tr> 
    </AlternatingItemTemplate>
    <FooterTemplate>
    </table>
    </FooterTemplate>
 </asp:DataList>
                    
                    </td>
            </tr> 
        </table>
    
    </fieldset>
    </div>
    </form>
</body>
</html>
