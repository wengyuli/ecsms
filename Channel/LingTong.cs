using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Web;

namespace ECSMS.Channel
{
    public class LingTong
    {
        private string _userName { set; get; }
        private string _passWord { set; get; }
        public LingTong()
        {
            try
            {
                ECSMS.BLL.EC_SmsChannel myChannel = new ECSMS.BLL.EC_SmsChannel();
                var channel = myChannel.GetModel(Channel.lingtong.ToString());
                this._userName = channel.Account;
                this._passWord = channel.Pwd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        /// <summary>
        /// 发送短信
        /// </summary> 
        /// <param name="phonenumber"></param>
        /// <param name="msgtitle"></param>
        /// <returns></returns>
        public int SendSms(string phonenumber,string msgtitle)
        {
            WebClient wb = new WebClient();
            Encoding ed = Encoding.GetEncoding("gb2312");
            string strRequest = "http://210.21.119.156:33221/send.asp?name=" + this._userName + "&pwd=" + this._passWord + "&phone=" + phonenumber + "&msg=" +HttpUtility.UrlEncode(msgtitle,ed) + "";
            string str = wb.DownloadString(strRequest);
            if (str == "0")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        #region MD5加密
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        private string StringToMD5Hash(string inputString)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encryptedBytes = md5.ComputeHash(Encoding.ASCII.GetBytes(inputString));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < encryptedBytes.Length; i++)
            {
                sb.AppendFormat("{0:x2}", encryptedBytes[i]);
            }
            return sb.ToString();
        }
        #endregion
    }
}
