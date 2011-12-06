using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AllowUser :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            if (this.Page.PreviousPage==null)
            {
                this.Page.Controls.Clear();
                this.Page.Response.Write("请通过正常途径进入本页面。");
                return;
            }

            if (Request.QueryString["id"]!=null&&Request.QueryString["id"]!="")
            {
                this.lblUserId.Text = Request.QueryString["id"].ToString();
                ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
                ECSMS.Model.EC_User model = new ECSMS.Model.EC_User();
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
                this.txtSign.Text = model.Sign;
                this.lblTrySmsType.Text = model.TrySmsType.Replace("A", Public.GetProNameByLetter("A")).Replace("B", Public.GetProNameByLetter("B")).Replace("C", Public.GetProNameByLetter("C")).Replace("D", Public.GetProNameByLetter("D")).Replace("E", Public.GetProNameByLetter("E"));
                this.rbtnAllow.SelectedValue = model.State.ToString();
                this.txtMaxCount.Text = model.MaxSendNum.ToString();
                this.rbtnSign.SelectedValue = model.SignLock.ToString();
                this.txtAwokeNum.Text=model.AwokeNum.ToString();
                this.lblCardNumber.Text = model.CertificateNumbers;
                this.lblUpUser.Text = Public.GetUserAccount( model.UserId.Value);

                this.linkChange.PostBackUrl = "admin/changeagent.aspx?id="+model.Id;

                if (Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0)
                {
                    this.btnRePwd.Visible = true;
                    if (model.Role == 1)
                    {
                        this.btnBack.PostBackUrl = "~/admin/users.aspx?type=agent";
                    }
                    else
                    {
                        this.btnBack.PostBackUrl = "~/admin/users.aspx?type=user";
                    }
                    
                }
                else
                {
                    this.linkChange.Visible = false;
                    this.lblUserMaxCount.Visible = false;
                    this.txtMaxCount.Visible = false;
                    if (model.Role == 1)
                    {
                        this.btnBack.PostBackUrl = "~/usermanage.aspx?type=agent";
                    }
                    else
                    {
                        this.btnBack.PostBackUrl = "~/usermanage.aspx?type=user";
                    }
                    
                }
            }


        }        
    }
    protected void btnPass_Click(object sender, EventArgs e)
    {
        ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
        ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
        newUser = myUser.GetModel(int.Parse(this.lblUserId.Text));
        bool sendSms = false;
        if (newUser.State != 2 && this.rbtnAllow.SelectedValue=="2")
        {
            sendSms = true;
        }
        if(this.lblTel.Text!="")
        {
            newUser.Telephone = this.lblTel.Text;
        }
        if(this.lblName.Text!="")
        {
            newUser.Name = this.lblName.Text;
        }
        if(this.lblMobile.Text!="")
        {
            newUser.Mobile = this.lblMobile.Text;   
        }
        if(this.lblqq.Text!="")
        {
            newUser.QQ = this.lblqq.Text;
        }        
        newUser.State = int.Parse(this.rbtnAllow.SelectedValue);
        newUser.MaxSendNum = int.Parse(this.txtMaxCount.Text);
        newUser.Sign = txtSign.Text;
        newUser.SignLock = int.Parse(this.rbtnSign.SelectedValue);
        newUser.AwokeNum = int.Parse(this.txtAwokeNum.Text);
        myUser.Update(newUser);

        if (newUser.Mobile != ""&&sendSms)
        {
            Public.SendSystemSms(newUser.Mobile, "尊敬的商信宝用户，您的账户【"+newUser.Account+"】已经审核开通，欢迎您使用商信宝短信平台。地址：www.ecsms.cn");
        }

        Maticsoft.Common.MessageBox.ShowAndRedirect(this,"用户资料保存成功。",ResolveUrl( this.btnBack.PostBackUrl));
        
    }
    /// <summary>
    /// 重置密码
    /// </summary> 
    protected void btnRePwd_Click(object sender, EventArgs e)
    {
        ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
        ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
        newUser = myUser.GetModel(int.Parse(this.lblUserId.Text));
        string strNewPwd=System.Configuration.ConfigurationManager.AppSettings["repwd"].ToString();
        newUser.Pwd = strNewPwd;
        myUser.Update(newUser);

        Maticsoft.Common.MessageBox.Show(this.Page, "密码重置成功！新密码为【"+strNewPwd+"】");
    }


}
