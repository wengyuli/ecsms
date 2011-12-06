using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SetOnLine : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["id"]!=null&&Request.QueryString["id"]!="")
        {
            string id = Request.QueryString["id"].ToString();
            var user = new ECSMS.BLL.EC_User().GetModel(int.Parse(id));
            user.LastUpdateTime = DateTime.Now;
            user.OnLine = 1;
            new ECSMS.BLL.EC_User().Update(user);
        }
    }
}