<%@ WebHandler Language="C#" Class="Reg" %>

using System;
using System.Web;
using System.Data;

public class Reg : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        if (context.Request.QueryString["account"] != null&&context.Request.QueryString["account"]!="")
        {
            string account =context.Request.QueryString["account"].ToString();
            ECSMS.BLL.EC_User user = new ECSMS.BLL.EC_User();
            DataSet ds = user.GetList("account='"+account+"'");
            int count = ds.Tables[0].Rows.Count;
            context.Response.ContentType = "text/plain";
            if (count > 0)
            {
                context.Response.Write("no");
            }
            else
            {
                context.Response.Write("ok");
            }
        }

        if (context.Request.QueryString["province"] != null && context.Request.QueryString["province"]!="")
        {
            string provinceid = context.Request.QueryString["province"].ToString();
            string returnstring = string.Empty;
            ECSMS.BLL.EC_Area area = new ECSMS.BLL.EC_Area();
            DataSet ds = area.GetList("parentid=" + provinceid + "");
            int count = ds.Tables[0].Rows.Count;
            if(count>0)
            {                
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    returnstring += row["id"] + "-" + row["name"] + "|";
                }
                returnstring = returnstring.Substring(0, returnstring.Length - 1);
                context.Response.Write(returnstring);
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}