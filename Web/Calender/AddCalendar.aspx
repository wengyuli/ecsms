<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddCalendar.aspx.cs" Inherits="Calendar" %>

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
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
        <legend style="font-size:14px; font-weight:bold;">编辑日程</legend>
       
        <table class="style1">
            <tr>
                <td colspan="2">
        
     
                </td>
            </tr>
            <tr>
                <td align="right">
                    日程标题:</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right">
                    提醒时间:</td>
                <td>
                    <cc1:ZLTextBox ID="txtTime" runat="server" InputType="date"></cc1:ZLTextBox>
               (将提前一天开始提醒)
                </td>
            </tr>
            <tr>
                <td valign="top" align="right">
                    内容:</td>
                <td>
                    <asp:TextBox ID="txtContent" runat="server" Height="138px" TextMode="MultiLine" 
                        Width="283px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" onclick="btnAdd_Click" Text="保存" 
                        style="height: 26px" />
                    <asp:Button ID="Button1" runat="server" 
                        PostBackUrl="~/Calender/ViewCalender.aspx" Text="返回" />
                </td>
            </tr>
        </table>
         </fieldset>
    </div>
    </form>
</body>
</html>
