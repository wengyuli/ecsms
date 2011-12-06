using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FindPwd :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Public.GetUserId(this.Page) != "0")
            {
                this.lblUserId.Text = Public.GetUserId(this.Page);
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
        ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
        newUser = myUser.GetModel(int.Parse(Public.GetUserId(this.Page)));
        Public.SendSystemSms(newUser.Mobile, "您的商信宝登录账户：【"+newUser.Account+"】;密码：【"+newUser.Pwd+"】");
    }
}
