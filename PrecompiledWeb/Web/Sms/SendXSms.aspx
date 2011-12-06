<%@ page language="C#" autoeventwireup="true" inherits="SendXSms, App_Web_o2hbm0z2" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function changetext() {
            document.getElementById("lblCount").innerHTML = document.getElementById("txtContent").value.length;
            if (document.getElementById("txtContent").value.length > 70) {
                document.getElementById("txtContent").value = document.getElementById("txtContent").value.substr(0, 70);
                
                return false;
            }
        }
    </script>
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
    
        <table class="style1">
            <tr>
                <td class="style2" align="right">
                    地区：</td>
                <td>
                    <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlProvince_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlCity" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    性别：</td>
                <td>
                    <asp:CheckBoxList ID="cbSex" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    年龄：</td>
                <td>
                    <asp:CheckBoxList ID="cbAge" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem>18岁以下</asp:ListItem>
                        <asp:ListItem>18-24岁</asp:ListItem>
                        <asp:ListItem>25-34岁</asp:ListItem>
                        <asp:ListItem>35-44岁</asp:ListItem>
                        <asp:ListItem>45-54</asp:ListItem>
                        <asp:ListItem>54以上</asp:ListItem>
                        
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    个人爱好：</td>
                <td>
                    <asp:CheckBoxList ID="cbFav" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem>运动</asp:ListItem>
                        <asp:ListItem>计算机</asp:ListItem>
                        <asp:ListItem>音乐</asp:ListItem>
                        <asp:ListItem>金融</asp:ListItem>
                        <asp:ListItem>医疗健康</asp:ListItem>
                        <asp:ListItem>财经</asp:ListItem>
                        <asp:ListItem>生物</asp:ListItem>
                        <asp:ListItem>阅读</asp:ListItem>
                        <asp:ListItem>时事</asp:ListItem>
                        <asp:ListItem>生活资讯</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    行业：</td>
                <td class="style2">
                    <asp:CheckBoxList ID="cbHy" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem>广告</asp:ListItem>
                        <asp:ListItem>教育培训</asp:ListItem>
                        <asp:ListItem>计算机</asp:ListItem>
                        <asp:ListItem>建筑</asp:ListItem>
                        <asp:ListItem>会计</asp:ListItem>
                        <asp:ListItem>化学、化工</asp:ListItem>
                        <asp:ListItem>房地产</asp:ListItem>
                        <asp:ListItem>零售业</asp:ListItem>
                        <asp:ListItem>其他行业</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    话费：</td>
                <td class="style2">
                    <asp:CheckBoxList ID="cbHf" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem>100元以下</asp:ListItem>
                        <asp:ListItem>100-300元</asp:ListItem>
                        <asp:ListItem>300-500元</asp:ListItem>
                        <asp:ListItem>500元以上</asp:ListItem>
                    </asp:CheckBoxList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right" valign="top">
                    自定义：</td>
                <td class="style2">
                    <asp:TextBox ID="txtBySelf" runat="server" Height="85px" TextMode="MultiLine" 
                        Width="389px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    使用产品：</td>
                <td>
                    <asp:RadioButtonList ID="rbtnPro" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow" DataTextField="Name" DataValueField="Type"> 
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    选择条数：</td>
                <td>
                    <asp:RadioButtonList ID="rbtnCount" runat="server" 
                        RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem>1000</asp:ListItem>
                        <asp:ListItem Selected="True">2000</asp:ListItem>
                        <asp:ListItem>3000</asp:ListItem>
                        <asp:ListItem>5000</asp:ListItem>
                        <asp:ListItem>10000</asp:ListItem>
                        <asp:ListItem>20000</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right" valign="top">
                    短信内容：</td>
                <td>
                    <asp:TextBox ID="txtContent" onpropertychange="changetext()" runat="server" Height="86px" TextMode="MultiLine" 
                        Width="390px"></asp:TextBox>
                    已输入<asp:Label ID="lblCount" runat="server" Text="0"></asp:Label>
                    字</td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="提交需求" onclick="Button1_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
