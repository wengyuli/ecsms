using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Right :System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Write(DateTime.Now.ToUniversalTime().ToString("yyyyMMdd hhmmss ffff"));
        //Public.MailSend("主题", "内容", "wengyuli@126.com");

        //ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
        //Response.Write(((ECSMS.Model.EC_User) bll.GetModel(17)).Name);

        //Response.Cookies["UserId"].Value = "399";
        //Response.Cookies["UserId"].Expires = DateTime.Now.AddHours(1);

        //Response.Write(Request.Cookies["User"].Value);

        //Response.Write( Public.GetUserId(this.Page));
        //string str="";
        //string[] a = str.Split(',');
        //Response.Write("值:【"+a[0]+"】");
        //Response.Write( Public.NumberClearWrong("13629843286,13623810256,34,87,89,87"));
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
