using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Maticsoft.Common;
using System.Text.RegularExpressions;
using System.Text;
using System.IO;

public partial class DownLoads_ShowDown : PageBase
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
        ECSMS.BLL.EC_DownLoad myDown = new ECSMS.BLL.EC_DownLoad();
        DataSet ds = myDown.GetList("");
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            this.DataList1.DataSource = ds;
            this.DataList1.DataBind();
        }
    }

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Header)
        {
            Label lbl = e.Item.FindControl("lblprice") as Label;
            if (lbl != null)
            {
                string[] arr = lbl.Text.Split('|');
                bool isHasPrice = false;
                foreach (string str in arr)
                {
                    string[] strArr = str.Split('-');
                    if (int.Parse(strArr[1]) > 0)
                    {
                        isHasPrice = true;
                        break;
                    }
                }
                if (isHasPrice)
                {
                    Label lblId = e.Item.FindControl("lblId") as Label;
                    System.Web.UI.HtmlControls.HtmlAnchor link = e.Item.FindControl("downUrl") as System.Web.UI.HtmlControls.HtmlAnchor;
                    link.Attributes.Add("onclick","opendown('" + lblId.Text + "')");
                    link.InnerText = "【点击进入扣费下载】";
                }
                else
                { 
                    Label lblId = e.Item.FindControl("lblAllName") as Label;
                    System.Web.UI.HtmlControls.HtmlAnchor link = e.Item.FindControl("downUrl") as System.Web.UI.HtmlControls.HtmlAnchor;
                    link.HRef = "Files/"+lblId.Text;
                    link.InnerText = "【直接右键下载软件】";
                }
            }
        }
    }
 
    protected void btnBackUp_Click(object sender, EventArgs e)
    {
        ECSMS.BLL.EC_Customer myCustomer = new ECSMS.BLL.EC_Customer();
        ECSMS.Model.EC_Customer newCustomer = new ECSMS.Model.EC_Customer();
        ECSMS.BLL.EC_CustomerGroup myCustomerGroup = new ECSMS.BLL.EC_CustomerGroup();
        ECSMS.Model.EC_CustomerGroup newCustomerGroup = new ECSMS.Model.EC_CustomerGroup();
        string strId = Public.GetUserId(this.Page).ToString();
        string strwhere = "  UserId='" + strId + "'";
        DataSet ds = myCustomer.GetList(strwhere);
        StringBuilder builder = new StringBuilder();
        builder.Append("姓名,");
        builder.Append("称呼,");
        builder.Append("性别,");
        builder.Append("出生日期,");
        builder.Append("手机号码,");
        builder.Append("手机号码2,");
        builder.Append("QQ,");
        builder.Append("职位,");
        builder.Append("Email,");
        builder.Append("邮编,");
        builder.Append("家庭电话,");
        builder.Append("家庭住址,");
        builder.Append("公司名称,");
        builder.Append("公司电话,");
        builder.Append("公司地址,");
        builder.Append("公司网址,");
        builder.Append("公司传真,");
        builder.Append("会员卡号/车牌号,");
        builder.Append("客服专员,");
        builder.Append("起始时间,");
        builder.Append("结束时间,");
        builder.Append("关系级别,");
        builder.Append("个人爱好/其他备注,");
        builder.Append("\n");
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            builder.Append(row["Name"].ToString() + ",");
            builder.Append(row["NickName"].ToString() + ",");
            builder.Append((row["Sex"].ToString() == "男") ? "男" : "女" + ",");
            builder.Append(row["Birthday"].ToString() + ",");
            builder.Append(row["Mobile"].ToString() + ",");
            builder.Append(row["mobile2"].ToString() + ",");
            builder.Append(row["QQ"].ToString() + ",");
            builder.Append(row["Positions"].ToString() + ",");
            builder.Append(row["Email"].ToString() + ",");
            builder.Append(row["PostCode"].ToString() + ",");
            builder.Append(row["HomeTel"].ToString() + ",");
            builder.Append(row["HomeAddress"].ToString() + ",");
            builder.Append(row["CompanyName"].ToString() + ",");
            builder.Append(row["Telephone"].ToString() + ",");
            builder.Append(row["CompanyAddress"].ToString() + ",");
            builder.Append(row["Website"].ToString() + ",");
            builder.Append(row["Fax"].ToString() + ",");
            builder.Append(row["CardNumber"].ToString() + ",");
            builder.Append(row["Servicer"].ToString() + ",");
            builder.Append(row["StartDate"].ToString() + ",");
            builder.Append(row["EndDate"].ToString() + ",");
            builder.Append(row["RelationLevel"].ToString() + ",");
            builder.Append(row["Favrate"].ToString()+" 备注：" + row["Remark"].ToString() + ",");
            builder.Append("\n");
        }
        ECSMS.BLL.EC_User myuser = new ECSMS.BLL.EC_User();
        ECSMS.Model.EC_User newuser = myuser.GetModel(Int32.Parse(strId));

        string strfilename = "所有客户信息.csv";
        string strfiletype = "application/ms-excel";
        GenerationCvsFile(builder, strfilename, strfiletype);
    }

    #region  输出各种文档
    /// <summary>
    ///  输出各种文档
    /// </summary>
    /// <param name="strtitlename">文件的内容(各项以逗号隔开 以"\n"结束)</param>
    /// <param name="strfilename">生成的文件名</param>
    /// <param name="strfilename">输出文件的类型为application/ms-excel || application/ms-word || application/ms-txt || application/ms-html</param>
    public void GenerationCvsFile(StringBuilder strbuilder, string strfilename, string strfiletype)
    {
        try
        {
            string strTemp = string.Format("attachment;filename={0}", Server.UrlEncode(strfilename));
            Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            Response.ClearHeaders();
            Response.AppendHeader("Content-disposition", strTemp);
            Response.ContentType = strfiletype;
            Response.Write(strbuilder);
            Response.End();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.Page, ex.Message.ToString());
        }
    }
    #endregion 
   
}
