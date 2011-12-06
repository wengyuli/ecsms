using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using Maticsoft.DBUtility;

namespace ECSMSServer
{
    public partial class Form1 : Form
    { 
        //定时检测短信间隔
        static int sendInerval = 10000;
        //提取数量
        static int smsCount = 100;
        //定时接收对应间隔
        static int receiveInerval = 30000;

        static bool IsProcessing = false;

        //初始化通道参数
        ECSMS.Channel.LingKai lingkai;
        ECSMS.Channel.LingTong lingtong;
        ECSMS.Channel.WanZhong wanzhong;
        ECSMS.Channel.I0533 i0533;
        ECSMS.Channel.YiSuXin yisuxin;

        ECSMS.BLL.EC_SmsChannel myChannel = new ECSMS.BLL.EC_SmsChannel();
        ECSMS.Model.EC_SmsChannel newChannel = new ECSMS.Model.EC_SmsChannel();
        ECSMS.Model.EC_ProChannel prochannel = new ECSMS.Model.EC_ProChannel();
        ECSMS.BLL.EC_ProChannel myProChannel = new ECSMS.BLL.EC_ProChannel();

        //定时发送
        System.Timers.Timer sendTimer;
        //定时收取
        System.Timers.Timer receiveTimer;
        //定时检测在线用户
        System.Timers.Timer onlineTimer;
         
        public Form1()
        {
            try
            {
                InitializeComponent();
                
                System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

                lingkai = new ECSMS.Channel.LingKai();
                lingtong = new ECSMS.Channel.LingTong();
                wanzhong = new ECSMS.Channel.WanZhong();
                i0533 = new ECSMS.Channel.I0533();
                yisuxin = new ECSMS.Channel.YiSuXin();

                //发送短信
                this.sendTimer = new System.Timers.Timer(sendInerval);
                this.sendTimer.Elapsed += (o,e) => {
                    try
                    {
                        SendSms();
                    }
                    catch(Exception ex)
                    {
                        WriteLog("发送出错："+ex.Message);
                    }
                }; 
                //接收短信
                this.receiveTimer = new System.Timers.Timer(receiveInerval);
                this.receiveTimer.Elapsed += (o,e) => {
                    try 
                    { 
                        //待写   
                    }
                    catch(Exception ex)
                    {
                        WriteLog("接收出错：" + ex.Message);
                    }
                }; 
                //在线用户处理
                this.onlineTimer = new System.Timers.Timer(60000);
                this.onlineTimer.Elapsed += (o, e) =>
                {
                    var list = new ECSMS.BLL.EC_User().GetModelList(" online=1 ");
                    foreach(var item in list)
                    {
                        if(item.LastUpdateTime!=null)
                        {
                            if(item.LastUpdateTime.Value.AddMinutes(30)<DateTime.Now)
                            {
                                item.OnLine = 0;
                                new ECSMS.BLL.EC_User().Update(item);
                                WriteLog("对用户 "+item.Name+" 做离线处理");
                            }
                        }
                    }
                }; 
            }
            catch(Exception ex)
            {
                WriteLog("软件启动异常："+ex.Message);
            }
        }

        #region 开关定时
        void StartTimer()
        {
            this.onlineTimer.Start();
            this.sendTimer.Start();
            this.receiveTimer.Start();
        }
        void StopTimer()
        {
            this.onlineTimer.Stop();
            this.sendTimer.Stop();
            this.receiveTimer.Stop();
        }
        #endregion

