using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_UserDetail : System.Web.UI.Page
{

    ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
    ECSMS.Model.EC_User model = new ECSMS.Model.EC_User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //int role = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)));
            //if (role != 0)
            //{
            //    this.Page.Controls.Clear();
            //    Response.Write("您没有此权限");
            //}

            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                this.lblUserId.Text = Request.QueryString["id"].ToString();
                model = bll.GetModel(int.Parse(this.lblUserId.Text));
                switch (model.Role)
                {
                    case 1: this.lblUserType.Text = "代理"; break;
                    case 2: this.lblUserType.Text = "集团用户"; break;
                    case 3: this.lblUserType.Text = "个人用户"; break;
                }
                this.lblAccount.Text = model.Account;
                this.lblcity.Text = model.CompanyaCity;
                this.lblcompanyaddress.Text = model.CompanyAddress;
                this.lblcompanyname.Text = model.CompanyName;
                this.lblEmail.Text = model.Email;
                this.lblMobile.Text = model.Mobile; 
                this.lblName.Text = model.Name;
                this.lblqq.Text = model.QQ;
                this.lblSex.Text = model.Sex == 0 ? "男" : "女";
                this.lblTel.Text = model.Telephone;
                this.lblwebsite.Text = model.WebSite;
                this.lblSign.Text = model.Sign;
                this.lblTrySmsType.Text = model.TrySmsType;
                this.lblExNumber.Text = model.CertificateNumbers;
                this.lblTrySmsType.Text = this.lblTrySmsType.Text.Replace("A", Public.GetProNameByLetter("A")).Replace("B", Public.GetProNameByLetter("B")).Replace("C", Public.GetProNameByLetter("C")).Replace("D", Public.GetProNameByLetter("D")).Replace("E", Public.GetProNameByLetter("E"));
                this.lblUserMaxCount.Text = model.MaxSendNum.ToString();
                this.lblSignLock.Text = model.SignLock.ToString()=="1"?"未锁定":"已锁定";
                this.lblAwokenum.Text = model.AwokeNum.ToString();
                this.lblIsPass.Text = model.State == 2 ? "已审核" : "未审核";

                if (Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0)
                {
                    this.btnBack.PostBackUrl = "~/admin/regmanage.aspx";
                }
                else
                { 
                    this.btnBack.PostBackUrl = "~/usermanage.aspx?type=user";
                }
            }
        }
    }
    protected void btnPass_Click(object sender, EventArgs e)
    { 
        model = bll.GetModel(int.Parse(this.lblUserId.Text));
        model.State = 2;
        bll.Update(model);

        if (model.Mobile != "" && model.State == 2)
        {
            Public.SendSystemSms(model.Mobile, "感谢您注册成为商信宝短信平台用户！您的登录名【"+model.Account+"】密码【"+model.Pwd+"】，登陆地址www.ecsms.cn");
        }

        Maticsoft.Common.MessageBox.ShowAndRedirect(this, "帐号【"+model.Account+"】已审核通过！", ResolveUrl(this.btnBack.PostBackUrl));

    }
}
