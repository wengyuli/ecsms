using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SendXSms :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindPrin();
            BindCity();
            LoadTypes();
        }
    }
    void LoadTypes()
    {
        ECSMS.BLL.EC_SmsType MySmstype = new ECSMS.BLL.EC_SmsType();
        List<ECSMS.Model.EC_SmsType> smsTypes = MySmstype.GetModelList("");
        this.rbtnPro.DataSource = smsTypes;
        this.rbtnPro.DataBind();
    }
    protected void BindPrin()
    {
        ECSMS.BLL.EC_Area area = new ECSMS.BLL.EC_Area();
        DataSet ds = area.GetList("parentid=0");
        Public.DropdownListBind(this.ddlProvince, ds, "name", "id");
    }

    protected void BindCity()
    {
        this.ddlCity.Items.Clear();
        ECSMS.BLL.EC_Area area = new ECSMS.BLL.EC_Area();
        DataSet ds = area.GetList("parentid=" + this.ddlProvince.SelectedValue + "");
        Public.DropdownListBind(this.ddlCity, ds, "name", "id");
    }

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindCity();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.txtContent.Text == "")
        {
            Maticsoft.Common.MessageBox.Show(this,"请输入短信内容后再提交需求。");
            return;
        }
        //为了防止发送时没有余额 先扣除
        string strSmsType = this.rbtnPro.SelectedValue;       
        ECSMS.BLL.EC_UserSmsAccount myAccount = new ECSMS.BLL.EC_UserSmsAccount();
        ECSMS.Model.EC_UserSmsAccount newAccount = new ECSMS.Model.EC_UserSmsAccount();
        DataSet ds = myAccount.GetList(" userid=" + Public.GetUserId(this.Page) + " and smstype='" + strSmsType + "' ");
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            if (int.Parse(ds.Tables[0].Rows[0]["LeaveNum"].ToString()) < int.Parse(this.rbtnCount.SelectedValue))
            { 
                Maticsoft.Common.MessageBox.Show(this, "对不起，您在【" + this.rbtnPro.SelectedItem.Text + "】余额【" + ds.Tables[0].Rows[0]["leavenum"].ToString() + "】不够发送本次短信，请充值或选择其他短信产品。");
                return;
            }
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this, "对不起，您在【" + this.rbtnPro.SelectedItem.Text + "】没有余额，请充值或选择其他短信产品。");
            return;
        }

        ECSMS.BLL.EC_ForbidWord bllKeys = new ECSMS.BLL.EC_ForbidWord();
        
        DataSet dsKeys = bllKeys.GetList("channelcode='card'");//检查是否有关键字
        foreach (DataRow row in dsKeys.Tables[0].Rows)
        {
            if (this.txtContent.Text.Contains(row["name"].ToString()))
            {
                Maticsoft.Common.MessageBox.Show(this, "您的短信内容含有非法关键字【" + row["name"].ToString() + "】，请您更改短信内容后再进行发送！");
                return;
            }
        }
        dsKeys = bllKeys.GetList("channelcode='wanzhong'");//检查关键字，网关以万众为准
        foreach (DataRow row in dsKeys.Tables[0].Rows)
        {
            if (this.txtContent.Text.Contains(row["name"].ToString()))
            {
                Maticsoft.Common.MessageBox.Show(this, "您的短信内容含有非法关键字【" + row["name"].ToString() + "】，请您更改短信内容后再进行发送！");
                return;
            }
        }

        Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(" update ec_usersmsaccount set leavenum=leavenum-" + int.Parse(this.rbtnCount.SelectedValue) + " where  userid=" + Public.GetUserId(this.Page) + " and smstype='" + strSmsType + "'  ");

        ECSMS.BLL.SendMsgTable bllSend = new ECSMS.BLL.SendMsgTable();
        ECSMS.Model.SendMsgTable modelsend = new ECSMS.Model.SendMsgTable();
        modelsend.PhoneNumber="省市："+this.ddlProvince.SelectedItem.Text+";"+this.ddlCity.SelectedItem.Text+";\r\n";
        modelsend.PhoneNumber += "年龄：";
        foreach(ListItem item in this.cbAge.Items)
        {
            if (item.Selected)
            {
                modelsend.PhoneNumber += item.Text+";";
            }
        }
        modelsend.PhoneNumber += "\r\n爱好："; 
        foreach (ListItem item in this.cbFav.Items)
        {
            if (item.Selected)
            {
                modelsend.PhoneNumber += item.Text + ";";
            }
        }
        modelsend.PhoneNumber += "\r\n话费：";
        foreach (ListItem item in this.cbHf.Items)
        {
            if (item.Selected)
            {
                modelsend.PhoneNumber += item.Text + ";";
            }
        }
        modelsend.PhoneNumber += "\r\n行业：";
        foreach (ListItem item in this.cbHy.Items)
        {
            if (item.Selected)
            {
                modelsend.PhoneNumber += item.Text + ";";
            }
        }
        modelsend.PhoneNumber += "\r\n性别：";
        foreach (ListItem item in this.cbSex.Items)
        {
            if (item.Selected)
            {
                modelsend.PhoneNumber += item.Text + ";";
            }
        }
        modelsend.PhoneNumber += "\r\n";
        modelsend.PhoneNumber += "个性需求："+this.txtBySelf.Text+"\r\n";
        modelsend.MsgTitle = this.txtContent.Text;
        modelsend.MsgStatus = (int)ECSMS.Channel.SmsStatus.待发状态;
        modelsend.MsgType = "X";
        modelsend.SendTime = DateTime.Now;
        modelsend.IsExperNum = 0;
        modelsend.ExerNumbers = 0;
        modelsend.UserId = int.Parse(Public.GetUserId(this.Page));
        modelsend.NumbersCount = int.Parse(rbtnCount.SelectedValue);
        Random rand = new Random();
        modelsend.ServerID = DateTime.Now.ToString("yyyyMMddHHmmss") + Public.GetUserId(this.Page) + rand.Next(11, 99).ToString();
        bllSend.Add(modelsend);          
        
        Maticsoft.Common.MessageBox.ShowAndRedirect(this,"您的发送需求已经提交，我们会尽快处理。","../smslog/sendlog.aspx?type=x");
    }





}
