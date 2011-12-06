<%@ page language="C#" autoeventwireup="true" inherits="SelectNumbers, App_Web_o2hbm0z2" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function getNumber() {
            var phone = document.getElementById("txtNumbers").value;
            window.opener.document.getElementById("txtNumbers").value += phone+"\r\n";
            window.close();
        }
    </script>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
    <fieldset>
    <legend style="font-size:14px; font-weight:bold;">导入号码</legend>
    <div id="divTxt" >
                    选择号码文件:<asp:FileUpload ID="fileUp" runat="server" /><br />
                    <span style=" color:Red;">
                    1:上传文件应为文本文件(*.txt)；                     
                        <br />2:多个手机号码之间用回车符分割；
                        <br />3:读取大容量文件速度较慢，请不要在读取过程中进行操作。</span>
                    <div>
                    
                        <table width="481">
                            <tr>
                                <td>
                    
                                    &nbsp;</td>
                                <td align="right">
                    
                    <asp:Button ID="btnReadNumbers" runat="server" Text="读取数据" onclick="btnReadNumbers_Click" />
                    
                    
                                </td>
                            </tr>
                        </table>
                    
                    
                    </div>
                    
                    

                    <asp:TextBox ID="txtNumbers" runat="server" Height="281px" TextMode="MultiLine" 
                        Width="481px"></asp:TextBox>
                    </div>
    
    </fieldset>
    </div>
    </form>
</body>
</html>
