using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class GiveLog :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {  
            this.txtStartDate.Text = DateTime.Now.AddHours(-24).ToString();
            this.txtEndDate.Text = DateTime.Now.ToString();
            BindSms();
        }
    }
    protected void BindSms()
    {
        try
        {
            ECSMS.BLL.EC_SmsAssignLog bll = new ECSMS.BLL.EC_SmsAssignLog();
            string strSql = string.Empty;
            string strName = string.Empty;

            string strAdmin = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0 ? "" : " and a.fromuserid=" + Public.GetUserId(this.Page) + " ";
            strName = this.txtName.Text == "" ? "" : " ( b.account like '%" + txtName.Text + "%' or b.name like '%" + txtName.Text + "%') and ";
            
            strSql = "select distinct a.id,a.acttype,a.smscount,a.smstype,a.opertime,a.leavenum,a.remark,b.account,a.fromuserid from ec_smsassignlog a,ec_user b "
        + " where " + strName + " a.touserid=b.id " + strAdmin + " and a.OperTime>'" + Convert.ToDateTime(txtStartDate.Text).ToString("yyyy/MM/dd HH:mm:ss") + "' and a.OperTime<'" + Convert.ToDateTime(txtEndDate.Text).ToString("yyyy/MM/dd HH:mm:ss") + "'  order by OperTime desc";
            
            DataSet dsList = Maticsoft.DBUtility.DbHelperSQL.Query(strSql); 
            int count = dsList.Tables[0].Rows.Count;
            if (count >= 0)
            {
                this.lblCount.Text = count.ToString();
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
        string strName = string.Empty;

        string strAdmin = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0 ? "" : " and a.fromuserid=" + Public.GetUserId(this.Page) + " ";
        strName = this.txtName.Text == "" ? "" : " ( b.account like '%" + txtName.Text + "%' or b.name like '%" + txtName.Text + "%') and ";

        strSql = "select distinct a.id,a.acttype,a.smscount,a.smstype,a.opertime,a.leavenum,a.remark,b.account,a.fromuserid from ec_smsassignlog a,ec_user b "
    + " where " + strName + " a.touserid=b.id " + strAdmin + " and a.OperTime>'" + txtStartDate.Text + "' and a.OperTime<'" + txtEndDate.Text + "'  order by OperTime desc";

        DataSet dsList = Maticsoft.DBUtility.DbHelperSQL.Query(strSql); 
        int count = dsList.Tables[0].Rows.Count;
        if (count > 0)
        {
            System.Text.StringBuilder strBuider = new System.Text.StringBuilder();      
            strBuider.Append("帐号,");
            strBuider.Append("短信类型,");
            strBuider.Append("操作类型,");
            strBuider.Append("增减条数,");
            strBuider.Append("分后余额,");
            strBuider.Append("充值备注,");
            strBuider.Append("分配人,");
            strBuider.Append("时间\n");
            foreach(DataRow row in dsList.Tables[0].Rows)
            {
                
                strBuider.Append(row["account"].ToString()+",");
                strBuider.Append(Public.GetProNameByLetter( row["smstype"].ToString())+",");
                strBuider.Append(row["acttype"].ToString() == "add" ? "增加" + "," : "减少" + ",");
                
                strBuider.Append(row["smscount"].ToString()+",");
                strBuider.Append(row["leavenum"].ToString()+",");
                strBuider.Append(row["remark"].ToString()+",");
                strBuider.Append(Public.GetUserAccount(int.Parse( row["fromuserid"].ToString()))+",");
                strBuider.Append(row["opertime"].ToString() + "\n");
            }
            Public.ExportFiles(this.Page, strBuider, "充值记录.csv", "application/ms-excel");
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this, "暂无充值记录可供导出。");
        }
    }
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        BindSms();
    }
}
