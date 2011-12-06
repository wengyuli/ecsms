using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class ReceiveLog :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["type"] != null && Request.QueryString["type"] != "")
            {
                this.lbltype.Text = Request.QueryString["type"].ToString();
                BindSms();
            }

        }
    }
    protected DataSet GetInfo()
    {
        string strSql = string.Empty;
        string strUserId = Public.GetUserId(this.Page);
        switch (this.lbltype.Text)
        {
            case "A":
                strSql = " where msgtype=2 and MsgStatus=" + strUserId + " ";
                break;
            case "B":
                strSql = " where msgtype=3 and MsgStatus=" + strUserId + " ";
                break;
            case "C":
                strSql = " where msgtype=4 and MsgStatus=" + strUserId + " ";
                break;
            case "D":
                strSql = " where msgtype=5 and MsgStatus=" + strUserId + " ";
                break;
            case "E":
                strSql = " where msgtype=6 and MsgStatus=" + strUserId + " ";
                break;
            case "X":
                strSql = " where msgtype=7 and MsgStatus=" + strUserId + " ";
                break;
            case "all":
                strSql = " where 1=1 ";
                this.lblDelPwd.Visible = true;
                this.txtDelPwd.Visible = true;
                break;
            case "myuser":
                strSql = " where msgstatus in (select id from ec_user where userid=" + strUserId + ") ";
                break;
        }

        if(this.txtKey.Text!="")
        {
            if (this.lbltype.Text == "all" || this.lbltype.Text == "myuser")
            {
                string strTempId = Maticsoft.DBUtility.DbHelperSQL.GetSingle(" select top 1 id from ec_user where account like '%" + this.txtKey.Text + "%' ").ToString();
                if (strTempId != null)
                {
                    strSql += " and (msgtilte like '%" + this.txtKey.Text + "%' or MsgStatus like '%"+strTempId+"%' ) ";
                }
            }
            else
            {
                strSql += " and ( MsgTilte like '%" + this.txtKey.Text + "%'  )";
            }
        }

        DataSet dsList = Maticsoft.DBUtility.DbHelperSQL.Query(" select * from RecvMsgTable " + strSql + " order by RecvTime desc");
        return dsList;
    }
    protected void BindSms()
    {
        try
        {
            DataSet dsList = GetInfo();
            int count = dsList.Tables[0].Rows.Count;
            if (count >= 0)
            {
                Pager(DataList1, AspNetPager1, dsList);
                this.lblCount.Text = count.ToString();
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
        if (e.CommandName == "del")
        {
            if (this.lbltype.Text == "all")
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
            }
            string strSql = " delete RecvMsgTable where msgindex= " + e.CommandArgument.ToString();
            Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(strSql);
            Maticsoft.Common.MessageBox.Show(this.Page, "本条记录已经成功删除！");
            BindSms();
        }
    }

    protected string GetAccountById(int userId)
    {
        ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
        ECSMS.Model.EC_User model = new ECSMS.Model.EC_User();
        model = bll.GetModel(userId);
        if (model != null)
        {
            return model.Account;
        }
        else
        {
            return "无法对应";
        }
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        BindSms();
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        DataSet dsList = GetInfo();
        int count = dsList.Tables[0].Rows.Count;
        if (count > 0)
        {
            StringBuilder strData = new StringBuilder();
            strData.Append("编号,");
            strData.Append("回复号码,");
            strData.Append("接收人,");
            strData.Append("短信内容,"); 
            strData.Append("接收时间");
            strData.Append("\n"); 
            foreach (DataRow row in dsList.Tables[0].Rows)
            {
                strData.Append(row["MsgIndex"].ToString() + ",");
                strData.Append(row["PhoneNumber"].ToString() + ",");
                strData.Append(Public.GetUserAccount(int.Parse(row["MsgStatus"].ToString()))+",");
                strData.Append(row["MsgTilte"].ToString() + ",");
                strData.Append(row["RecvTime"].ToString()); 
                strData.Append("\n");
            }
            string strTemp = string.Format("attachment;filename={0}", Server.UrlEncode("回复短信列表.csv"));
            Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            Response.ClearHeaders();
            Response.AppendHeader("Content-disposition", strTemp);
            Response.Write(strData);
            Response.End();
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this, "在您的查询范围内暂无充值记录可供导出。");
        }
    }
    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        System.Web.UI.WebControls.LinkButton lbtn = (System.Web.UI.WebControls.LinkButton)(e.Item.FindControl("lbtnDel"));
        if (lbtn != null)
        {
            if (this.lbltype.Text == "myuser")
            {
                lbtn.Visible = false;
            }
            else
            {
                lbtn.Visible = true;
            }
        }
    }
}
