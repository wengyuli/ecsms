using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Data;
public partial class ViewPhrase :PageBase
{
    public string strwhere = string.Empty;
    public ECSMS.BLL.EC_Phrase myPhrase = new ECSMS.BLL.EC_Phrase();
    public ECSMS.Model.EC_Phrase newPhrase = new ECSMS.Model.EC_Phrase();
    ECSMS.BLL.EC_PhraseGroup myPhraseGroup = new ECSMS.BLL.EC_PhraseGroup();
    ECSMS.Model.EC_PhraseGroup newPhraseGroup = new ECSMS.Model.EC_PhraseGroup();
    ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
    ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            
            if (Public.GetUserId(this.Page) != "")
            {
                this.dropGroup.DataSource = myPhraseGroup.GetList( " UserId='"+Public.GetUserId(this.Page)+"' ");
                this.dropGroup.DataTextField = "Name";
                this.dropGroup.DataValueField = "Id";
                this.dropGroup.DataBind();
                string strsql = " GroupId='" + this.dropGroup.SelectedValue + "' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
                DataSet ds = myPhrase.GetList(strsql);
                Public.Datalistbind(ds, this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
            }
        }
    }
    #region 根据条件返回子TreeNode数组
    /// <summary>
    ///  根据条件返回TreeNode数组
    /// </summary>
    /// <param name="strwhere">查询条件</param>
    /// <returns></returns>
    public ListItem[] BindTrvGroup(string strwhere)
    {

        DataSet ds = myPhraseGroup.GetList(strwhere);
        DataTable dt = ds.Tables[0];
        ListItem[] NodeArray = new ListItem[dt.Rows.Count];
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow row = ds.Tables[0].Rows[i];
            NodeArray[i] = new ListItem(row["Name"].ToString(), row["Id"].ToString());
          
        }
        return NodeArray;
    }
    #endregion

   
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strsql = string.Empty;
        if ((this.rbtnSelect.SelectedValue == "public"))
        {
            strsql= " GroupId='" + this.dropGroup.SelectedValue + "' and UserId='sys'";
        }
        else
        {
            strsql = " GroupId='" + this.dropGroup.SelectedValue + "' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
 
        }
        DataSet ds = myPhrase.GetList(strsql);
        Public.Datalistbind(ds, this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);

    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.dropGroup.Items.Clear();
        string strsql = string.Empty;
        if ((this.rbtnSelect.SelectedValue == "public"))
        {
            strwhere = " UserId='sys'";
        }
        else
        {
            strwhere = " UserId='" + Public.GetUserId(this.Page).ToString() + "'";
        }
        ListItem[] NodeArray = BindTrvGroup(strwhere);
        if (NodeArray.Length > 0)
        {
            int i = 0;
            foreach (ListItem item in NodeArray)
            {

                if (i == 0)
                {
                    item.Selected = true;
                }
                this.dropGroup.Items.Add(item);
                i = i + 1;
            }
        }
        string strValue = string.Empty;

        if ((this.rbtnSelect.SelectedValue == "public"))
        {
            strsql = " GroupId='" + this.dropGroup.SelectedValue + "' and UserId='sys'";
        }
        else
        {

            strsql = " GroupId='" + this.dropGroup.SelectedValue + "' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";

        }

        /*选择组织之后右边的的添加组织初始化的操作*/
        DataSet ds = myPhrase.GetList(strsql);
        Public.Datalistbind(ds, this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
    }


    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        string strsql = string.Empty;
        if ((this.rbtnSelect.SelectedValue == "public"))
        {
            strsql = " GroupId='" + this.dropGroup.SelectedValue + "' and UserId='sys'";
        }
        else
        {
            strsql = " GroupId='" + this.dropGroup.SelectedValue + "' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";

        }
        DataSet ds = myPhrase.GetList(strsql);
        Public.Datalistbind(ds, this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
    }

    
}
