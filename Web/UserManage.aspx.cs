using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class UserManage :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {//仅管理本人管理的用户或集团用户,代理            
            
            BindUser();
        }
    }
    
    protected void BindUser()
    {
        try
        {
            string strUserId = Public.GetUserId(this.Page);
            string str = string.Empty;
            string strType = string.Empty;
            strType = Request.QueryString["type"];
            switch(Public.GetUserRole(int.Parse(strUserId)))
            {
                case 1://代理查看代理和集团用户
                    if (strType == "user")
                    {
                        str = " (role=3 or role=2) and ";
                        this.btnNewAgent.Visible = false;
                        this.btnNewUser.Visible = true;
                        this.lblTitle.Text = "用户管理";
                    }
                    else if(strType=="agent")
                    {
                        str = " role=1 and ";
                        this.btnNewAgent.Visible = true;
                        this.btnNewUser.Visible = false;
                        this.lblTitle.Text = "代理管理";
                    }                    
                break;
                case 2://集团用户查看用户
                    str=" (role=3 or role=2) and ";
                    this.btnNewAgent.Visible = false;
                    this.btnNewUser.Visible = true;
                break;
            }

            if (this.txtSearchText.Text != "")
            {
                str += " account like '%"+this.txtSearchText.Text+"%' and ";
            }

            ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
            DataSet dsList = myUser.GetList(str+" role!=0 and userid="+strUserId+" order by id ");
            int count = dsList.Tables[0].Rows.Count;
            this.lblTotalUserCount.Text = count.ToString();
            if (count > 0)
            {
                Pager(DataList1, AspNetPager1, dsList);
            }
        }
        catch (Exception ex)
        {
            Maticsoft.Common.MessageBox.Show(this,ex.Message);
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
            BindUser();
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





    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "repwd")
        {
            Random rand = new Random();
            string newPwd=rand.Next(100000,999999).ToString();
            ECSMS.Model.EC_User newuser = new ECSMS.Model.EC_User();
            ECSMS.BLL.EC_User myuser = new ECSMS.BLL.EC_User();
            newuser = myuser.GetModel(int.Parse(e.CommandArgument.ToString()));
            newuser.Pwd = newPwd;
            myuser.Update(newuser);
            Maticsoft.Common.MessageBox.Show(this, "密码已成功重置为"+newPwd);
        }
    }
}
