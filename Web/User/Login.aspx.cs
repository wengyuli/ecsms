using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Agent_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["account"] != null && Request.QueryString["account"] != "")
            {
                this.iptUser.Value = Server.UrlDecode( Request.QueryString["account"].ToString());
            }
        }
    }
    
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string strUserName = this.iptUser.Value.Trim();
        string strPwd = this.iptPwd.Value.Trim();
        if (strUserName == "" || strPwd == "")
        {
            Maticsoft.Common.MessageBox.Show(this,"请输入用户名和密码。");
            return;
        }
        if (this.txtCode.Text.ToLower() != Session["CheckCode"].ToString().ToLower())
        {
            Maticsoft.Common.MessageBox.Show(this, "验证码输入错误。");
            return;
        }
        ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
        DataSet ds = myUser.GetList("Account='" + strUserName + "' and pwd='" + strPwd + "' and role="+this.ddlRole.SelectedValue+"");
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            Response.Cookies["UserId"].Value = ds.Tables[0].Rows[0]["id"].ToString();
            Response.Cookies["UserId"].Expires = DateTime.Now.AddHours(1);

            Session["UserId"] = ds.Tables[0].Rows[0]["id"].ToString();

            ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
            newUser = myUser.GetModel(int.Parse(Session["UserId"].ToString()));
            newUser.OnLine = 1;
            myUser.Update(newUser);

            Response.Redirect("index.aspx");
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this, "对不起您的用户名或密码错误！请重新输入");
        }
    }


}
