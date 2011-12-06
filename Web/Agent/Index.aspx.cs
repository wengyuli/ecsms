using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Index :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Public.GetUserId(this.Page) != "0")
            {
                int role = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)));
                if (role != 1 )
                {
                    this.Page.Controls.Clear();
                    Response.Write("您不具备代理权限。");
                }
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "请通过正常途径登录。", ResolveUrl("~/default.aspx"));
                return;
            }
        }
    }
    protected void btnQuit_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Redirect("../agent/login.aspx");
    }


}
