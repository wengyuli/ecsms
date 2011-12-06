using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_ProChannelConfig : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int role = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)));
            if (role != 0)
            {
                this.Page.Controls.Clear();
                Response.Write("您没有管理员的权限，拒绝访问。");
            }
            BindData();
        }
        
    }

    void BindData()
    {
        ECSMS.BLL.EC_SmsType MySmstype = new ECSMS.BLL.EC_SmsType();
        List<ECSMS.Model.EC_SmsType> smsTypes = MySmstype.GetModelList("");
        this.ddlPro.DataSource = smsTypes;
        this.ddlPro.DataBind();

        ECSMS.BLL.EC_SmsChannel MyChannel = new ECSMS.BLL.EC_SmsChannel();
        List<ECSMS.Model.EC_SmsChannel> channels = MyChannel.GetModelList("");
        this.ddlChannelDX.DataSource = channels;
        this.ddlChannelDX.DataBind();
        this.ddlChannelLT.DataSource = channels;
        this.ddlChannelLT.DataBind();
        this.ddlChannelYD.DataSource = channels;
        this.ddlChannelYD.DataBind();
    }
    protected void ddlPro_SelectedIndexChanged(object sender, EventArgs e)
    {
        string proName = this.ddlPro.SelectedItem.Value;
        ECSMS.BLL.EC_ProChannel myProChannel = new ECSMS.BLL.EC_ProChannel();
        List<ECSMS.Model.EC_ProChannel> proChannels = myProChannel.GetModelList(" ProCode='" + proName + "' ");
        if (proChannels.Where(m => m.SpCode == "中国电信").Count() > 0)
        {
            this.ddlChannelDX.SelectedValue = proChannels.Where(m => m.SpCode == "中国电信").FirstOrDefault().Channel;
        }
        else
        {
            this.ddlChannelDX.SelectedIndex = 0;
        }
        if (proChannels.Where(m => m.SpCode == "中国联通").Count() > 0)
        {
            this.ddlChannelLT.SelectedValue = proChannels.Where(m => m.SpCode == "中国联通").FirstOrDefault().Channel;
        }
        else
        {
            this.ddlChannelLT.SelectedIndex = 0;
        }
        if (proChannels.Where(m => m.SpCode == "中国移动").Count() > 0)
        {
            this.ddlChannelYD.SelectedValue = proChannels.Where(m => m.SpCode == "中国移动").FirstOrDefault().Channel;
        }
        else
        {
            this.ddlChannelYD.SelectedIndex = 0;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        ECSMS.BLL.EC_ProChannel myProChannel = new ECSMS.BLL.EC_ProChannel();
        if (myProChannel.GetModelList(" spcode='中国联通' and procode='" + this.ddlPro.SelectedValue + "' ").Count == 0)
        {
            myProChannel.Add(new ECSMS.Model.EC_ProChannel() { ProCode = this.ddlPro.SelectedValue, SpCode = "中国联通", Channel = this.ddlChannelLT.SelectedValue });
        }
        else
        { 
            var model = myProChannel.GetModelList(" spcode='中国联通' and procode='" + this.ddlPro.SelectedValue + "' ")[0];
            model.Channel = this.ddlChannelLT.SelectedValue;
            myProChannel.Update(model);
        }
        if (myProChannel.GetModelList(" spcode='中国电信' and procode='" + this.ddlPro.SelectedValue + "' ").Count == 0)
        {
            myProChannel.Add(new ECSMS.Model.EC_ProChannel() { ProCode = this.ddlPro.SelectedValue, SpCode = "中国电信", Channel = this.ddlChannelDX.SelectedValue });
        }
        else
        {
            var model = myProChannel.GetModelList(" spcode='中国电信' and procode='" + this.ddlPro.SelectedValue + "' ")[0];
            model.Channel = this.ddlChannelDX.SelectedValue;
            myProChannel.Update(model);
        }
        if (myProChannel.GetModelList(" spcode='中国移动' and procode='" + this.ddlPro.SelectedValue + "' ").Count == 0)
        {
            myProChannel.Add(new ECSMS.Model.EC_ProChannel() { ProCode = this.ddlPro.SelectedValue, SpCode = "中国移动", Channel = this.ddlChannelYD.SelectedValue });
        }
        else
        {
            var model = myProChannel.GetModelList(" spcode='中国移动' and procode='" + this.ddlPro.SelectedValue + "' ")[0];
            model.Channel = this.ddlChannelYD.SelectedValue;
            myProChannel.Update(model);
        }
        Maticsoft.Common.MessageBox.Show(this, "保存成功！");
    }
}