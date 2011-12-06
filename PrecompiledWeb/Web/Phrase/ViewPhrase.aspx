<%@ page language="C#" autoeventwireup="true" inherits="ViewPhrase, App_Web_03kr0a4j" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>从我的短语库选择短语</title>
    <style type="text/css">
       #main
       {
       	 font-size:12px;
          width:100%; 
       }
       
      #operate
      {  
      	 text-align:left; 
         height: 543px;
        }
 
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div id="main">
   
    <div id="treeview"> 
    
    <table><tr><td>
        短语分类：<asp:RadioButtonList ID="rbtnSelect" runat="server" AutoPostBack="true"  
            onselectedindexchanged="RadioButtonList1_SelectedIndexChanged" 
            RepeatDirection="Horizontal" RepeatLayout="Flow" >
        <asp:ListItem Text="我的短语库" Value="my" Selected="True"></asp:ListItem>
         <asp:ListItem Text="公共短语库" Value="public"></asp:ListItem> </asp:RadioButtonList>  </td>
         <td align="right">
             &nbsp;</td>
         <td>   
             &nbsp;</td></tr><tr><td><br />
             分组列表：<asp:DropDownList ID="dropGroup" runat="server" AutoPostBack="true"    onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            </td>
         <td align="right">
             &nbsp;</td>
         <td>   
             &nbsp;</td></tr></table>      
             
          
         </div>
      <hr />
      <div id="operate">
      
           <fieldset >
              <legend>短语列表</legend>      
        <asp:Label ID="lbTishi" runat="server" Text=""></asp:Label>
            <asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
              <asp:Label ID="lbViewTishi" runat="server" Visible="false"></asp:Label>
              
           <asp:Panel ID="Panelist" runat="server"  >
           <asp:DataList ID="Dlist" runat="server"   Width="100%" >
     <HeaderTemplate>
       <table align="left" cellpadding="3px" cellspacing="0" style=" background-color:#E3EFFB">
        <tr>
          <td  align="left" style="width: 1%; height: 16px"><span style=" font-weight:bold"></span></td>
          <td align="left" style="width: 10%; height: 16px"><span style=" font-weight:bold">
          <asp:Label ID="lbName" runat="server" Text="内容"></asp:Label></span></td>
        </tr>
          </table>
    </HeaderTemplate>
    <ItemTemplate >
            <table cellpadding="3px" cellspacing="0">
            <tr>
                <td align="left" style="width: 1%; height: 16px"><input  type="checkbox"  id="Chkitem"   name="Chk" runat="server"  onclick="SelectOne()"/></td>
                <td  align="left" style="width: 10%; height: 16px" >
                    <asp:Label ID="lbPhrase"  title='<%# Eval("Phrase").ToString()%>' runat="server" Text='<%# ((Eval("Phrase").ToString().Length>30)?(Eval("Phrase").ToString().Substring(0,30)+"..."):Eval("Phrase").ToString())%>'></asp:Label></td>
               
            </tr>
            </table>
        </ItemTemplate>
          </asp:DataList> 
          <webdiyer:AspNetPager ID="AspNetPager1" runat="server"    
            PageSize="10"
             FirstPageText="首页"
             LastPageText="末页"
             NextPageText="下一页"
             PrevPageText="上一页" 
             Font-Size="12px"          
              HorizontalAlign="left"  OnPageChanging="AspNetPager1_PageChanging">
    </webdiyer:AspNetPager> 
          </asp:Panel>
          <input id="btnCertain" type="button" value="选择此短语" onclick="GetPhrase()" />
            
            </fieldset>
          </div>  
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    function SelectOne() {
        var Id = event.srcElement.id;
      
        var allchkbox = 'Dlist_ctl00_Chkitem';
        var el = document.getElementsByTagName('input');
        var len = el.length;
        for (var i = 0; i < len; i++) {
            if ((el[i].type == "checkbox") && ((el[i].id == Id))) {
                el[i].checked = true;
            }
            else {
                el[i].checked = false;
            }
        }
    }
    function GetPhrase() {
        var Prase="";
        var el = document.getElementsByTagName('input');
        var len = el.length;
        for (var i = 0; i < len; i++) {
            if ((el[i].type == "checkbox") && ((el[i].name.indexOf('Dlist$ct')) != -1)) {
                if ((el[i].checked == true)&&(el[i].id!='Dlist_ctl00_Chkitem')) {
                    var chkId = el[i].id;
                    
                    chkId = chkId.substring(0, chkId.lastIndexOf('_')) + "_lbPhrase";
       
                    Prase += document.getElementById(chkId).title;

                }
            }
        }
      
        window.opener.document.getElementById("txtSmsContent").value = Prase;
        window.close();
    }
</script>
