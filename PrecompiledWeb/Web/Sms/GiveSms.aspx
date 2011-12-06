<%@ page language="C#" autoeventwireup="true" inherits="GiveSms, App_Web_o2hbm0z2" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
     <fieldset>
     <legend style="font-size:14px; font-weight:bold;">短信充值</legend>             
        <table class="style1">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblId" Visible="false" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    账号：</td>
                <td>
                    <asp:Label ID="lblAccount" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    姓名：</td>
                <td>
                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    账户余额：</td>
                <td>
                    <asp:Label ID="lblSmsTotal" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                        短信产品：</td>
                <td>
                    <asp:DropDownList ID="ddlSmsType" runat="server" DataTextField="Name" DataValueField="Type"> 
                    </asp:DropDownList>
                </td>
            </tr>
            <tr id="trOperType" runat="server">
            <td align="right">充值操作：</td>
            <td>
                <asp:DropDownList ID="ddlOperType" runat="server">
                    <asp:ListItem Value="add" Selected="True">充值</asp:ListItem>
                    <asp:ListItem Value="sub">扣值</asp:ListItem>
                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right">
                    充值条数：</td>
                <td>
                    <asp:TextBox ID="txtCount" runat="server" Width="87px"></asp:TextBox>
                    条&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                        ValidationExpression="^[1-9]\d*$" ErrorMessage="短信条数为正数" 
                        ControlToValidate="txtCount"></asp:RegularExpressionValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txtCount"  runat="server" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    充值备注：</td>
                <td>  
                    <asp:TextBox ID="txtRemark" runat="server" Height="55px" TextMode="MultiLine" 
                        Width="173px" ToolTip="如：暂未收款，现金付讫，活动赠送，支付宝款，银行转款，记帐后付，它因充值，平台扣值等"></asp:TextBox>
                     
                    
                     <span style=" font-size:12px; color:Red;"> 此备注信息下级用户也能看见</span></td>
            </tr>
            
            <tr>
            <td></td>
            
            <td>
            <span style=" font-size:12px; color:Red;">   暂未收款，现金付讫，活动赠送，支付宝款，<br />银行转款，记帐后付，它因充值，平台扣值等</span> 
            
            </td>
            </tr>
            <tr>
            <td></td>
            <td>
                <asp:CheckBox ID="cbContinue" runat="server" Text="继续充值"/></td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="确定" />
                    <asp:Button ID="btnBack" runat="server" ValidationGroup="3" Text="返回" />
                </td>
            </tr>
        </table>
        </fieldset>
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
