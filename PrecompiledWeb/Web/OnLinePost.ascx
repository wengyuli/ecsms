<%@ control language="C#" autoeventwireup="true" inherits="OnLinePost, App_Web_yfwijek1" %>
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

