using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class AgentAdd :PageBase
{ 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int role = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)));
            if (role == 3 || role == 2)
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "对不起，您没有添加代理的权限", "login.aspx");
                return;
            }
 
            if (Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0)
            {
                this.btnBack.PostBackUrl = ResolveUrl("~/admin/users.aspx?type=agent");
            }
            else
            {
                this.btnBack.PostBackUrl = ResolveUrl("~/usermanage.aspx?type=agent");
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.txtAccount.Text != "" && this.txtPwd1.Text != "" && this.txtPwd2.Text != "")
        {
            if (Public.IsForbiddenWord(this.txtAccount.Text, "reg"))
            {
                Maticsoft.Common.MessageBox.Show(this, "对不起，此用户名属于敏感词，禁止注册。");
                return;
            }

            if(this.txtPwd1.Text!=this.txtPwd2.Text)
            {
                Maticsoft.Common.MessageBox.Show(this, "两次输入密码不一致！");
                return;
            }
            ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
            ECSMS.Model.EC_User model = new ECSMS.Model.EC_User();
            DataSet ds = bll.GetList(" account='"+this.txtAccount.Text+"' ");
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                Maticsoft.Common.MessageBox.Show(this,"对不起，该账号已存在。");
                return;
            }
            if (TextBox1.Text == "")
            {
                Maticsoft.Common.MessageBox.Show(this,"请输入有效证件号码");
                return;
            }
            model.Account = this.txtAccount.Text;
            model.Pwd = this.txtPwd2.Text;
            model.CompanyName = this.txtCompanyName.Text;
            model.Name = this.txtName.Text;
            model.Role = 1;
            model.MaxSendNum = Public.GetUserMaxCount();//单次发送上限
            model.CompanyaCity = this.ddlProvince.SelectedItem.Text +"-"+ this.ddlCity.SelectedItem.Text;
            model.CertificateType = this.DropDownList1.SelectedValue;
            model.CertificateNumbers = this.TextBox1.Text;
            model.UserId = int.Parse(Public.GetUserId(this.Page));
            model.State = 2;
            model.Sign = this.txtSign.Text;
            model.Operater = int.Parse(Public.GetUserId(this.Page));
            model.Mobile = txtMobile.Text;
            model.Telephone = txtTel.Text;
            model.StartDate = DateTime.Now.ToString();
            bll.Add(model);           

            Maticsoft.Common.MessageBox.ShowAndRedirect(this,"代理添加成功！",this.btnBack.PostBackUrl);
            
        }
        else 
        {
            Maticsoft.Common.MessageBox.Show(this,"用户名、密码不能为空！");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Server.Transfer( this.btnBack.PostBackUrl);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.txtAccount.Text != "")
        {

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
                this.lblShow.Text = "对不起，此用户名已经被注册。";
            }
            else
            {
                this.lblShow.Text = "恭喜您，这个用户名可以注册。";
            }
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this, "请输入用户名后再进行检验。");
        }
    }
}
