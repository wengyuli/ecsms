<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminContactList.aspx.cs" Inherits="Contact_AdminContactList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
           #main
       {
          width:100%; height:100%; 
       }
       #treeview
      {
       position:absolute;
       left:0px; top:15px; width:160px; height:410px; 
       text-align:left;
      }
      
      
      #operate
      {
      	 position:absolute; left:180px; top:15px; width:501px; 
height:360px; 	 
      	 }
    </style>
</head>

<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
   <div id="treeview"> 
            <asp:TreeView ID="TrviewGroup" runat="server"  Width="16%" 
                onselectednodechanged="TrviewGroup_SelectedNodeChanged" 
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
                           
                        <fieldset>
              <legend>我的名片夹</legend>      
                                   <asp:Label ID="lbViewTishi" runat="server" ></asp:Label>
<asp:Panel ID="Panelist" runat="server"  Visible="false">

            <asp:DataList ID="Dlist" runat="server"  >
     <HeaderTemplate>
       <table align="center" cellpadding="3px" cellspacing="0" width="100%" style=" background-color:#E3EFFB">
        <tr >
          <td align="left" style="width: 48px; height: 16px"><span style=" font-weight:bold"><input  type="checkbox"  id="Chkitem"   name="Chk" runat="server" onclick="select_all()" /></span></td>
          <td align="left" style="width: 148px; height: 16px"><span style=" font-weight:bold">组名</span></td>
               
        </tr>
          </table>
    </HeaderTemplate>
    <ItemTemplate >
            <table align="center" cellpadding="3px" cellspacing="0" width="100%">
            <tr>
                <td align="left"  style="width: 48px;height: 16px"><input  type="checkbox"  id="Chkitem"   name="Chk" runat="server" /></td>
                <td align="left"  style="width: 148px;height: 16px"><asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label>
                    <asp:Label ID="lbName" runat="server" Text='<%# Eval("Name") %>'></asp:Label></td>
               
            </tr>
            </table>
        </ItemTemplate>
          </asp:DataList> 
      <webdiyer:AspNetPager ID="AspNetPager1" runat="server"    PageSize="10"
             FirstPageText="首页"
             LastPageText="末页"
             NextPageText="下一页"
             PrevPageText="上一页" 
             Font-Size="12px"          
              HorizontalAlign="left"  OnPageChanging="AspNetPager1_PageChanging">
    </webdiyer:AspNetPager>
             <asp:Button ID="btnout" runat="server" Text="导出名片夹" onclick="btnout_Click" />
          </asp:Panel>
            </fieldset>
          </div> 
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    function select_all() {
        var allchkbox = 'Dlist_ctl00_Chkitem';
        var allchk = document.getElementById(allchkbox);
        var el = document.getElementsByTagName('input');
        var len = el.length;
        for (var i = 0; i < len; i++) {
            if ((el[i].type == "checkbox") && ((el[i].name.indexOf('Dlist$ct')) != -1)) {
                if (allchk.checked == true) {
                    el[i].checked = true;
                }
                else {
                    el[i].checked = false;
                }
            }
        }
    }
</script>