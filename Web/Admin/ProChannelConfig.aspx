<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProChannelConfig.aspx.cs" Inherits="Admin_ProChannelConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 269px;
        }
        .style2
        {
            width: 97px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend style="width: 148px; font-size:20px;"> 产品通道配置</legend>

        <table class="style1">
            <tr>
                <td class="style2" align="right">
                    产品：</td>
                <td>
                    <asp:DropDownList ID="ddlPro" runat="server"
                    DataTextField="Name" DataValueField="Type"
                    OnSelectedIndexChanged="ddlPro_SelectedIndexChanged" AutoPostBack="True" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    联通通道：</td>
                <td>
                    <asp:DropDownList ID="ddlChannelLT" runat="server" 
                    DataTextField="Name" DataValueField="Code">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    移动通道：</td>
                <td>
                    <asp:DropDownList ID="ddlChannelYD" runat="server"
                    DataTextField="Name" DataValueField="Code">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    电信通道：</td>
                <td>
                    <asp:DropDownList ID="ddlChannelDX" runat="server"
                    DataTextField="Name" DataValueField="Code">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Text="保存" Height="34px" 
                        onclick="btnSave_Click" Width="67px" />
                </td>
            </tr>
        </table>

    </fieldset>
    </div>
    </form>
</body>
</html>
