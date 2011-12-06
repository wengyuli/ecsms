using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECSMS.Channel
{
    public class WanZhong
    {
        private string _userName { set; get; }
        private string _passWord { set; get; }
        public WanZhong()
        {
            try
            {
                ECSMS.BLL.EC_SmsChannel myChannel = new ECSMS.BLL.EC_SmsChannel();
                var channel = myChannel.GetModel(Channel.wanzhong.ToString());
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
        /// <param name="smscontent"></param>
        /// <returns></returns>
        public int SendSms(string phonenumber,string smscontent)
        {
            var proxy = new WanZhongService.Service1SoapClient();
            proxy.g_Submit(this._userName, this._passWord, "", "", "", smscontent);
            return 0;
        }
        /// <summary>
        /// 获取余额
        /// </summary>
        /// <returns></returns>
        public int GetSmsRemain()
        {
            var proxy = new WanZhongService.Service1SoapClient();
            return proxy.Sm_GetRemain(this._userName, this._passWord, "", "").Remain;
        }

        public string GetSms()
        {
            var proxy = new WanZhongService.Service1SoapClient();
            return "";
        }
    }
}
