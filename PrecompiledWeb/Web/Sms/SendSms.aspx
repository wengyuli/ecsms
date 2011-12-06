<%@ page language="C#" autoeventwireup="true" inherits="SendSms, App_Web_o2hbm0z2" stylesheettheme="default" %>

<%@ Register assembly="ZLTextBox" namespace="BaseText" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     
    <script type="text/javascript">
        function checkdata() {
//            document.getElementById("txtSign").disabled = true; //签名
//            document.getElementById("txtSmsContent").disabled = true; //短信内容
//            document.getElementById("txtNumbers").disabled = true//号码
//            document.getElementById("txtSendTime").disabled = true;//时间
        
            if (document.getElementById("txtNumbers").value == "") {
                alert("请填写接收短信的手机号码。");
                return false;
            }  
            if (document.getElementById("txtSmsContent").value == "") {
                alert("请填写短信内容。");
                return false;
            }
            if (!document.getElementById("cbAgree").checked) {
                alert("您没有同意[商信宝短信管理平台使用协议]，不能提交短信。");
                return false;
            }
            PreViewSms();
            var totalNumbers = GetTotalNumbers();
            var SmsLength = document.getElementById("lblTextLength").innerHTML;
            var CutNum = document.getElementById("lblCutNum").innerHTML;
            var issend = confirm("本次任务短信内容【" + SmsLength + "】字，拆分【" + CutNum + "】条，号码【" + totalNumbers + "】个，共消费【" + totalNumbers * CutNum + "】条，\r\n\r\n请确保内容无敏感词，号码格式输入正确。\r\n\r\n确定提交本次任务吗？");
            if (issend) {
                showWait();
                return true;
            }
            else {
                return false;
            }
        }
        function showWait() {
            document.getElementById("div_wait").style.display = "block";
        }
        function PreViewSms() {
            var signText = document.getElementById("txtSign").value; //签名
            var smsText = document.getElementById("txtSmsContent").value; //短信内容            
            var signPostion = document.getElementById("radioFirst");
            var totalText = signPostion.checked ? signText + smsText : smsText + signText; //完全内容
            var totallength = totalText.length;  //总长度
            var IsLong = document.getElementById("selectLong").options[document.getElementById("selectLong").selectedIndex].value;
            switch (IsLong) {
                case "0": //普通
                    if (totallength > 70) {
                        document.getElementById("txtSmsContent").value = document.getElementById("txtSmsContent").value.substr(0, 70 - document.getElementById("txtSign").value.length);
                        return false;
                    }
                    else {
                        document.getElementById("lblTextLength").innerHTML = totallength;
                        document.getElementById("lblCutNum").innerHTML = 1;
                        document.getElementById("txtPre").value = totalText;
                        return;
                    }
                    break;
                case "1": //超长
                    var byteLength = totalText.replace(/[^x00-xFF]/g, '**').length;
                    var reg = /^\w*$/;
                    if (reg.test(totalText)) {//纯英文、数字
                        if (byteLength > 255) {
                            document.getElementById("txtSmsContent").value = document.getElementById("txtSmsContent").value.substr(0, 255 - document.getElementById("txtSign").value.length);
                            return false;
                        }
                        else {
                            document.getElementById("lblTextLength").innerHTML = totallength;
                            document.getElementById("lblCutNum").innerHTML = (totallength % 60 == 0 ? totallength / 60 : parseInt(totallength / 60) + 1);
                            document.getElementById("txtPre").value = totalText;
                            return;
                        }
                    } else {//非纯英文、数字
                    if (totallength > 127) {
                        document.getElementById("txtSmsContent").value = document.getElementById("txtSmsContent").value.substr(0, 127 - document.getElementById("txtSign").value.length);
                        return false;
                    }
                    else {
                        document.getElementById("lblTextLength").innerHTML = totallength;
                        document.getElementById("lblCutNum").innerHTML = (totallength % 60 == 0 ? totallength / 60 : parseInt(totallength / 60) + 1);
                        document.getElementById("txtPre").value = totalText;
                        return;
                    }
                    }
                    break;
                case "2": //分条
                    if (totallength > 594) {
                        document.getElementById("txtSmsContent").value = document.getElementById("txtSmsContent").value.substr(0, 594 - document.getElementById("txtSign").value.length);
                        return false;
                    }
                    else {
                        var totalTips;
                        if (totallength > 70) {
                            totalTips = (totallength % 66 == 0 ? totallength / 66 : parseInt(totallength / 66) + 1);
                            totallength += totalTips * 4;
                        }
                        totalTips = (totallength % 70 == 0 ? totallength / 70 : parseInt(totallength / 70) + 1); //普通短信拆分条数
                        document.getElementById("lblTextLength").innerHTML = totallength;
                        document.getElementById("lblCutNum").innerHTML = totalTips;
                        if (totalTips > 1) {
                            document.getElementById("txtPre").value = "1/" + totalTips + ")" + (totalText).substr(0, 66);
                        }
                        else {
                            document.getElementById("txtPre").value = totalText;
                        }
                        return;
                    }
                    break;                    
            }       
        }
        //实时预览
        function changetext() {
            PreViewSms();
        }        
        
        //设置签名前后顺序
        function SetSign() {
            PreViewSms();
        }
        
        //切换上一页 下一页
        function showsms(type) {
            var IsLong = document.getElementById("selectLong").options[document.getElementById("selectLong").selectedIndex].value;
             if (IsLong == "2") {
                var txt = document.getElementById("txtSmsContent");
                var sign = document.getElementById("txtSign");
                var pre = document.getElementById("txtPre");                
                var radio = document.getElementById("radioFirst");
                var totalText = radio.checked ? sign.value + txt.value : txt.value + sign.value;
                var totallength = totalText.length;
                var pageIndex = document.getElementById("pageIndex");
                var pageCount;
                if (totallength > 70) {
                    pageCount = (totallength % 66 == 0 ? totallength / 66 : parseInt(totallength / 66) + 1);
                    totallength += pageCount * 4;
                } 
                if (totalText.length < 70) {
                    return false;
                }
                else {
                    var preText;
                    var contentText;
                    var startIndex;
                    var subLength;
                    switch (type) {
                        case 'pre':
                            if (parseInt(pageIndex.value) - 1 > 0) {
                                document.getElementById("pageIndex").value = parseInt(pageIndex.value) - 1;
                                preText = pageIndex.value + "/" + pageCount + ")";
                                startIndex = (parseInt(pageIndex.value)-1) * 66;
                                subLength = (totalText.length - startIndex) > 66 ? 66 : totalText.length - startIndex;
                                //alert(totalText.length+"-"+startIndex+"-"+subLength);
                                contentText = totalText.substr(startIndex, subLength);
                                document.getElementById("txtPre").value = preText + contentText;

                            }
                            break;
                        case 'next':
                            if (parseInt(pageIndex.value) + 1 <= pageCount) {
                                preText = (parseInt(pageIndex.value) + 1) + "/" + pageCount + ")";
                                startIndex = pageIndex.value * 66;
                                subLength = (totalText.length - pageIndex.value * 66) > 66 ? 66 : totalText.length - pageIndex.value * 66;
                                contentText = totalText.substr(startIndex, subLength); 
                                document.getElementById("txtPre").value = preText + contentText;
                                document.getElementById("pageIndex").value = parseInt(pageIndex.value) + 1;
                            }
                            break;
                    }
                }
            }
            else {
                return false;
            }


        } 
         
        function getNewArray(receiveArray) {
            var arrResult = new Array(); //定义一个返回结果数组.
            var arrA = receiveArray.split("\r\n");
            for (var i = 0; i < arrA.length; i++) {
                if (check(arrResult, arrA[i]) == -1)//在这里做i元素与所有判断相同与否
                {
                    arrResult.push(arrA[i]); //　添加该元素到新数组。如果if内判断为false（即已添加过），则不添加。
                }
            }
            return arrResult;
        }
        function check(receiveArray, checkItem) {
            var index = -1; //　函数返回值用于布尔判断
            for (var i = 0; i < receiveArray.length; i++) {
                if (receiveArray[i] == checkItem) {
                    index = i;
                    break;
                }
            }
            return index;
        }

        function DelRepeat() {
            var number = document.getElementById("txtNumbers").value;
            var str = new Array();
            var strA = number.split("\r\n");
            str = getNewArray(number);
            var temp=new String();
            for (var i = 0; i < str.length; i++) {
                 temp+= str[i] + "\r\n";
             }
             document.getElementById("txtNumbers").value = temp;
             alert("过滤了个【"+(strA.length-str.length)+"】重号");
         }
        
        function DelWrong() {
            var number = document.getElementById("txtNumbers").value;
            var str = number.split("\r\n");
            var temp = new String();
            var p = /^1[358]\d{9}$/;
            var a=0;
            for (var i = 0; i < str.length; i++) {
                if (str[i] != "") {
                    if (p.test(str[i])) {
                        temp += str[i] + "\r\n";
                    }
                    else {
                        a++;
                    } 
                }
            }
            document.getElementById("txtNumbers").value = temp;
            alert("过滤了个【" + a + "】错号");         
        }

        function GetTotalNumbers() {
            var numbers = document.getElementById("txtNumbers").value;
            var tryNumbers = document.getElementById("txtTryNumbers").value;
            var arrNumbers = numbers.split("\r\n");
            var count = 0;
            for (var i = 0; i < arrNumbers.length; i++) {
                if (arrNumbers[i] != "") {
                    count++;
                }
            }
            arrNumbers = tryNumbers.split("\r\n");
            for (var i = 0; i < arrNumbers.length; i++) {
                if (arrNumbers[i] != "") {
                    count++;
                }
            }
            return count;
        }
    
        function Computenumbers() {
            document.getElementById("lblNumberCount").innerHTML = "共【" + GetTotalNumbers() + "】个号码";
        }

        function ClearNumbers() {
            document.getElementById("txtNumbers").value = "";
        }
    </script>
    
    <script type="text/javascript">
        function OpenWindow(url, width, height) {
            window.open(url,
            "",
            "top=50, left=150,height=" + height + ", width=" + width + ",toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,status=no",
            "")
        }                    
    </script>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 507px;
        }
        .style3
        {
            width: 499px;
        }
        .style4
        {
            width: 322px;
        }
        .style5
        {
            width: 490px;
        }
        .sendnumber{ 
	color:#000;
	border:1px solid #b3b3b3;
	background-position:100% 0%;
	background-attachment:fixed;
	background:url(../Img/sendnumber.gif) no-repeat left;
}
    .sendcontent{ 
	color:#000;
	border:1px solid #b3b3b3;
	background-position:100% 0%;
	background-attachment:fixed;
	background:url(../Img/sendcontent.gif) no-repeat left;
}
    </style>
