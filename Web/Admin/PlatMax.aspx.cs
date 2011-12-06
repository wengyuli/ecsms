using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_PlatMax :PageBase
{
    ECSMS.BLL.EC_Config bll = new ECSMS.BLL.EC_Config();
    ECSMS.Model.EC_Config model = new ECSMS.Model.EC_Config();

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

            BindPlatMax();
        }
    }

    protected void BindPlatMax()
    {
        DataSet ds = bll.GetList("");
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            this.txtPlatCount.Text = ds.Tables[0].Rows[0]["PlatMax"].ToString();
            this.txtUserMax.Text = ds.Tables[0].Rows[0]["usermax"].ToString();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Maticsoft.Common.PageValidate.IsNumber(this.txtPlatCount.Text))
        {
            DataSet ds = bll.GetList("");
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                model = bll.GetModel(int.Parse(ds.Tables[0].Rows[0]["id"].ToString()));
                model.PlatMax = int.Parse(this.txtPlatCount.Text);
                model.UserMax = int.Parse(this.txtUserMax.Text);
                bll.Update(model);
                Maticsoft.Common.MessageBox.Show(this,"权限更新成功，当前平台权限为:【"+this.txtPlatCount.Text+"】，默认用户权限为：【"+this.txtUserMax.Text+"】");
                BindPlatMax();
            }
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this,"请输入正整数！");
        }
    }


}
