<%@ page language="C#" autoeventwireup="true" inherits="Admin_ChangeAgent, App_Web_2qvchb0s" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            width: 117px;
        }
    </style>
</head>
<body style=" font-size:12px;  font-family:微软雅黑;">
    <form id="form1" runat="server">
    <div>
      <fieldset>
      <legend style="font-size:14px; font-weight:bold;">调配用户</legend>
          <asp:Label ID="lblUserId" Visible="false" runat="server" Text="Label"></asp:Label>
          <table class="style1">
              <tr>
                  <td class="style2" align="right">
                      用户名：</td>
                  <td>
                      <asp:Label ID="lblAccount" runat="server" Text="Label"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td class="style2" align="right">
                                            姓名：</td>
                  <td>
                      <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td class="style2" align="right">
                      现属于：</td>
                  <td>
                      <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td class="style2" align="right">
                      调配给：</td>
                  <td>
                      <asp:DropDownList ID="ddlAgent" runat="server">
                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <td class="style2">
                      &nbsp;</td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td class="style2">
                      &nbsp;</td>
                  <td>
                      <asp:Button ID="btnSave" runat="server" OnClientClick="javascript:return confirm('你确定要将调配此用户么')" Text="调配" onclick="btnSave_Click" />
                      <asp:Button ID="btnBack" runat="server" Text="返回" />
                      <asp:Label ID="lblshowok" runat="server" Text=""></asp:Label>
                  </td>
              </tr>
          </table>
      
      </fieldset>
    </div>
    </form>
</body>
</html>
