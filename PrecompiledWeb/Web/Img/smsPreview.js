	function checkMdn(value)
	{
		var exp = /^(130|131|132|133|134|135|136|137|138|139|159|158|153|150)(\d){8}$/; 
		return exp.test(value);
	}
	function checkalertMdnStr()
	{
		var str = $('alertMdnStr').value;
		if(str == null || str == '')
		{
			return true;
		}
		var tem = str.split("\r\n");
		if(tem.length > 11)
		{
			alert('每次最多可添加10个体验号码');
			return false;
		}
		for(i=0;i<tem.length;i++)
		{
			var tttt = tem[i];
			tttt = tttt.replace(/(^\s*)|(\s*$)/g, ""); 
			if(tttt!=''&& !checkMdn(tttt))
			{
				alert('体验号码第'+(i+1)+'行不是正确的手机号!');
				return false;
			}
		}
		return true;
	}

	function SMSData() {
		this.refresh();
	}

	SMSData.prototype.refresh=function() {
		this.content = ""; //最后一次有效的内容
		this.conentMaxLen = 112; //短信允许的最大长度
		this.lengthPerSms = 60; //每条短信的长度
		this.prefixLength = 4; //前缀的长度
		this.contentLen = 0; //输入内容的长度(不包含短信前缀)
		this.smsCount = 0; //分成短信的条数(不包含短信前缀)
		this.contentLenWithPerfix = 0; //输入内容的长度(包含短信前缀)
		this.smsCountWithPerfix = 0; //分成短信的条数(包含短信前缀)
	}


	var _currentCount = 0;
	
	function _previewSMS(data, currentCount){
		var sms = "";
		if(data.smsCountWithPerfix <= 1) {
			sms = data.content;
		}else {
			currentCount = currentCount < 0 ? 0 : currentCount < (data.smsCountWithPerfix - 1) ? currentCount : (data.smsCountWithPerfix - 1);
			var content = data.content;
			for(var i = currentCount; i > 0; i--) {
				content = "####" + content;
				content = content.substring(data.lengthPerSms, content.length);
			}
			content = (currentCount + 1) 
						  + "/"
						  + data.smsCountWithPerfix
						  + ")"
						  + content;
			var end = content.length > data.lengthPerSms ? data.lengthPerSms : content.length;
			sms = content.substring(0, end);
			_currentCount = currentCount;
		}
		document.getElementById("priviewSMS").value = sms;
	}

	function _writePriview() {

		document.write("<table width='144' cellspacing='0' background='/decorators/custom/images/z_17.gif'>");
        document.write("    <tr> ");
        document.write("        <td height='19' background='/decorators/custom/images/z_16.gif' class='lh19'> 　　 短 信 预 览</td>");
		document.write("    </tr>");
		document.write("    <tr> ");
		document.write("    <td align='center'><table width='125' height='110' border='0' cellpadding='0' cellspacing='0'>");
        document.write("    <tr> ");
        document.write("    <td bgcolor='E8EDF3'> ");
        document.write("    <textarea name='textarea' id='priviewSMS' cols='18' rows='9' style='overflow-x:hidden;overflow-y:hidden;' readonly></textarea> ");
        document.write("    </td> ");
        document.write("    </tr> ");
        document.write("    </table></td> ");
        document.write("    </tr>");
        document.write("    <tr> ");
        document.write("    <td><table width='100%' cellspacing='6'> ");
        document.write("    <tr> ");
        document.write("    <td width='50%' height='15' align='center' bgcolor='E8EDF3'> <span onclick=\"_previewSMS(data,_currentCount-1)\" style='cursor:hand' >上一页</span></td> ");
        document.write("    <td width='50%' align='center' bgcolor='E8EDF3'><span onclick=\"_previewSMS(data,_currentCount+1)\" style='cursor:hand' > 下一页</span></td> ");
        document.write("    </tr> ");
        document.write("    </table> ");
	    document.write("    </td> ");
        document.write("    </tr> ");
        document.write("    <tr> ");
        document.write("    <td><img src='/decorators/custom/images/z_18.gif' width='144' height='5' /></td> ");
        document.write("    </tr> ");
        document.write("    </table> ");
	}


