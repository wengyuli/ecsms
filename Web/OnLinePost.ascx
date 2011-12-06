<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OnLinePost.ascx.cs" Inherits="OnLinePost" %>
<script type="text/javascript" src="http://www.ecsms.cn/JavaScript/jquery.js"></script>
<script type="text/javascript">
    function requestServer(userId) {
        
        $.get(
            "../SetOnLine.aspx",
            { id: userId },
            function (data) {
                //alert(data);
            }
            );
    } 
</script>

