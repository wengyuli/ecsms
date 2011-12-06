using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditGiveLogRemark : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.QueryString["id"]!=null&&Request.QueryString["id"]!="")
            {
                int id = int.Parse( Request.QueryString["id"].ToString());
                ECSMS.BLL.EC_SmsAssignLog bll = new ECSMS.BLL.EC_SmsAssignLog();
                ECSMS.Model.EC_SmsAssignLog model = new ECSMS.Model.EC_SmsAssignLog();
                model = bll.GetModel(id);
                if(model!=null)
                {
                    if (model.FromUserId == int.Parse(Public.GetUserId(this.Page)))
                    {
                        this.lblRemark.Text = model.Remark;
                        this.lblID.Text = id.ToString();
                    }
                    else 
                    {
                        this.Page.Controls.Clear();
                    }
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.txtRemark.Text != "")
        {
            int id = int.Parse(this.lblID.Text);
            ECSMS.BLL.EC_SmsAssignLog bll = new ECSMS.BLL.EC_SmsAssignLog();
            ECSMS.Model.EC_SmsAssignLog model = new ECSMS.Model.EC_SmsAssignLog();
            model = bll.GetModel(id);
            model.Remark = this.txtRemark.Text;
            bll.Update(model);
            this.Page.RegisterStartupScript(
                    "onload",
                    "<script>window.onload=function(){ editOK('"+this.txtRemark.Text+"');}</script>");
        }
    }
}
