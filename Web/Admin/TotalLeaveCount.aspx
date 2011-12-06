<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TotalLeaveCount.aspx.cs" Inherits="Admin_TotalLeaveCount" %>

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
            width: 177px;
        }
        .style3
        {
            width: 176px;
        }
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">销售查询</legend>
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">平台产品总余额列表</legend> 
        <table class="style1">
            <tr>
                <td class="style2" align="right">
                    3G直告：</td>
                <td>
                    <asp:Label ID="lblA" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    企信通：</td>
                <td>
                   <asp:Label ID="lblB" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    会员通：</td>
                <td>
                    <asp:Label ID="lblC" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    准告：</td>
                <td>
                    <asp:Label ID="lblD" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    闪信：</td>
                <td>
                    <asp:Label ID="lblE" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
        </table>
        </fieldset>
        <fieldset>
        <legend style="font-size:14px; font-weight:bold;">平台产品发送情况</legend>
        
        <table class="style1">
            <tr>
                <td align="RIGHT" class="style3">
                    3G直告：</td>
                <td>
                    <asp:Label ID="lblALeave" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="RIGHT" class="style3">
                    企信通：</td>
                <td>
                    <asp:Label ID="lblBLeave" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="RIGHT" class="style3">
                    会员通：</td>
                <td>
                    <asp:Label ID="lblCLeave" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="RIGHT" class="style3">
                    准告：</td>
                <td>
                    <asp:Label ID="lblDLeave" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="RIGHT" class="style3">
                    闪信：</td>
                <td>
                    <asp:Label ID="lblELeave" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
        </table>
        
        </fieldset>
    </fieldset>
    </div>
    </form>
    
</body>
</html>
