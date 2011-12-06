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
public partial class mybase_ViewBase :PageBase
{
    public string strwhere = string.Empty;
    public ECSMS.BLL.EC_Numbers myNumbers = new ECSMS.BLL.EC_Numbers();
    public ECSMS.Model.EC_Numbers newNumbers = new ECSMS.Model.EC_Numbers();
    ECSMS.BLL.EC_NumbersGroup myNumbersGroup = new ECSMS.BLL.EC_NumbersGroup();
    ECSMS.Model.EC_NumbersGroup newNumbersGroup = new ECSMS.Model.EC_NumbersGroup();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            if (Public.GetUserId(this.Page) != "")
            {
                TreeNode Nodes = new TreeNode("我的数据库", "0");
                strwhere = "ParentId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
                TreeNode[] NodeArray = BindTrvGroup(strwhere);
                foreach (TreeNode Node in NodeArray)
                {
                    Nodes.ChildNodes.Add(Node);
                }
                TrviewGroup.Nodes.Add(Nodes);
                Nodes = new TreeNode("公共数据库", "-1");
                strwhere = "ParentId='-1' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
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

        DataSet ds = myNumbersGroup.GetList(strwhere);
        DataTable dt = ds.Tables[0];
        TreeNode[] NodeArray = new TreeNode[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow row = ds.Tables[0].Rows[i];
            string groupName = string.Empty;
            groupName = row["userid"].ToString() == "sys" ? row["Name"].ToString()+"("+row["price"]+")" : row["Name"].ToString();
            NodeArray[i] = new TreeNode(groupName, row["Id"].ToString());
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
    public DataSet GetDataSet(string strwhere, int type,string str)
    {
        string strsql = string.Empty;
        if (type == 0)
        {
            strsql = " SELECT     dbo.EC_NumbersGroup.Id, dbo.EC_Numbers.GroupId, dbo.EC_Numbers.Number " +
                          " FROM         dbo.EC_Numbers INNER JOIN " +
                          " dbo.EC_NumbersGroup ON dbo.EC_Numbers.GroupId = dbo.EC_NumbersGroup.Id " + strwhere + "";
        }
        else
        {

            strsql = "SELECT    Id='"+str+"', dbo.EC_Numbers.GroupId, dbo.EC_Numbers.Number " +
                          "  FROM           dbo.EC_Numbers " + strwhere + "";



        }
        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(strsql);
        return ds;
    }

    protected void TrviewGroup_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        string str = Request.Form["__EVENTARGUMENT"].ToString();
        string strwhere = string.Empty;
        string strche = str.Substring(str.LastIndexOf("&") + 1);
        int index = str.LastIndexOf("\\\\");
        int lastIndex = 0;
        if (index != -1)
        {
            index = index + 2;
            lastIndex = str.LastIndexOf("'");
            str = str.Substring(index, lastIndex - index);
            strwhere = " ParentId='"+str+"' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
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
        }
        else
        {
            index = str.LastIndexOf("s");
            index = index + 1;
            lastIndex = str.LastIndexOf(")");
            str = str.Substring(index, lastIndex - index - 1);
        }
        DataSet ds = new DataSet();
        if ((str == "0") || (str == "-1"))
        {
            ds = GetDataSet(" where GroupId='" + Int32.Parse(str) + "'  and EC_Numbers.UserId='" + Public.GetUserId(this.Page).ToString() + "'", 1, str);
        }
        else
        {
            ds = GetDataSet(" where GroupId='" + Int32.Parse(str) + "' and EC_Numbers.UserId='" + Public.GetUserId(this.Page).ToString() + "'", 0, str);
        }

        if (strche != "uncheck")
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                txtphone.Text += row["Number"].ToString() + "\r\n";
            }
        }
        else
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                index = txtphone.Text.IndexOf(row["Number"].ToString());
                if (index != -1)
                {
                    txtphone.Text = txtphone.Text.Replace(row["Number"].ToString() + "\r\n", "");
                }

            }
        }


        /*选择组织之后右边的的添加组织初始化的操作*/
    }
   
}