</head>
<body style=" background-color:White; font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div >
        <div id="div_wait" style=" background-color:Gray;  position:absolute; width:100%; height:100%; filter:alpha(opacity=70);
             display:none; font-family:微软雅黑; font-size:larger; text-align:center; vertical-align:middle; color:White; ">
             <br /><br /><br /><br /><br />
        <span style=" font-size:x-large; "> 正在发送中...<br /><br />
        （由于号码数量较多或者网络原因导致提交速度慢，请耐心等待）
        </span></div>

        <table class="style1">
            <tr bgcolor="#FFFFFF">
                <td class="style5" style=" color:Red;">
                    您在【<asp:Label ID="lblTypeName" runat="server"></asp:Label>】
                    中的余额为【<asp:Label ID="lblSmsCount" runat="server"></asp:Label>】
                    条
                    <asp:Label ID="lblType" style=" visibility:hidden;" runat="server"></asp:Label>
                    <asp:Label ID="lblUserId" runat="server" style=" visibility:hidden;"></asp:Label>
                </td>
                <td>  
                <asp:TextBox ID="txtInType" Text="input" style=" visibility:hidden;" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style=" border:solid 1px Red; background-color:#F4F4F4">
                <td class="style5" valign="top" bgcolor="#FFFFFF" >                                    
                    <%--<input type="button" onclick="show('num')" value="输入手机号码"></input>--%>
                    <input type="button" onclick="OpenWindow('SelectNumbers.aspx','520','445')" value="文件导入" ></input>
                    <input type="button" onclick="OpenWindow('../Contact/ViewContact.aspx','650','600')" value="名片夹导入"></input>
                    <input type="button" onclick="OpenWindow('../numbers/viewbase.aspx','400','450')" value="我的数据库导入"></input>
                    <span style=" color:Red;">手机号码之间用回车符分隔</span> 
                </td>
                <td bgcolor="#FFFFFF" align="center" valign="bottom" class="style10" >
                                        体验号码</td>
            </tr>
            <tr style=" background-color:#F4F4F4">
                <td class="style5" valign="top" bgcolor="#FFFFFF">

                    <div id="divNum" >
                        <table class="style1">
                            <tr>
                                <td class="style4">
                    <asp:TextBox ID="txtNumbers" CssClass="sendnumber" onchange="Computenumbers()"  runat="server" 
                            Height="111px" TextMode="MultiLine" 
                            Width="312px"></asp:TextBox>      
                    
                                </td> 
                                <td valign="top" style=" color:Red;">
                                    1，每行写一个号码，每个号码末尾回车<br />
                                    2，请不要一行写多个号码<br />
                                    3，空行当作一个号码<br />
                                    例如：<br />
                                    13666666666<br />
                                    13888888888<br />
                                    13999999999<br />
                                </td>
                            </tr>
                        </table>
                    
                    </div>
                    
                </td>
                <td class="style8" bgcolor="#FFFFFF" align="center" valign="top">
                                        <asp:TextBox ID="txtTryNumbers" onchange="Computenumbers()" runat="server" Height="111px" 
                        TextMode="MultiLine" Width="161px" ></asp:TextBox>
                         
                </td>
            </tr>
            <tr>
                <td class="style3" valign="bottom" bgcolor="#FFFFFF" colspan="2">
                    <input id="Button1" type="button" onclick="DelRepeat()" value="过滤重号" /> 
                    <input id="Button2" type="button" onclick="DelWrong()" value="过滤错号" />
                    <asp:Button ID="delBlack" runat="server" onclick="delBlack_Click" Text="过滤我的黑名单" />
                    <input id="Button3" type="button" onclick=" return ClearNumbers()" value="清空号码" /><asp:Label ID="lblNumberCount" runat="server" Text=""></asp:Label>
                        </td>
            </tr>
            <tr>
                <td class="style5" valign="bottom" bgcolor="#FFFFFF">
                    请输入短信内容
                    <input id="btnPhrase" type="button" onclick="OpenWindow('../Phrase/ViewPhrase.aspx','600','500')" value="常用短语"/>
                    <%--<select id="selectLong" runat="server">
                    </select>--%>
                    <asp:DropDownList ID="selectLong" onchange="PreViewSms()" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="center" bgcolor="#FFFFFF" >短信预览</td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td class="style5" valign="top">
                    <asp:TextBox ID="txtSmsContent" CssClass="sendcontent" onclick="Computenumbers()" onpropertychange="changetext()" runat="server" 
                        Height="100px" TextMode="MultiLine" 
                        Width="439px"></asp:TextBox>
                        
                        
                        <br />
                     预览总字数 <asp:Label ID="lblTextLength" runat="server" Text="0" ForeColor="Red"></asp:Label>
                     字，拆分成 
                    <asp:Label ID="lblCutNum" ForeColor='Red' runat="server" Text="0"></asp:Label>条，普通短信每条上限70个字；
                    <br />超长短信每条60个字，最多支持127个字。
                      
                 
                    <br />签名：
                    <asp:TextBox ID="txtSign" onpropertychange="changetext()" ToolTip="签名的格式如【河南大方公司】，您可以在账户信息中修改签名。" runat="server"></asp:TextBox>
                    如：【商信宝】
                    <input id="radioFirst"  type="radio" value="0" name="ds" runat="server" onclick="SetSign()"/>前置签名
                    <input id="radioLast" checked="true" type="radio" value="1" name="ds" runat="server" onclick="SetSign()"/>后置签名
                </td>
                <td align="center" valign="top">
                <div style= " background-image:url( ../Img/z_16.gif); width:144px; height:19px;"></div>
                    <asp:TextBox ID="txtPre" runat="server" Height="140px" TextMode="MultiLine" 
                        Width="140px" BorderStyle="Solid" BorderColor="#B9B9B9" ReadOnly="true" BorderWidth="1px"></asp:TextBox>
                    <br /><input id="pageIndex" style=" display:none; width:5px;" type="text" value="1"/>
                    <span id="prePage" onclick="showsms('pre')" style=" cursor:pointer;">上一页</span>  
                    <span id="nextPage" onclick="showsms('next')" style=" cursor:pointer;" >下一页</span></td>
            </tr>
            <tr>
                <td align="center" style=" color:Red;" colspan="3" bgcolor="#FFFFFF">
                    <asp:CheckBox ID="cbAgree" runat="server" Text="我同意" />
                    
[<a href="../User/Reg.aspx?agree=yes" style=" color:Red;" target="_blank">商信宝短信管理平台使用协议</a>]</td>
            </tr>
            <tr>
                <td align="center" colspan="4" bgcolor="#FFFFFF">
 <br />
                    定时发送时间:<cc1:ZLTextBox ID="txtSendTime" runat="server" InputType="date"></cc1:ZLTextBox>


                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;


                <asp:Button ID="btnSend" OnClientClick="return checkdata()" runat="server" 
                        Text="立即发送" onclick="btnSend_Click" />
                         
                    </td>
            </tr> 
        </table>
 
    </div>
    </form>
</body>
</html>
