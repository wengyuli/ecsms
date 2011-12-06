using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class BroadCast :PageBase
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

            BindBank();
        }
    }
    protected void BindBank()
    {
        ECSMS.BLL.EC_Broadcast bll = new ECSMS.BLL.EC_Broadcast();

        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(" select * from ec_broadcast order by posttime desc ");
        int count = ds.Tables[0].Rows.Count;
        if (count >= 0)
        {
            Pager(this.DataList1, this.AspNetPager1, ds);
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
        BindBank();
    }

    protected void dlDel(object sender, DataListCommandEventArgs e)
    {
        try
        {
            string strId = this.DataList1.DataKeys[e.Item.ItemIndex].ToString();
            string strSql = "delete ec_broadcast where Id=" + strId;
            Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(strSql);

            Maticsoft.Common.MessageBox.Show(this.Page, "删除成功！");

            BindBank();
        }
        catch (Exception ex)
        {

        }
    }
    protected void dlEdit(object sender, DataListCommandEventArgs e)
    {
        try
        {
            string strId = this.DataList1.DataKeys[e.Item.ItemIndex].ToString();
            ECSMS.BLL.EC_Broadcast bll = new ECSMS.BLL.EC_Broadcast();
            ECSMS.Model.EC_Broadcast model = new ECSMS.Model.EC_Broadcast();
            model = bll.GetModel(int.Parse(strId));
            this.txtTitle.Text = model.Title;
            this.txtShowName.Text = model.ShowName;
            this.txtContent.Text = model.Content;
            this.Button1.Text = "保存";
            this.Button2.Visible = true;
            this.lblId.Text = model.Id.ToString();
        }
        catch (Exception ex)
        {

        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        ECSMS.BLL.EC_Broadcast bll = new ECSMS.BLL.EC_Broadcast();
        ECSMS.Model.EC_Broadcast model = new ECSMS.Model.EC_Broadcast();
        if (this.txtContent.Text != "" && this.txtTitle.Text != "")
        {
            string strShow = string.Empty;
            if (this.Button1.Text == "添加公告")
            {
                Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("update ec_broadcast set state=0");
                
                model.Content = this.txtContent.Text;
                model.ShowName = this.txtShowName.Text;
                model.Title = this.txtTitle.Text;
                model.UserId = int.Parse(Public.GetUserId(this.Page));
                model.PostTime = DateTime.Now;
                model.State = 1;
                bll.Add(model);
                strShow = "公告添加成功！";
            }
            else
            {
                model = bll.GetModel(int.Parse(this.lblId.Text));
                model.Title = this.txtTitle.Text;
                model.ShowName = this.txtShowName.Text;
                model.Content = this.txtContent.Text;
                bll.Update(model);
                strShow = "公告保存成功！";
                this.Button1.Text = "添加公告";
                this.Button2.Visible = false;
            }
            BindBank();
            this.txtContent.Text = "";
            this.txtShowName.Text = "";
            this.txtTitle.Text = "";
            
            Maticsoft.Common.MessageBox.Show(this.Page,strShow);
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this.Page, "请完善标题和内容后再提交。");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.Button1.Text = "添加公告";
        this.txtContent.Text = "";
        this.txtShowName.Text = "";
        this.txtTitle.Text = "";
        this.Button2.Visible = false;
    }




}
