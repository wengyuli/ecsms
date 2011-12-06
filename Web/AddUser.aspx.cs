using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AddUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0)
            {
                this.btnBack.PostBackUrl = ResolveUrl("~/admin/users.aspx?type=user");
            }
            else
            {
                this.btnBack.PostBackUrl = ResolveUrl("~/UserManage.aspx?type=user");
            }
            BindPrin();
            BindCity();
        }
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

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        if (this.txtAccount.Text != "")
        {
            if(Public.IsForbiddenWord(this.txtAccount.Text,"reg"))
            {
                Maticsoft.Common.MessageBox.Show(this,"对不起，此用户名属于敏感词，禁止注册。");
                return;
            }

            ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
            ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
            DataSet ds = myUser.GetList(" account='"+this.txtAccount.Text+"' ");
            int count = 0;
            count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                this.lblShow.Text="对不起，此用户名已经被注册。";
            }
            else
            {
                this.lblShow.Text="恭喜您，这个用户名可以注册。";
            }
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this,"请输入用户名后再进行检验。");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.txtAccount.Text == "")
        {
            Maticsoft.Common.MessageBox.Show(this,"请输入用户名后再进行添加。");
            return;
        }

        if (Public.IsForbiddenWord(this.txtAccount.Text, "reg"))
        {
            Maticsoft.Common.MessageBox.Show(this, "对不起，此用户名属于敏感词，禁止注册。");
            return;
        }

        
        ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
        ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
        DataSet ds = myUser.GetList(" account='" + this.txtAccount.Text + "' ");
        int count = 0;
        count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            Maticsoft.Common.MessageBox.Show(this,"对不起，此用户名已经被注册。");
            return;
        }

        if(this.txtPwd1.Text!=this.txtPwd2.Text)
        {
            Maticsoft.Common.MessageBox.Show(this,"两次输入的密码不一致。");
            return;
        }

        newUser = new ECSMS.Model.EC_User();
        newUser.Account = this.txtAccount.Text;
        newUser.AwokeNum = 0;
        newUser.CompanyName = this.txtCompany.Text;
        newUser.CertificateType = this.ddlcard.SelectedValue;
        newUser.CertificateNumbers = this.txtCardNumber.Text;
        newUser.MaxSendNum = Public.GetUserMaxCount();
        newUser.Mobile = this.txtMobile.Text;
        newUser.Role = int.Parse(this.rbtnRole.SelectedValue);
        newUser.Sign = this.txtSign.Text;
        newUser.Telephone = this.txtTel.Text;
        newUser.UserId = int.Parse(Public.GetUserId(this.Page));
        newUser.Pwd = this.txtPwd1.Text;
        newUser.State = 2;
        newUser.StartDate = DateTime.Now.ToString();
        newUser.Operater = int.Parse(Public.GetUserId(this.Page));
        newUser.CompanyaCity = this.ddlProvince.SelectedItem.Text + "-" + this.ddlCity.SelectedItem.Text;
        newUser.Name = this.txtName.Text;
        myUser.Add(newUser);

        Maticsoft.Common.MessageBox.ShowAndRedirect(this,"新建用户保存成功！",this.btnBack.PostBackUrl);
    }

}
