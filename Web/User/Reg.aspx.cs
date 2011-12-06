using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_Reg : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["agree"] == null || Request.QueryString["agree"] == "" || Request.QueryString["agree"] != "yes")
            {
                Response.Redirect("login.aspx");
            }

            this.txtaccount.Attributes.Add("onblur", "CheckAccount()");
            this.txtpwd.Attributes.Add("onkeyup", "checkPassword()");
            this.txtpwd2.Attributes.Add("onkeyup", "checkRePassword()");    
        
            this.ddlProvince.Attributes.Add("onchange","BindCity()");

            this.txtemail.Attributes.Add("onblur", "CheckEmail()");
            this.txttelephone.Attributes.Add("onblur","CheckTelephone()");
            this.txtmobile.Attributes.Add("onblur","CheckMobile()");

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
        ECSMS.BLL.EC_Area area = new ECSMS.BLL.EC_Area();
        DataSet ds = area.GetList("parentid=" + this.ddlProvince.SelectedValue + "");
        Public.DropdownListBind(this.ddlCity, ds, "name", "id");
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string strErr = "";
        if (this.rbtnRole.SelectedValue == "")
        {
            strErr += "请选择注册用户类型！\\n";
        }
        if (this.txtaccount.Text == "")
        {
            strErr += "用户名不能为空！\\n";
        }
        else
        {
            if (Public.IsForbiddenWord(this.txtaccount.Text, "reg"))
            {
                Maticsoft.Common.MessageBox.Show(this, "对不起，此用户名属于敏感词，禁止注册。");
                return;
            } 

            ECSMS.BLL.EC_User user = new ECSMS.BLL.EC_User();
            DataSet ds = user.GetList("account='" + txtaccount.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string str = "系统中已经存在用户名:" + txtaccount.Text + "，请更换用户名。\\n";
                Maticsoft.Common.MessageBox.Show(this, str);
                return;
            }
        }
        if (this.txtpwd.Text == "" || txtpwd2.Text == "")
        {
            strErr += "密码不能为空！\\n";
        }
        else
        {
            string str = string.Empty;
            if (this.txtpwd.Text != this.txtpwd2.Text)
            {
                str += "两次输入密码不一致。\\n";
            }
            if (str != "")
            {
                Maticsoft.Common.MessageBox.Show(this, str);
                return;
            }
        } 
        if(this.txtCard.Text=="")
        {
            strErr += "请填写有效证件号！\\n";
        }
        if (this.txtname.Text == "")
        {
            strErr += "请填写真实姓名！\\n";
        }
        if (this.txtmobile.Text=="")
        {
            strErr += "请填写手机号码！\\n";
        }
        if (!this.txtemail.Text.Contains("@")&&this.txtemail.Text.Contains("."))
        {
            strErr += "请填写有效的邮箱地址！\\n";
        }


        if (strErr != "")
        {
            Maticsoft.Common.MessageBox.Show(this, strErr);
            return;
        }

        ECSMS.Model.EC_User model = new ECSMS.Model.EC_User();
        model.Account = this.txtaccount.Text;
        model.Pwd = this.txtpwd.Text;
        model.Name = this.txtname.Text;
        model.Sex = int.Parse(this.ddlsex.SelectedValue);
        model.Telephone = this.txttelephone.Text;
        model.Mobile = this.txtmobile.Text;
        model.Email = this.txtemail.Text;
        model.Fax = this.txtfax.Text;
        model.QQ = this.txtqq.Text;
        model.CertificateNumbers = this.txtCard.Text;
        model.CompanyName = this.txtcompanyname.Text;
        model.CompanyaCity = ddlProvince.SelectedItem.Text + "-" + ddlCity.SelectedItem.Text;
        model.CompanyAddress = this.txtcompanyaddress.Text;
        model.WebSite = this.txtwebsite.Text;
        model.PostCode = this.txtpostcode.Text;
        model.Role = int.Parse(this.rbtnRole.SelectedValue);
        model.MaxSendNum = Public.GetUserMaxCount();
        string strTrySmsType = string.Empty;
        foreach(ListItem item in this.cbTrySmsType.Items)
        {
            if (item.Selected)
            {
                strTrySmsType += item.Value+ ",";
            }
        }
        if (strTrySmsType != "")
        {
            model.TrySmsType = strTrySmsType.Substring(0, strTrySmsType.Length - 1);
        }
        foreach(ListItem item in this.cbRegFor.Items)
        {
            if (item.Selected)
            {
                model.RegFor += item.Text + ",";
            }
        }
        ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
        model.StartDate = DateTime.Now.ToString();
        bll.Add(model);
        this.btnAdd.Enabled = false;
        string strSmsAndMailContent = "感谢您注册成为商信宝短信平台用户！您的用户名是【" + model.Account + "】密码是【" + model.Pwd + "】，请登录【http://www.ecsms.cn】。";
        //Public.SendSystemSms(model.Mobile, strSmsAndMailContent);
        string strTitle = "感谢您注册成为商信宝用户，www.ecsms.cn请妥善保管好您的用户名和密码！";
        Public.MailSend(strTitle, strSmsAndMailContent, this.txtemail.Text);

        Maticsoft.Common.MessageBox.ShowAndRedirect(this,"注册成功！","login.aspx?account="+Server.UrlEncode( this.txtaccount.Text));
    }




}
