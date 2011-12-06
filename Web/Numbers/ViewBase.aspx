<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewBase.aspx.cs" Inherits="mybase_ViewBase" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>从我的数据库导入号码</title>
    <style type="text/css">
           #main
       {
          width:100%; height:100%; 
       }
       #treeview
      {
       position:relative; float:left;
       text-align:left;
      }
      
      
      #operate
      {
      	 position:relative; float:right;	 
      	 }
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
      <div id="main">
    <div id="treeview"> 
            <asp:TreeView ID="TrviewGroup" runat="server"  Width="16%" onclick="ClickTree()" 
                ShowCheckBoxes="All" 
                 ExpandDepth="0"  ontreenodecheckchanged="TrviewGroup_TreeNodeCheckChanged"
                ImageSet="Contacts" NodeIndent="10" >
                <ParentNodeStyle Font-Bold="True" ForeColor="#5555DD" />
                <HoverNodeStyle Font-Underline="False" />
                <SelectedNodeStyle BackColor="#CCCCFF" Font-Underline="True" 
                    HorizontalPadding="0px" VerticalPadding="0px" />
                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" 
                    HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            </asp:TreeView>
         </div>
         <div id="operate">
          <fieldset >
              <legend>我的数据库</legend>
         
          <asp:TextBox ID="txtphone" runat="server" TextMode="MultiLine" Height="331px" 
                  Width="169px"></asp:TextBox>
          <br />
          <asp:Button ID="btnsms" runat="server" Text="发送短信"  OnClientClick="return getNum();"/>
        </fieldset>
        
          </div>
          </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    
    function ClickTree() {
        var o = window.event.srcElement;
        if (o.tagName == "INPUT" && o.type == "checkbox") {
            var chkcheck = "uncheck";
            if (o.checked == true) {
                chkcheck = "check";
            }
            var ChkId = o.id;
            var index = ChkId.indexOf('CheckBox');
            var Grindex =ChkId.indexOf('TrviewGroupn');
            var linkId = ChkId.substring(Grindex+12,index);
         
            var link = document.getElementById("TrviewGroupt"+linkId );
            __doPostBack("", link.href + "&" + chkcheck);
        }
    }
    function getNum() {
        var txtphone = '<%=txtphone.ClientID %>';
        var phone = document.getElementById(txtphone).innerHTML;
        window.opener.document.getElementById("txtNumbers").value += phone;
        window.close();
        return false;
    }
</script>