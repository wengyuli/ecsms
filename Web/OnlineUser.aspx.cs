using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class OnlineUser :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindUser();
        }
    }
    protected void BindUser()
    {
        try
        {
            string strUserId = Public.GetUserId(this.Page);
            string str = string.Empty;
            if (Public.GetUserRole(int.Parse(strUserId)) != 0)
            {
                str = " and userid=" + strUserId + " ";
            }
            ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
            DataSet dsList = bll.GetList(" (role=3 or role=2 " + str + ") and online=1 and id!="+strUserId);
            int count = dsList.Tables[0].Rows.Count;
            if (count > 0)
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
            BindUser();
        }
        catch (Exception ex)
        {

        }
    }
}
