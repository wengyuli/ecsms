using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Broadcast : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ECSMS.BLL.EC_Broadcast bll = new ECSMS.BLL.EC_Broadcast();
            DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query("  Select * from ec_broadcast order by posttime desc ");
            int count = 0;
            count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
                {
                    this.div1.InnerHtml += "<a id=a" + i + " onclick='openBroad(content" + i + ")' href='#'>["+ (i + 1) +"] " + ds.Tables[0].Rows[i]["title"].ToString() + "</a><br><br>";
                    this.div1.InnerHtml += "<span id='content" + i + "'>&nbsp;&nbsp;&nbsp;&nbsp;" + ds.Tables[0].Rows[i]["content"].ToString() + "</span><br><br>";
                }
            }
            else
            {
                this.div1.InnerHtml = "暂无公告。";
            }
        }
    }
    
}
