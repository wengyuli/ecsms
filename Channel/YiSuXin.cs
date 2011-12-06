using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Web;

namespace ECSMS.Channel
{
    public class YiSuXin
    {
        private string _userName { set; get; }
        private string _passWord { set; get; }
        public YiSuXin()
        {
            try
            {
                ECSMS.BLL.EC_SmsChannel myChannel = new ECSMS.BLL.EC_SmsChannel();
                var channel = myChannel.GetModel(Channel.yisuxin.ToString());
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
            WebClient wb = new WebClient();
            Encoding ed = Encoding.GetEncoding("gb2312");
            string strRequest = "http://222.35.32.190:8686/smsway/send?user=" + 
                this._userName + "&pwd=" + this._passWord + "&src=0165&dest=" + phonenumber 
                + "&msg=" + HttpUtility.UrlEncode(msgtitle, ed) + "";
            string str = wb.DownloadString(strRequest).Substring(0,1);
            if (str=="0")
            {
                return 1;//成功
            }
            else
            {
                return 0;
            }
        }
    }
}
