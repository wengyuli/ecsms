<%@ page language="C#" autoeventwireup="true" inherits="Admin_KeyWords, App_Web_2qvchb0s" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 88%;
        }
        .style2
        {
        }
        .style3
        {
            width: 339px;
        }
        .style6
        {
            height: 37px;
        }
    </style>
    <script type="text/javascript">
        function check() {
            if (document.getElementById("txtKeyWords").value == "") {
                alert("请填写关键字后再提交！");
                return false;
            }
        }
    </script>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">通道配置</legend>
        <table class="style1">
            <tr>
                <td align="right" valign="top" class="style2">
                    &nbsp;</td>
                <td class="style2" colspan="2">
                    通道选择：<asp:RadioButtonList ID="rbtnChannel" AutoPostBack="true" runat="server" 
                        onselectedindexchanged="rbtnChannel_SelectedIndexChanged" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                    </asp:RadioButtonList>    
                </td>
            </tr>
            <tr>
                <td align="right" valign="top" class="style2">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style2" rowspan="4">
                    <br />
        关键词:(关键词之间以 # 分隔，如 家乐福#火车票)<br />
                    <asp:TextBox ID="txtKeyWords" runat="server" TextMode="MultiLine" 
            Height="107px" Width="415px"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td align="right" valign="top">
                    通道权限：</td>
                <td>
                    <asp:TextBox ID="txtMaxNum" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td align="right" valign="top">
                    余额提醒：</td>
                <td>
                    <asp:TextBox ID="txtLeavesms" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    通道开关：</td>
                <td>
                    <asp:RadioButtonList ID="rbtnIsClose" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Value="1">开</asp:ListItem>
                        <asp:ListItem Value="0">关</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnSave" runat="server" OnClientClick="return check()" onclick="btnSave_Click" Text="保存" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">通道状态测试</legend>
    <br />
        <table class="style1">
            <tr>
                <td class="style3">
    
        凌凯移动通道短信余额：【<asp:Label ID="lbllkSmsCount" runat="server" Text="待查询"></asp:Label>】
                 
                    <br />
                    凌凯联通通道短信余额：【<asp:Label ID="lbllkuSmsCount" runat="server" Text="待查询"></asp:Label>】
                </td>
                <td valign="top">
                    手机号码：<asp:TextBox ID="txtTestNumber" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ControlToValidate="txtTestNumber" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
            </tr>
 
            <tr>
                <td class="style3">
        万众通道短信余额：【<asp:Label ID="lblwzSmsCount" runat="server" Text="待查询"></asp:Label>】
                </td>
                <td class="style6" rowspan="2" valign="top">
                    测试短信：<asp:TextBox ID="txtTestSms" runat="server" Text="测试通道是否发送正常" Height="48px" TextMode="MultiLine" 
                                    Width="199px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ControlToValidate="txtTestSms" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
            </tr>
            <tr>
                <td class="style3" rowspan="2">
        <asp:Button ID="btnQuery" runat="server" Text="查询余额" onclick="btnQuery_Click" 
                        ValidationGroup="2" />
                    <br />
                </td>
            </tr>
            <tr>
                <td>
        <asp:Button ID="btnlkSend" runat="server" Text="凌凯移动发送" 
            onclick="btnlkSend_Click" Width="100px" />
            <asp:Button ID="Button1" runat="server" Text="凌凯联通发送" 
            onclick="btnlkSend1_Click" Width="100px" />
        <asp:Button ID="btnwzSend" runat="server" Text="万众发送" 
            onclick="btnwzSend_Click" Width="100px" />
    
                            </td>
            </tr>
        </table>
        <br />
    
    </fieldset>
    </div>
    </form>
</body>
</html>
