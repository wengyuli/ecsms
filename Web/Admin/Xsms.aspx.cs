using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_Xsms:PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    { 
            int role = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)));
            if (role != 0)
            {
                this.Page.Controls.Clear();
                Response.Write("您没有管理员的权限，拒绝访问。");
            }

            BindSms(); 
        
    }
    protected void BindSms()
    {
        try
        {
            ECSMS.BLL.SendMsgTable bll = new ECSMS.BLL.SendMsgTable();
            DataSet dsList = bll.GetList(" MsgStatus="+(int)ECSMS.Channel.SmsStatus.等待发送+" and msgtype='X' order by sendtime desc");
            int count = dsList.Tables[0].Rows.Count;
            if (count > 0)
            {
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

    

}
