using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_DownLoad : PageBase
{
    ECSMS.Model.EC_DownLoad model = new ECSMS.Model.EC_DownLoad();
    ECSMS.BLL.EC_DownLoad bll = new ECSMS.BLL.EC_DownLoad();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            int role = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)));
            if (role != 0)
            {
                this.Page.Controls.Clear();
                Response.Write("您没有管理员的权限，拒绝访问。");
            }

            BindDownLoad();
        }
    }

    protected void BindDownLoad()
    { 
        DataSet ds = bll.GetList("");
        int count = ds.Tables[0].Rows.Count;
        if(count>=0)
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
        BindDownLoad();
    }

    protected void dlDel(object sender, DataListCommandEventArgs e)
    {
        try
        {
            int id = int.Parse(e.CommandArgument.ToString());           

            model = bll.GetModel(id); 
            if (model != null)
            {
                System.IO.FileInfo file =new System.IO.FileInfo( Server.MapPath("files\\") + model.FullFileName);
                if (file.Exists)
                {
                    file.Delete();
                }
            }

            bll.Delete(id);

            Maticsoft.Common.MessageBox.Show(this, "删除成功！");

            BindDownLoad();
        }
        catch (Exception ex)
        {

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.txtShowName.Text != "")
        {
            if(this.FileUpload1.PostedFile.ContentType.Contains(".exe"))
            {
                Maticsoft.Common.MessageBox.Show(this,"对不起，为了服务器安全，不能上传可执行文件，请压缩后上传。");
                return;
            }
            
            string strUrl = Server.MapPath("Files/") + this.FileUpload1.FileName;
            this.FileUpload1.SaveAs(strUrl);
            model.FullFileName = this.FileUpload1.FileName;
            model.ShowName = txtShowName.Text;
            model.Remark = txtRemark.Text;
            model.PostTime = DateTime.Now;
            model.Price = "A-"+this.txtA.Text+"|B-"+this.txtB.Text+"|C-"+this.txtC.Text+"|D-"+this.txtD.Text+"|E-"+this.txtE.Text+"";
            bll.Add(model);
            this.txtRemark.Text = "";
            this.txtShowName.Text = "";
            BindDownLoad(); 
            Maticsoft.Common.MessageBox.Show(this,"添加成功！");
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this,"请填写下载文件的全名、显示名称后再添加！");
        }
    }
}
