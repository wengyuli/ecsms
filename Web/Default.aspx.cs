using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ssl"] != null && Request.QueryString["ssl"] != "")
        {
            if(Request.QueryString["ssl"]!="ecsms2010")
            {
                Response.Redirect("user/login.aspx");
            }
        }
        else
        {
            Response.Redirect("user/login.aspx");
        }

        
        //添加

        //ECSMS.BLL.EC_User user = new ECSMS.BLL.EC_User();
        //ECSMS.Model.EC_User newuser = new ECSMS.Model.EC_User();
        //newuser.account = "wengyuli";
        //newuser.companyacity = "河南-郑州";
        //newuser.companyaddress = "金水区";
        //newuser.companyname = "大方软件";
        //newuser.email = "wengyuli@gmail.com";
        //newuser.fax = "0371-64738948";
        //newuser.groupid = 1;
        //newuser.mobile = "13629843286";
        //newuser.msn = "wengyuli@hotmail.com";
        //newuser.name = "翁玉礼";
        //newuser.operater = 2;
        //newuser.postcode = "450000";
        //newuser.pwd = "111111";
        //newuser.qq = "191349433";
        //newuser.role = 0;
        //newuser.sex = "0";
        //newuser.telephone = "0371-64738948";
        //newuser.website = "http://www.google.com";
        //user.Add(newuser);


        //更新

        //newuser = user.GetModel(2);
        //newuser.account = "xiejianjun";
        //user.Update(newuser);


        //删除
        //user.Delete(1);

        //测试DBUtility
        //System.Data.DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("select * from ec_user");
        //Response.Write(ds.Tables[0].Rows.Count.ToString());


       
    }
 
}