        #region 开启、停止监控数据库
        /// <summary>
        /// 开始监控
        /// </summary>
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnStop.Enabled = true;
                this.btnStart.Enabled = false;
                StartTimer();
                WriteLog("服务器已启动，开始监控..."); 
            }
            catch(Exception ex)
            {
                WriteLog("服务启动出现异常：" + ex.Message); 
            }
        }

        /// <summary>
        /// 停止监控
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                this.btnStop.Enabled = false;
                this.btnStart.Enabled = true;
                StopTimer();
                WriteLog("服务器已停止监控.");
            }
            catch (Exception ex)
            {
                WriteLog("服务停止出现异常：" + ex.Message);
            }
        }
        #endregion 


        #region 读取数据库内容并发送
        protected void SendSms()
        {
            try
            {                
                if(IsProcessing)
                {
                    return;
                }
                IsProcessing = true;
                SetTimeSms();
                DateTime dtSentTime = DateTime.Now;
                ECSMS.BLL.SendMsgTable mySend = new ECSMS.BLL.SendMsgTable();
                ECSMS.Model.SendMsgTable newSend = new ECSMS.Model.SendMsgTable();
                ECSMS.BLL.EC_ProChannel myProChannel=new ECSMS.BLL.EC_ProChannel();
                string strSql = " msgstatus=" + (int)ECSMS.Channel.SmsStatus.等待发送 + " and ServerID=(select top 1 ServerID from SendMsgTable where phonenumber not like '% %' and MsgStatus=" + (int)ECSMS.Channel.SmsStatus.等待发送 + ") ";
                ///选取ABD产品中状态为待发的短信
                DataSet ds = mySend.GetList(strSql); 
                var sendList = BuildSend(ds);
                int count = sendList.Count;
                if (count > 0)
                {                    
                    WriteLog("提取任务" + sendList[0].ServerID + "");
                    WriteLog("共有短信" + sendList.Count + "条，准备提交..");  
                    //细分移动，联通，电信
                    var spList = new List<int> {1,2,3 };
                    if(sendList.Where(m=>m.SpId.Value==0).Count()>0)
                    {
                        //SetSmsToWait(sendList.Where(m => m.SpId.Value == 0).ToList(), sendList[0].ServerID);
                        SetSmsSuccess(sendList.Where(m => m.SpId.Value == 0).ToList(), dtSentTime);
                        sendList.RemoveAll(m => m.SpId.Value == 0);
                        if(sendList.Count==0)
                        {
                            WriteLog("本次提取的短信无法发送，置为发送成功状态。");
                        }
                    }
                    foreach(var item in spList)
                    {
                        var list = sendList.Where(m => m.SpId == item).OrderBy(m=>m.MsgIndex).ToList();
                        int totalCount = list.Count;
                        if (totalCount > 0)//如果含有某SP的号码
                        {
                            int totalSucess = 0;
                            string channel = GetChannel(list[0].MsgType, ((ECSMS.Channel.SP)item).ToString());
                            if (channel != "")
                            {
                                while (list.Count > 0)
                                {
                                    int sucessCount = Process(channel, list.Take(list.Count > 100 ? 100 : list.Count).ToList());
                                    if (sucessCount > 0)
                                    {
                                        totalSucess += sucessCount;
                                        this.SetSmsSuccess(list.Take(list.Count > 100 ? 100 : list.Count).ToList(), dtSentTime);
                                        list.RemoveRange(0, list.Count > 100 ? 100 : list.Count);
                                    }
                                }
                                WriteLog("" + (ECSMS.Channel.SP)item + ":" + totalCount + "条,成功" + totalSucess + "条,失败" + (totalCount - totalSucess) + "条");
                            }
                        }
                    }
                    
                    WriteLog("任务"+sendList[0].ServerID+"处理完毕"); 
                }
                IsProcessing = false;
            }
            catch (Exception ex)
            {
                IsProcessing = false;
                WriteLog("请检查网络连接。：" + ex.Message);
            }
        } 
        void SetSmsSuccess(List<ECSMS.Model.SendMsgTable> list,DateTime sentTime)
        {
            try
            {
                string strNumbers = string.Empty;
                foreach (var item in list)
                {
                    strNumbers += item.MsgIndex + ",";
                }
                if (strNumbers.Length > 0)
                {
                    strNumbers = strNumbers.Substring(0, strNumbers.Length - 1);
                    string strSql = "update sendmsgtable set msgstatus=" + (int)ECSMS.Channel.SmsStatus.发送成功 + ",senttime='" + sentTime.ToString("yyyy-MM-dd HH:mm:ss") + "' where msgindex in (" + strNumbers + ") ";//设置本次发送的短信状态为提交
                    DbHelperSQL.ExecuteSql(strSql);
                }
            }
            catch(Exception ex)
            {
                WriteLog("更新短信为成功状态出错："+ex.Message);
            }
        }
        void SetSmsToWait(List<ECSMS.Model.SendMsgTable> list, string serverId)
        {
            if (list.Count > 0)
            {
                string strNumbers = string.Empty;
                foreach (var item in list)
                {
                    strNumbers += item.MsgIndex + ",";
                }                
                try
                {
                    if (strNumbers.Length > 0)
                    {
                        strNumbers = strNumbers.Substring(0, strNumbers.Length - 1);
                        string strSql = "update sendmsgtable set msgstatus=" + (int)ECSMS.Channel.SmsStatus.待发状态 + " where msgindex in (" + strNumbers + ") and serverid='" + serverId + "' ";
                        DbHelperSQL.ExecuteSql(strSql);
                    }
                }
                catch (Exception ex)
                {
                    WriteLog("更新短信状态为待发时出错" + ex.Message);
                }
            }
        }
        int Process(string channel, List<ECSMS.Model.SendMsgTable> sendList)
        {
            List<string> listMsgTitle = new List<string>();
            sendList.ForEach(m => listMsgTitle.Add(m.MsgTitle));
            listMsgTitle = listMsgTitle.Distinct().ToList();

            string strNumbers = string.Empty;
            foreach (var item in sendList)
            {
                if (!strNumbers.Contains(item.PhoneNumber))
                {
                    strNumbers += item.PhoneNumber + ",";
                }
            }
            strNumbers = strNumbers.Substring(0, strNumbers.Length - 1);
            int SendCount = 0;
            try
            {
                foreach(var item in listMsgTitle)
                {
                    if (channel == ECSMS.Channel.Channel.lingkaim.ToString())
                    {
                        SendCount = lingkai.SendMSms(strNumbers, item, sendList[0].UserId.ToString(), "");
                    }
                    else if (channel == ECSMS.Channel.Channel.lingkaiu.ToString())
                    {
                        SendCount = lingkai.SendUSms(strNumbers, item, sendList[0].UserId.ToString(), "");
                    }
                    else if (channel == ECSMS.Channel.Channel.lingtong.ToString())
                    {
                        SendCount = lingtong.SendSms(strNumbers, item);
                    }
                    else if (channel == ECSMS.Channel.Channel.wanzhong.ToString())
                    {
                        SendCount = wanzhong.SendSms(strNumbers, item);
                    }
                    else if(channel==ECSMS.Channel.Channel.I0533.ToString())
                    {
                        SendCount = i0533.SendSms(strNumbers, item);
                    }
                    else if(channel==ECSMS.Channel.Channel.yisuxin.ToString())
                    {
                        SendCount = yisuxin.SendSms(strNumbers, item);
                    }
                }                
            }
            catch(Exception ex)
            {
                WriteLog("发送异常，已经短信置为待发。"+ex.Message);
                SetSmsToWait(sendList, sendList[0].ServerID);
            }
            if (SendCount > 0)
            {
                WriteLog((ECSMS.Channel.SP)sendList[0].SpId + "发送" + sendList.Count + "条");
                return sendList.Count;
            }
            else
            {
                WriteLog(strNumbers+"发送失败，进入待发状态");
                SetSmsToWait(sendList, sendList[0].ServerID);
                return 0;
            }
        }
        string GetChannel(string smsType, string spCode)
        {
            try
            { 
                return myProChannel.GetModelList(" procode='" + smsType + "' and spcode='" + spCode + "' ").FirstOrDefault().Channel;
            }
            catch
            {
                return "";
            }
        }
        #endregion    

        #region 接收短信
        /// <summary>
        /// 接收短信 目前只支持凌凯
        /// </summary>
        protected void GetSms()
        {
            try
            {
                string strGetSmsM = string.Empty;
                string strGetSmsU = string.Empty;

                strGetSmsM = lingkai.GetMSms();
                strGetSmsU = lingkai.GetUSms();
                
                AddLKReceiveSms(strGetSmsM);
                AddLKReceiveSms(strGetSmsU);
                 
            }
            catch(Exception ex)
            {
                WriteLog("接收短信出现异常:"+ex.Message);
            }
        }
        protected void AddLKReceiveSms(string strGetSms)
        {
            try
            {
                if (strGetSms == "-1")
                {
                    WriteLog("收取回复短信出现错误：账号未注册。");
                }
                else if (strGetSms == "-2")
                {
                    WriteLog("收取回复短信出现错误：其他错误。");
                }
                else if (strGetSms == "-3")
                {
                    WriteLog("收取回复短信出现错误：密码错误。");
                }
                else
                {
                    string[] strSeparators = new string[] { "||" };
                    string[] arrGetContent = strGetSms.Split(strSeparators, StringSplitOptions.RemoveEmptyEntries);
                    string[] arrSms;
                    ECSMS.BLL.RecvMsgTable myRev = new ECSMS.BLL.RecvMsgTable();
                    ECSMS.Model.RecvMsgTable newRev = new ECSMS.Model.RecvMsgTable();
                    foreach (string strTemp in arrGetContent)
                    {
                        if (strTemp != "")
                        {
                            arrSms = strTemp.Split('#');
                            newRev.PhoneNumber = arrSms[0].ToString();
                            newRev.MsgTilte = arrSms[1].ToString();
                            newRev.MsgStatus = 0;
                            newRev.MsgType = 0;
                            if (Maticsoft.Common.PageValidate.IsDateTime(arrSms[2].ToString()))
                            {
                                newRev.RecvTime = Convert.ToDateTime(arrSms[2].ToString());
                            }
                            else
                            {
                                newRev.RecvTime = DateTime.Now;
                            }
                            myRev.Add(newRev);
                        }
                    }
                    if (arrGetContent.Length != 0)
                    {
                        WriteLog("收到【" + arrGetContent.Length + "】条回复短信。");
                    }
                }
            }
            catch(Exception ex)
            {
                WriteLog("接收短信出现异常:" + ex.Message);
            }
        }
        #endregion

        #region 对应接收到的短信 MsgStatus 为0的，-1时为对应失败
        protected void FindCardSendUser()
        {
            try
            {
                DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(" select top 1000 * from RecvMsgTable where MsgStatus=0 ");
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    ECSMS.BLL.SendMsgTable mySend = new ECSMS.BLL.SendMsgTable();
                    DataSet dsSend = new DataSet();
                    string strUserId = string.Empty;
                    string strMsgType = string.Empty;
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        dsSend = mySend.GetList(" phonenumber like '%" + row["phonenumber"].ToString() + "%' and sendtime between '"+DateTime.Now.AddHours(-24)+"' and '"+DateTime.Now+"' ");
                        if (dsSend.Tables[0].Rows.Count > 0)
                        {
                            strUserId = dsSend.Tables[0].Rows[0]["userid"].ToString();
                            strMsgType = dsSend.Tables[0].Rows[0]["msgtype"].ToString();
                        }
                        else
                        {
                            strUserId = "-1";
                            strMsgType = "A";
                        }
                        Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(" update recvmsgtable set msgstatus=" + strUserId + ",msgtype=" + strMsgType + " where msgindex="+row["msgindex"].ToString());
                        WriteLog("对应回复短信【" + row["phonenumber"].ToString() + "】到用户ID【" + strUserId + "】。");
                    }
                }
            }
            catch(Exception ex)
            {
                WriteLog("对应号码时出现异常："+ex.Message);
            }
        }
        #endregion          

        #region 发送提醒短信
        /// <summary>
        /// 发送提醒短信
        /// </summary>
        /// <param name="number"></param>
        /// <param name="content"></param>
        public void SendAwokeSms(string number,string content)
        {
            lingtong.SendSms(number, content);
        }
        #endregion

        #region 写日志
        protected void WriteLog(string strLog)
        {
            try
            {
                this.lbMessage.Items.Add(strLog);
                this.lbMessage.SelectedIndex = this.lbMessage.Items.Count - 1;

                System.IO.File.AppendAllText("e:/短信发送日志"+DateTime.Now.ToString("yyyy-MM-dd")+".txt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + ":" + strLog + "\r\n\r\n");
            }
            catch(Exception ex)
            {
                this.lbMessage.Items.Add("无法写入E盘"+ex.Message);
                this.lbMessage.SelectedIndex = this.lbMessage.Items.Count - 1;
            }
        }
        #endregion 
         
        #region 构造发送集合
        List<ECSMS.Model.SendMsgTable> BuildSend(DataSet ds)
        {
            var list = new List<ECSMS.Model.SendMsgTable>();
            if(ds.Tables.Count>0)
            {
                if(ds.Tables[0].Rows.Count>0)
                {
                    foreach(DataRow row in ds.Tables[0].Rows)
                    {
                        var model = new ECSMS.Model.SendMsgTable();
                        if (ds.Tables[0].Rows[0]["MsgIndex"].ToString() != "")
                        {
                            model.MsgIndex = int.Parse(row["MsgIndex"].ToString());
                        }
                        model.PhoneNumber = row["PhoneNumber"].ToString();
                        model.MsgTitle = row["MsgTitle"].ToString();
                        model.MMSInfoFile = row["MMSInfoFile"].ToString();
                        model.TimeSend = row["TimeSend"].ToString();
                        if (row["MsgStatus"].ToString() != "")
                        {
                            model.MsgStatus = int.Parse(row["MsgStatus"].ToString());
                        }
                        model.MsgType = row["MsgType"].ToString();
                        model.SentTime = row["SentTime"].ToString();
                        model.RunInfo = row["RunInfo"].ToString();
                        model.SendReport = row["SendReport"].ToString();
                        model.ServerMsgID = row["ServerMsgID"].ToString();
                        if (row["SpId"].ToString() != "")
                        {
                            model.SpId = int.Parse(row["SpId"].ToString());
                        }
                        if (row["UserId"].ToString() != "")
                        {
                            model.UserId = int.Parse(row["UserId"].ToString());
                        }
                        if (row["IsExperNum"].ToString() != "")
                        {
                            model.IsExperNum = int.Parse(row["IsExperNum"].ToString());
                        }
                        if (row["SendNum"].ToString() != "")
                        {
                            model.SendNum = int.Parse(row["SendNum"].ToString());
                        }
                        if (row["SendTime"].ToString() != "")
                        {
                            model.SendTime = DateTime.Parse(row["SendTime"].ToString());
                        }
                        if (row["ExerNumbers"].ToString() != "")
                        {
                            model.ExerNumbers = int.Parse(row["ExerNumbers"].ToString());
                        }
                        if (row["NumbersCount"].ToString() != "")
                        {
                            model.NumbersCount = int.Parse(row["NumbersCount"].ToString());
                        }
                        model.ServerID = row["ServerID"].ToString();
                        
                        list.Add(model);
                    }                    
                }
            }

            return list;
        }
        #endregion

        #region 设置定时短信到待发状态
        void SetTimeSms()
        {
            int smscount = Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("update SendMsgTable set MsgStatus=" + (int)ECSMS.Channel.SmsStatus.等待发送 + " where TimeSend<GETDATE() and TimeSend!='' and MsgStatus=" + (int)ECSMS.Channel.SmsStatus.定时待发 + "");
            if(smscount>0)
            WriteLog("设置了"+smscount+"个定时短信到待发状态");
        }
        #endregion
    }
}
