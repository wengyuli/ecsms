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
    //验证账户是否存在
    function IsExsitAccount(name) 
    {
        createxmlhttp();
        var url = "Reg.ashx?account="+encodeURI(name);
        xmlHttp.open("Get", url,true);
        xmlHttp.onreadyStateChange = function() {
            if (xmlHttp.readyState == 4) {
                if (xmlHttp.status == 200) {
                    var result = xmlHttp.responseText;
                    if (result == "ok") {
                        document.getElementById("accountwarn").innerHTML = "恭喜您，此用户名可用。";
                        document.getElementById("accountwarn").style.color = "blue";
                    }
                    else {
                        document.getElementById("accountwarn").innerHTML = "用户名已存在，请更换用户名。";
                        document.getElementById("accountwarn").style.color = "red";
                    }

                }
            }
        }
        xmlHttp.send(null); //发送数据
    }
    //根据省份绑定城市
    function BindCity() {
        createxmlhttp();
        var province = document.getElementById("ddlProvince").value;
        var city=document.getElementById("ddlCity");
        var url = "Reg.ashx?province=" + province;
        xmlHttp.open("Get", url, true);
        xmlHttp.onreadyStateChange = function() {
            if (xmlHttp.readyState == 4) {
                if (xmlHttp.status == 200) {
                    var result = xmlHttp.responseText;
                    if (result != "") {
                        var arr = result.split('|');
                        city.options.length = 0;
                        for (var i = 0; i < arr.length; i++) {
                            var brr = arr[i].split('-');
                            var item = new Option(brr[1], brr[0]);
                            city.options.add(item);
                        }
                    }
                }
            }
        }
        xmlHttp.send(null); //发送数据
     }
 

 