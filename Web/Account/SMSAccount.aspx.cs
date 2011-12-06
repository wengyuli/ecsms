using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AccountSMS : PageBase
{
    ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
    ECSMS.Model.EC_User model = new ECSMS.Model.EC_User();

    protected void Page_Load(object sender, EventArgs e)
    {
            this.lblUserId.Text = Public.GetUserId(this.Page);
            
            model = bll.GetModel(int.Parse(this.lblUserId.Text));
            this.lblName.Text = model.Name;
            this.lblAccount.Text = model.Account;
            this.lblCompanyName.Text = model.CompanyName;
            this.lblUpAccount.Text = Public.GetUserAccount(model.UserId.Value);
            BindBalance();

            if (Public.GetUserRole(int.Parse(this.lblUserId.Text))==0)
            {
                this.userAccountTable.Visible = false;
                this.divtotalleave.Visible = true;
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
                    this.lblA.Text = "【" + ds.Tables[0].Rows[0][0].ToString() + "】单价：" + ds.Tables[0].Rows[0][1].ToString() + "合计：" + ds.Tables[0].Rows[0][2].ToString() + "元";
                    this.lblB.Text = "【" + ds.Tables[0].Rows[1][0].ToString() + "】单价：" + ds.Tables[0].Rows[1][1].ToString() + "合计：" + ds.Tables[0].Rows[1][2].ToString() + "元";
                    this.lblC.Text = "【" + ds.Tables[0].Rows[2][0].ToString() + "】单价：" + ds.Tables[0].Rows[2][1].ToString() + "合计：" + ds.Tables[0].Rows[2][2].ToString() + "元";
                    this.lblD.Text = "【" + ds.Tables[0].Rows[3][0].ToString() + "】单价：" + ds.Tables[0].Rows[3][1].ToString() + "合计：" + ds.Tables[0].Rows[3][2].ToString() + "元";
                    this.lblE.Text = "【" + ds.Tables[0].Rows[4][0].ToString() + "】单价：" + ds.Tables[0].Rows[4][1].ToString() + "合计：" + ds.Tables[0].Rows[4][2].ToString() + "元";
                }


                this.divShowWait.Visible = true;
                this.divNews.Visible = false;
                #region 在线用户
                ds = bll.GetList(" online=1 ");
                count = 0;
                count = ds.Tables[0].Rows.Count;
                if(count>0)
                {
                    int userCount=0;
                    int agentCount=0;
                    int cuserCount=0;
                    foreach(DataRow row in ds.Tables[0].Rows)
                    {
                        if (row["role"].ToString() == "1")
                        {
                            agentCount += 1;
                        }
                        if (row["role"].ToString() == "2")
                        {
                            cuserCount += 1;
                        }
                        if (row["role"].ToString() == "3")
                        {
                            userCount += 1;
                        }
                    }
                    this.lblOnlineAgent.Text = agentCount.ToString();
                    this.lblOnlineCUser.Text = cuserCount.ToString();
                    this.lblOnlineUser.Text = userCount.ToString();
                    
                }
                #endregion

                #region 待办事项
                
                //已提交短信
                object obj = Maticsoft.DBUtility.DbHelperSQL.GetSingle(" select count( distinct ServerID ) from sendmsgtable where MsgStatus = " + (int)ECSMS.Channel.SmsStatus.等待发送 + " or MsgStatus = " + (int)ECSMS.Channel.SmsStatus.待发状态 + " ");
                if (obj != null)
                {
                    this.lblWaitSmsCount.Text = obj.ToString();
                }
                
                //待审核客户
                ECSMS.BLL.SendMsgTable mySend = new ECSMS.BLL.SendMsgTable();
                ds = bll.GetList(" state=0 and role!=0 and role!=1");
                count = ds.Tables[0].Rows.Count;
                this.lblWaitUserCount.Text = count.ToString();
                #endregion
            }
    }

    #region 查询余额
    /// <summary>
    /// 查询余额
    /// </summary>
    protected void BindBalance()
    {
        ECSMS.BLL.EC_UserSmsAccount myAccount = new ECSMS.BLL.EC_UserSmsAccount();
        DataSet dsAccount = myAccount.GetList("userid=" + this.lblUserId.Text + "");
        int count = dsAccount.Tables[0].Rows.Count;
        if (count > 0)
        {
            bool IsAdmin = true;
            if (Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0)
            {
                IsAdmin = true;
            }
            else
            {
                IsAdmin = false;
            }
            foreach (DataRow row in dsAccount.Tables[0].Rows)
            {
                switch (row["smstype"].ToString())
                {
                    case "A":
                        this.lblABalance.Text = "【"+row["LeaveNum"].ToString()+"】";
                        if (IsAdmin)
                        {
                            this.lblABalance.Text += "  余额:【" + (int.Parse(row["LeaveNum"].ToString()) * double.Parse(GetProPrice("A"))).ToString() + "】元";
                        }
                        break;
                    case "B":
                        this.lblBBalance.Text = "【" + row["LeaveNum"].ToString() + "】";
                        if (IsAdmin)
                        {
                            this.lblBBalance.Text += "  余额:【" + (int.Parse(row["LeaveNum"].ToString()) * double.Parse(GetProPrice("B"))).ToString() + "】元";
                        }
                        break;
                    case "C":
                        this.lblCBalance.Text = "【" + row["LeaveNum"].ToString() + "】";
                        if (IsAdmin)
                        {
                            this.lblCBalance.Text += "  余额:【" + (int.Parse(row["LeaveNum"].ToString()) * double.Parse(GetProPrice("C"))).ToString() + "】元";
                        }
                        break;
                    case "D":
                        this.lblDBalance.Text = "【" + row["LeaveNum"].ToString() + "】";
                        if (IsAdmin)
                        {
                            this.lblDBalance.Text += "  余额:【" + (int.Parse(row["LeaveNum"].ToString()) * double.Parse(GetProPrice("D"))).ToString() + "】元";
                        }
                        break;
                    case "E":
                        this.lblEBalance.Text = "【" + row["LeaveNum"].ToString() + "】";
                        if (IsAdmin)
                        {
                            this.lblEBalance.Text += "  余额:【" + (int.Parse(row["LeaveNum"].ToString()) * double.Parse(GetProPrice("E"))).ToString() + "】元";
                        }
                        break;
                }
            }
        }
    }
    #endregion

    #region 返回指定产品的价格
    protected string GetProPrice(string ProductCode)
    {
        ECSMS.BLL.EC_SmsType myType = new ECSMS.BLL.EC_SmsType();
        ECSMS.Model.EC_SmsType newType = new ECSMS.Model.EC_SmsType();
        newType = myType.GetModel(ProductCode);

        return newType.Price;
    }
    #endregion


}
