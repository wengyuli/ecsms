using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Bank :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDownLoad(); 
        }
    }

    protected void BindDownLoad()
    {
        ECSMS.BLL.EC_Bank bll = new ECSMS.BLL.EC_Bank();
        DataSet ds = bll.GetList(" userid= "+Public.GetUserId(this.Page));
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
        BindDownLoad();
    }

    protected void dlDel(object sender, DataListCommandEventArgs e)
    {
        try
        {
            string strId = this.DataList1.DataKeys[e.Item.ItemIndex].ToString();
            string strSql = "delete ec_bank where Id=" + strId;
            Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(strSql);

            Maticsoft.Common.MessageBox.Show(this, "删除成功！");

            BindDownLoad();
        }
        catch (Exception ex)
        {

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (this.txtAccount.Text!=""&&this.txtName.Text!="")
        {
            ECSMS.BLL.EC_Bank bll = new ECSMS.BLL.EC_Bank();
            ECSMS.Model.EC_Bank model = new ECSMS.Model.EC_Bank();
            model.BankAccount = this.txtAccount.Text.Trim();
            model.BankName = this.ddlBankName.SelectedItem.Text;
            switch(this.ddlBankName.SelectedItem.Text)
            {
                case "中国银行":
                    model.IconUrl = "img/3.gif";
                    break;
                case "中国农业银行":
                    model.IconUrl = "img/2.gif";
                    break;
                case "中国工商银行":
                    model.IconUrl = "img/6.gif";
                    break;
                case "中国建设银行":
                    model.IconUrl = "img/1.gif";
                    break;
                case "中信银行":
                    model.IconUrl = "img/7.gif";
                    break;
                case "招商银行":
                    model.IconUrl = "img/9.gif";
                    break;
                case "兴业银行":
                    model.IconUrl = "img/10.gif";
                    break;
                case "上海浦东发展银行":
                    model.IconUrl = "img/5.gif";
                    break;
                case "交通银行":
                    model.IconUrl = "img/8.gif";
                    break;
                case "民生银行":
                    model.IconUrl = "img/4.gif";
                    break;
                case "淘宝网账户":
                    model.IconUrl = "img/taobao.png";
                    break;
                case "支付宝账户":
                    model.IconUrl = "img/alipay.png";
                    break;
            }
            model.UserId = int.Parse( Public.GetUserId(this.Page));
            model.Name = this.txtName.Text;
            model.Remark = this.txtRemark.Text;
            model.PayUrl = this.txtPayUrl.Text;
            bll.Add(model);
            this.txtName.Text = ""; 
            this.txtAccount.Text = "";
            this.txtRemark.Text = "";
            BindDownLoad();

            Maticsoft.Common.MessageBox.Show(this, "银行账户添加成功！");
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this, "请填写完整的银行名称，银行账号，开户姓名后再添加！");
        }
    }
}
