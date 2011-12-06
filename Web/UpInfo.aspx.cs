using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UpInfo :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindDownLoad();
        }
    }
    protected void BindDownLoad()
    {
        ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
        int AgentId = ((ECSMS.Model.EC_User)(myUser.GetModel(int.Parse( Public.GetUserId(this.Page))))).UserId.Value;
        ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
        newUser = myUser.GetModel(AgentId);
        this.lblCompanyName.Text = newUser.CompanyName;
        this.lblMobile.Text = newUser.Mobile;
        this.lblName.Text = newUser.Name;
        this.lblTel.Text = newUser.Telephone;       
        
        
        ECSMS.BLL.EC_Bank bll = new ECSMS.BLL.EC_Bank();
        DataSet ds = bll.GetList(" userid= " + AgentId);
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            this.DataList1.DataSource = ds;
            this.DataList1.DataBind();
        }
    }
}
