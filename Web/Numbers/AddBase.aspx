<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddBase.aspx.cs" Inherits="mybase_AddBase" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <script src="../JavaScript/Validator.js" type="text/javascript"></script>
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
      	 position:absolute; left:180px; top:0px; width:400px; height:360px; 	 
      	 }
        .style1
        {
            height: 23px;
        }
        .style2
        {
            height: 40px;
        }
    </style>
</head>
<body  style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div id="main">
        <asp:Label ID="lbvalue" runat="server"  style=" visibility:hidden;"></asp:Label>
        <asp:Label ID="lbParentId" runat="server"  style=" visibility:hidden;"></asp:Label> 

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
           <fieldset style=" height:500px;  width:480px;">
              <legend>我的数据库</legend>
            <asp:Panel ID="PaneoPerate" runat="server">
        
      
             <div id="nav-menu">
         </div> <asp:Label ID="lbTishi" runat="server" Text=""></asp:Label>
            <asp:Label ID="lbCount" runat="server" Text=""></asp:Label>
            <asp:Label ID="lbSelect" runat="server"  Visible="false"></asp:Label> 
            <br />
            <asp:Button ID="lbtnAddmyBaseGroup" runat="server" Text="添加组" 
                    onclick="lbtnAddGroup_Click" Visible="false" />
                <asp:Button ID="lbtnAddmyBase" runat="server" onclick="lbtnAddCums_Click" 
                    Text="添加号码" Visible="false" />
             <asp:Button ID="btndelGroup" runat="server" Text="删除组"  Visible="false" 
                    onclick="btndelGroup_Click" OnClientClick="return confirm('您确认要删除吗！')" />
                <asp:Button ID="btnEditGroup" runat="server" onclick="btnEditGroup_Click" 
                    Text="编辑组" Visible="false" />
                    <asp:Button ID="btnImport" runat="server" onclick="btnImport_Click" 
                    Text="导入客户信息" Width="92px" Visible="false"/>
                    <asp:Button ID="btnCusExport" runat="server" onclick="btnCusExport_Click" 
                    Text="导出客户号码" Width="92px" Visible="false"/>
                    <br />
             <asp:Label ID="lbViewTishi" runat="server"  Visible="false"></asp:Label>
             <asp:Label ID="lbtype" runat="server" Visible="false"></asp:Label>
           </asp:Panel>
            <asp:Panel ID="Panelist" runat="server"  >
          <hr />
            <asp:DataList ID="Dlist" runat="server" oneditcommand="Dlist_EditCommand" 
                    onitemdatabound="Dlist_ItemDataBound">
     <HeaderTemplate>
       <table align="center" cellpadding="3px" cellspacing="0" style=" background-color:#E3EFFB">
        <tr>
          <td align="left" style="width: 50px; height: 16px"><span style=" font-weight:bold">
          <input  type="checkbox"  id="Chkitem"   name="Chk" runat="server" onclick="select_all()" /></span></td>
          <td align="left" style="width:150px; height: 16px"><span style=" font-weight:bold">号码</span></td>
            <td align="left" style="width:150px; height: 16px"><span style=" font-weight:bold">备注</span></td>
           <td align="left" style="width: 50px; height: 16px"><span style=" font-weight:bold">操作</span></td>       
        </tr>
          </table>
    </HeaderTemplate>
    <ItemTemplate >
            <table align="center" cellpadding="3px" cellspacing="0">
            <tr>
                <td align="left" style="width: 50px; height: 16px"><input  type="checkbox"  id="Chkitem"   name="Chk" runat="server" /></td>
                <td  align="left" style="width:150px; height: 16px">
                    <asp:Label ID="lbNum" runat="server" Text='<%# Eval("Number").ToString()%>'></asp:Label></td>
                <td  align="left" style="width:150px; height: 16px"><%#((Eval("Remark").ToString().Length>10)?(Eval("Remark").ToString().Substring(0,10)+"..."):Eval("Remark").ToString())%></td>

                <td align="left" style="width: 50px; height: 16px">
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
                <asp:DropDownList ID="droppubup" runat="server">
                 <asp:ListItem Selected="True" Value="A">3G直告</asp:ListItem>
                        <asp:ListItem Value="B">企信通</asp:ListItem>
                        <asp:ListItem Value="C">会员通</asp:ListItem>
                        <asp:ListItem Value="D">准告</asp:ListItem>
                        <asp:ListItem Value="E">闪信</asp:ListItem>

                </asp:DropDownList>
                <asp:Button ID="btnpubup" runat="server" onclick="Button1_Click" Text="导出号码" 
                    Width="70px" />
          </asp:Panel>
            <asp:Panel ID="PanelAddGroup" runat="server" >
                <table align="left" cellpadding="3px" cellspacing="0">
                 <tr>
	                <td ><span >组名:</span></td>
	                <td><asp:TextBox ID="txtGroupName" runat="server"   Text="" ></asp:TextBox></td>
	             </tr><tr>
	             <td></td><td >(请在组名称中标明组名称和号码数量 <br />例如:公司固定客户1800个)</td></tr>
	             <tr>
	                <td class="style1" ><span >父组:</span></td>
	                <td class="style1">
                        <asp:Label ID="lbParent" runat="server" Text=""></asp:Label></td>
	             </tr> 
	             
	             <asp:Panel ID="PanelPrice" runat="server">
                    <tr>
                    
	                <td ><span >价格:</span></td>
	                <td>
                        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox> </td>
	             </tr> </asp:Panel>
	             <asp:Panel ID="PanelAddGroupCon" runat="server">
	 	        <tr id="Tr1" runat="server" >
	                <td >是否继续添加:</td>
	                <td ><asp:CheckBox ID="ChGroupKeep" runat="server" Text="继续添加"/> </td>
                </tr>
                </asp:Panel>
                 <tr >
	                <td >&nbsp;&nbsp;</td>
	                <td><asp:Button ID="btnSaveGruop" runat="server" Text="保存" OnClientClick="return SaveGroup();" onclick="btnSaveGruop_Click"/>
                        <asp:Button ID="btnCaneclGruop" runat="server" Text="返回" 
                            onclick="btnCaneclGruop_Click"   /></td>
                </tr>
               </table>
            </asp:Panel>
            <asp:Panel ID="PanelAddmyBase" runat="server" >
                 <asp:Label ID="lbPraseId" runat="server"  Visible="false"></asp:Label>
              <table align="left" cellpadding="3px" cellspacing="0">
                <tr>
	                <td class="style2" ><span >手机号码:</span></td>
	                <td class="style2"><asp:TextBox ID="txtMobile" runat="server"  Width="183px"></asp:TextBox></td>
	            </tr>
	            <tr>
	                <td><span >所属组:</span></td>
	                <td>
                        <asp:Label ID="lbmyBaseGroupId" runat="server" style="visibility:hidden"></asp:Label><asp:Label ID="lbPraseGroup" runat="server" Text=""></asp:Label></td>
	            </tr>
	              <tr>
	                <td><span >备注:</span></td>
	                <td>
                        <asp:TextBox ID="txtRemark" runat="server"  TextMode="MultiLine"></asp:TextBox>                        </td>
	            </tr>
                  <asp:Panel ID="panelPrasecon" runat="server">
             
	            <tr id="Tr2" runat="server">
	                <td >是否继续添加:</td>
	                <td ><asp:CheckBox ID="ChCusKeep" runat="server" Text="继续添加"  /> </td>
                </tr>     
                </asp:Panel>
                <tr>
	                <td >&nbsp;</td>
	                <td > <asp:Button ID="btnSave" runat="server" Text="保存" OnClientClick='return SavemyBase();' onclick="btnSave_Click"/>
	                    <asp:Button ID="btnCaneclmyBase" runat="server" Text="返回" 
                            onclick="btnCaneclmyBase_Click"   />
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
	               <asp:Panel ID="PanelEditPrice" runat="server">
                    <tr>
	                <td ><span >价格:</span></td>
	                <td><asp:TextBox ID="txtEditPrice" runat="server"   Text="" ></asp:TextBox></td>
	             </tr>
	             </asp:Panel>

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
            <asp:Panel ID="PanelImport" runat="server" Visible="false">
                <table> 
                <tr><td> <asp:Label ID="Label2" runat="server" Text="请先下载导入模板"></asp:Label> 
                 <asp:Button ID="BtnTemplate" runat="server" Text="下载导入模板" onclick="BtnTemplate_Click" /> </td></tr> 
                 <tr><td>
               <asp:FileUpload ID="FUploadCus" runat="server" /><asp:Button ID="btnImportCus" runat="server" Text="上传" onclick="btnImportCus_Click" />
                       <pre> (  文件类型为:execl文件 大小小于4M)</pre>

           </td></tr>
              <tr>
              <td><asp:DataList ID="DlistImport" runat="server"   Width="120px" oneditcommand="Dlist_EditCommand" Visible="false">
        <HeaderTemplate>
       <table align="center" cellpadding="3px" cellspacing="0"  style=" background-color:#E3EFFB">
        <tr>
          <td align="center" style="width: 60px; height: 16px"><span style=" font-weight:bold">号码</span></td>
          <td align="center" style="width: 60px; height: 16px"><span style=" font-weight:bold">备注</span></td>
         
         </tr>
          </table>
    </HeaderTemplate>
    <ItemTemplate >
            <table align="center" cellpadding="3px" cellspacing="0">
            <tr>
               <td  align="center" style="width: 60px; height: 16px"><asp:Label ID="lbNumber" runat="server" Text='<%# Eval("Number") %>'></asp:Label></td>
                <td  align="center"style="width: 60px; height: 16px"><asp:Label ID="lbRemark" runat="server" Text='<%# Eval("Remark") %>'></asp:Label></td> 
               
            </tr>
            </table>
        </ItemTemplate>
          </asp:DataList></td>  </tr>
          <tr>
              <td> <asp:Button ID="btnConfirm" runat="server" Text="确认导入" onclick="btnConfirm_Click"  Visible="false"/>  
                <asp:Button ID="btnCancer" runat="server" Text="取消导入"  onclick="btnCancer_Click" Visible="false"/>
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
    function SaveGroup() {
        var lbSelect = document.getElementById('<%=lbvalue.ClientID %>').innerHTML;
        var lbParentId = '<%=lbParentId.ClientID %>';
        var GroupNameId = '<%=txtGroupName.ClientID %>';
        if (IsValueNull(lbParentId)) {
            alert("请选择父组织！");
            return false;
        }
        else if (IsValueNull(GroupNameId)) {
            alert("请填写组名称！");
            return false;
        }
        else {
            if ((lbSelect == "sys")||(lbSelect == "public")) {
                var reg = new RegExp("^[1-9]\d*$");
                var txtPrice = '<%=txtPrice.ClientID %>';
                var Price = document.getElementById('<%=txtPrice.ClientID %>').value;
                if (IsValueNull(txtPrice)) {
                    alert("请填写价格！");
                    return false;
                }
                else {
                   if (!reg.test(Price)) {
                        alert("请填写正整数！");
                        return false;
                    }
                }
               
                
            }
           
            return true;
        }
    }
     function EditGroupName() {
         var lbParentId = '<%=lbParentId.ClientID %>';
         var GroupNameId = '<%=txtEditGroupName.ClientID %>';
         var lbSelect = document.getElementById('<%=lbvalue.ClientID %>').innerHTML;
        if (IsValueNull(lbParentId)) {
            alert("请选择父组织！");
            return false;
        }
        else if (IsValueNull(GroupNameId)) {
            alert("请填写组织名称！");
            return false;
        }
        else {
            if ((lbSelect == "sys") || (lbSelect == "public")) {
                var txtPrice = '<%=txtEditPrice.ClientID %>';
                var Price = document.getElementById('<%=txtEditPrice.ClientID %>').value;
                var reg = new RegExp("^[1-9]\d*$");
                if (IsValueNull(txtPrice)) {
                    alert("请填写价格！");
                    return false;
                }
                else {
                    if (!reg.test(Price)) {
                        alert("请填写正整数！");
                        return false;
                    }
                }
            }
            return true;
        }
    }

    function SavemyBase() {
        var lbPraseGroup = '<%= lbPraseGroup.ClientID %>';
        var txtMobile= '<%= txtMobile.ClientID %>';
       
        if (IsValueNull(lbPraseGroup)) {
            alert("请选择父组织！");
            return false;
        }
        else if (IsValueNull(txtMobile)) {
            alert("请填写手机号码！");
            return false;
        }
        else {
            var txtMobile = document.getElementById(txtMobile).value;
            if (!(regIsPhone(txtMobile))) {
                return false;
            }
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

