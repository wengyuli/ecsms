using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SendSms :PageBase
{
    ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
    ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["type"] != null && Request.QueryString["type"] != "")
            {
                if (Public.GetUserId(this.Page) != "0")
                {
                    ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
                    ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
                    newUser = myUser.GetModel(int.Parse(Public.GetUserId(this.Page)));

                    this.lblUserId.Text = newUser.Id.ToString();
                    if (newUser.State == 0)
                    {
                        this.Page.Controls.Clear();
                        Response.Write("<span style='font-size:12px; font-family:微软雅黑;'>您未通过审核，暂不能发送短信。</span>");
                        return;
                    }

                    if (newUser.IsLock == 1)
                    {
                        this.Page.Controls.Clear();
                        Response.Write("<span style='font-size:12px; font-family:微软雅黑;'>您的账户已被锁定，请联系上级客服进行解锁。</span>");
                        return;
                    }
                }
                else
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this, "您本次登录已经超时，请重新登录。", ResolveUrl("~/default.aspx"));
                    return;
                }
                this.lblType.Text = Request.QueryString["type"].ToString();
                this.lblTypeName.Text = Public.GetProNameByLetter(this.lblType.Text);  
                
                this.selectLong.Items.Clear();
                this.selectLong.Items.Add(new ListItem("普通短信", "0"));
                this.selectLong.Items.Add(new ListItem("分条短信", "2")); 

                int count = int.Parse(Public.GetUserLeaveSms(int.Parse(this.lblUserId.Text), this.lblType.Text));
                if (count > 0)
                {
                    this.lblSmsCount.Text = count.ToString();

                    newUser = myUser.GetModel(int.Parse(Public.GetUserId(this.Page)));

                    if (newUser.SignLock == 0)//锁定
                    {
                        this.txtSign.Enabled = false;
                        if (newUser.Sign != "")
                        {
                            this.txtSign.Text = "【" + newUser.Sign + "】";
                        }
                    }
                    else
                    {
                        this.txtSign.Enabled = true;
                        if (newUser.Sign != "")
                        {
                            this.txtSign.Text = "【" + newUser.Sign + "】";
                        }
                    }
                }
                else
                {
                    this.Page.Controls.Clear();
                    Response.Write("<span style='font-size:12px; font-family:微软雅黑;'>您的【" + this.lblTypeName.Text + "】余额为【0】或暂未开通，请您联系客户经理开通冲值后再发送短信</span>");
                }
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "请通过正常途径访问本页面。", ResolveUrl("~/default.aspx"));
            }
        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.txtSendTime.textValue != "")
            {
                if (Convert.ToDateTime(this.txtSendTime.Text) < DateTime.Now)
                {
                    Maticsoft.Common.MessageBox.Show(this.Page, "定时发送时间应该晚于当前时间【" + DateTime.Now.ToString() + "】");
                    return;
                }
            }
            ECSMS.BLL.SendMsgTable bll = new ECSMS.BLL.SendMsgTable();
            ECSMS.Model.SendMsgTable model = new ECSMS.Model.SendMsgTable();

            string strNumbers = this.txtNumbers.Text;
            string strTryNumbers = this.txtTryNumbers.Text;
            string[] arrSplit = new string[] { "\r\n" };
            string[] arrNumbers = strNumbers.Split(arrSplit, System.StringSplitOptions.RemoveEmptyEntries);
            string[] arrTryNumbers = strTryNumbers.Split(arrSplit, System.StringSplitOptions.RemoveEmptyEntries);
            int totalNumbers = arrNumbers.Length + arrTryNumbers.Length;
            //检查号码数量
            if (totalNumbers == 0)
            {
                Maticsoft.Common.MessageBox.Show(this, "请填写号码后再进行发送！");
                return;
            }
            
            this.txtSmsContent.Text = this.radioFirst.Checked ? this.txtSign.Text + this.txtSmsContent.Text : this.txtSmsContent.Text + this.txtSign.Text;
            
            //检查短信内容
            if (this.txtSmsContent.Text == "")
            {
                Maticsoft.Common.MessageBox.Show(this, "短信内容不能为空！");
                return;
            }
            model.TimeSend = this.txtSendTime.Text;
            //判断发送是否超出权限 
            if (totalNumbers <= Public.GetPlatMaxCount() && totalNumbers <= Public.GetUserMaxCount(int.Parse(this.lblUserId.Text)))
            {
                model.MsgStatus = (int)ECSMS.Channel.SmsStatus.等待发送;
                if(model.TimeSend!="")
                {
                    model.MsgStatus = (int)ECSMS.Channel.SmsStatus.定时待发;
                }
            }
            else
            {
                model.MsgStatus = (int)ECSMS.Channel.SmsStatus.待发状态;//待发状态
            }             
            model.SendTime = DateTime.Now;
            model.UserId = int.Parse(this.lblUserId.Text);           
            
            switch (this.selectLong.SelectedValue)
            {
                case "0":
                    model.SendNum = 1;
                    break;
                case "2":
                    if (this.txtSmsContent.Text.Length <= 70)
                    {
                        model.SendNum = 1;
                    }
                    else
                    {
                        model.SendNum = this.txtSmsContent.Text.Length % 66 == 0 ? this.txtSmsContent.Text.Length / 66 : this.txtSmsContent.Text.Length / 66 + 1;
                    }
                    break;         
            }
            //检查余额
            if (int.Parse(Public.GetUserLeaveSms(int.Parse(this.lblUserId.Text), this.lblType.Text)) < totalNumbers*model.SendNum)
            {
                Maticsoft.Common.MessageBox.Show(this, "您的余额不足以发送【" + totalNumbers * model.SendNum + "】条信息，请充值以后再进行发送！");
                return;
            }
            Random rand = new Random();
            model.ServerID = DateTime.Now.ToString("yyyyMMddHHmmss") + model.UserId.ToString() + rand.Next(11, 99).ToString();
            DataSet dsKeys = new DataSet();
            ECSMS.BLL.EC_ForbidWord bllKeys = new ECSMS.BLL.EC_ForbidWord();
              
            dsKeys = bllKeys.GetList("channelcode='"+ECSMS.Channel.Channel.wanzhong.ToString()+"'");//检查关键字，网关以万众为准
            foreach (DataRow row in dsKeys.Tables[0].Rows)
            {
                if (this.txtSmsContent.Text.Contains(row["name"].ToString()))
                {
                    Maticsoft.Common.MessageBox.Show(this, "您的短信内容含有非法关键字【" + row["name"].ToString() + "】，请您更改短信内容后再进行发送！");
                    return;
                }
            }
            model.MsgType = this.lblType.Text; 
            if (arrTryNumbers.Length > 0)
            {
                model.IsExperNum = 1;
            }
            foreach (string number in arrTryNumbers)
            {
                if (number != "")
                {
                    model.ExerNumbers = arrTryNumbers.Length;//体验号码个数
                    model.NumbersCount = totalNumbers;//总号码数量
                    model.SpId = Public.GetNumerSp(number);//得到号码的运营商ID
                    model.PhoneNumber = number;

                    switch (this.selectLong.SelectedValue)
                    {
                        case "0":
                            model.MsgTitle = this.txtSmsContent.Text;
                            bll.Add(model);
                            break;
                        case "2":
                            for (int i = 0; i < model.SendNum; i++)
                            {
                                if (model.SendNum <= 1)
                                {
                                    model.MsgTitle = this.txtSmsContent.Text;
                                }
                                else
                                {
                                    model.MsgTitle = (i + 1) + "/" + model.SendNum + ")" + this.txtSmsContent.Text.Substring(i * 66, this.txtSmsContent.Text.Length - i * 66 > 66 ? 66 : this.txtSmsContent.Text.Length - i * 66);
                                }
                                bll.Add(model);
                            }
                            break;
                    }
                }
            }
            foreach (string number in arrNumbers)
            {
                if (number != "")
                {
                    model.ExerNumbers = arrTryNumbers.Length;//体验号码个数
                    model.NumbersCount = totalNumbers;//总号码数量
                    model.SpId = Public.GetNumerSp(number);//得到号码的运营商ID
                    model.PhoneNumber = number.Replace(" ","");

                    switch (this.selectLong.SelectedValue)
                    {
                        case "0":
                            model.MsgTitle = this.txtSmsContent.Text;
                            bll.Add(model);
                            break;
                        case "2":
                            for (int i = 0; i < model.SendNum; i++)
                            {
                                if (model.SendNum <= 1)
                                {
                                    model.MsgTitle = this.txtSmsContent.Text;
                                }
                                else
                                {
                                    model.MsgTitle = (i + 1) + "/" + model.SendNum + ")" + this.txtSmsContent.Text.Substring(i * 66, this.txtSmsContent.Text.Length - i * 66 > 66 ? 66 : this.txtSmsContent.Text.Length - i * 66);
                                }
                                bll.Add(model);
                            }
                            break;
                    }
                }

            }

            //扣费
            Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("update ec_usersmsaccount set leavenum=leavenum-" + totalNumbers * model.SendNum + " where userid=" + Public.GetUserId(this.Page) + " and smstype='" + this.lblType.Text + "'");
            string strShow = string.Empty;
            //消费提醒
            int intUserAwokeNum = Public.GetUserAwokeNum(int.Parse(this.lblUserId.Text));
            if (totalNumbers*model.SendNum >= intUserAwokeNum)
            {
                ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
                ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
                newUser = myUser.GetModel(int.Parse(this.lblUserId.Text));
                if (newUser.Mobile != ""&&intUserAwokeNum!=0)
                {
                    Public.SendSystemSms(newUser.Mobile, "商信宝温馨提醒：您的余额提醒值为【" + intUserAwokeNum + "】，您的账户【"+newUser.Account+"】于【"+DateTime.Now.ToString()+"】发送了【" + totalNumbers*model.SendNum + "】条信息。");
                }
            }
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "共消费【" + model.SendNum * model.NumbersCount + "】条，本次任务提交成功！", "../smslog/sendlog.aspx?type=" + this.lblType.Text);
        }
        catch(Exception ex)
        {
            Maticsoft.Common.MessageBox.Show(this,"提交失败，原因:"+ex.Message);
        }
        
    }
    protected void delBlack_Click(object sender, EventArgs e)
    {
        string[] arrSplit = new string[] { "\r\n" };
        if (this.txtNumbers.Text != "")
        {
            int before = 0;
            int after = 0;
            string[] arrNumbers = this.txtNumbers.Text.Split(arrSplit, System.StringSplitOptions.RemoveEmptyEntries);
            before = arrNumbers.Length;
            ECSMS.BLL.EC_Customer bll = new ECSMS.BLL.EC_Customer();
            DataSet ds = bll.GetList("userid=" + Public.GetUserId(this.Page) + " and groupid=-2");
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                string strBlackNumber = string.Empty;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    strBlackNumber += row["mobile"].ToString();
                }
                this.txtNumbers.Text = "";
                foreach (string number in arrNumbers)
                {
                    if (!strBlackNumber.Contains(number))
                    {
                        this.txtNumbers.Text += number + "\r\n";
                        after++;
                    }
                }
                Maticsoft.Common.MessageBox.Show(this.Page, "过滤黑名单【"+(before-after)+"】个");
            }
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this.Page, "请输入号码后再过滤黑名单。");
        }
    }



}
