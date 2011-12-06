using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_RegForbidWord : System.Web.UI.Page
{
    ECSMS.BLL.EC_ForbidWord bll = new ECSMS.BLL.EC_ForbidWord();
    ECSMS.Model.EC_ForbidWord model = new ECSMS.Model.EC_ForbidWord();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            int role = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)));
            if (role != 0)
            {
                this.Page.Controls.Clear();
                Response.Write("您没有管理员的权限，拒绝访问。");
            }

            DataSet ds = bll.GetList(" channelcode='reg' ");
            int count = ds.Tables[0].Rows.Count;
            if(count>0)
            {
                System.Text.StringBuilder strBuilder = new System.Text.StringBuilder("");
                foreach(DataRow row in ds.Tables[0].Rows)
                {
                    strBuilder.Append(row["name"].ToString()+"#");
                }
                this.txtKeys.Text = strBuilder.ToString();
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(" delete EC_ForbidWord where channelcode='reg' ");

        string[] strKeys = this.txtKeys.Text.Split('#');
        model.ChannelCode = "reg";
        foreach(string str in strKeys)
        {
            model.Name = str;
            bll.Add(model);
        }
        Maticsoft.Common.MessageBox.Show(this,"更新成功！");
    }
}
