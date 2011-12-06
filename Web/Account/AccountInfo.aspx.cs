using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AccountInfo : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
 
            if (Public.GetUserId(this.Page) != "0")
            {
                ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
                ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
                newUser = myUser.GetModel(int.Parse(Public.GetUserId(this.Page)));
                this.lblAccount.Text = newUser.Account;
                this.lblCity.Text = newUser.CompanyaCity;
                this.lblCompanyAddress.Text = newUser.CompanyAddress;
                this.lblCompanyName.Text = newUser.CompanyName;
                this.lblEmail.Text = newUser.Email;
                this.lblFax.Text = newUser.Fax;
                this.lblMobile.Text = newUser.Mobile; 
                this.lblName.Text = newUser.Name;
                this.lblPostCode.Text = newUser.PostCode;
                this.lblQQ.Text = newUser.QQ;
                this.lblSex.Text = (newUser.Sex.ToString()=="0"?"男":"女");
                this.lblTelephone.Text = newUser.Telephone;
                this.lblWebsite.Text = newUser.WebSite;
                this.lblawoke.Text = newUser.AwokeNum.ToString();
                this.lblsign.Text = newUser.Sign;
                switch(newUser.Role)
                {
                    case 0:
                        this.lblUserType.Text = "管理员"; 
                        break;
                    case 1:
                        this.lblUserType.Text = "代理商";
                        break;
                    case 2:
                        this.lblUserType.Text = "集团用户";
                        break;
                    case 3:
                        this.lblUserType.Text = "个人用户";
                        break;
                }

            }
 
    }
    protected void btnModifyPwd_Click(object sender, EventArgs e)
    {
        Response.Redirect("pwdmodify.aspx");
    }
}
