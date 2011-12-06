using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Admin_Users :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {//此页面为管理员使用
        if (!IsPostBack)
        {
            int role = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)));
            if (role !=0)
            {
                this.Page.Controls.Clear();
                Response.Write("您没有管理员的权限，拒绝访问。");
            }

            if (Request.QueryString["type"] != null && Request.QueryString["type"] != "")
            { 
                this.txtType.Text = Request.QueryString["type"].ToString();
                switch(this.txtType.Text)
                {
                    case "user":
                        this.lblUserType.Text = "客户管理";
                        break;
                    case "agent":
                        this.lblUserType.Text = "代理管理";
                        break;
                }         
                
                BindUser();  
            }             
        }             
    } 
    protected string GetRoleName(int Role)
    {
        string strRole = "";
        switch (Role)
        {
            case 1: strRole = "代理"; break;
            case 2: strRole = "集团用户"; break;
            case 3: strRole = "个人用户"; break;
        }
        return strRole;
    }

    protected void BindUser()
    {
        try
        {
            string str = string.Empty; 
            switch (this.txtType.Text)
            {
                case "user":
                    str = " and (role=3 or role=2) ";
                    this.Button1.Visible = false;
                    break;
                case "agent":
                    str = " and role=1 ";
                    this.Button2.Visible = false;
                    break;
            }
            if(this.txtKeyWord.Text!="")
            {
                str += " and (account like '%"+this.txtKeyWord.Text+"%' or name like '%"+this.txtKeyWord.Text+"%')  ";
            }
            ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User(); 
            DataSet dsList = bll.GetList(" role!=0 and state=2 "+str+" order by id ");
            int count = dsList.Tables[0].Rows.Count;
            if (count >= 0)
            {
                Pager(DataList1, AspNetPager1, dsList);
                this.lblCount.Text = count.ToString();
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
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            if (this.txtDeletePwd.Text == "")
            {
                Maticsoft.Common.MessageBox.Show(this,"请输入删除密码。");
                return;
            }
            ECSMS.BLL.EC_Config myConfig = new ECSMS.BLL.EC_Config();
            DataSet ds = myConfig.GetList(" DelPwd='"+this.txtDeletePwd.Text+"' ");
            int count = ds.Tables[0].Rows.Count;
            if (count == 0)
            {
                Maticsoft.Common.MessageBox.Show(this, "删除密码输入错误。");
                return;
            }

            ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
            bll.Delete(int.Parse(e.CommandArgument.ToString()));

            Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("delete EC_UserSmsAccount where userid="+e.CommandArgument);
            
            //Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(" delete  ");

            Maticsoft.Common.MessageBox.Show(this, "删除成功！");
            BindUser();
        }
        if (e.CommandName == "lock")
        {
            ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
            ECSMS.Model.EC_User model = new ECSMS.Model.EC_User();
            model = bll.GetModel(int.Parse(e.CommandArgument.ToString()));
            if (model.IsLock == 1)
            {
                model.IsLock = 0;
                bll.Update(model);
                Maticsoft.Common.MessageBox.Show(this, "账户【" + model.Account + "】已解锁！");
                BindUser();
            }
            else
            {
                model.IsLock = 1;
                bll.Update(model);
                Maticsoft.Common.MessageBox.Show(this, "账户【" + model.Account + "】已被锁定！");
                BindUser();
            }            
        }
    }
    protected void btnQueryUser_Click(object sender, EventArgs e)
    {
        BindUser();
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (this.txtDeletePwd.Text == "")
        {
            Maticsoft.Common.MessageBox.Show(this, "请输入导出密码。");
            return;
        }
        ECSMS.BLL.EC_Config myConfig = new ECSMS.BLL.EC_Config();
        DataSet ds = myConfig.GetList(" DelPwd='" + this.txtDeletePwd.Text + "' ");
        int count = ds.Tables[0].Rows.Count;
        if (count == 0)
        {
            Maticsoft.Common.MessageBox.Show(this, "导出密码输入错误。");
            return;
        }
        string str = string.Empty;
        switch (this.txtType.Text)
        {
            case "user":
                str = " and (role=3 or role=2) "; 
                break;
            case "agent":
                str = " and role=1 "; 
                break;
        }
        if (this.txtKeyWord.Text != "")
        {
            str += " and (account like '%" + this.txtKeyWord.Text + "%' or name like '%" + this.txtKeyWord.Text + "%')  ";
        }
        ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
        DataSet dsList = bll.GetList(" role!=0 and state=2 " + str);
        StringBuilder strBuider = new StringBuilder();
        strBuider.Append("帐号,");
        strBuider.Append("姓名,");
        strBuider.Append("密码,");
        strBuider.Append("手机,");
        strBuider.Append("余额,");
        strBuider.Append("归属,");
        strBuider.Append("用户级别,");
        strBuider.Append("注册时间,");
        strBuider.Append("自动发送,");
        strBuider.Append("账户状态\n");
        foreach(DataRow row in dsList.Tables[0].Rows)
        {
            strBuider.Append(row["account"].ToString()+",");
            strBuider.Append(row["name"].ToString() + ",");
            strBuider.Append(row["pwd"].ToString() + ",");
            strBuider.Append(row["mobile"].ToString() + ",");
            strBuider.Append(Public.GetUserLeaveSms(int.Parse(row["id"].ToString())).Replace(",","-") + ",");
            strBuider.Append(Public.GetUserAccount(int.Parse( row["userid"].ToString())) + ",");
            strBuider.Append(GetRoleName( int.Parse( row["role"].ToString())) + ",");
            strBuider.Append(row["startdate"].ToString() + ",");
            strBuider.Append(row["maxsendnum"].ToString() + ",");
            strBuider.Append(row["state"].ToString()=="2"?"审核通过,":"未审核,");
            strBuider.Append("\n");
        }
        Public.ExportFiles(this.Page, strBuider, "用户列表.csv", "application/ms-excel");
    }
}
