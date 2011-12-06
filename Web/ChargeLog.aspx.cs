using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class ChargeLog :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        { 
            //本页面是消费记录，供代理、集团用户、用户使用
            this.txtStartDate.Text = DateTime.Now.AddHours(-24).ToString();
            this.txtEndDate.Text = DateTime.Now.ToString();
            BindSms();
        }
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        BindSms();
    }

    protected void BindSms()
    {
        try
        {
            ECSMS.BLL.EC_SmsAssignLog bll = new ECSMS.BLL.EC_SmsAssignLog();
            string strSql = string.Empty;
            strSql = "select a.acttype,a.smscount,a.smstype,a.opertime,a.remark,b.account,a.fromuserid from ec_smsassignlog a,ec_user b "
        + " where a.touserid=b.id and a.OperTime>'" + Convert.ToDateTime(txtStartDate.Text).ToString("yyyy/MM/dd HH:mm:ss") + "' and a.OperTime<'" + Convert.ToDateTime(this.txtEndDate.Text).ToString("yyyy/MM/dd HH:mm:ss") + "' and a.touserid=" + Public.GetUserId(this.Page) + " order by a.OperTime desc";

            DataSet dsList = Maticsoft.DBUtility.DbHelperSQL.Query(strSql);
            int count = dsList.Tables[0].Rows.Count;
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
        PagedDataSource pds = new PagedDataSource();
        pds.DataSource = dst.Tables[0].DefaultView;
        pds.AllowPaging = true;

        anp.RecordCount = dst.Tables[0].DefaultView.Count;
        pds.CurrentPageIndex = anp.CurrentPageIndex - 1;
        pds.PageSize = anp.PageSize;

        dl.DataSource = pds;
        dl.DataBind();
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        BindSms();
    }


    protected void btnExport_Click(object sender, EventArgs e)
    {
        string strSql = string.Empty;
        strSql = "select a.acttype,a.smscount,a.smstype,a.opertime,a.remark,b.account,a.fromuserid from ec_smsassignlog a,ec_user b "
    + " where a.touserid=b.id and a.OperTime>'" + txtStartDate.Text + "' and a.OperTime<'" + txtEndDate.Text + "' and a.touserid=" + Public.GetUserId(this.Page) + " order by a.OperTime desc";
        DataSet dsList = Maticsoft.DBUtility.DbHelperSQL.Query(strSql);
        int count = dsList.Tables[0].Rows.Count;
        if (count > 0)
        {
            StringBuilder strData = new StringBuilder();
            strData.Append("账号,");
            strData.Append("短信类型,");
            strData.Append("操作类型,");
            strData.Append("增减条数,");
            strData.Append("分配人,");
            strData.Append("充值时间");
            strData.Append("\n");
            string strIsZero = string.Empty;
            foreach (DataRow row in dsList.Tables[0].Rows)
            {
                strData.Append(row["account"].ToString()+",");
                strData.Append(Public.GetProNameByLetter( row["smstype"].ToString())+",");
                strData.Append(row["acttype"].ToString()=="add"?"充值,":"扣值,");
                strData.Append(row["smscount"].ToString() + ",");
                strData.Append(Public.GetUserName(int.Parse(row["fromuserid"].ToString())) + ",");
                strData.Append(row["opertime"].ToString());
                strData.Append("\n");
            }

            string strTemp = string.Format("attachment;filename={0}", Server.UrlEncode("" + Convert.ToDateTime(this.txtStartDate.Text.ToString()).ToString("yyyyMMdd") + "-" + Convert.ToDateTime(this.txtStartDate.Text.ToString()).ToString("yyyyMMdd") + "充值记录.csv"));
            Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            Response.ClearHeaders();
            Response.AppendHeader("Content-disposition", strTemp);
            Response.Write(strData);
            Response.End();    
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this,"在您的查询范围内暂无充值记录可供导出。");
        }
    }




}
