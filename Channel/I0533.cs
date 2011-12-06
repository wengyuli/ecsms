using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

namespace ECSMS.Channel
{
    public class I0533
    {
        private string _userName { set; get; }
        private string _passWord { set; get; }
        public I0533()
        {
            try
            {
                ECSMS.BLL.EC_SmsChannel myChannel = new ECSMS.BLL.EC_SmsChannel();
                var channel = myChannel.GetModel(Channel.I0533.ToString());
                this._userName = channel.Account;
                this._passWord = channel.Pwd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 返回值1为成功
        /// </summary>
        /// <param name="phonenumber"></param>
        /// <param name="msgtitle"></param>
        /// <returns>1为成功</returns>
        public int SendSms(string phonenumber, string msgtitle) 
        {
            string webInfo = string.Empty;
            string IP = "http://60.209.7.78:8080/smsServer/submit";
            string CORPID = this._userName;
            string CPPW = this._passWord;
            string Phone = phonenumber;
            string Text = msgtitle;
            string sendtime = "";
            string srctermid = "";
            string haveyd = "0";
            string msgid = "";

            StringBuilder sburl = new StringBuilder();
            sburl.Append(IP)
                .Append("?CORPID=")
                .Append(CORPID)
                .Append("&CPPW=")
                .Append(MD5Encrypt(CPPW))
                .Append("&PHONE=")
                .Append(Phone)
                .Append("&SENDTIME=")
                .Append(sendtime)
                .Append("&CONTENT=")
                .Append(URLEncoding(Text))
                .Append("&SRCTERMID=").Append(srctermid)
                .Append("&HAVEYD=").Append(haveyd)
                .Append("&MSGID=").Append(msgid);

            Submit(sburl.ToString(), ref webInfo);
            if (webInfo == "SUCCESS")
            {
                return 1;//成功
            }
            else
            {
                return 0;
            }
        }

        public bool Submit(string Url, ref string webInfo)
        {
            bool flag = true;
            try
            {
                WebRequest request = WebRequest.Create(Url);
                request.Method = "POST";

                request.GetRequestStream().Close();
                WebResponse response = request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8);
                webInfo = sr.ReadToEnd();
                sr.Close();
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        public string MD5Encrypt(string strText)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strText, "MD5").ToLower();
        }
        public string URLEncoding(string str)
        {
            return System.Web.HttpUtility.UrlEncode(str, System.Text.Encoding.GetEncoding("UTF-8"));
        }

    }
}
