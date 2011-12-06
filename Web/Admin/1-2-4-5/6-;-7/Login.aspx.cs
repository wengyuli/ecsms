using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string strUserName = this.username.Value.Trim();
        string strPwd = this.password.Value.Trim();
        strUserName = strUserName.Replace(" ", "");
        strPwd = strPwd.Replace(" ", "");
        ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
        DataSet ds = myUser.GetList("Account='" + strUserName + "' and pwd='" + strPwd + "' and role=0");
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            Response.Cookies["UserId"].Value = ds.Tables[0].Rows[0]["id"].ToString();
            Response.Cookies["UserId"].Expires = DateTime.Now.AddHours(1);
            Session["UserId"] = ds.Tables[0].Rows[0]["id"].ToString();
            Response.Redirect(ResolveUrl("~/admin/index.aspx"));
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this, "对不起您的用户名或密码错误！请重新输入");
        }
    }
}
