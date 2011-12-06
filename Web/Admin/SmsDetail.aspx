<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SmsDetail.aspx.cs" Inherits="Admin_SmsDetail" %>

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
            width: 100px;
        }
        .style3
        {
            width: 352px;
        }
    </style>  
    <script type="text/javascript">
        function OpenWindow(url, width, height) {
            window.open(url,
            "",
            "top=50, left=150,height=" + height + ", width=" + width + ",toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,status=no",
            "")
        }
        function copyNumber() {

            clipboardData.setData('Text', document.getElementById("txtNumbers").value + document.getElementById("txtExperNumbers").value);
            alert("号码已复制到剪切板，您可以使用Ctrl+V进行粘贴。");
        }
        function copyContent() {
            clipboardData.setData('Text', document.getElementById("txtContent").value);
            alert("短信内容已复制到剪切板，您可以使用Ctrl+V进行粘贴。");
        }
        function changesmstype() {
            var id = document.getElementById("lblId").innerHTML;
            OpenWindow("ChangeSmsPro.aspx?smsid="+id, "400", "400");
        }

    </script> 
</head>
<body style=" font-size:12px;  font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">已提交短信处理</legend>
        <table class="style1">
            <tr>
                <td align="right" class="style2">
                    短信编号:</td>
                <td colspan="2">
                    <asp:Label ID="lblId" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    定时:</td>
                <td colspan="2">
                    <asp:Label ID="lblIsTimeSend" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    短信类型:</td>
                <td colspan="2">
                    <asp:Label ID="lblSmstype" runat="server" Text=""></asp:Label>
                    <input value="更改短信产品" type="button" onclick="changesmstype()" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    用户名:</td>
                <td colspan="2">
                    <asp:Label ID="lblUserName" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    号码数量:</td>
                <td colspan="2">
                    【<asp:Label ID="lblNumbersCount" runat="server" Text="0"></asp:Label>】
                   <span style=" color:Gray;">(为了提高服务器发送短信效率，仅显示前1000个号码，全部号码请使用“导出txt”)</span> </td>
            </tr>
            <tr>
                <td align="right" class="style2" valign="top">
                    <asp:Label ID="lblNumber" runat="server" Text="手机号码:"></asp:Label></td>
                <td class="style3" align="left">
                    <asp:TextBox ID="txtNumbers" runat="server" Height="150px" TextMode="MultiLine" 
                        Width="260px"></asp:TextBox>
                    
                    <br />
                    
                    <asp:Button ID="btnExport" runat="server" Text="导出全部号码为txt" 
                        onclick="btnExport_Click" />
                    
                    <input id="btnCopy" onclick="copyNumber()" type="button" value="复制当前号码" /></td>
                <td valign="bottom"><asp:Label ID="lblExperNumCount" runat="server" Text="0"></asp:Label>
                    <br />
                    <asp:TextBox ID="txtExperNumbers" TextMode="MultiLine" runat="server" 
                        Height="127px" Width="213px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2" valign="top">
                    短信内容:</td>
                <td colspan="2">
                    <asp:TextBox ID="txtContent" runat="server" Height="110px" TextMode="MultiLine" 
                        Width="259px"></asp:TextBox>号码：
                    <asp:TextBox ID="txtTestNumber" runat="server" Width="147px"></asp:TextBox>
                    <asp:Button ID="btnTest" runat="server" Text="测试" onclick="btnTest_Click" />
                    <br />
                    当前内容共<asp:Label ID="lblContentCharCount" runat="server" Text="0"></asp:Label>
                    字 <input id="Button1" onclick="copyContent()" type="button" value="复制当前内容" /> </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    发送时间:</td>
                <td colspan="2">
                    <asp:Label ID="lblSendTime" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    <asp:Button ID="btnSend" runat="server" Text="处理为任务发送成功" 
                        onclick="btnSend_Click" />
                        <%--<span style=" color:Red;">所有卡发产品的短信需人工提取号码进行发送</span>--%>
                    <asp:Button ID="btnSend0" runat="server" Text="处理为待发进入自动发送" 
                        onclick="btnSend0_Click" />
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    <asp:Button ID="btnBack" PostBackUrl="~/Admin/WaitSms.aspx" runat="server" Text="返回" />
                </td>
            </tr>
        </table>
    </fieldset>
    </div>
    </form>
</body>
</html>
