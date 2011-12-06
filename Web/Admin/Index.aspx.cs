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
            int role = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)));
            if (role != 0)
            {
                this.Page.Controls.Clear();
                Response.Write("您不具备管理员权限。");
            }
        }
    }
    protected void lbtnQuit_Click(object sender, EventArgs e)
    {
        Session["UserId"] = null;
        Response.Redirect("../Admin/1-2-4-5/6-;-7/Login.aspx");
    }

}
