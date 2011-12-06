<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactList.aspx.cs" Inherits="ContactList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register assembly="ZLTextBox" namespace="BaseText" tagprefix="cc1" %>
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
      	 position:absolute; left:180px; top:15px; width:601px; height:360px; 	 
     }
    </style>
    <script language="javascript" type="text/javascript" src="../JavaScript/Validator.js"></script>
</head>
<body style=" font-size:12px; font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div id="main">
                        <asp:Label ID="lbParentId" runat="server" Text="Label"  style="visibility:hidden"></asp:Label>
         <div id="treeview"> 
            <asp:TreeView ID="TrviewGroup" runat="server"  Width="16%" 
                 onselectednodechanged="TrviewGroup_SelectedNodeChanged" ImageSet="Contacts" 
                 NodeIndent="10">
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
              <legend>我的名片夹</legend>
             <asp:LinkButton ID="lbtnBrithday" runat="server" onclick="lbtnBrithday_Click" Visible="true">今天谁生日？</asp:LinkButton>
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;客户关键字查找：
             <asp:TextBox ID="txtSelect" runat="server" Width="86px"></asp:TextBox>
            <asp:Button ID="btnSelect" runat="server" Text="查询" onclick="btnSelect_Click" />
            <br />
            <asp:Label ID="lbtype" runat="server" Visible="false"></asp:Label>
            
            <asp:Panel ID="PanelGroupOperate" runat="server" Visible="false" Width="585px">
            <asp:Label ID="lbTishi" runat="server" Text=""></asp:Label>
            【<asp:Label ID="lbCount" runat="server" Text="0"></asp:Label>】个客户
                <br />
                 <asp:Button ID="lbtnAddGroup" runat="server" onclick="lbtnAddGroup_Click" 
                    Text="添加分组" Width="69px"></asp:Button>
                 <asp:Button ID="lbtnAddCums" runat="server" onclick="lbtnAddCums_Click" 
                    Text="添加客户" Width="67px"></asp:Button>
                 <asp:Button ID="btndelGroup" runat="server" Text="删除本组" 
                    onclick="btndelGroup_Click"  OnClientClick="return confirm('您确认要删除吗！')" 
                    Width="68px" />
               <asp:Button ID="btnEditGroup" runat="server" Text="编辑组名" onclick="btnEditGroup_Click" />
                <asp:Button ID="btnImport" runat="server" onclick="btnImport_Click" 
                    Text="导入客户信息" Width="92px" />
                <asp:Button ID="btnExport" runat="server" onclick="btnExport_Click" 
                    Text="导出客户信息" Width="92px" />
                <asp:Button ID="btnCusExport" runat="server" onclick="btnCusExport_Click" 
                    Text="导出客户号码" Width="92px" />
            </asp:Panel> 
             <asp:Label ID="lbViewTishi" runat="server" Text="" Visible="false"></asp:Label>
            <asp:Panel ID="Panelist" runat="server"  Visible="false">
          <hr />
            <asp:DataList ID="Dlist" runat="server"   Width="600px"  oneditcommand="Dlist_EditCommand" >
     <HeaderTemplate>
       <table align="center" cellpadding="3px" cellspacing="0" width="100%">
        <tr>
          <td align="left" style="width: 48px; height: 16px"><span style=" font-weight:bold"><input  type="checkbox"  id="Chkitem"   name="Chk" runat="server" onclick="select_all()" /></span></td>
          <td align="left" style="width: 48px; height: 16px"><span style=" font-weight:bold"><asp:Label ID="lbName" runat="server" Text="姓名"></asp:Label></span></td>
          <td align="left" style="width: 60px; height: 16px"><span style=" font-weight:bold"><asp:Label ID="Label5" runat="server" Text="称呼"></asp:Label></span></td>
          <td align="left" style="width: 60px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="Label7" runat="server" Text="性别"></asp:Label></span></td>  
          <td align="left" style="width: 90px; height: 16px"><span style=" font-weight:bold"><asp:Label ID="lbMobile" runat="server" Text="手机"></asp:Label></span></td>
          <td align="left" style="width: 90px; height: 16px"><span style=" font-weight:bold"><asp:Label ID="Label1" runat="server" Text="QQ"></asp:Label></span></td>
          <td align="left" style="width: 60px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="Label6" runat="server" Text="所属组"></asp:Label></span></td>  
          <td align="left" style="width: 60px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="lbOper" runat="server" Text="操作"></asp:Label></span></td>       
        </tr>
          </table>
    </HeaderTemplate>
    <ItemTemplate >
            <table align="center" cellpadding="3px" cellspacing="0" width="100%" >
            <tr>
                <td align="left"  style="width: 48px;height: 16px"><input  type="checkbox"  id="Chkitem"   name="Chk" runat="server" /></td>
                <td align="left"  style="width: 48px;height: 16px"><asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label><%# Eval("Name") %></td>
                <td align="left"  style="width: 60px; height: 16px"><asp:Label ID="lbGroupId" runat="server" Text='<%# Eval("GroupId") %>' Visible="false"></asp:Label><%# (Eval("NickName").ToString() == "") ? "暂无" : Eval("NickName").ToString()%></td>
                <td align="left"  style="width: 60px; height: 16px"><%# Eval("Sex").ToString()%></td>  
                <td align="left"  style="width: 90px; height: 16px"><%# Eval("Mobile")%></td>  
                <td align="left"  style="width: 90px; height: 16px"><%# Eval("QQ")%></td> 
                <td align="left"  style="width: 60px; height: 16px"><%# Eval("GroupName")%></td>
                <td align="left"  style="width: 60px; height: 16px">
                <asp:LinkButton ID="lbtnEdit" runat="server"  CommandName="edit" CommandArgument='<%# Eval("Id") %>'>[详细]</asp:LinkButton> 
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
          <asp:Button ID="btnsms" runat="server" Text="发送短信" onclick="btnsms_Click" 
                    Visible="False" Width="74px" /> <asp:DropDownList ID="dropChangeGroup" runat="server" Width="113px">
                </asp:DropDownList>        <asp:Button ID="btnChangeGroup" runat="server" 
                    Text="更换分组" onclick="btnChangeGroup_Click" />
          </asp:Panel>
            <asp:Panel ID="PanelAddGroup" runat="server" Visible="false">
                <table align="left" cellpadding="3px" cellspacing="0">
                 <tr>
	                <td ><span >分组名称:</span></td>
	                <td><asp:TextBox ID="txtGroupName" runat="server"   Text="" ></asp:TextBox></td>
	             </tr>
	             <tr>
	                <td ><span >上级组名:</span></td>
	                <td> <asp:Label ID="lbParent" runat="server" Text=""></asp:Label></td>
	             </tr>
	 	         <tr>
	                <td><span >备注:</span></td>
	                <td><asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine"></asp:TextBox></td>
	             </tr>
               <asp:Panel ID="PanelAddGroupCon" runat="server">
                <tr>
	                <td >是否继续添加:</td>
	                <td ><asp:CheckBox ID="ChGroupKeep" runat="server" Text="继续添加"  /> </td>
                </tr> 
                </asp:Panel> 
	           
                 <tr>
	                <td >&nbsp;</td>
	                <td ><asp:Button ID="btnSaveGruop" runat="server" Text="保存" OnClientClick="return SaveGroup();" onclick="btnSaveGruop_Click"/>&nbsp;&nbsp;
                        <asp:Button ID="Button1" runat="server" Text="返回" onclick="Button1_Click"   /></td>
                </tr>
               </table>
            </asp:Panel>
            <asp:Panel ID="PanelAddCums" runat="server" Visible="false">
                 <asp:Label ID="lbCusId" runat="server" Text="Label" Visible="false"></asp:Label>
              <table align="left" cellpadding="3px" cellspacing="0">
                <tr>
	                <td  align="right"><span >姓名：</span></td>
	                <td ><asp:TextBox ID="txtName" runat="server"></asp:TextBox><span style=" color:red">*</span></td>
	            <td align="right"><span >手机号码：</span></td>
	                <td><asp:TextBox ID="txtMobile" runat="server"></asp:TextBox><span style=" color:red">*</span></td>
	            </tr>
	            <tr>
	                <td align="right"><span >称呼：</span></td>
	                <td><asp:TextBox ID="txtNickName" runat="server"></asp:TextBox><span style=" color:red">*</span></td>
	          <td align="right"><span >性别：</span></td>
	                <td><asp:RadioButtonList ID="rbtnSex" runat="server" RepeatDirection="Horizontal">
	                <asp:ListItem Value="男" Selected="True">男</asp:ListItem>
	                 <asp:ListItem Value="女">女</asp:ListItem>
                    </asp:RadioButtonList>&nbsp;</td>
	           
	            </tr>
	            <tr>
	                <td align="right"><span >手机2：</span></td>
	                <td><asp:TextBox ID="txtMobile2" runat="server" ></asp:TextBox></td>
	             <td align="right"><span >出生日期：</span></td>
	                <td>
	                <cc1:ZLTextBox ID="txtBrithday" runat="server" InputType="date" IsDisplayTime="False"></cc1:ZLTextBox>
	                </td> 
	             </tr>
	             <tr>
	               <td align="right"><span >QQ：</span></td>
	                <td><asp:TextBox ID="txtQQ" runat="server"></asp:TextBox></td>
	              <td align="right"><span >Email：</span></td>
	                <td><asp:TextBox ID="txtEmail" runat="server" ></asp:TextBox></td>
	             </tr>
	             <tr>
	                <td align="right"><span >职务：</span></td>
	                <td><asp:TextBox ID="txtPositions" runat="server"></asp:TextBox></td>
	            <td align="right"><span >部门：</span></td>
	                <td><asp:TextBox ID="txtDept" runat="server" ></asp:TextBox></td>
	             </tr>
	             <tr>
	                <td align="right"><span >公司传真：</span></td>
	                <td><asp:TextBox ID="txtfax" runat="server" ></asp:TextBox></td>
	             <td align="right"><span >公司电话：</span></td>
	                <td><asp:TextBox ID="txtTel" runat="server"></asp:TextBox></td>
	            </tr>
	           
	            <tr>
	                <td align="right"><span >公司名称：</span></td>
	                <td colspan="3"><asp:TextBox ID="txtCompany" runat="server" Width="342px"  ></asp:TextBox></td>
	        
	            </tr>
	            
	            <tr>
	                <td align="right"><span >公司网址：</span></td>
	                <td colspan="3"><asp:TextBox ID="txtWebSite" runat="server" Width="342px" ></asp:TextBox></td>
	       
	            </tr>
	            <tr>
	                <td align="right"><span >公司地址：</span></td>
	                <td colspan="3"><asp:TextBox ID="txtComAddress" runat="server" Width="342px"></asp:TextBox></td>
	          
	            </tr>
	            <tr>
	                <td align="right"><span >家庭电话：</span></td>
	                <td ><asp:TextBox ID="txtHomeTel" runat="server" ></asp:TextBox></td>
	           <td align="right"><span >家庭地址：</span></td>
	                <td><asp:TextBox ID="txtHomeAddress" runat="server" ></asp:TextBox></td> 
	             </tr>
	             
	            <tr>
	              <td align="right"><span >邮编：</span></td>
	                <td><asp:TextBox ID="txtPCode" runat="server" ></asp:TextBox></td>
	               <td align="right"><span >客服专员：</span></td>
	                <td><asp:TextBox ID="txtServicer" runat="server" ></asp:TextBox></td>
	            </tr>
	            <tr>
	                <td align="right"><span >起始日期：</span></td>
	                <td><cc1:ZLTextBox ID="ZLTStartTime" runat="server" InputType="date" IsDisplayTime="False"></cc1:ZLTextBox></td>
	             <td align="right"><span >截止日期：</span></td>
	                <td>
	                <cc1:ZLTextBox ID="ZLTStopTime" runat="server" InputType="date" IsDisplayTime="False"></cc1:ZLTextBox>
	                </td> 
	             </tr>
	            
	            <tr>
	                <td align="right"><span >关系级别：</span></td>
	                <td><asp:TextBox ID="txtRelationLevel" runat="server" ></asp:TextBox></td>
	            <td align="right"><span >会员卡号/车牌号：</span></td>
	                <td><asp:TextBox ID="txtCardNumber" runat="server" ></asp:TextBox></td>
	             </tr>
	           
	            
	            <tr>
	                <td align="right"><span >所属组：</span></td>
	                <td colspan="3">
                        <asp:Label ID="lbCusGroupId" runat="server" Text="Label" Visible="false"></asp:Label><asp:Label ID="lbCusGroup" runat="server" Text=""></asp:Label></td>
	            </tr>
	            <tr>
	                <td align="right"><span >个人爱好/其他备注：</span></td>
	                <td colspan="3"><asp:TextBox ID="txtFavrate" runat="server" TextMode="MultiLine" 
                            Width="338px"></asp:TextBox>
                            <br />(请以、间隔 例如 游泳、篮球、等)</td>
	            </tr>
	            <asp:Panel ID="PanelAddCumsCon" runat="server">
	            <tr>
	                <td align="right">是否继续添加：</td>
	                <td colspan="3"><asp:CheckBox ID="ChCusKeep" runat="server" Text="继续添加" /> </td>
                </tr>
                </asp:Panel>
                <tr>
	                <td >&nbsp;</td>
	                <td colspan="3"> <asp:Button ID="btnSaveCus" runat="server" Text="保存" OnClientClick='return SaveCus();' onclick="btnSave_Click"/>
	                 <asp:Button ID="Button2" runat="server" Text="返回" onclick="Button2_Click"   /></td>
                </tr>
              </table>
            </asp:Panel>
            <asp:Panel ID="PanelImport" runat="server" Visible="false">
                 <asp:Label ID="Label2" runat="server" Text="请先下载导入模板"></asp:Label> 
                 <asp:Button ID="BtnTemplate" runat="server" Text="下载导入模板" onclick="BtnTemplate_Click" />
                <asp:FileUpload ID="FUploadCus" runat="server" /><asp:Button ID="btnImportCus" runat="server" Text="上传" onclick="btnImportCus_Click" />
                 <pre> (  文件类型为:execl文件 大小小于4M)</pre>  
                 <asp:Button ID="btnConfirm" runat="server" Text="确认导入" onclick="btnConfirm_Click"/>  
                <asp:Button ID="btnCancer" runat="server" Text="取消导入"  onclick="btnCancer_Click" />
                 <asp:DataList ID="DlistImport" runat="server"   Width="600px" 
                     oneditcommand="Dlist_EditCommand" onitemdatabound="DlistImport_ItemDataBound" >
        <HeaderTemplate>
       <table align="left" cellpadding="3px" cellspacing="0" style=" background-color:#E3EFFB" width="100%">
        <tr>
          <td align="left"  style="width: 60px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="lbName" runat="server" Text="姓名"></asp:Label></span></td>
          <td align="left"  style="width: 60px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="Label3" runat="server" Text="称呼"></asp:Label></span></td>
          <td align="left"  style="width: 60px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="lbSex" runat="server" Text="性别"></asp:Label></span></td>
          <td align="left"  style="width: 60px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="lbMobile" runat="server" Text="手机"></asp:Label></span></td>
          <td align="left"  style="width: 90px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="lbBirthday" runat="server" Text="生日"></asp:Label></span></td>       
          <td align="left"  style="width: 90px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="lbComName" runat="server" Text="公司名称"></asp:Label></span></td>       
          <td align="left"  style="width: 90px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="lbCompanyAddress" runat="server" Text="公司地址"></asp:Label></span></td>       
          <td align="left"  style="width: 90px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="lbEmail" runat="server" Text="Email"></asp:Label></span></td>       
          <td align="left"  style="width: 90px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="lbPostCode" runat="server" Text="邮编"></asp:Label></span></td>       

         </tr>
          </table>
    </HeaderTemplate>
    <ItemTemplate >
            <table align="left" cellpadding="3px" cellspacing="0" style=" background-color:#E3EFFB" width="100%">
            <tr>
               <td  align="left" style="width: 60px; height: 16px"><asp:Label ID="lbName" runat="server" Text='<%# Eval("Name") %>'></asp:Label></td>
                <td align="left" style="width: 60px; height: 16px"><asp:Label ID="lbNickName" runat="server" Text='<%# Eval("NickName") %>'></asp:Label></td> 
                <td align="left" style="width: 60px; height: 16px"><asp:Label ID="lbSex"  runat="server"  Text='<%# Eval("Sex")%>'></asp:Label></td>
                <td align="left" style="width: 60px; height: 16px"><asp:Label ID="lbMobile" runat="server" Text='<%# Eval("Mobile")%>'></asp:Label>  </td>
                <td align="left" style="width: 90px; height: 16px"><asp:Label ID="lbBirthday" runat="server" Text='<%# Eval("Birthday")%>'></asp:Label></td>  
                <td align="left" style="width: 90px; height: 16px"><asp:Label ID="lbComName" runat="server" Text='<%# Eval("CompanyName")%>'></asp:Label></td>  
                <td align="left" style="width: 90px; height: 16px"><asp:Label ID="lbCompanyAddress" runat="server" Text='<%# Eval("CompanyAddress")%>'></asp:Label></td>  
                <td align="left" style="width: 90px; height: 16px"><asp:Label ID="lbEmail" runat="server" Text='<%# Eval("Email")%>'></asp:Label></td>  
                <td align="left" style="width: 90px; height: 16px"><asp:Label ID="lbPostCode" runat="server" Text='<%# Eval("PostCode")%>'></asp:Label>
                <asp:Label ID="lbTelephone" runat="server" Text='<%# Eval("Telephone")%>' Visible="false"></asp:Label>
                    <asp:Label ID="lbMobile2"  runat="server" Text='<%# Eval("Mobile2")%>' Visible="false"></asp:Label>
                    <asp:Label ID="lbQQ" runat="server" Text='<%# Eval("QQ")%>' Visible="false"></asp:Label>
                    <asp:Label ID="lbPositions" runat="server" Text='<%# Eval("Positions")%>' Visible="false"></asp:Label>
                    <asp:Label ID="lbHomeTel" runat="server" Text='<%# Eval("HomeTel")%>' Visible="false"></asp:Label>
                    <asp:Label ID="lbHomeAddress" runat="server" Text='<%# Eval("HomeAddress")%>' Visible="false"></asp:Label>
                    <asp:Label ID="lbWebsite"  runat="server" Text='<%# Eval("Website")%>' Visible="false"></asp:Label>
                    <asp:Label ID="lbFax" runat="server" Text='<%# Eval("Fax")%>' Visible="false"></asp:Label>
                    <asp:Label ID="lbCardNumber" runat="server" Text='<%# Eval("CardNumber")%>' Visible="false"></asp:Label>
                    <asp:Label ID="lbServicer"  runat="server" Text='<%# Eval("Servicer")%>' Visible="false"></asp:Label>
                    <asp:Label ID="lbStartDate" runat="server" Text='<%# Eval("StartDate")%>' Visible="false"></asp:Label>
                    <asp:Label ID="lbEndDate" runat="server" Text='<%# Eval("EndDate")%>' Visible="false"></asp:Label>
                    <asp:Label ID="lbRelationLevel"  runat="server" Text='<%# Eval("RelationLevel")%>' Visible="false"></asp:Label>
                    <asp:Label ID="lbFavrate" runat="server" Text='<%# Eval("Favrate")%>' Visible="false"></asp:Label>
              
                </td>  
            </tr>
            </table>
        </ItemTemplate>
          </asp:DataList>
              
        </asp:Panel>
             <asp:Panel ID="PanelEditGroup" runat="server" Visible="false">
             <table align="left" cellpadding="3px" cellspacing="0">
                 <tr>
	                <td ><span >组名称:</span></td>
	                <td><asp:TextBox ID="txtEditGroupContent" runat="server"   Text="" ></asp:TextBox></td>
	             </tr>
	             <tr>
	                <td >&nbsp;</td>
	                <td ><asp:Button ID="btnEditGroupSave" runat="server" Text="保存" 
                            OnClientClick="return EditGroup()" OnClick="btnEditGroupSave_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnEditGroupBack" runat="server" Text="返回" 
                            onclick="btnEditGroupBack_Click" />
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
        var lbParentId = '<%=lbParentId.ClientID %>';
        var GroupNameId = '<%=txtGroupName.ClientID %>';
        if (IsValueNull(lbParentId)) {
              alert("请选择父组织！");
              return false;
        }
        else if(IsValueNull(GroupNameId))
        {
            alert("请填写组织名称！");
            return false;
        }
        else {
            return true;
        }
    }
    function EditGroup() {
      
         var lbParentId = '<%=lbParentId.ClientID %>';
        var GroupNameId = '<%=txtEditGroupContent.ClientID %>';
        
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
    function SaveCus() {
        var txtNameId = '<%=txtName.ClientID %>';
        var txtMobileId = '<%=txtMobile.ClientID %>';
        var txtNickName = '<%=txtNickName.ClientID %>';
        var lbCusGroupId = '<%=lbCusGroup.ClientID %>';
        var txtCompanyId = '<%=txtCompany.ClientID %>';
        var txtEmailId = '<%=txtEmail.ClientID %>';
        var txtBrithdayId = '<%=txtBrithday.ClientID %>';
        var txtTelId = '<%=txtTel.ClientID %>';
        var txtPostCodeId = '<%=txtPCode.ClientID %>';
        var txtComAddress = '<%=txtComAddress.ClientID %>';
        var txtWebSite = '<%=txtWebSite.ClientID %>';
        var txtCompany = '<%=txtCompany.ClientID %>';
        var txtTel = '<%=txtTel.ClientID %>';
        var txtfax = '<%=txtfax.ClientID %>';
        var txtDept = '<%=txtDept.ClientID %>';
        var txtPositions = '<%=txtPositions.ClientID %>';
        if (IsValueNull(txtNameId)) {
            alert("请输入客户名称！");
            document.getElementById(txtNameId).focus();
            return false;
        }
        else if (IsValueNull(txtMobileId)) {
            alert("请输入客户手机号码！");
            document.getElementById(txtMobileId).focus();
            return false;
        }
        //        else if (IsValueNull(txtCompanyId)) {
        //            alert("请输入公司名称！");
        //            return false;
        //        }
        //        else if (IsValueNull(txtDept)) {
        //            alert("请输入部门！");
        //            return false;
        //        }
        //        
        //        else if (IsValueNull(txtPositions)) {
        //            alert("请输入职务！");
        //            return false;
        //        }
        //        else if (IsValueNull(txtComAddress)) {
        //            alert("请输入公司地址！");
        //            return false;
        //        }
        //        else if (IsValueNull(txtWebSite)) {
        //            alert("请输入公司网址！");
        //            return false;
        //        }
        //        else if (IsValueNull(txtTel)) {
        //            alert("请输入公司电话！");
        //            return false;
        //        }
        //        else if (IsValueNull(txtfax)) {
        //            alert("请输入公司传真！");
        //            return false;
        //        }
        else if (IsValueNull(txtNickName)) {
            alert("请输入称呼！");
            document.getElementById(txtNickName).focus();
            return false;
        }
        else if (IsValueNull(lbCusGroupId)) {
            alert("请在左边的树上选择您要添加的父组织！");
            return false;
        }
        else {
            var txtMobile = document.getElementById(txtMobileId).value;
            if (!(regIsPhone(txtMobile))) {
                document.getElementById(txtMobileId).focus();
                return false;
            }
            if (!(IsValueNull(txtEmailId))) {
                var txtEmail = document.getElementById(txtEmailId).value;
                if (!regIsEmail(txtEmail)) {
                    alert("您输入的邮箱地址不正确请检查！");
                    document.getElementById(txtEmailId).focus();
                    return false;
                }
            }
            if (!(IsValueNull(txtBrithdayId))) {
                var txtBrithday = document.getElementById(txtBrithdayId).value;
                if (!IsDate(txtBrithday)) {
                    alert("请您按照1980-06-06日期格式输入生日！");
                    document.getElementById(txtBrithdayId).focus();
                    return false;
                }
            }
            if (!(IsValueNull(txtTelId))) {
                var txtTel = document.getElementById(txtTelId).value;
                if (!(regIsTel(txtTel))) {
                    alert("请输入正确的电话号码！例如037166666666");
                    document.getElementById(txtTelId).focus();
                    return false;
                }
            }
            if (!(IsValueNull(txtPostCodeId))) {
                var txtPostCode = document.getElementById(txtPostCodeId).value;
                if (!(regIsDigit(txtPostCode))) {
                    alert("请填写正确的邮编地址！");
                    document.getElementById(txtPostCodeId).focus();
                    return false;
                }
            }
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