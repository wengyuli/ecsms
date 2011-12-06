<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeSmsPro.aspx.cs" Inherits="Admin_ChangeSmsPro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 193px;
        }
        .style2
        {
        }
        .style3
        {
            width: 133px;
        }
    </style>
    
    
</head>

<body>
    <form id="form1" runat="server">
    <div>
    
        
    
        <table class="style1">
            <tr>
                <td align="right" class="style2" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    短信编号：</td>
                <td>
                    <asp:Label ID="lblSmsId" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    当前使用产品：</td>
                <td>
                    <asp:Label ID="lblSmsTypeName" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style3">
                    选择使用新产品：</td>
                <td>
                    <asp:DropDownList ID="ddlPro" runat="server" DataTextField="Name" DataValueField="Type" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" OnClientClick="javascript:return confirm('你确定要更改短信产品吗？')"  Text="确定" onclick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" Text="取消" OnClientClick="javascript:window.close();" />
                </td>
            </tr>
        </table>
    
        
    
    </div>
    </form>
</body>
</html>
