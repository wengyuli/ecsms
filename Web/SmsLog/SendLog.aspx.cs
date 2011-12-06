using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class SendLog :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["type"] != null && Request.QueryString["type"] == "all")
            {
                if (Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) != 0)
                {
                    this.Page.Controls.Clear();
                    Response.Write("您没有权限，拒绝访问。");
                }
            }
            this.txtStartDate.Text = DateTime.Now.AddHours(-24).ToString();
            this.txtEndDate.Text = DateTime.Now.ToString();
            if(Request.QueryString["type"]!=null&&Request.QueryString["type"]!="")
            {
                this.lbltype.Text = Request.QueryString["type"].ToString();
                if (Request.QueryString["type"] == "all" || Request.QueryString["type"] == "myuser")
                {
                    this.lblShow.Text = "发送记录";
                }
                else
                {
                    this.lblShow.Text = "您在【" + Public.GetProNameByLetter(this.lbltype.Text) + "】的发送记录";                
                }
                
            }
            BindSms();

        }
    }
    protected void BindSms()
    {
        try
        {
            string strSql=string.Empty;
            string strUserId = Public.GetUserId(this.Page);
            
            switch(this.lbltype.Text)
            {
                case "all"://管理员查看所有发送记录
                    strSql = " msgstatus!=0 and msgstatus!=2 and msgstatus!=5 ";
                    this.lblShow.Text = "发送记录：";                     
                    this.txtContentKey.ToolTip = "可针对内容，用户名，编号进行查询";
                    this.lblKeyWords.Text = "帐号：";
                    this.lblPhoneKey.Text = "产品类型：";
                    this.lblDelPwd.Visible = true;
                    this.txtDelPwd.Visible = true;
                    break;
                case "myuser":
                    strSql = " userid in (select id from ec_user where userid="+strUserId+") ";
                    this.lblShow.Text = "发送记录：";this.txtContentKey.ToolTip = "可针对帐号进行查询";
                    this.lblKeyWords.Text = "帐号：";                    
                    this.lblPhoneKey.Text = "产品类型：";
                    break;
                default:
                    strSql = "  msgtype='"+this.lbltype.Text+"' and userid=" + strUserId + " ";
                    break;
            }            
            if (this.txtStartDate.Text != "" && this.txtEndDate.Text != "")
            {
                strSql += " and sendtime>='" + Convert.ToDateTime(this.txtStartDate.Text).ToString("yyyy/MM/dd HH:mm:ss") + "' and sendtime <='" + Convert.ToDateTime(this.txtEndDate.Text).ToString("yyyy/MM/dd HH:mm:ss") + "' ";
            }
            DataSet dsList = Maticsoft.DBUtility.DbHelperSQL.Query(" select serverid,sendnum*numberscount as totalsmscount from sendmsgtable where " + strSql + " group by serverid,sendnum,numberscount ");
            int count = dsList.Tables[0].Rows.Count;
            if (count > 0)
            {
                int smsCount = 0;
                foreach (DataRow row in dsList.Tables[0].Rows)
                {
                    smsCount += int.Parse(row["totalsmscount"].ToString());
                }
                this.lblTotalSmsCount.Text = ",共计发出【" + smsCount + "】条";
            }
            if (this.txtContentKey.Text != "")
            { 
                string strTempId = Maticsoft.DBUtility.DbHelperSQL.GetSingle(" select top 1 id from ec_user where account like '%" + this.txtContentKey.Text + "%' ").ToString();
                if (strTempId != null) 
                {
                    strSql += " and (msgtitle like '%" + this.txtContentKey.Text + "%' or serverid like '%" + this.txtContentKey.Text + "%' or userid=" + strTempId + " )  "; 
                }
            }
            if (this.txtPhoneKey.Text != "")
            {
                if (this.lbltype.Text == "all" || this.lbltype.Text == "myuser")
                {
                    string msgtype = new ECSMS.BLL.EC_SmsType().GetModel(this.txtPhoneKey.Text).Name;
                    strSql += " and (msgtype like '%" + msgtype + "%'  )";
                }
                else
                {
                    strSql += " and PhoneNumber like '%" + this.txtPhoneKey.Text + "%' ";
                }                
            }
            string strAll = "select  distinct top 2000 serverid,msgtitle,msgstatus,timesend,msgtype,sendnum,exernumbers,numberscount,userid,senttime,sendtime from sendmsgtable where " + strSql + "  order by sendtime desc";
            dsList = Maticsoft.DBUtility.DbHelperSQL.Query(strAll);
            count = dsList.Tables[0].Rows.Count;
            this.lblCount.Text = count.ToString();
            if (count >= 0)
            {
                Pager(DataList1, AspNetPager1, dsList);
            }
        }
        catch (Exception ex)
        {

        }
    }

    protected void Pager(DataList dl, Wuqi.Webdiyer.AspNetPager anp, System.Data.DataSet dst)
    {
        try
        {
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = dst.Tables[0].DefaultView;
            pds.AllowPaging = true;

            anp.RecordCount = dst.Tables[0].DefaultView.Count;
            pds.CurrentPageIndex = anp.CurrentPageIndex - 1;
            pds.PageSize = anp.PageSize;

            dl.DataSource = pds;
            dl.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        try
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindSms();
        }
        catch (Exception ex)
        {

        }
    }
 
    
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        System.Web.UI.HtmlControls.HtmlAnchor anchor = ((System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("aoperate")));
        if (anchor != null)
        {
            if (this.lbltype.Text == "myuser")
            {
                anchor.Visible = false;
            }
            else
            {
                anchor.Visible = true;
            }
        }
        System.Web.UI.WebControls.LinkButton lbtn = (System.Web.UI.WebControls.LinkButton)(e.Item.FindControl("lbtnDel"));
        if (lbtn != null)
        {
            if (this.lbltype.Text == "all")
            {
                lbtn.Visible = true;
            }
            else
            {
                lbtn.Visible = false;
            }
        } 
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    { 
        BindSms();
    }

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            if (this.txtDelPwd.Text == "")
            {
                Maticsoft.Common.MessageBox.Show(this, "请输入删除密码。");
                return;
            }
            ECSMS.BLL.EC_Config myConfig = new ECSMS.BLL.EC_Config();
            DataSet ds = myConfig.GetList(" DelPwd='" + this.txtDelPwd.Text + "' ");
            int count = ds.Tables[0].Rows.Count;
            if (count == 0)
            {
                Maticsoft.Common.MessageBox.Show(this, "删除密码输入错误。");
                return;
            }
            string strSql = " delete sendmsgtable where serverid= "+e.CommandArgument.ToString();
            Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(strSql);
            Maticsoft.Common.MessageBox.Show(this.Page,"本条记录已经成功删除！");
            BindSms();
        }
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        string strSql = string.Empty;
        string strUserId = Public.GetUserId(this.Page);
        switch (this.lbltype.Text)
        { 
            case "all"://管理员查看所有发送记录
                strSql = " msgstatus!=0 and msgstatus!=2 ";
                break;
            case "myuser":
                strSql = " userid in (select id from ec_user where userid=" + strUserId + ") "; 
                break;
            default:
                strSql = "  msgtype='"+this.lbltype.Text+"' and userid=" + strUserId + " ";
                break;
        }
        if (this.txtStartDate.Text != "" && this.txtEndDate.Text != "")
        {
            strSql += " and sendtime>='" + DateTime.Parse(this.txtStartDate.Text).ToString("yyyy-MM-dd HH:mm:ss") + "' and sendtime <='" + DateTime.Parse(this.txtEndDate.Text).ToString("yyyy-MM-dd HH:mm:ss") + "' ";
        }
        if (this.txtContentKey.Text != "")
        {
            string strTempId = Maticsoft.DBUtility.DbHelperSQL.GetSingle(" select top 1 id from ec_user where account like '%" + this.txtContentKey.Text + "%' ").ToString();
            if (strTempId != null)
            {
                strSql += " and (msgtitle like '%" + this.txtContentKey.Text + "%' or serverid like '%" + this.txtContentKey.Text + "%' or userid=" + strTempId + " )  ";
            }
        }
        if (this.txtPhoneKey.Text != "")
        {
            if (this.lbltype.Text == "all" || this.lbltype.Text == "myuser")
            {
                string msgtype = new ECSMS.BLL.EC_SmsType().GetModel(this.txtPhoneKey.Text).Name;
                strSql += " and (msgtype like '%" + msgtype + "%' )";
            }
            else
            {
                strSql += " and PhoneNumber like '%" + this.txtPhoneKey.Text + "%' ";
            }
        }
        string strAll = "select distinct serverid ,msgtitle,exernumbers,sendnum ,numberscount,sendtime,userid,msgtype,msgstatus  from sendmsgtable where " + strSql + "  order by sendtime desc";
        DataSet dsList = Maticsoft.DBUtility.DbHelperSQL.Query(strAll);
        int count = dsList.Tables[0].Rows.Count;
        if(count>0)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            str.Append("任务编号,");
            str.Append("帐号,");
            str.Append("产品类型,");
            str.Append("短信内容,");
            str.Append("发送状态,");
            str.Append("拆分条数,");
            str.Append("号码数量,");
            str.Append("体验数量,");
            str.Append("提交时间\n");
            foreach(DataRow row in dsList.Tables[0].Rows)
            {
                str.Append("'"+row["serverid"].ToString()+",");
                str.Append(Public.GetUserAccount(int.Parse(row["userid"].ToString()))+",");
                str.Append(new ECSMS.BLL.EC_SmsType().GetModel(row["msgtype"].ToString()).Name+",");
                row["msgtitle"] = row["msgtitle"].ToString().Replace(",", ".");
                str.Append(row["msgtitle"].ToString() + ",");
                str.Append((ECSMS.Channel.SmsStatus)Convert.ToInt32(row["msgstatus"])+",");
                str.Append(row["sendnum"].ToString() + ",");
                str.Append(row["numberscount"].ToString() + ",");
                str.Append(row["exernumbers"].ToString()+",");
                str.Append(row["sendtime"].ToString() + ",");
                str.Append("\n");
            }
            Public.ExportFiles(this.Page, str, "发送记录.csv", "application/ms-excel");
        }
    }
}
