using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECSMS.Channel
{
    public class LingKai
    {
        private string _uuserName { set; get; }
        private string _upassWord { set; get; }
        
        private string _muserName { set; get; }
        private string _mpassWord { set; get; }

        public LingKai()
        {
            try
            {
                ECSMS.BLL.EC_SmsChannel myChannel = new ECSMS.BLL.EC_SmsChannel();
                var channel = myChannel.GetModel(Channel.lingkaiu.ToString());
                this._uuserName = channel.Account;
                this._upassWord = channel.Pwd;
                channel = myChannel.GetModel(Channel.lingkaim.ToString());
                this._muserName = channel.Account;
                this._mpassWord = channel.Pwd;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 发送短信
        /// </summary> 
        /// <param name="phonenumber">号码</param>
        /// <param name="content">短信内容</param>
        /// <param name="cell">子号</param>
        /// <param name="sendtime">发送时间</param>
        /// <returns>状态</returns>
        public int SendMSms(string phonenumber,string content,string cell,string sendtime)
        {
            var proxy = new LingKaiService.LinkWSSoapClient();
            return proxy.Send(this._muserName, this._mpassWord, phonenumber, content, cell, sendtime);
        }
        /// <summary>
        /// 发送短信
        /// </summary> 
        /// <param name="phonenumber">号码</param>
        /// <param name="content">短信内容</param>
        /// <param name="cell">子号</param>
        /// <param name="sendtime">发送时间</param>
        /// <returns>状态</returns>
        public int SendUSms(string phonenumber, string content, string cell, string sendtime)
        {
            var proxy = new LingKaiService.LinkWSSoapClient();
            return proxy.Send(this._uuserName, this._upassWord, phonenumber, content, cell, sendtime);
        }
        /// <summary>
        /// 收短信
        /// </summary>
        /// <returns></returns>
        public string GetMSms()
        {
            var proxy = new LingKaiService.LinkWSSoapClient();
            return proxy.Get(this._muserName, this._mpassWord);
        }
        /// <summary>
        /// 收短信
        /// </summary>
        /// <returns></returns>
        public string GetUSms()
        {
            var proxy = new LingKaiService.LinkWSSoapClient();
            return proxy.Get(this._uuserName, this._upassWord);
        }
        /// <summary>
        /// 查询余额
        /// </summary>
        /// <returns></returns>
        public int GetMSmsRemain()
        {
            var proxy = new LingKaiService.LinkWSSoapClient();
            return proxy.SelSum(this._muserName, this._mpassWord);
        }
        /// <summary>
        /// 查询余额
        /// </summary>
        /// <returns></returns>
        public int GetUSmsRemain()
        {
            var proxy = new LingKaiService.LinkWSSoapClient();
            return proxy.SelSum(this._uuserName, this._upassWord);
        }
    }
}
