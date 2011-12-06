<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SMSAccount.aspx.cs" Inherits="AccountSMS" %>

<%@ Register src="../Broadcast/Broadcast.ascx" tagname="Broadcast" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 495px;
        }
        .style2
        {
            width: 95px;
        }
        .style3
        {
            width: 100%;
        }
    </style>
    
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div style="">
        <fieldset style="height: 205px">
        <legend style="font-size:14px; font-weight:bold;">平台动态</legend>
            <table width="100%">
                <tr>
                    <td class="style1">
                    <div id="divShowWait" runat="server" visible="false">
                        <table class="style11">
                            <tr>
                                <td align="right" class="style12">
                                    在线代理   ：</td>
                                <td>
                                    <a href="../OnlineUser.aspx">【<asp:Label ID="lblOnlineAgent" runat="server" Text="0"></asp:Label>】人</a>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style12">
                                    在线集团用户：</td>
                                <td>
                                    <a href="../OnlineUser.aspx">【<asp:Label ID="lblOnlineCUser" runat="server" Text="0"></asp:Label>】人</a>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style12">
                                    在线用户   ：</td>
                                <td>
                                    <a href="../OnlineUser.aspx">【<asp:Label ID="lblOnlineUser" runat="server" Text="0"></asp:Label>】人</a>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style12">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right" class="style12">
                                    当前待发短信 ：</td>
                                <td>
                                    <a href="../Admin/WaitSms.aspx">【<asp:Label ID="lblWaitSmsCount" Text="0" runat="server"></asp:Label>】条</a></td>
                            </tr>
                            <tr>
                                <td align="right" class="style12">
                        当前待审核用户：</td>
                                <td>
                                    <a href="../Admin/regmanage.aspx">【<asp:Label ID="lblWaitUserCount" Text="0" runat="server"></asp:Label>】人</a></td>
                            </tr>
                        </table>
                    </div>
                    <div id="divNews" runat="server" style=" width:490px; height:210px;">
                        <iframe frameborder="0" 

width="490px" height="210px" marginheight="1" 

marginwidth="1" src="http://ecsms.com.cn/news/index.asp" 

scrolling="no"></iframe>
                    </div>   
                    </td>
                    <td class="style10">                   
                    <div style=" margin-left:50px; ">
                        <iframe 

src="http://m.weather.com.cn/m/pn12/weather.htm " 

width="245" height="110" marginwidth="0" marginheight="0" 

hspace="0" vspace="0" frameborder="0" 

scrolling="no"></iframe>
                    </div>
                    </td>
                </tr>
                </table>
        </fieldset>
        
        <fieldset>
        <legend style="font-size:14px; font-weight:bold;">我的账户</legend>
           
        <asp:Label ID="lblUserId" runat="server" Visible="false"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


        
        <table  style=" font-family:微软雅黑;" width="100%">
            <tr>
                <td align="center" class="style2" >
                    &nbsp;</td>
                <td align="center">
                    &nbsp;</td>
                <td align="center" colspan="3">
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td align="right" class="style2" >
                    姓名：</td>
                <td align="left" >
                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
                <td align="left" colspan="3" rowspan="5" >
                    <table class="style3" id="userAccountTable" runat="server">
                        <tr>
                            <td>
    3G直告可发送条数：</td>
                            <td>
                    <asp:Label ID="lblABalance" runat="server" Text="【0】"></asp:Label>
                            </td>
                            <td>
                    <asp:ImageButton ID="ImageButton1" PostBackUrl="~/UpInfo.aspx" ImageUrl="../Img/buysms.gif" style="width: 87px; height: 18px"  runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
    企信通可发送条数：</td>
                            <td>
                    <asp:Label ID="lblBBalance" runat="server" Text="【0】"></asp:Label>
                            </td>
                            <td>
                    <asp:ImageButton ID="ImageButton2" PostBackUrl="~/UpInfo.aspx" ImageUrl="../Img/buysms.gif" style="width: 87px; height: 18px"  runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
    会员通可发送条数：</td>
                            <td>
                    <asp:Label ID="lblCBalance" runat="server" Text="【0】"></asp:Label>
                            </td>
                            <td>
            <asp:ImageButton ID="ImageButton3" PostBackUrl="~/UpInfo.aspx" ImageUrl="../Img/buysms.gif" style="width: 87px; height: 18px"  runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
    准告可发送条数：</td>
                            <td>
                    <asp:Label ID="lblDBalance" runat="server" Text="【0】"></asp:Label>
                            </td>
                            <td>
                   <asp:ImageButton ID="ImageButton4" PostBackUrl="~/UpInfo.aspx" ImageUrl="../Img/buysms.gif" 
                                    style="width: 87px; height: 18px"  runat="server" Height="16px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
    闪信可发送条数：</td>
                            <td>
                    <asp:Label ID="lblEBalance" runat="server" Text="【0】"></asp:Label>
                            </td>
                            <td>
                  <asp:ImageButton ID="ImageButton5" PostBackUrl="~/UpInfo.aspx" ImageUrl="../Img/buysms.gif" style="width: 87px; height: 18px"  runat="server" />
                            </td>
                        </tr>
                    </table>
                    <div id="divtotalleave" visible="false" runat="server">
                        <table class="style1">
            <tr>
                <td class="style2" align="right">
                    3G直告：</td>
                <td align="left">
                    <asp:Label ID="lblA" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    企信通：</td>
                <td align="left">
                   <asp:Label ID="lblB" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    会员通：</td>
                <td align="left">
                    <asp:Label ID="lblC" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    准告：</td>
                <td align="left">
                    <asp:Label ID="lblD" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2" align="right">
                    闪信：</td>
                <td align="left">
                    <asp:Label ID="lblE" runat="server" Text="0"></asp:Label>
                </td>
            </tr>
        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    账户名称：</td>
                <td align="left" >
                    <asp:Label ID="lblAccount" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    公司名称：</td>
                <td align="left" class="style5" >
                    <asp:Label ID="lblCompanyName" runat="server" Text="暂无"></asp:Label>


        
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    您的经销商：</td>
                <td align="left" class="style5">
                    <asp:Label ID="lblUpAccount" runat="server" Text="无"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
                    &nbsp;</td>
                <td align="right" class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                <td class="style6">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        </fieldset> 
    </div>
    </form>
</body>
</html>
