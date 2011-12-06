var xmlHttp;
function createxmlhttp() {
        if (window.ActiveXObject) {
            xmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
            return xmlHttp;
        }
        else if (window.XMLHttpRequest) {
        xmlHttp = new XMLHttpRequest();
        return xmlHttp;
        }
    }
//根据部门Id选择人员
function DeptDhange(SchId, DeptId, lisBoxId,hlkId) {
    createxmlhttp();
   
    var SchValue = document.getElementById(SchId).value;//获取学校下拉列表的选择项
    var DeptValue = document.getElementById(DeptId).value; //获取年级下拉列表的选择项
    var listBox = document.getElementById(lisBoxId); //获取人员选择listBox 对象
    var hlkdept = document.getElementById(hlkId); //获取部门连接LinkButton
    var warm = document.getElementById("warn");
   
    if (hlkdept.disabled) {
        var url = "../Doc/AjaxHandler.ashx?SchValue=" + encodeURIComponent(SchValue) + "&DeptValue=" + encodeURIComponent(DeptValue) + "&type=3"; //发送到服务器的根据部门Id返回具有审批权限的人员
    }
    else {
        var url = "../Doc/AjaxHandler.ashx?SchValue=" + encodeURIComponent(SchValue) + "&DeptValue=" + encodeURIComponent(DeptValue) + "&type=1"; //发送到服务器的根据部门Id返回此部门包含的人员
    }
    xmlHttp.open("Get", url,true);
    xmlHttp.onreadyStateChange = function() {
        if (xmlHttp.readyState == 4) {
            if (xmlHttp.status == 200) {
                xmlDoc = xmlHttp.responseXML;
                listBox.length = 0; //清空listBox对象中的数据
                var UserGid = xmlDoc.getElementsByTagName("Gid"); //读取xml对象中的Gid节点
                var UserName = xmlDoc.getElementsByTagName("Name"); //读取xml对象中的Name节点
                for (var i = 0; i < UserGid.length; i++) {
                    var Gid = UserGid[i].firstChild.nodeValue; //读取xml对象中的Gid节点的值
                    var Name = UserName[i].firstChild.nodeValue; //读取xml对象中的Name节点的值
                    var option = new Option(Name, Gid);
                    listBox.options.add(option);
                }
                if (listBox.length == 0) {
                      warm.style.display = "block";
                    if (hlkdept.disabled) {

                        warm.innerHTML = "该部门中暂时没有具有审批权限的人员";

                    }
                    else
                        warm.innerHTML = "该部门中暂时没有人员";
                }
            }
        }
    }
    xmlHttp.send(null); //发送数据
}
//点击按部门选择是填充部门下拉框
function UserSelect(DeptId, lbdeptId, SchId, lsbuserId) {
    createxmlhttp();
    var SchValue = document.getElementById(SchId).value; //获取学校下拉列表的选择项
    var DeptObject = document.getElementById(DeptId); //获取年级下拉列表
    var listUser = document.getElementById(lsbuserId);
    var warm = document.getElementById("warn");
    warm.style.display = "none";
    listUser.length = 0;
    DeptObject.style.display = "block";
    document.getElementById(lbdeptId).style.display = "block"; 
   
    //xmlHttp.setRequestHeader("Content-Type", "text/xml;charset=GB2312");
   
    var url = "../Doc/AjaxHandler.ashx?SchValue=" + encodeURIComponent(SchValue) + "&type=2"; //发送到服务器的url返回所有部门
   
    xmlHttp.open("Get", url, true); 

    xmlHttp.onreadyStateChange = function() {
 
        if (xmlHttp.readyState == 4) {
            if (xmlHttp.status == 200) {
                var xmlDoc = xmlHttp.responseXML;
                var DeptId = xmlDoc.getElementsByTagName("Id"); //读取xml对象中的Gid节点
                var DeptName = xmlDoc.getElementsByTagName("DeptName"); //读取xml对象中的Name节点
                //按人员选择时
                DeptObject.length = 0; //清空listBox对象中的数据
                var opt = new Option("请选择部门", "-1");
                DeptObject.options.add(opt);
                for (var i = 0; i < DeptId.length; i++) {
                    var Id = DeptId[i].firstChild.nodeValue; //读取xml对象中的Gid节点的值
                    var Name = DeptName[i].firstChild.nodeValue; //读取xml对象中的Name节点的值
                    var option = new Option(Name, Id);
                    DeptObject.options.add(option);

                }
                DeptObject.options[0].selected = true;
            }
        }
    }
    xmlHttp.send(null); //发送数据
}
function DeptSelect(DeptId, lbdeptId, SchId, lsbuserId, hidId) {
    //按部门选择时
   createxmlhttp();
   document.getElementById(hidId).innerText = "&";
    var SchValue = document.getElementById(SchId).value; //获取学校下拉列表的选择项
    var DeptObject = document.getElementById(DeptId); //获取年级下拉列表
    var listUser = document.getElementById(lsbuserId);
    var warm = document.getElementById("warn");
    warm.style.display = "none";
    DeptObject.style.display = "none";
    document.getElementById(lbdeptId).style.display = "none";

    var url = "../Doc/AjaxHandler.ashx?SchValue=" + encodeURIComponent(SchValue) + "&type=2"; //发送到服务器的url
       xmlHttp.open("Get", url, true);
       xmlHttp.onreadyStateChange = function() {
          
           if (xmlHttp.readyState == 4) {
               if (xmlHttp.status == 200) {
                  var xmlDoc = xmlHttp.responseXML;
                   var DeptId = xmlDoc.getElementsByTagName("Id"); //读取xml对象中的Gid节点
                   var DeptName = xmlDoc.getElementsByTagName("DeptName"); //读取xml对象中的Name节点
                   listUser.length = 0;
                   for (var i = 0; i < DeptId.length; i++) {
                       var Id = DeptId[i].firstChild.nodeValue; //读取xml对象中的Gid节点的值
                       var Name = DeptName[i].firstChild.nodeValue; //读取xml对象中的Name节点的值
                       var option = new Option(Name, Id);
                       listUser.options.add(option);
                   }
               }
           }
       }
     xmlHttp.send(null); //发送数据

 }
 function SelectDeptDhange(DeptCode,lbdeptId) {
     createxmlhttp();
     var DeptName = (document.getElementById(DeptCode).options[document.getElementById(DeptCode).selectedIndex]).innerHTML;
     var Code = document.getElementById(DeptCode).value;
     if ((DeptName =="【初中部】")||(DeptName =="【高中部】")) {
        Code = Code + "T";
     }
     var listUser = document.getElementById(lbdeptId);
      var url = "../../Base/TeaManage/DeptSelect.aspx?DeptCode=" + encodeURIComponent(Code); //发送到服务器的url
       xmlHttp.open("Get", url, true);
       xmlHttp.onreadyStateChange = function() {
           if (xmlHttp.readyState == 4) {
               if (xmlHttp.status == 200) {
                   var xmlDoc = xmlHttp.responseXML;
                   if (xmlDoc != null) {
                       var DeptCode = xmlDoc.getElementsByTagName("Code"); //读取xml对象中的Code节点
                       var DeptName = xmlDoc.getElementsByTagName("Name"); //读取xml对象中的Name节点
                       listUser.length = 0;
                       for (var i = 0; i < DeptCode.length; i++) {
                           var Id = DeptCode[i].firstChild.nodeValue; //读取xml对象中的Code节点的值
                           var Name = DeptName[i].firstChild.nodeValue; //读取xml对象中的Name节点的值
                           var option = new Option(Name, Id);
                           listUser.options.add(option);
                       }
                   }

               }
           }
       }
       xmlHttp.send(null); //发送数据

   }
   
   
   //判断账号是否存在
   function GetAccount(Account) {
       createxmlhttp();
       var urlstr = location.pathname;
       var strurl = urlstr.substr(urlstr.lastIndexOf("Base"));
       var url = "../../" + strurl + "?Account=" + encodeURIComponent(Account); //发送到服务器的url
       xmlHttp.open("Get", url, true);
       xmlHttp.onreadyStateChange = function() {
           if (xmlHttp.readyState == 4) {
               if (xmlHttp.status == 200) {
                   var Name = xmlHttp.responseText;
                   var txtaccount = document.getElementById("accountInfo");
                   txtaccount.style.display = "block";
                   if (Name != 0) {
                       acc.value = Name;
                       txtaccount.innerHTML ="对不起您的账号存在重复系统将您的账号修改为" + Name + "您可以修改！";
                   }
                   else {
                       txtaccount.innerHTML = "账号可用";
                   }
               }

           }
       }

       xmlHttp.send(null); //发送数据
   }
   //判断账号是否存在

 

 