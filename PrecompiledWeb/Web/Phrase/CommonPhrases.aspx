<%@ page language="C#" autoeventwireup="true" inherits="Contact_Common_Phrases, App_Web_03kr0a4j" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
       #main
       {
          width:100%; height:100%; 
       }
       #treeview
      {
       position:absolute;
       left:0px; top:0px; width:160px; height:410px; 
       text-align:left;
      }
      
      
      #operate
      {
      	 position:absolute; left:180px; top:0px; width:400px; 	 
      	 }
    </style>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div id="main">
                           <asp:Label ID="lbParentId" runat="server" Text="Label" style=" visibility:hidden;"></asp:Label> 

         <div id="treeview"> 
             <asp:Panel ID="Panel1" Width="150px" Height="400px" runat="server">             
            <asp:TreeView ID="TrviewGroup" runat="server"   
                     onselectednodechanged="TrviewGroup_SelectedNodeChanged" 
                     ImageSet="XPFileExplorer" NodeIndent="15">
                <ParentNodeStyle Font-Bold="False" />
                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" 
                    HorizontalPadding="0px" VerticalPadding="0px" />
                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" 
                    HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
            </asp:TreeView>
             <asp:Label ID="lbRole" runat="server" Visible="false"></asp:Label>
            </asp:Panel>
         </div>
         
           <div id="operate">
           <fieldset style="width:480px;">
              <legend>我的短语库</legend>  
            <asp:Panel ID="PaneoPerate" runat="server">
        
      
             <div id="nav-menu">
         </div> <asp:Label ID="lbTishi" runat="server" Text=""></asp:Label>
            <asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
            <asp:Label ID="lbSelect" runat="server"  Visible="false"></asp:Label> 
            <br />
            <asp:Button ID="lbtnAddPhraseGroup" runat="server" Text="添加分组" 
                    onclick="lbtnAddGroup_Click" Visible="false" />
                <asp:Button ID="lbtnAddPhrase" runat="server" onclick="lbtnAddCums_Click" 
                    Text="添加短语" Visible="false" />
             <asp:Button ID="btndelGroup" runat="server" Text="删除本组"  Visible="false" 
                    onclick="btndelGroup_Click" OnClientClick="return confirm('您确认要删除吗！')" />
                <asp:Button ID="btnEditGroup" runat="server" onclick="btnEditGroup_Click" 
                    Text="更改组名" Visible="false" />
             <asp:Label ID="lbViewTishi" runat="server" ></asp:Label>
             <asp:Label ID="lbtype" runat="server" Visible="false"></asp:Label>
           </asp:Panel>
            <asp:Panel ID="Panelist" runat="server"  >
          <hr />
            <asp:DataList ID="Dlist" runat="server"   Width="480px" oneditcommand="Dlist_EditCommand" >
     <HeaderTemplate>
       <table align="center" cellpadding="3px" cellspacing="0" style=" background-color:#E3EFFB">
        <tr>
          <td align="left" style="width: 40px; height: 16px"><span style=" font-weight:bold"><input  type="checkbox"  id="Chkitem"   name="Chk" runat="server" onclick="select_all()" /></span></td>
          <td align="left" style="width:400px; height: 16px"><span style=" font-weight:bold"><asp:Label ID="lbName" runat="server" Text="内容"></asp:Label></span></td>
           <td align="left" style="width: 40px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="lbOper" runat="server" Text="操作"></asp:Label></span></td>       
        </tr>
          </table>
    </HeaderTemplate>
    <ItemTemplate >
            <table align="center" cellpadding="3px" cellspacing="0">
            <tr>
                <td align="left" style="width: 40px; height: 16px"><input  type="checkbox"  id="Chkitem"   name="Chk" runat="server" /></td>
                <td  align="left" style="width:400px; height: 16px"><%# ((Eval("Phrase").ToString().Length>30)?(Eval("Phrase").ToString().Substring(0,30)+"..."):Eval("Phrase").ToString())%></td>
                <td align="left" style="width: 40px; height: 16px">
                <asp:LinkButton ID="lbtnEdit" runat="server"  CommandName="edit" CommandArgument='<%# Eval("Id") %>'>[编辑]</asp:LinkButton> 
               </td>
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
          <hr />
          <asp:Button   ID="btndel"  runat="server" Text="删除" OnClientClick="return confirm('您确认要删除吗！')" onclick="btndel_Click"/>
          </asp:Panel>
            <asp:Panel ID="PanelAddGroup" runat="server" >
                <table align="left" cellpadding="3px" cellspacing="0">
                 <tr>
	                <td ><span >分组名称:</span></td>
	                <td><asp:TextBox ID="txtGroupName" runat="server"   Text="" ></asp:TextBox></td>
	             </tr>
	             <tr>
	                <td ><span >上级组织:</span></td>
	                <td>
                        
                        <asp:Label ID="lbParent" runat="server" Text=""></asp:Label></td>
	             </tr>
	             <asp:Panel ID="PanelAddGroupCon" runat="server">
	 	        <tr runat="server" >
	                <td >是否继续添加:</td>
	                <td ><asp:CheckBox ID="ChGroupKeep" runat="server" Text="继续添加"/> </td>
                </tr>
                </asp:Panel>
                 <tr >
	                <td >&nbsp;</td>
	                <td ><asp:Button ID="btnSaveGruop" runat="server" Text="保存" OnClientClick="return SaveGroup();" onclick="btnSaveGruop_Click"/>&nbsp;&nbsp;
                        <asp:Button ID="btnCaneclGruop" runat="server" Text="返回" 
                            onclick="btnCaneclGruop_Click"   /></td>
                </tr>
               </table>
            </asp:Panel>
            <asp:Panel ID="PanelAddPhrase" runat="server" >
                 <asp:Label ID="lbPraseId" runat="server"  Visible="false"></asp:Label>
              <table align="left" cellpadding="3px" cellspacing="0">
                <tr>
	                <td align="right" valign="top"><span >短语内容:</span></td>
	                <td><asp:TextBox ID="txtName" runat="server" TextMode="MultiLine" Height="90px" 
                            Width="220px" onKeyDown='gbcount(1000);' onKeyUp='gbcount(1000);'></asp:TextBox><br /> <asp:Label ID="lbError" runat="server"></asp:Label></td>
	            </tr>
	            <tr>
	                <td><span >所属组:</span></td>
	                <td>
                        <asp:Label ID="lbPhraseGroupId" runat="server" style="visibility:hidden"></asp:Label><asp:Label ID="lbPraseGroup" runat="server" Text=""></asp:Label></td>
	            </tr>
                  <asp:Panel ID="panelPrasecon" runat="server">
             
	            <tr runat="server">
	                <td >是否继续添加:</td>
	                <td ><asp:CheckBox ID="ChCusKeep" runat="server" Text="继续添加"  /> </td>
                </tr>     
                </asp:Panel>
                <tr>
	                <td >&nbsp;</td>
	                <td > <asp:Button ID="btnSave" runat="server" Text="保存" OnClientClick='return SavePhrase();' onclick="btnSave_Click"/>
	                    <asp:Button ID="btnCaneclPhrase" runat="server" Text="返回" 
                            onclick="btnCaneclPhrase_Click"   />
	                </td>
                </tr>
              </table>
            </asp:Panel>
            <asp:Panel ID="PanelEditGroup" runat="server" Visible="false">
            <table align="left" cellpadding="3px" cellspacing="0">
                 <tr>
	                <td ><span >组名称:</span></td>
	                <td><asp:TextBox ID="txtEditGroupName" runat="server"   Text="" ></asp:TextBox></td>
	             </tr>

	            <tr >
	                <td >&nbsp;</td>
	                <td ><asp:Button ID="btnEditGroupName" runat="server" Text="保存" 
                            OnClientClick="return EditGroupName();" onclick="btnEditGroupName_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnEditBack" runat="server" Text="返回" 
                            onclick="btnEditBack_Click" />
                      </td>
                </tr>
               </table>
            </asp:Panel>
            </fieldset>
          </div> 
          
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
    function gbcount(total) {
        var txtContent = document.getElementById('<%=txtName.ClientID %>');
        var lbError = document.getElementById('<%=lbError.ClientID %>');
        lbError.innerHTML = "提示：您已输入(" + txtContent.value.length + "/" + total + ")个字";
        if (txtContent.value.length > total) {
            lbError.innerHTML = "提示：您已输入(" + total + "/" + total + ")个字";
            txtContent.value = txtContent.value.substring(0, total);
        }
    }
    function SaveGroup() {
        var lbParentId = '<%=lbParentId.ClientID %>';
        var GroupNameId = '<%=txtGroupName.ClientID %>';
        if (IsValueNull(lbParentId)) {
            alert("请选择父组织！");
            return false;
        }
        else if (IsValueNull(GroupNameId)) {
            alert("请填写组织名称！");
            return false;
        }
        else {
            return true;
        }
    }
     function EditGroupName() {
         var lbParentId = '<%=lbParentId.ClientID %>';
        var GroupNameId = '<%=txtEditGroupName.ClientID %>';
        if (IsValueNull(lbParentId)) {
            alert("请选择父组织！");
            return false;
        }
        else if (IsValueNull(GroupNameId)) {
            alert("请填写组织名称！");
            return false;
        }
        else {
            return true;
        }
    }

    function SavePhrase() {
        var lbPraseGroup = '<%= lbPraseGroup.ClientID %>';
        var PhraseNameId = '<%= txtName.ClientID %>';
       
        if (IsValueNull(lbPraseGroup)) {
            alert("请选择父组织！");
            return false;
        }
        else if (IsValueNull(PhraseNameId)) {
            alert("请填写短语内容！");
            return false;
        }
        else {
            return true;
        }
        
    }
    function IsValueNull(txtId) {
        var txt = document.getElementById(txtId);
        if (txt.value != "") {
            return false;
        }
        else {
            return true;
        }
    }
    
</script>
