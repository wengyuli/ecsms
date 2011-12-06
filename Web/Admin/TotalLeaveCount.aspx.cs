using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_TotalLeaveCount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int role = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)));
            if (role != 0)
            {
                this.Page.Controls.Clear();
                Response.Write("您没有管理员的权限，拒绝访问。");
            }

            int adminId = 0;
            ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
            DataSet ds = myUser.GetList(" role=0 ");
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                adminId = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
            }

            string strSql = string.Empty;
            strSql = "    select sum(a.leavenum),convert(float,b.price),sum(a.leavenum)*convert(float,b.price) from ec_usersmsaccount a,EC_SmsType b where a.smstype=b.type and a.userid!=" + adminId + " and a.smstype='A' group by b.price "
            + " union all select sum(a.leavenum),convert(float,b.price),sum(a.leavenum)*convert(float,b.price) from ec_usersmsaccount a,EC_SmsType b where a.smstype=b.type and a.userid!=" + adminId + " and a.smstype='B' group by b.price "
            + " union all select sum(a.leavenum),convert(float,b.price),sum(a.leavenum)*convert(float,b.price) from ec_usersmsaccount a,EC_SmsType b where a.smstype=b.type and a.userid!=" + adminId + " and a.smstype='C' group by b.price "
            + " union all select sum(a.leavenum),convert(float,b.price),sum(a.leavenum)*convert(float,b.price) from ec_usersmsaccount a,EC_SmsType b where a.smstype=b.type and a.userid!=" + adminId + " and a.smstype='D' group by b.price "
            + " union all select sum(a.leavenum),convert(float,b.price),sum(a.leavenum)*convert(float,b.price) from ec_usersmsaccount a,EC_SmsType b where a.smstype=b.type and a.userid!=" + adminId + " and a.smstype='E' group by b.price ";

            ds = Maticsoft.DBUtility.DbHelperSQL.Query(strSql);
            count = ds.Tables[0].Rows.Count;
            if (count > 4)
            {
                this.lblA.Text = "【" + ds.Tables[0].Rows[0][0].ToString() + "】单价：" + ds.Tables[0].Rows[0][1].ToString() + "合计："+ ds.Tables[0].Rows[0][2].ToString() + "元";
                this.lblB.Text = "【" + ds.Tables[0].Rows[1][0].ToString() + "】单价：" + ds.Tables[0].Rows[1][1].ToString() + "合计：" + ds.Tables[0].Rows[1][2].ToString() + "元";
                this.lblC.Text = "【" + ds.Tables[0].Rows[2][0].ToString() + "】单价：" + ds.Tables[0].Rows[2][1].ToString() + "合计：" + ds.Tables[0].Rows[2][2].ToString() + "元";
                this.lblD.Text = "【" + ds.Tables[0].Rows[3][0].ToString() + "】单价：" + ds.Tables[0].Rows[3][1].ToString() + "合计：" + ds.Tables[0].Rows[3][2].ToString() + "元";
                this.lblE.Text = "【" + ds.Tables[0].Rows[4][0].ToString() + "】单价：" + ds.Tables[0].Rows[4][1].ToString() + "合计：" + ds.Tables[0].Rows[4][2].ToString() + "元";
            }

            this.lblALeave.Text = this.GetInfoByType("A");
            this.lblBLeave.Text = this.GetInfoByType("B");
            this.lblCLeave.Text = this.GetInfoByType("C");
            this.lblDLeave.Text = this.GetInfoByType("D");
            this.lblELeave.Text = this.GetInfoByType("E");         
        }
    }
    string GetInfoByType(string type)
    {
        string strSql = "select count(*) from sendmsgtable where msgtype='" + type + "' and ( msgstatus=" + (int)ECSMS.Channel.SmsStatus.等待发送 + " or msgstatus=" + (int)ECSMS.Channel.SmsStatus.待发状态 + " ) "
                + " union all select count(*) from sendmsgtable where msgtype='" + type + "' and msgstatus="+(int)ECSMS.Channel.SmsStatus.发送成功+"";
        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(strSql);
        int count=0;
        count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            return "提交待发【" + ds.Tables[0].Rows[0][0].ToString() + "】，已发【" + (int.Parse(ds.Tables[0].Rows[1][0].ToString()) - int.Parse(ds.Tables[0].Rows[0][0].ToString())) + "】";
        }
        else
        {
            return "";
        }
    }

}
