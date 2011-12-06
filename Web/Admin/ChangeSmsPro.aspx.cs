using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;

public partial class Admin_ChangeSmsPro : PageBase
{
    private static string _smsServerId { get; set; }
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
            if (Request.QueryString.AllKeys.Where(m => m == "smsid").Count() > 0)
            {
                _smsServerId = Request.QueryString["smsid"].ToString();
                BindData();
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "短信编号无效！");
            }
        }

    }

    void BindData()
    {
        ECSMS.BLL.EC_SmsType MySmstype = new ECSMS.BLL.EC_SmsType();
        List<ECSMS.Model.EC_SmsType> smsTypes = MySmstype.GetModelList("");
        this.ddlPro.DataSource = smsTypes;
        this.ddlPro.DataBind();

        ECSMS.BLL.SendMsgTable mySend = new ECSMS.BLL.SendMsgTable(); 
        var list = mySend.GetModelList(" serverid='"+_smsServerId+"' ");
        this.lblSmsId.Text = _smsServerId;
        string proName = new ECSMS.BLL.EC_SmsType().GetModel(list[0].MsgType).Name;
        this.lblSmsTypeName.Text = proName;  
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        var list = new ECSMS.BLL.SendMsgTable().GetModelList("serverid='" + _smsServerId + "'");
        foreach(var item in list)
        {
            item.MsgType = this.ddlPro.SelectedValue;
            new ECSMS.BLL.SendMsgTable().Update(item);
        } 
        this.Page.RegisterStartupScript(
                    "onload",
                    "<script>window.onload=function(){window.opener.document.getElementById('lblSmstype').innerHTML='" + this.ddlPro.SelectedItem.Text + "';  window.close();}</script>");
    } 

}