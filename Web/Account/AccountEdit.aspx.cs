using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Data;

public partial class AccountEdit : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Public.GetUserId(this.Page) != "0")
            {
                ShowInfo(int.Parse(Public.GetUserId(this.Page)));
            }            
        }
    }

    private void ShowInfo(int Id)
    {
        ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
        ECSMS.Model.EC_User model = bll.GetModel(Id);

        string[] strCity = model.CompanyaCity.Split('-');
        ECSMS.BLL.EC_Area myArea = new ECSMS.BLL.EC_Area();
        DataSet ds = myArea.GetList("ParentId=0");
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            Public.DropdownListBind(this.ddlProvince, ds, "name", "id");
            for (int i = 0; i < ddlProvince.Items.Count; i++)
            {
                ddlProvince.Items[i].Selected = false;
                if (ddlProvince.Items[i].Text == strCity[0].ToString())
                {
                    ddlProvince.Items[i].Selected = true;
                }
            }

            ds = myArea.GetList("parentid=" + this.ddlProvince.SelectedValue + "");
            count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                Public.DropdownListBind(this.ddlCity, ds, "name", "id");        
                
                for (int i = 0; i < ddlCity.Items.Count; i++)
                {
                    ddlCity.Items[i].Selected = false;
                    if (ddlCity.Items[i].Text == strCity[1].ToString())
                    {
                        ddlCity.Items[i].Selected = true;
                    }
                }

            }
        }
        this.txtAccount.Text = model.Account;
        this.txtName.Text = model.Name;
        this.ddlSex.SelectedValue = model.Sex.ToString();
        this.txtTelephone.Text = model.Telephone;
        this.txtMobile.Text = model.Mobile;
        this.txtEmail.Text = model.Email;
        this.txtFax.Text = model.Fax;
        this.txtQQ.Text = model.QQ; 
        this.txtCompanyName.Text = model.CompanyName;
        this.txtCompanyAddress.Text = model.CompanyAddress;
        this.txtWebSite.Text = model.WebSite;
        this.txtPostCode.Text = model.PostCode;
        this.txtSign.Text = model.Sign;
        if (model.SignLock == 0)
        {
            this.txtSign.Enabled = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0 ? true : false;
        }
        else
        {
            this.txtSign.Enabled = true;
        }
        this.txtYxzj.Text = model.CertificateNumbers;
        switch (model.Role)
        {
            case 0:
                this.txtRole.Text = "管理员";
                break;
            case 1:
                this.txtRole.Text = "代理商";
                break;
            case 2:
                this.txtRole.Text = "集团用户";
                break;
            case 3:
                this.txtRole.Text = "个人用户";
                break;
        }
        this.txtAwokeNum.Text = model.AwokeNum.ToString();

        switch (model.State)
        {
            case 0:
                this.txtState.Text = "未审核";
                break;
            case 1:
                this.txtState.Text = "审核未通过";
                break;
            case 2:
                this.txtState.Text = "审核通过";
                break;
        }

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {

        string strErr = "";
        if (this.txtAccount.Text == "")
        {
            strErr += "账户不能为空！\\n";
        }
        if (this.txtName.Text == "")
        {
            strErr += "姓名不能为空！\\n";
        }
        if (this.txtTelephone.Text == "")
        {
            strErr += "电话不能为空！\\n";
        }
        if (this.txtMobile.Text == "")
        {
            strErr += "手机不能为空！\\n";
        }
        if (this.txtEmail.Text == "")
        {
            strErr += "电子邮件不能为空！\\n";
        }
 
        if (this.txtCompanyName.Text == "")
        {
            strErr += "公司名称不能为空！\\n";
        }
        if (this.txtCompanyAddress.Text == "")
        {
            strErr += "公司地址不能为空！\\n";
        }
 
 
        if (!PageValidate.IsNumber(txtAwokeNum.Text))
        {
            strErr += "提醒额度不是数字！\\n";
        }
        if (strErr != "")
        {
            MessageBox.Show(this, strErr);
            return;
        }
        string Account = this.txtAccount.Text;
        string Name = this.txtName.Text;
        int Sex = int.Parse(this.ddlSex.SelectedValue);
        string Telephone = this.txtTelephone.Text;
        string Mobile = this.txtMobile.Text;
        string Email = this.txtEmail.Text;
        string Fax = this.txtFax.Text;
        string QQ = this.txtQQ.Text; 
        string CompanyName = this.txtCompanyName.Text;
        string CompanyaCity = this.ddlProvince.SelectedItem.Text + "-" + this.ddlCity.SelectedItem.Text;
        string CompanyAddress = this.txtCompanyAddress.Text;
        string WebSite = this.txtWebSite.Text;
        string PostCode = this.txtPostCode.Text;
        int AwokeNum = int.Parse(this.txtAwokeNum.Text);


        ECSMS.Model.EC_User model = new ECSMS.Model.EC_User();
        ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
        if (Public.GetUserId(this.Page) != "0")
        {
            model.Id = int.Parse(Public.GetUserId(this.Page));
        }
        model = bll.GetModel(model.Id);
        model.Account = Account;
        model.Name = Name;
        model.Sex = Sex;
        model.Telephone = Telephone;
        model.Mobile = Mobile;
        model.Email = Email;
        model.Fax = Fax;
        model.QQ = QQ; 
        model.CompanyName = CompanyName;
        model.CompanyaCity = CompanyaCity;
        model.CompanyAddress = CompanyAddress;
        model.WebSite = WebSite;
        model.PostCode = PostCode;
        model.AwokeNum = AwokeNum;
        model.Sign = txtSign.Text;
        model.CertificateNumbers = this.txtYxzj.Text;
        bll.Update(model);
        Maticsoft.Common.MessageBox.ShowAndRedirect(this,"修改信息成功！","accountinfo.aspx");
    }

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlCity.Items.Clear();
        ECSMS.BLL.EC_Area myArea = new ECSMS.BLL.EC_Area();
        DataSet ds = myArea.GetList("ParentId="+this.ddlProvince.SelectedValue+"");
        Public.DropdownListBind(this.ddlCity, ds, "name", "id");
    }
}
