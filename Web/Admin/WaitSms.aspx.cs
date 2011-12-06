using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class WaitSms_ViewWaitSms :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        if(!IsPostBack)
        {
            this.tdDelPwd.Visible = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0 ? true : false;
            BindSms();    
        }
    }
    protected void BindSms()
    {
        try
        {
            string strSql = string.Empty;
            string strIsAdmin = string.Empty;
            string strIsHas5 = string.Empty;
            if (Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) != 0)
            {
                strIsAdmin = " and userid in (select id from ec_user where userid=" + Public.GetUserId(this.Page) + ") ";
                strIsHas5 = " and msgtype!='X' ";
            }
            strSql = "select distinct ServerID,msgtitle,msgstatus,msgtype,timesend,sendnum,exernumbers,numberscount,userid,sendtime from sendmsgtable where  (MsgStatus=" + (int)ECSMS.Channel.SmsStatus.等待发送 + " or MsgStatus=" + (int)ECSMS.Channel.SmsStatus.定时待发 + " or msgstatus=" + (int)ECSMS.Channel.SmsStatus.待发状态 + " ) " + strIsHas5 + " " + strIsAdmin + " order by sendtime desc";
            DataSet dsList = Maticsoft.DBUtility.DbHelperSQL.Query(strSql);
            int count = dsList.Tables[0].Rows.Count;
            if (count > 0)
            {
                this.lblNumbersCount.Text = dsList.Tables[0].Compute("sum(numberscount)", "").ToString();
                this.lblWaitSmsCount.Text = count.ToString();
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

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "delete")
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
            Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(" delete SendMsgTable where serverid='"+e.CommandArgument.ToString()+"' ");
            BindSms();
            Maticsoft.Common.MessageBox.Show(this, "删除成功！");
        }
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        bool isAdmin = true;
        isAdmin=Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0?true:false;

        System.Web.UI.HtmlControls.HtmlAnchor anchor = ((System.Web.UI.HtmlControls.HtmlAnchor)(e.Item.FindControl("linkOper")));
        if (anchor != null)
        {
             anchor.Visible= isAdmin;
        }
        System.Web.UI.WebControls.LinkButton lbtn = (System.Web.UI.WebControls.LinkButton)(e.Item.FindControl("LinkButton1"));
        if (lbtn != null)
        {
             lbtn.Visible=isAdmin;
        }

        Label lbl=new Label();
        lbl = e.Item.FindControl("lblExCount") as Label;
        if (lbl != null)
        {
            lbl.Visible = isAdmin;
        }

        lbl = e.Item.FindControl("lblOper") as Label;
        if (lbl != null)
        {
            lbl.Visible = isAdmin;
        }

        lbl = e.Item.FindControl("lblExprCount") as Label;
        if (lbl != null)
        {
            lbl.Visible = isAdmin;
        }
        
    }
    protected void btnProcessToWait_Click(object sender, EventArgs e)
    {
        string strServerIDs = string.Empty;
        foreach(var item in this.DataList1.Items)
        {
            var dataItem = item as DataListItem;             
            var cb = dataItem.FindControl("cbAll") as CheckBox;
            if(cb.Checked)
            {
                if ((dataItem.FindControl("lblIsTimeSend") as Label).Text == "是")
                {
                    Maticsoft.Common.MessageBox.Show(this.Page, "定时短信请单独处理！");
                    return;
                }
                strServerIDs += "'"+(dataItem.FindControl("hfID") as HiddenField).Value+"',";
            }
        }
        if (strServerIDs != "")
        {
            strServerIDs = strServerIDs.Substring(0, strServerIDs.Length - 1);

            string strSql = string.Empty;
            string strShow = string.Empty; 
            strSql = "update sendmsgtable set MsgStatus=" +(int)ECSMS.Channel.SmsStatus.等待发送 + ",senttime='" + DateTime.Now + "' where ServerID in ("+strServerIDs+") ";
            int count = Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(strSql);
            Maticsoft.Common.MessageBox.Show(this, "已将此任务共【" + count + "】条记录状态改变为【待发进入自动发送】。");
            BindSms();
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this.Page,"请选中后再进行操作。");
        }
    }
    protected void btnProcessToSuccess_Click(object sender, EventArgs e)
    {
        string strServerIDs = string.Empty;
        foreach (var item in this.DataList1.Items)
        {
            var dataItem = item as DataListItem; 
            var cb = dataItem.FindControl("cbAll") as CheckBox;
            if (cb.Checked)
            {
                strServerIDs += "'" + (dataItem.FindControl("hfID") as HiddenField).Value + "',";
            }
        }
        if (strServerIDs != "")
        {
            strServerIDs = strServerIDs.Substring(0, strServerIDs.Length - 1);

            string strSql = string.Empty;
            string strShow = string.Empty;
            strSql = "update sendmsgtable set MsgStatus=" + (int)ECSMS.Channel.SmsStatus.发送成功 + ",senttime='" + DateTime.Now + "' where ServerID in (" + strServerIDs + ") ";
            int count = Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(strSql);
            Maticsoft.Common.MessageBox.Show(this, "已将此任务共【" + count + "】条记录状态处理为【发送成功】。");
            BindSms();
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this.Page, "请选中后再进行操作。");
        }
    }
}
