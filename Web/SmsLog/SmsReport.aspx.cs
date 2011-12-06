using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class SmsLog_SmsReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["taskid"] != null && Request.QueryString["taskid"] != "")
            {
                this.lblTaskId.Text = Request.QueryString["taskid"];
                BindSms();

                string str = Request.QueryString["returnurl"].ToString();
                string[] arr = str.Split('-');
                this.btnBack.PostBackUrl = ""+arr[0].ToString()+"?type="+arr[1].ToString()+"" ;
            }

        }
    }
    protected void BindSms()
    {
        try
        {
            DataSet dsList = Maticsoft.DBUtility.DbHelperSQL.Query(" select * from sendmsgtable where ServerID='"+this.lblTaskId.Text+"' ");
            int count = dsList.Tables[0].Rows.Count; 
            if (count >= 0)
            {
                if (dsList.Tables[0].Rows[0]["msgtype"].ToString() == "0")
                { 
                    string strNumbers = dsList.Tables[0].Rows[0]["phonenumber"].ToString();
                    string[] arrNumbers = strNumbers.Split(',');
                    string msgindex = dsList.Tables[0].Rows[0]["msgindex"].ToString();
                    string msgtitle = dsList.Tables[0].Rows[0]["msgtitle"].ToString();
                    string msgstatus = dsList.Tables[0].Rows[0]["msgstatus"].ToString();
                    string msgtype = dsList.Tables[0].Rows[0]["msgtype"].ToString(); 
                    string senttime = dsList.Tables[0].Rows[0]["senttime"].ToString();
                    string userid = dsList.Tables[0].Rows[0]["userid"].ToString();
                    string isexpernum = dsList.Tables[0].Rows[0]["isexpernum"].ToString();
                    string sendnum = dsList.Tables[0].Rows[0]["sendnum"].ToString();
                    string exernumbers = dsList.Tables[0].Rows[0]["exernumbers"].ToString();
                    string numberscount = dsList.Tables[0].Rows[0]["numberscount"].ToString();
                    string serverid = dsList.Tables[0].Rows[0]["serverid"].ToString();
                    dsList.Tables[0].Rows.Clear();
                    foreach(string number in arrNumbers)
                    {
                        if (number != "")
                        {
                            dsList.Tables[0].Rows.Add(
                                msgindex,
                                number,
                                msgtitle,
                                "",
                                "",
                                msgstatus,
                                msgtype, 
                                senttime,
                                "",
                                "",
                                "",
                                0,
                                userid,
                                isexpernum,
                                sendnum,
                                DateTime.Now,
                                exernumbers,
                                numberscount,
                                serverid                        
                                );
                        }                        
                    }
                    for (int i = 0; i < dsList.Tables[0].Rows.Count;i++ )
                    {
                        if (dsList.Tables[0].Rows[i]["senttime"] != "")
                        {
                            DateTime dt = DateTime.Parse(dsList.Tables[0].Rows[i]["senttime"].ToString());
                            dsList.Tables[0].Rows[i]["senttime"] = dt.AddMilliseconds((i + 1) * 156 + 376).ToString("yyyy/MM/dd HH:mm:ss");
                        }
                    } 
                }
                Pager(DataList1, AspNetPager1, dsList); 
            }
        }
        catch (Exception ex)
        {
            Maticsoft.Common.MessageBox.Show(this.Page,ex.Message);
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

    protected void btnExport_Click(object sender, EventArgs e)
    {
        DataSet dsList = Maticsoft.DBUtility.DbHelperSQL.Query("select phonenumber,msgtitle,userid, msgtype,msgstatus,numberscount ,sendnum,senttime from sendmsgtable where ServerID='" + this.lblTaskId.Text + "'");
        int count = dsList.Tables[0].Rows.Count;
        if (count > 0)
        { 
            System.Text.StringBuilder strBuilder=new System.Text.StringBuilder();
            strBuilder.Append("号码,");
            strBuilder.Append("短信内容,");
            strBuilder.Append("短信类型,");
            strBuilder.Append("发送状态,");
            strBuilder.Append("拆分条数,");
            strBuilder.Append("发送时间,");
            strBuilder.Append("\n");
            string strUserId = string.Empty;
            string NumbersCount = string.Empty;
            for (int i = 0; i < dsList.Tables[0].Rows.Count;i++ )
            {
                if (strUserId == "") { strUserId = dsList.Tables[0].Rows[i]["userid"].ToString(); }
                if (NumbersCount == "") { NumbersCount =dsList.Tables[0].Rows[i]["numberscount"].ToString(); }
                strBuilder.Append(dsList.Tables[0].Rows[i]["phonenumber"].ToString() + ",");
                strBuilder.Append(dsList.Tables[0].Rows[i]["msgtitle"].ToString() + ",");
                strBuilder.Append(new ECSMS.BLL.EC_SmsType().GetModel( dsList.Tables[0].Rows[i]["msgtype"].ToString()).Name + ",");
                strBuilder.Append((dsList.Tables[0].Rows[i]["msgstatus"].ToString() == "3" || dsList.Tables[0].Rows[i]["msgstatus"].ToString() == "1") ? "成功" + "," : "已提交" + ",");
                strBuilder.Append(dsList.Tables[0].Rows[i]["sendnum"].ToString() + ",");
                strBuilder.Append(dsList.Tables[0].Rows[i]["senttime"].ToString() + ",");
                strBuilder.Append("\n");
            }

            Public.ExportFiles(this.Page,strBuilder,"【"+Public.GetUserName(int.Parse(strUserId))+"】发送明细【"+NumbersCount+"】.csv","application/ms-excel");
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this, "暂无充值记录可供导出。");
        }
    }
     
}
