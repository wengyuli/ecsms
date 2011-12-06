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
public partial class Contact_ViewContact :PageBase
{
    public string strwhere = string.Empty;
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


                TreeNode Nodes = new TreeNode("我的名片夹", "0");
                strwhere = "ParentId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
                TreeNode[] NodeArray = BindTrvGroup(strwhere);
                foreach (TreeNode Node in NodeArray)
                {
                    Nodes.ChildNodes.Add(Node);
                }
                TrviewGroup.Nodes.Add(Nodes);
                Nodes = new TreeNode("我的短信回访", "-1");
                strwhere = "ParentId='-1' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
                NodeArray = BindTrvGroup(strwhere);
                foreach (TreeNode Node in NodeArray)
                {
                    Nodes.ChildNodes.Add(Node);
                }
                TrviewGroup.Nodes.Add(Nodes);
                Nodes = new TreeNode("黑名单", "-2");
                strwhere = "ParentId='-2' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
                NodeArray = BindTrvGroup(strwhere);
                foreach (TreeNode Node in NodeArray)
                {
                    Nodes.ChildNodes.Add(Node);
                }
                TrviewGroup.Nodes.Add(Nodes);

            }
        }



    }
    #region 根据条件返回子TreeNode数组
    /// <summary>
    ///  根据条件返回TreeNode数组
    /// </summary>
    /// <param name="strwhere">查询条件</param>
    /// <returns></returns>
    public TreeNode[] BindTrvGroup(string strwhere)
    {
        DataSet ds = myCustomerGroup.GetList(strwhere);
        DataTable dt = ds.Tables[0];
        TreeNode[] NodeArray = new TreeNode[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow row = ds.Tables[0].Rows[i];
            NodeArray[i] = new TreeNode(row["Name"].ToString(), row["Id"].ToString());
            NodeArray[i].Expanded = false;
            NodeArray[i].SelectAction = TreeNodeSelectAction.SelectExpand;
        }
        return NodeArray;
    }
    #endregion

    #region 通过Value查找指定节点
    /// <summary>
    /// 查找指定节点
    /// </summary>
    /// <param name="tnParent">节点</param>
    /// <param name="strValue">值</param>
    /// <returns></returns>
    private TreeNode FindNode(TreeNode tnParent, string strValue)
    {
        TreeNode treeNode2 = new TreeNode();
        string venueCode = "";
        if (tnParent == null) return null;
        if (tnParent.Value == strValue) return tnParent;
        tnParent.Expand();
        TreeNode tnRet = null;
        foreach (TreeNode tn in tnParent.ChildNodes)
        {
            //获得节点Value
            if (venueCode == "")
            {
                //记录节点
                treeNode2 = tn;
                venueCode = tn.Value;
            }
            else
            {
                //当选择节点发生变化时
                if (venueCode != tn.Value)
                {
                    treeNode2.Collapse();
                    venueCode = tn.Value;
                    treeNode2 = tn;
                }
            }

            tnRet = FindNode(tn, strValue);
            if (tnRet != null) break;
        }
        return tnRet;
    }
    #endregion
    public DataSet GetDataSet(string strwhere,int type)
    { string strsql=string.Empty;
        if (type == 0)
        {
            strsql = "SELECT     dbo.EC_Customer.GroupId,dbo.EC_Customer.Name, dbo.EC_Customer.Mobile, dbo.EC_Customer.Id , " +
                           "  dbo.EC_Customer.NickName, dbo.EC_Customer.CompanyName, dbo.EC_CustomerGroup.Name as GroupName, " +
                           " dbo.EC_Customer.Email" +
                           " FROM         dbo.EC_Customer INNER JOIN" +
                           " dbo.EC_CustomerGroup ON dbo.EC_Customer.GroupId = dbo.EC_CustomerGroup.Id " + strwhere + "";
        }
        else
        {
             strsql ="SELECT     dbo.EC_Customer.GroupId,dbo.EC_Customer.Name, dbo.EC_Customer.Mobile, dbo.EC_Customer.Id ,  "+
                           "   dbo.EC_Customer.NickName, dbo.EC_Customer.CompanyName,  GroupName='我的名片夹',  dbo.EC_Customer.Email"+
                           "  FROM         dbo.EC_Customer " + strwhere + "";

        }
        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(strsql);
        return ds;
    }
    protected void TrviewGroup_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        string str=Request.Form["__EVENTARGUMENT"].ToString();
        DataSet ds = new DataSet();
        string strche=str.Substring(str.LastIndexOf("&")+1);
        int index=str.LastIndexOf("\\\\");
        int lastIndex =0;
        if (index != -1)
        {
            index = index + 2;
            lastIndex = str.LastIndexOf("'");
            str = str.Substring(index, lastIndex - index);
            string strwhere = "ParentId='" + str + "' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
            foreach (TreeNode node in this.TrviewGroup.Nodes)
            {
                TreeNode treeNode = FindNode(node, str);
                if (treeNode != null)
                {
                    treeNode.ExpandAll();
                    treeNode.Selected = true;
                    if (treeNode.ChildNodes.Count == 0)
                    {
                        TreeNode[] NodeArray = BindTrvGroup(strwhere);
                        foreach (TreeNode Node in NodeArray)
                        {
                           
                            treeNode.ChildNodes.Add(Node);
                        }
                    }
                    break;
                }
            }
             ds = GetDataSet(" where GroupId='" + Int32.Parse(str) + "' and dbo.EC_Customer.UserId='" + Public.GetUserId(this.Page).ToString() + "'",0);
        }
        else
        {
            index = str.LastIndexOf("s");
            index = index + 1;
            lastIndex = str.LastIndexOf(")");
            str = str.Substring(index, lastIndex - index - 1);
             ds = GetDataSet(" where  GroupId='" + Int32.Parse(str) + "' and dbo.EC_Customer.UserId='" + Public.GetUserId(this.Page).ToString() + "'",1);
        }

       
        Public.Datalistbind(ds, this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
       
        if (strche != "uncheck")
        {
            DataListItem Dlist = (DataListItem)this.Dlist.Controls[0];
            if (Dlist.ItemType == ListItemType.Header)
            {
                System.Web.UI.HtmlControls.HtmlInputCheckBox chkitem = (System.Web.UI.HtmlControls.HtmlInputCheckBox)Dlist.FindControl("Chkitem");
                chkitem.Checked = true;

            }
            foreach (DataListItem Dli in this.Dlist.Items)
            {
                System.Web.UI.HtmlControls.HtmlInputCheckBox chkitem = (System.Web.UI.HtmlControls.HtmlInputCheckBox)Dli.FindControl("Chkitem");
                chkitem.Checked = true;
            }
            if ((txtphone.Text != "")&&(ds.Tables[0].Rows.Count>0))
            {
                txtphone.Text += "\r\n";
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count;i++)
            {
                if (i != ds.Tables[0].Rows.Count - 1)
                {
                    txtphone.Text += ds.Tables[0].Rows[i]["Mobile"].ToString() + "\r\n";
                }
                else
                {
                    txtphone.Text += ds.Tables[0].Rows[i]["Mobile"].ToString();
                }
            }

        }
        else
        {
            DataListItem Dlist = (DataListItem)this.Dlist.Controls[0];
            if (Dlist.ItemType == ListItemType.Header)
            {
                System.Web.UI.HtmlControls.HtmlInputCheckBox chkitem = (System.Web.UI.HtmlControls.HtmlInputCheckBox)Dlist.FindControl("Chkitem");
                chkitem.Checked =false;

            }
            foreach (DataListItem Dli in this.Dlist.Items)
            {
                System.Web.UI.HtmlControls.HtmlInputCheckBox chkitem = (System.Web.UI.HtmlControls.HtmlInputCheckBox)Dli.FindControl("Chkitem");
                chkitem.Checked = false;
            }
            foreach (DataRow row in ds.Tables[0].Rows)
            {
               index=txtphone.Text.IndexOf(row["Mobile"].ToString());
               if (index != -1)
               {
                   if (txtphone.Text.IndexOf(row["Mobile"].ToString() + "\r\n") == -1)
                   {
                    txtphone.Text = txtphone.Text.Replace(row["Mobile"].ToString(), "");
                   }
                   else
                   {
                    txtphone.Text = txtphone.Text.Replace(row["Mobile"].ToString() + "\r\n", "");

                   }
               }
               
            }
        }
       

        /*选择组织之后右边的的添加组织初始化的操作*/
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        DataSet ds = new DataSet();
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string str = Request.Form["__EVENTARGUMENT"].ToString();
        string strche = str.Substring(str.LastIndexOf("&") + 1);
        int index = str.IndexOf("\\\\");
        int lastIndex = 0;
        if (index != -1)
        {
            index = index + 2;
            lastIndex = str.LastIndexOf("'");
            str = str.Substring(index, lastIndex - index);
            ds = GetDataSet(" where GroupId='" + Int32.Parse(str) + "' and dbo.EC_Customer.UserId='" + Public.GetUserId(this.Page).ToString() + "'", 0);

        }
        else
        {
            index = str.LastIndexOf("s");
            index = index + 1;
            lastIndex = str.LastIndexOf(")");
            str = str.Substring(index, lastIndex - index - 1);
            ds = GetDataSet(" where  GroupId='" + Int32.Parse(str) + "' and dbo.EC_Customer.UserId='" + Public.GetUserId(this.Page).ToString() + "'", 1);

        }
     
        Public.Datalistbind(ds, this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
        


    }

}
