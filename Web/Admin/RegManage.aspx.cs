using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_RegManage : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {//此页面为管理员审核用户

        if (!IsPostBack)
        {
            int role = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)));
            if (role != 0)
            {
                this.Page.Controls.Clear();
                Response.Write("您没有管理员的权限，拒绝访问。");
            }

            BindUser(); 
        }      

    }

    protected void BindUser()
    {
        try
        { 
            ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
            DataSet dsList = bll.GetList(" role!=0 and state=0 ");
            int count = dsList.Tables[0].Rows.Count;
            if (count >= 0)
            {
                this.lblShow.Text = "共有新注册用户【"+count+"】个";
                Pager(DataList1, AspNetPager1, dsList);
                if (count == 0)
                {
                    this.DataList1.Visible = false;
                    this.lblShow.Visible = true;
                }
            }
        }
        catch (Exception ex)
        {
            Maticsoft.Common.MessageBox.Show(this, ex.Message);
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
            Maticsoft.Common.MessageBox.Show(this, ex.Message);
        }
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    { 
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        BindUser(); 
    }


    protected string GetRoleName(int Role)
    {
        string strRole = "";
        switch (Role)
        {
            case 2: strRole = "集团用户"; break;
            case 3: strRole = "个人用户"; break;
        }
        return strRole;
    }


    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        { 
            ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
            bll.Delete(int.Parse(e.CommandArgument.ToString()));
            BindUser();
            Maticsoft.Common.MessageBox.Show(this, "删除成功！");
        }
        if(e.CommandName=="pass")
        {
            var model = new ECSMS.BLL.EC_User().GetModel(int.Parse(e.CommandArgument.ToString()));
            model.State = 2;
            new ECSMS.BLL.EC_User().Update(model);

            if (model.Mobile != "" && model.State == 2)
            {
                Public.SendSystemSms(model.Mobile, "感谢您注册成为商信宝短信平台用户！您的登录名【" + model.Account + "】密码【" + model.Pwd + "】，登陆地址www.ecsms.cn");
            }
            Maticsoft.Common.MessageBox.Show(this,"快速开通成功！");
        }
    }
}
