<%@ page language="C#" autoeventwireup="true" inherits="DownLoads_ShowDown, App_Web_phsuf21d" stylesheettheme="default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function opendown(id) {
            OpenWindow("DownPriceFiles.aspx?id="+id, 400, 400)
        }
        function OpenWindow(url, width, height) {
            window.open(url,
            "",
            "top=50, left=150,height=" + height + ", width=" + width + ",toolbar=no,menubar=no,scrollbars=yes,resizable=yes,location=no,status=no",
            "")
        }
    </script>
</head>
<body style=" font-size:12px; font-family:微软雅黑; ">
    <form id="form1" runat="server">
    <div>
    <fieldset style="">
        <legend style="font-size:14px; font-weight:bold;">软件下载</legend>
        <asp:DataList ID="DataList1" Width="100%" runat="server" DataKeyField="Id" 
            onitemdatabound="DataList1_ItemDataBound"  >
         <HeaderTemplate>
            <table width="100%">
            <tr align="center" style=" background-color:#E3EFFB;">   
            <th>编号</th>
            <th>软件名称</th>
            <th>软件说明</th> 
            <th>扣费说明</th>
            <th>下载</th>
            </tr>
            </HeaderTemplate>
            <ItemTemplate>
            <tr align="center">
            <td>
                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
            </td>
            <td><%#Eval("showname") %>
                <asp:Label ID="lblAllName" runat="server" Text='<%#Eval("fullfilename") %>'></asp:Label>
            </td>
            <td title='<%#Eval("Remark") %>'><%#Eval("Remark").ToString().Length>10?Eval("Remark").ToString().Substring(0,10)+"...":Eval("Remark").ToString()%></td>
            <td>
                <asp:Label ID="lblprice" runat="server" Text='<%#Eval("price").ToString().Replace("A", Public.GetProNameByLetter("A")).Replace("B", Public.GetProNameByLetter("B")).Replace("C", Public.GetProNameByLetter("C")).Replace("D", Public.GetProNameByLetter("D")).Replace("E", Public.GetProNameByLetter("E"))%>'></asp:Label>
             </td>
            <td>
            <a id="downUrl" runat="server">[下载]</a>
            </td>
            </tr>    
            </ItemTemplate>
            <FooterTemplate>
            </table>
            </FooterTemplate>
         </asp:DataList>
        <br />
        <span style=" color:Red;"> 请使用右键“目标另存为...”下载以上软件。</span>
    </fieldset>
    <fieldset style="height: 153px">
    <legend style="font-size:14px; font-weight:bold;">辅助服务</legend>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnAdvice" runat="server" PostBackUrl="~/Advice/AddAdvice.aspx" 
            Text="投诉建议" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnBackUp" runat="server" Text="备份名片夹" 
            onclick="btnBackUp_Click" />
    </fieldset>
    </div>
    </form>
</body>
</html>
