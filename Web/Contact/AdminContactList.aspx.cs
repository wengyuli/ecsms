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
public partial class Contact_AdminContactList :PageBase
{
    public string strwhere = string.Empty;
    ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
    ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
    public ECSMS.BLL.EC_Customer myCustomer = new ECSMS.BLL.EC_Customer();
    public ECSMS.Model.EC_Customer newCustomer = new ECSMS.Model.EC_Customer();
    ECSMS.BLL.EC_CustomerGroup myCustomerGroup = new ECSMS.BLL.EC_CustomerGroup();
    ECSMS.Model.EC_CustomerGroup newCustomerGroup = new ECSMS.Model.EC_CustomerGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            if (Public.GetUserId(this.Page) != "")
            {
                newUser = myUser.GetModel(Int32.Parse(Public.GetUserId(this.Page).ToString()));
                TreeNode Node = new TreeNode();

                if (newUser.Role != 0)
                {
                    MessageBox.Show(this.Page, "对不起您不是管理员！");
                }
                else
                {
                    Node.Value = "-5";
                    Node.Text = "名片夹";
                   
                    TrviewGroup.Nodes.Add(Node);
                    TreeNode[] NodeArray = BindTrvGroup();
                    if (NodeArray.Length > 0)
                    {
                        
                        foreach (TreeNode Nod in NodeArray)
                        {
                            Node.ChildNodes.Add(Nod);
                        }
                    }
                }

            }
        }
    }
    protected void TrviewGroup_SelectedNodeChanged(object sender, EventArgs e)
    {
        TreeNode SelectNode = this.TrviewGroup.SelectedNode;

        
        if (SelectNode.Value != "public")
        {
            DataSet ds = myCustomerGroup.GetList(" UserId='" + SelectNode.Value + "'");
            Public.Datalistbind(ds, this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);

        }
    }
    #region 根据条件返回子TreeNode数组
    /// <summary>
    ///  根据条件返回TreeNode数组
    /// </summary>
    /// <param name="strwhere">查询条件</param>
    /// <returns></returns>
    public TreeNode[] BindTrvGroup()
    {
       string strsql = " SELECT distinct  dbo.EC_CustomerGroup.UserId, dbo.EC_User.Name" +
                       " FROM   dbo.EC_User INNER JOIN" +
                       " dbo.EC_CustomerGroup ON dbo.EC_User.Id = dbo.EC_CustomerGroup.UserId ";
       DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(strsql);
        DataTable dt = ds.Tables[0];
        TreeNode[] NodeArray = new TreeNode[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow row = ds.Tables[0].Rows[i];
            NodeArray[i] = new TreeNode(row["Name"].ToString(), row["UserId"].ToString());
            NodeArray[i].Expanded = false;
            NodeArray[i].SelectAction = TreeNodeSelectAction.SelectExpand;
        }
        return NodeArray;
    }
    #endregion
    protected void btnout_Click(object sender, EventArgs e)
    {
        TreeNode SelectNode = this.TrviewGroup.SelectedNode;
        if (SelectNode == null)
        {
            MessageBox.Show(this.Page, "请先在左侧选择你所需要导出人员所在组！");
            return;
        }
        else
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("分组名称,");
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
            foreach (DataListItem Dli in this.Dlist.Items)
            {
                System.Web.UI.HtmlControls.HtmlInputCheckBox chkitem = (System.Web.UI.HtmlControls.HtmlInputCheckBox)Dli.FindControl("Chkitem");
                Label Groupid = (Label)Dli.FindControl("lbId");
                if (chkitem.Checked)
                {
                    string strwhere = " GroupId='" + Groupid.Text + "'";
                    DataSet ds = myCustomer.GetList(strwhere);
                    ECSMS.BLL.EC_CustomerGroup myGroup = new ECSMS.BLL.EC_CustomerGroup();
                    ECSMS.Model.EC_CustomerGroup newGroup = new ECSMS.Model.EC_CustomerGroup();
                    newGroup = myGroup.GetModel(int.Parse(Groupid.Text));
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        builder.Append(newGroup.Name+",");
                        builder.Append(row["Name"].ToString() + ",");
                        builder.Append(row["NickName"].ToString() + ",");
                        builder.Append((row["Sex"].ToString() == "0") ? "男"+"," : "女" + ",");
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
                        builder.Append(row["Favrate"].ToString() + "  备注：" + row["Remark"].ToString() + ",");
                        builder.Append("\n");
                    }
                }
            }
            string strfilename = SelectNode.Text + "客户分组.csv";
            string strfiletype = "application/ms-excel";
            GenerationCvsFile(builder, strfilename, strfiletype);

        }
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        TreeNode SelectNode = this.TrviewGroup.SelectedNode;


        if (SelectNode.Value != "public")
        {
            DataSet ds = myCustomerGroup.GetList(" UserId='" + SelectNode.Value + "'");
            Public.Datalistbind(ds, this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);

        }

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
