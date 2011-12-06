<%@ page language="C#" autoeventwireup="true" inherits="Admin_SegmentAdd, App_Web_2qvchb0s" stylesheettheme="default" %>

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
            width: 171px;
        }
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">平台号段管理</legend>
    
    <div>
        <table class="style1">
            <tr>
                <td align="right" class="style2">
       运营商:</td>
                <td style=" font-size:12px;">
                    <asp:DropDownList ID="ddlsp" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlsp_SelectedIndexChanged">
        </asp:DropDownList>
                    （注:添加时应以#号分隔）</td>
            </tr>
            <tr>
                <td align="right" class="style2" valign="top">
       号  段:</td>
                <td>
                    <asp:TextBox ID="txtSegment" runat="server" Height="186px" TextMode="MultiLine" 
                        Width="196px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
        <asp:Button ID="btnAdd" runat="server" Text="更新" onclick="btnAdd_Click" />
        
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        
    </div>
    </fieldset>
    </form>
</body>
</html>
