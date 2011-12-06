<%@ page language="C#" autoeventwireup="true" inherits="Right, App_Web_yfwijek1" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script language="javascript" type="text/javascript">
// <!CDATA[

        function say() {
            alert(document.getElementById("select1").options[document.getElementById("select1").selectedIndex].value);
        }

// ]]>
    </script>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
        <%--<%=DateTime.Now.ToString("yyyyMMddHHmmss") %>
        <asp:Image ID="Image1" ImageUrl="~/ValeCode.aspx" runat="server" />--%>
        <select id="Select1" onchange="return say()">
            <option value="1"></option>
            <option value="2"></option>
        </select> 
    </div>
    </form>
</body>
</html>
