using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_KeyWords :PageBase
{
    ECSMS.Channel.LingKai lkser = new ECSMS.Channel.LingKai();
    ECSMS.Channel.WanZhong wzser = new ECSMS.Channel.WanZhong();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            int role = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)));
            if (role != 0)
            {
                this.Page.Controls.Clear();
                Response.Write("您没有管理员的权限，拒绝访问。");
            }

            BindChannel();
            BindKey();
            BindChannelConf();
        }
    }

    protected void BindChannel()
    {
        ECSMS.BLL.EC_SmsChannel myChannel = new ECSMS.BLL.EC_SmsChannel();
        DataSet ds = myChannel.GetList("");
        int count = ds.Tables[0].Rows.Count;
        if(count>0)
        {            
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                this.rbtnChannel.Items.Add(new ListItem(row["name"].ToString(), row["code"].ToString()));
            }
            this.rbtnChannel.SelectedValue = "card";
        }        
    }
 

    protected void rbtnChannel_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindKey();
        BindChannelConf();
    }

    protected void BindKey()
    {
        ECSMS.BLL.EC_ForbidWord myWord = new ECSMS.BLL.EC_ForbidWord();
        DataSet ds = myWord.GetList("ChannelCode ='"+rbtnChannel.SelectedValue+"'");
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            this.txtKeyWords.Text = "";
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.txtKeyWords.Text += row["name"].ToString() + "#";
            }
            this.txtKeyWords.Text = this.txtKeyWords.Text.Substring(0, this.txtKeyWords.Text.Length - 1);
        }
        else
        {
            this.txtKeyWords.Text = "";
        }
    }

    protected void BindChannelConf()
    {
        ECSMS.BLL.EC_SmsChannel bll = new ECSMS.BLL.EC_SmsChannel();
        ECSMS.Model.EC_SmsChannel model = new ECSMS.Model.EC_SmsChannel();
        model = bll.GetModel(this.rbtnChannel.SelectedValue);
        this.txtLeavesms.Text = model.AwokeNum.ToString();
        this.txtMaxNum.Text = model.MaxSendNum.ToString();
        this.rbtnIsClose.SelectedValue = model.State.ToString();
    }
    /// <summary>
    /// 通道配置（权限、关键词、开关）
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.txtKeyWords.Text != "")
        {
            #region 关键词
            //先删
            Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete from ec_forbidword where channelcode='" + this.rbtnChannel.SelectedValue + "'");
            //再添加
            ECSMS.BLL.EC_ForbidWord myWord = new ECSMS.BLL.EC_ForbidWord();
            ECSMS.Model.EC_ForbidWord newWord = new ECSMS.Model.EC_ForbidWord();

            string strSeg = txtKeyWords.Text;
            strSeg = strSeg.Replace(" ", "");
            string[] segs = strSeg.Split('#');
            for (int i = 0; i < segs.Length; i++)
            {
                if (segs[i].ToString() != "")
                {
                    newWord = new ECSMS.Model.EC_ForbidWord();
                    newWord.Name = segs[i].ToString();
                    newWord.ChannelCode = this.rbtnChannel.SelectedValue;
                    myWord.Add(newWord);
                }
            }
            #endregion

            ECSMS.BLL.EC_SmsChannel myChannel = new ECSMS.BLL.EC_SmsChannel();
            ECSMS.Model.EC_SmsChannel newChannel = new ECSMS.Model.EC_SmsChannel();
            newChannel = myChannel.GetModel(rbtnChannel.SelectedValue);
            newChannel.AwokeNum =  int.Parse(this.txtLeavesms.Text);
            newChannel.MaxSendNum = int.Parse(this.txtMaxNum.Text);
            newChannel.State = int.Parse(this.rbtnIsClose.SelectedValue);
            myChannel.Update(newChannel);

            Maticsoft.Common.MessageBox.Show(this, "通道配置更新成功！");
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this,"请填写关键字后再提交。");
        }

    }

    #region 通道状态查询
    /// <summary>
    /// 查询两个通道余额
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        ECSMS.BLL.EC_SmsChannel bll = new ECSMS.BLL.EC_SmsChannel();
        ECSMS.Model.EC_SmsChannel model = new ECSMS.Model.EC_SmsChannel();         

        model = bll.GetModel(ECSMS.Channel.Channel.lingkaim.ToString());       
        this.lbllkSmsCount.Text = lkser.GetMSmsRemain().ToString();

        model = bll.GetModel(ECSMS.Channel.Channel.lingkaiu.ToString()); 
        this.lbllkuSmsCount.Text = lkser.GetUSmsRemain().ToString();

        model = bll.GetModel(ECSMS.Channel.Channel.wanzhong.ToString());    
        this.lblwzSmsCount.Text = wzser.GetSmsRemain().ToString();
    }
    /// <summary>
    /// 凌凯移动发送短信
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnlkSend_Click(object sender, EventArgs e)
    {
        if (this.txtTestNumber.Text != "" && this.txtTestSms.Text != "")
        {
            ECSMS.Channel.LingKai lingkai = new ECSMS.Channel.LingKai();
            int result = lingkai.SendMSms(this.txtTestNumber.Text, this.txtTestSms.Text, "", "");
            Maticsoft.Common.MessageBox.Show(this, SendLKSms(result));

        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this,"请输入手机号码和测试短信内容");
        }
    }
    /// <summary>
    /// 凌凯联通发送短信
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnlkSend1_Click(object sender, EventArgs e)
    {
        if (this.txtTestNumber.Text != "" && this.txtTestSms.Text != "")
        {
            ECSMS.Channel.LingKai lingkai = new ECSMS.Channel.LingKai();
            int result = lingkai.SendUSms(this.txtTestNumber.Text, this.txtTestSms.Text, "", "");
            Maticsoft.Common.MessageBox.Show(this, SendLKSms(result));
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this, "请输入手机号码和测试短信内容");
        }
    }
    protected string SendLKSms(int state)
    { 
        string strResult = string.Empty;
        switch (state)
        {
            case 0:
                strResult = "发送成功！";

                break;
            case -1:
                strResult = "账号未注册！";
                break;
            case -2:
                strResult = "其他错误！";
                break;
            case -3:
                strResult = "密码错误！";
                break;
            case -4:
                strResult = "手机号格式不对！";
                break;
            case -5:
                strResult = "余额不足！";
                break;
            case -6:
                strResult = "定时发送时间不是有效时间！";
                break;
        }
        return strResult;
    }
    /// <summary>
    /// 万众发送短信
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnwzSend_Click(object sender, EventArgs e)
    {
        int result = new ECSMS.Channel.WanZhong().SendSms(this.txtTestNumber.Text, this.txtTestSms.Text); 
        string strResult = string.Empty;
        switch (result)
        {
            case 0:
                strResult = "提交成功，审查！";
                break;
            case 6002:
                strResult = "信息内容超长！";
                break;
            case 6003:
                strResult = "提交参数不可为空！";
                break;
            case 6004:
                strResult = "提交速度限制！";
                break;
            case 6005:
                strResult = "提交池限制！";
                break;
            case 6006:
                strResult = "接收号码异常或号码总数超出1000！";
                break;
            case 100028:
                strResult = "账号余额不足！";
                break;
            case 100030:
                strResult = "记录入库失败！";
                break;
            case 100031:
                strResult = "用户账号无效！";
                break;
            case 100033:
                strResult = "用户计费失败！";
                break;
            case 100045:
                strResult = "用户没有购买该类产品！";
                break;
            case 100050:
                strResult = "IP地址不符合！";
                break;
            case 100051:
                strResult = "企业号错误！";
                break;
            case 200053:
                strResult = "数据库操作异常！";
                break;
            case 201005:
                strResult = "接收号码被过滤！";
                break;
            case 201054:
                strResult = "产品编号错误！";
                break;
            case 201056:
                strResult = "短信内容超长！";
                break;
            case -1:
                strResult = "提交接口异常！";
                break;
        }
        Maticsoft.Common.MessageBox.Show(this,strResult);
    }
    #endregion



}
