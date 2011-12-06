using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_ChangeAgent :PageBase
{
    ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
    ECSMS.Model.EC_User model = new ECSMS.Model.EC_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (this.Page.PreviousPage == null)
            {
                this.Page.Controls.Clear();
                this.Page.Response.Write("请通过正常途径进入本页面。");
                return;
            }

            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                this.lblUserId.Text = Request.QueryString["id"].ToString();
                
                model = bll.GetModel(int.Parse(this.lblUserId.Text));
                this.lblUserName.Text = model.Name;
                this.lblAccount.Text = model.Account;
                if (model.UserId != 0)
                {
                    model = bll.GetModel(model.UserId.Value);
                    if (model != null)
                    {
                        this.Label1.Text = model.Account;
                    }
                }
                DataSet ds = bll.GetList(" ( role=1 or role =2) and id!="+this.lblUserId.Text);
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    this.ddlAgent.Items.Clear();
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        this.ddlAgent.Items.Add(new ListItem(row["role"].ToString() == "1" ? "【代理】【" + row["account"] + "】" : "【集团】【" + row["account"] + "】", row["id"].ToString()));
                    }
                }
                else
                {
                    this.ddlAgent.Items.Add(new ListItem("暂无","no"));
                    this.ddlAgent.Enabled = false;
                    this.btnSave.Enabled = false;
                }

                this.btnBack.PostBackUrl = GetReturnUrl();
                
            }
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.ddlAgent.SelectedValue == "no")
        {
            Maticsoft.Common.MessageBox.Show(this,"对不起，暂无代理。");
            return;
        }
        model = bll.GetModel(int.Parse(this.lblUserId.Text));
        if (model.Role == 1&&Public.GetUserRole(int.Parse(this.ddlAgent.SelectedValue))==2)
        {
            Maticsoft.Common.MessageBox.Show(this,"对不起，代理不能分配给集团用户。");
            return;
        }
        model.UserId = int.Parse(this.ddlAgent.SelectedValue);
        bll.Update(model);
        Server.Transfer(GetReturnUrl());
   }

    protected string GetReturnUrl()
    {
        string strUrl = string.Empty;
        switch (Public.GetUserRole(int.Parse(this.lblUserId.Text)))
        { 
            case 3:
            case 2:
                strUrl = ResolveUrl("~/allowuser.aspx?id="+this.lblUserId.Text);
                break;
            case 1:
                strUrl = ResolveUrl("~/allowuser.aspx?id=" + this.lblUserId.Text);
                break;
        }
        return strUrl;
    }


}
