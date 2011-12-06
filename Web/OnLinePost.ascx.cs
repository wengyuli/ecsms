using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OnLinePost : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["UserId"] != null && Session["UserId"] != "")
            {
                RegJS(int.Parse(Session["UserId"].ToString()));
            }
        }        
    }

    void RegJS(int id)
    {
        this.Page.RegisterStartupScript(
            "onload",
            "<script>window.onload=function(){setInterval('requestServer(" + id + ")',60000);}</script>");
    }
}