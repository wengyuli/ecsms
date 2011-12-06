<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewContact.aspx.cs" Inherits="Contact_ViewContact" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>从我的名片夹导入号码</title>
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
                ontreenodecheckchanged="TrviewGroup_TreeNodeCheckChanged" ExpandDepth="0" 
                ImageSet="Contacts" NodeIndent="10">
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
         <asp:Panel ID="Panelist" runat="server"  Visible="false">
                       <asp:Label ID="lbViewTishi" runat="server" Text="" Visible="false"></asp:Label>

            <asp:DataList ID="Dlist" runat="server" >
     <HeaderTemplate>
       <table align="center" cellpadding="3px" cellspacing="0" width="100%" style=" background-color:#E3EFFB">
        <tr>
          <td align="left" style="width: 48px; height: 16px"><span style=" font-weight:bold"><input  type="checkbox"  id="Chkitem"  checked="checked"  name="Chk" runat="server" onclick="select_all()" /></span></td>
          <td align="left" style="width: 48px; height: 16px"><span style=" font-weight:bold"><asp:Label ID="lbName" runat="server" Text="姓名"></asp:Label></span></td>
          <td align="left" style="width: 60px; height: 16px"><span style=" font-weight:bold"><asp:Label ID="Label5" runat="server" Text="称呼"></asp:Label></span></td>
          <td align="left" style="width: 90px; height: 16px"><span style=" font-weight:bold"><asp:Label ID="lbMobile" runat="server" Text="手机"></asp:Label></span></td>
          <td align="left" style="width: 60px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="Label7" runat="server" Text="Email"></asp:Label></span></td>  
          <td align="left" style="width: 90px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="lbComName" runat="server" Text="公司名称"></asp:Label></span></td>
          <td align="left" style="width: 60px; height: 16px"><span style=" font-weight:bold"> <asp:Label ID="Label6" runat="server" Text="所属组"></asp:Label></span></td>  
        </tr>
          </table>
    </HeaderTemplate>
    <ItemTemplate >
            <table align="center" cellpadding="3px" cellspacing="0" width="100%">
            <tr>
                <td align="left"  style="width: 48px;height: 16px"><input  type="checkbox"  id="Chkitem"   name="Chk" runat="server" onclick="delMobile()" /></td>
                <td align="left"  style="width: 48px;height: 16px"><asp:Label ID="lbId" runat="server" Text='<%# Eval("Id") %>' Visible="false"></asp:Label><%# Eval("Name") %></td>
                <td align="left"  style="width: 60px; height: 16px"><%# (Eval("NickName").ToString() == "") ? "暂无" : Eval("NickName").ToString()%></td>
                <td align="left"  style="width: 90px; height: 16px">
                    <asp:Label ID="lbMobile" runat="server" Text='<%# Eval("Mobile")%>'></asp:Label></td>  
                <td align="left"  style="width: 60px; height: 16px"><%# (Eval("Email").ToString() == "") ? "暂无" : Eval("Email").ToString()%></td>
                <td align="left"  style="width: 90px; height: 16px"><%# (Eval("CompanyName") == "") ? "暂无" : Eval("CompanyName").ToString()%><asp:Label ID="lbGroupId" runat="server" Text='<%#Eval("GroupId")%>' Visible="false"></asp:Label></td>  
                <td align="left"  style="width: 60px; height: 16px"><%# Eval("GroupName")%></td>
               
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
          </asp:Panel>
           </fieldset>
           <fieldset>
           <legend>选择的号码</legend>
           <asp:TextBox ID="txtphone" runat="server" TextMode="MultiLine" Height="445px" 
                   Width="384px" ></asp:TextBox>
          <br />
          <asp:Button ID="btnsms" runat="server" Text="发送短信"  OnClientClick="return getNum();"/>
       
           </fieldset>
          </div>
         </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
    Array.prototype.remove = function(dx) {
        if (isNaN(dx) || dx > this.length) { return false; }
        for (var i = 0, n = 0; i < this.length; i++) {
            if (this[i] != this[dx]) {
                this[n++] = this[i]
            }
        }
        this.length -= 1
    }

    function select_all() {
        var allchkbox = 'Dlist_ctl00_Chkitem';
        var allchk = document.getElementById(allchkbox);
        var el = document.getElementsByTagName('input');
        var txtphone = '<%=txtphone.ClientID %>';
        var len = el.length;
        var phonearray = document.getElementById(txtphone).value.split('\r\n');
        for (var i = 0; i < len; i++) {
            if ((el[i].type == "checkbox") && ((el[i].name.indexOf('Dlist$ct')) != -1)) {
                if (allchk.checked == true) {
                    el[i].checked = true;

                }
                else {
                    el[i].checked = false;
                }
                if (el[i].id != allchkbox) {
                    var phone = document.getElementById(txtphone).innerHTML;
                    var ChkId = el[i].id;
                    var index = ChkId.lastIndexOf('_');
                    var MobileId = ChkId.substring(0, index) + "_lbMobile";
                    var Mobile = document.getElementById(MobileId).innerHTML;
                    var j = phone.indexOf(Mobile);
                    if (el[i].checked == true) {
                        if (j == -1) {
                            phonearray.push(Mobile);
                        }
                    }
                    else {
                        if (j != -1) {
                            for (var n = 0; n < phonearray.length; n++) {
                                if (phonearray[n] == Mobile) {
                                    phonearray.remove(n);
                                }
                            }
                        }
                    }

                }
            }
        }
        document.getElementById(txtphone).value = '';
        for (var j = 1; j < phonearray.length; j++) {
            
            if (j != phonearray.length - 1) {
            
                document.getElementById(txtphone).value += phonearray[j] + '\r\n';
            }
            else {
                document.getElementById(txtphone).value += phonearray[j];
            }
        }
        phonearray.length = 0;
    }
    function delMobile() {
        var txtphone = '<%=txtphone.ClientID %>';
        var phone = document.getElementById(txtphone).innerHTML;
        var o = window.event.srcElement;
        var ChkId = o.id;
        var index = ChkId.lastIndexOf('_');
        var MobileId = ChkId.substring(0, index) + "_lbMobile";
        var Mobile = document.getElementById(MobileId).innerHTML;
        var phonearray = document.getElementById(txtphone).value.split('\r\n');
        var i = phone.indexOf(Mobile);
        if (o.checked == true) {
            if (i == -1) {
                phonearray.push(Mobile);
            }
        }
        else {
            if (i != -1) {
                for (var j = 0; j < phonearray.length; j++) {
                    if (phonearray[j] == phone.substr(i, 11)) {
                        phonearray.remove(j);
                    }
                }
            }

        }
        document.getElementById(txtphone).value = '';
        for (var j = 0; j < phonearray.length; j++) {
            if (phonearray[j] != "") {
                if (j != phonearray.length - 1) {
                    document.getElementById(txtphone).value += phonearray[j] + '\r\n';
                }
                else {
                    document.getElementById(txtphone).value += phonearray[j];
                }
            }
        }
        phonearray.length = 0;

    }
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
        //var phonearray = document.getElementById(txtphone).value.split('\r\n');
        //window.opener.document.getElementById("lbNumber").value = phonearray.length;//获取号码总数
        window.opener.document.getElementById("txtNumbers").value += phone;
        window.close();
        return false;
    }
</script>