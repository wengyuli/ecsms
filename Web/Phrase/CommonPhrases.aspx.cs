using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Data;
public partial class Contact_Common_Phrases :PageBase
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
        if (!IsPostBack)
        { 
            if (Public.GetUserId(this.Page) != "")
            {
                newUser = myUser.GetModel(Int32.Parse(Public.GetUserId(this.Page).ToString()));
                TreeNode Node = new TreeNode();
                lbRole.Text = newUser.Role.ToString();
                if (newUser.Role != 0)
                {
                    Node = new TreeNode();
                    Node.Value = "my";
                    Node.Text = "我的短语库";
                    TrviewGroup.Nodes.Add(Node);
                    Node = new TreeNode();
                    Node.Value = "public";
                    Node.Text = "公共短语库";
                    TrviewGroup.Nodes.Add(Node);
                }
                else
                {
                    Node.Value = "public";
                    Node.Text = "公共短语库";
                    TrviewGroup.Nodes.Add(Node);
                }
                
            }
            this.PanelAddGroup.Visible = false;
            this.PanelAddPhrase.Visible = false;
            this.Panelist.Visible = false;
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
      
        DataSet ds = myPhraseGroup.GetList(strwhere);
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
    protected void TrviewGroup_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.btnEditGroup.Visible =false;
        this.btndelGroup.Visible = false;
        string strsql=string.Empty;
        TreeNode SelectNode = this.TrviewGroup.SelectedNode;
        this.lbtnAddPhrase.Visible = true;
        this.lbtnAddPhraseGroup.Visible = true;
        this.btndelGroup.Visible = true;
        this.btnEditGroup.Visible = true;
        this.btndel.Visible = true;
        this.lbSelect.Text = SelectNode.Value;
        if((TrviewGroup.SelectedNode.Value=="public"))
        {
            strwhere = " ParentId='-1' and UserId='sys'";
            strsql = " GroupId='-1' and UserId='sys'";
           this.lbPhraseGroupId.Text ="-1";
           this.lbPraseGroup.Text = "公共短语库";
           if (lbRole.Text != "0")
           {
               this.lbtnAddPhrase.Visible = false;
               this.lbtnAddPhraseGroup.Visible = false;
               this.btndelGroup.Visible = false;
               this.btnEditGroup.Visible = false;
               this.btndel.Visible = false;
               this.lbtnAddPhrase.Visible = false;
           }

        }
        else if (TrviewGroup.SelectedNode.Value == "my")
        {
            strwhere = " ParentId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
            strsql = " GroupId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
            this.lbPhraseGroupId.Text = "0";
            this.lbPraseGroup.Text = "我的短语库";
            this.lbtnAddPhrase.Visible = false;

        }
        else
        {
           strwhere = " ParentId='" + SelectNode.Value + "'";
           strsql = " GroupId='" + SelectNode.Value + "'";
           this.lbPhraseGroupId.Text = SelectNode.Value;
           this.lbPraseGroup.Text = SelectNode.Text;
           this.btndelGroup.Visible = true;
           this.btnEditGroup.Visible = true;
           newPhraseGroup = new ECSMS.Model.EC_PhraseGroup();
           newPhraseGroup = myPhraseGroup.GetModel(Int32.Parse(this.TrviewGroup.SelectedNode.Value));
            if (newPhraseGroup.UserId == "sys")
            {
                if (lbRole.Text != "0")
                {
                    this.lbtnAddPhrase.Visible = false;
                    this.lbtnAddPhraseGroup.Visible = false;
                    this.btndelGroup.Visible = false;
                    this.btnEditGroup.Visible = false;
                    this.btndel.Visible = false;
                }
            }
        }
        TreeNode[] NodeArray = BindTrvGroup(strwhere);
        if (NodeArray.Length > 0)
        {
            this.TrviewGroup.SelectedNode.ChildNodes.Clear();
            foreach (TreeNode Node in NodeArray)
            {

                SelectNode.ChildNodes.Add(Node);

            }
        }
        /*选择组织之后右边的的添加组织初始化的操作*/
     
        this.lbSelect.Text = SelectNode.Value;
        this.lbCount.Text = Public.ColumCount(strsql, "EC_Phrase").ToString();
        this.lbCount.Visible = false;
        this.lbTishi.Text = "您选择的当前分组为:【" + SelectNode.Text + "】 本组中共有:【" + this.lbCount.Text + "】短语";
        this.lbParent.Text = SelectNode.Text;
        this.txtGroupName.Text = "";
        DataSet ds = myPhrase.GetList(strsql);
            /*选择组织之后右边的的添加组织初始化的操作*/
        this.lbtype.Text = "1";
        ShowControl();
        Public.Datalistbind(ds, this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
      
        
    }
    protected void lbtnAddCums_Click(object sender, EventArgs e)
    {
        
        this.lbtype.Text = "3";
        this.PanelAddGroup.Visible = false;
        this.PanelAddPhrase.Visible = true;
        this.btnSave.Text = "保存";
        this.btnSave.CommandName = "add";
        MadeCumsVoid();
        this.Panelist.Visible = false;
        if (this.lbPraseGroup.Text == "")
        {
            this.btnSave.Enabled = false;
            MessageBox.Show(this.Page, "请在左侧选择你要添加的短语所属的分组！");
        }
        else
        {
            this.btnSave.Enabled = true;
        }
    }
    #region 添加用户控件值赋空值
    public void MadeCumsVoid()
    {
        txtName.Text = "";
        this.lbtype.Text = "3";
        ShowControl();
      
    }
    #endregion
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strsql = string.Empty;
        if (this.btnSave.CommandName == "edit")
        {
            newPhrase = myPhrase.GetModel(Int32.Parse(this.lbPraseId.Text));
        }
        newPhrase.Phrase = txtName.Text;
       
            newPhrase.GroupId = Int32.Parse(this.lbPhraseGroupId.Text);
        
        if (Public.GetUserId(this.Page) != null)
        {
            newPhrase.UserId = Public.GetUserId(this.Page).ToString();
            
        }
        if (this.btnSave.CommandName == "add")
        {
            int i = myPhrase.Add(newPhrase);
            if (i > 0)
            {
                MessageBox.Show(this.Page, "添加短语成功！");
                this.lbCount.Text = (Int32.Parse(this.lbCount.Text) + 1).ToString();
                if (this.ChCusKeep.Checked)
                {
                    MadeCumsVoid();
                    return;
                }
                else
                {
                    
                    this.lbtype.Text = "1";
                    ShowControl();
                }
            }
            else
            {
                MessageBox.Show(this.Page, "添加失败！");
            }
        }
        else
        {
            myPhrase.Update(newPhrase);
            MessageBox.Show(this.Page, "保存成功！");
            this.lbtype.Text = "1";
            ShowControl();
        }
        TreeNode SelectNode = this.TrviewGroup.SelectedNode;
        if ((TrviewGroup.SelectedNode.Value == "public"))
        {
            strwhere = " ParentId='-1' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
            strsql = " GroupId='-1' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
            this.lbPhraseGroupId.Text = "-1";
            this.lbPraseGroup.Text = "公共短语库";

        }
        else if (TrviewGroup.SelectedNode.Value == "my")
        {
            strwhere = " ParentId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
            strsql = " GroupId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
            this.lbPhraseGroupId.Text = "0";
            this.lbPraseGroup.Text = "我的短语库";
        }
        else
        {
            strwhere = " ParentId='" + SelectNode.Value + "'";
            strsql = " GroupId='" + SelectNode.Value + "'";
            this.lbPhraseGroupId.Text = SelectNode.Value;
            this.lbPraseGroup.Text = SelectNode.Text;

        }
        DataSet ds = myPhrase.GetList(strsql);
        /*选择组织之后右边的的添加组织初始化的操作*/
        Public.Datalistbind(ds, this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
        this.panelPrasecon.Visible = true;
    }
    protected void btnSaveGruop_Click(object sender, EventArgs e)
    {
       newPhraseGroup.Name = txtGroupName.Text;
       if (this.TrviewGroup.SelectedNode.Value == "public")    //判断父组织是否为公共短语库
       {
           newPhraseGroup.UserId = "sys";
           newPhraseGroup.ParentId = -1;

       }
       else if (this.TrviewGroup.SelectedNode.Value == "my")  //判断父组织是否为我的短语库
       {
           newPhraseGroup.UserId = Public.GetUserId(this.Page).ToString();
           newPhraseGroup.ParentId = 0;

       }
       else
       {
           newPhraseGroup.ParentId = Int32.Parse(this.TrviewGroup.SelectedNode.Value);
           ECSMS.Model.EC_PhraseGroup newPhraseGroupforUser = new ECSMS.Model.EC_PhraseGroup();
           newPhraseGroupforUser = myPhraseGroup.GetModel(Int32.Parse(this.TrviewGroup.SelectedNode.Value));
           if (newPhraseGroupforUser.UserId == "sys")
           {
               newPhraseGroup.UserId = "sys";
           }
           else
           {
               newPhraseGroup.UserId = Public.GetUserId(this.Page).ToString();
           }
       }
       int i= myPhraseGroup.Add(newPhraseGroup);
       if (i != -1)
       {
           MessageBox.Show(this.Page, "添加组成功!");
           this.TrviewGroup.SelectedNode.ChildNodes.Add(new TreeNode(newPhraseGroup.Name, i.ToString()));
           if (ChGroupKeep.Checked)
           {
               MadeGroupVoid();
           }
           else
           {
               this.lbtype.Text = "5";
               ShowControl();
           }
       }
       else
       {
           MessageBox.Show(this.Page, "添加失败!");
       }
       
    }
    #region 添加组控件值赋空值
    public void MadeGroupVoid()
    {
        txtGroupName.Text = "";
       
    }
    #endregion
    protected void lbtnAddGroup_Click(object sender, EventArgs e)
    {
       this.lbtype.Text = "2";
       this.PanelAddGroup.Visible = true;
       this.PanelAddPhrase.Visible = false;
       this.Panelist.Visible = false;
       if (lbPhraseGroupId.Text == "")
       {
           this.btnSaveGruop.Enabled = false;
           MessageBox.Show(this.Page, "请在左侧选择你要添加的分组的父组织！");
           MadeGroupVoid();
        }
       else
       {
           this.btnSaveGruop.Enabled = true;
       }

    }
    protected void btndelGroup_Click(object sender, EventArgs e)
    {
        TreeNode SelectNode = this.TrviewGroup.SelectedNode;
        if (SelectNode.ChildNodes.Count > 0)
        {
            MessageBox.Show(this.Page, "改组包含子分组请先移除子分组！");
        }
        if (SelectNode == null)
        {
            MessageBox.Show(this.Page, "请在左侧选择您要删除的组！");
        }
        else
        {
            DataSet ds =myPhrase.GetList(" GroupId='" + SelectNode.Value + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(this.Page, "对不起分组【" + SelectNode.Text + "】中存在短语信息，请先移除组内所有短语信息后再删除该组！");
                return;
            }
            else
            {
                myPhraseGroup.Delete(Int32.Parse(SelectNode.Value.ToString()));
                MessageBox.Show(this.Page, "【"+SelectNode.Text + "】删除成功！");
                SelectNode.Parent.ChildNodes.Remove(SelectNode);
                this.lbtype.Text = "4";
                ShowControl();
            }
        }
    }
    protected void Dlist_EditCommand(object source, DataListCommandEventArgs e)
    {
        this.btnSave.CommandName = "edit";

        newPhrase =myPhrase.GetModel(Int32.Parse(e.CommandArgument.ToString()));
        this.lbPraseId.Text= newPhrase.Id.ToString();
        this.Panelist.Visible = false;
        this.PanelAddPhrase.Visible = true;
        this.lbPraseId.Text = e.CommandArgument.ToString();
        txtName.Text = newPhrase.Phrase.ToString();
        if (newPhrase.GroupId > 0)
        {
            newPhraseGroup = myPhraseGroup.GetModel(newPhrase.GroupId.Value);

            this.lbPhraseGroupId.Text = newPhraseGroup.Id.ToString();
        }
        else
        {
            if (this.TrviewGroup.SelectedNode.Text == "my")
                this.lbPhraseGroupId.Text = "0";
            else
                this.lbPhraseGroupId.Text = "-1";
        }
         this.lbPraseGroup.Text =this.TrviewGroup.SelectedNode.Text;
      
        this.panelPrasecon.Visible = false;
        this.btnSave.Visible = true;
        if ((TrviewGroup.SelectedNode.Value == "public"))
        {
            if (lbRole.Text != "0")
            {
                this.btnSave.Visible = false;
            }

        }
        else
        {
            if ((this.TrviewGroup.SelectedNode.Value == "my")  )
            {
                this.btnSave.Visible = true;
            }
            else if (TrviewGroup.SelectedNode.Value == "public")
            {
                if (lbRole.Text != "0")
                {
                    this.btnSave.Visible = false;
                }
            }
            else
            {
                newPhraseGroup.ParentId = Int32.Parse(this.TrviewGroup.SelectedNode.Value);
                ECSMS.Model.EC_PhraseGroup newPhraseGroupforUser = new ECSMS.Model.EC_PhraseGroup();
                newPhraseGroupforUser = myPhraseGroup.GetModel(Int32.Parse(this.TrviewGroup.SelectedNode.Value));
                if (newPhraseGroup.UserId == "sys")
                {
                    if (lbRole.Text != "0")
                    {
                        this.btnSave.Visible = false;
                    }
                }
            }
        }
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (DataListItem Dli in this.Dlist.Items)
            {
                System.Web.UI.HtmlControls.HtmlInputCheckBox chkitem = (System.Web.UI.HtmlControls.HtmlInputCheckBox)Dli.FindControl("Chkitem");
                LinkButton Phraseid = (LinkButton)Dli.FindControl("lbtnEdit");
                if (chkitem.Checked)
                {

                    myPhrase.Delete(Int32.Parse(Phraseid.CommandArgument));
                    MessageBox.Show(this.Page, "删除成功！");
                }
            }
            Public.Datalistbind(myPhrase.GetList("GroupId='" + lbPhraseGroupId.Text + "'"), this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.Page, ex.Message.ToString());
        }
    }
    protected void btnCaneclGruop_Click(object sender, EventArgs e)
    {
        this.PanelAddGroup.Visible =false;
        this.PanelAddPhrase.Visible = false;
        this.Panelist.Visible = true;
    }
    protected void btnCaneclPhrase_Click(object sender, EventArgs e)
    {
        this.Panelist.Visible = true;
        this.PanelAddPhrase.Visible = false;
    }

    #region 根据条件决定那个panel显示
    /// <summary>
    /// 根据条件决定那个panel显示
    /// </summary>

    public void ShowControl()
    {
        switch (this.lbtype.Text)
        {
            case "1": this.PanelEditGroup.Visible = false; this.PaneoPerate.Visible = true; this.PanelAddPhrase.Visible = false; this.PanelAddGroup.Visible = false; this.Panelist.Visible = true; break;
            case "2": this.PanelEditGroup.Visible = false; this.PaneoPerate.Visible = true; this.PanelAddPhrase.Visible = false; this.PanelAddGroup.Visible = true; this.Panelist.Visible = false; break;
            case "3": this.PanelEditGroup.Visible = false; this.PaneoPerate.Visible = true; this.PanelAddPhrase.Visible = true; this.PanelAddGroup.Visible = false; this.Panelist.Visible = false; break;
            case "4": this.PanelEditGroup.Visible = false; this.PaneoPerate.Visible = false; this.PanelAddPhrase.Visible = false; this.PanelAddGroup.Visible = false; this.Panelist.Visible = false; break;
            case "5": this.PanelEditGroup.Visible = false; this.PaneoPerate.Visible = true; this.PanelAddPhrase.Visible = false; this.PanelAddGroup.Visible = false; this.Panelist.Visible = false; break;
            case "6": this.PanelEditGroup.Visible = true; this.PaneoPerate.Visible = true; this.PanelAddPhrase.Visible = false; this.PanelAddGroup.Visible = false; this.Panelist.Visible = false; break;
        }
    }
    #endregion
    protected void btnEditGroup_Click(object sender, EventArgs e)
    {
        this.lbtype.Text = "6";
        ShowControl();
        if (lbPhraseGroupId.Text == "")
        {
            this.btnSaveGruop.Enabled = false;
            MessageBox.Show(this.Page, "请在左侧选择你要添加的分组的父组织！");
            this.txtEditGroupName.Text = "";
        }
        else
        { 
            newPhraseGroup=myPhraseGroup.GetModel(Int32.Parse(this.TrviewGroup.SelectedNode.Value));
            this.txtEditGroupName.Text = newPhraseGroup.Name;
            this.btnEditGroup.Enabled = true;
        }
    }
    protected void btnEditGroupName_Click(object sender, EventArgs e)
    {
        TreeNode SelectNode = this.TrviewGroup.SelectedNode;
       
        newPhraseGroup = myPhraseGroup.GetModel(Int32.Parse(this.TrviewGroup.SelectedNode.Value));
        if (newPhraseGroup.Name != this.txtEditGroupName.Text)
        {
            newPhraseGroup.Name = this.txtEditGroupName.Text;
            myPhraseGroup.Update(newPhraseGroup);
            SelectNode.Text = this.txtEditGroupName.Text;
            this.lbTishi.Text = "您选择的当前分组为:【" +this.txtEditGroupName.Text + "】 本组中共有:" + this.lbCount.Text + "短语";

        }
        MessageBox.Show(this.Page, "更新组成功！");
        this.lbtype.Text = "1";
        ShowControl();


    }

    protected void btnEditBack_Click(object sender, EventArgs e)
    {
        this.lbtype.Text = "1";
        ShowControl();
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
   {
       AspNetPager1.CurrentPageIndex = e.NewPageIndex;
       string strsql = string.Empty;
       TreeNode SelectNode = this.TrviewGroup.SelectedNode;
       if ((TrviewGroup.SelectedNode.Value == "public"))
       {
           strwhere = " ParentId='-1' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
           strsql = " GroupId='-1' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
           this.lbPhraseGroupId.Text = "-1";
           this.lbPraseGroup.Text = "公共短语库";

       }
       else if (TrviewGroup.SelectedNode.Value == "my")
       {
           strwhere = " ParentId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
           strsql = " GroupId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
           this.lbPhraseGroupId.Text = "0";
           this.lbPraseGroup.Text = "我的短语库";
           this.btndelGroup.Visible = false;
           this.btnEditGroup.Visible = false;
       }
       else
       {
           strwhere = " ParentId='" + SelectNode.Value + "'";
           strsql = " GroupId='" + SelectNode.Value + "'";
           this.lbPhraseGroupId.Text = SelectNode.Value;
           this.lbPraseGroup.Text = SelectNode.Text;

       }
       DataSet ds = myPhrase.GetList(strsql);
       /*选择组织之后右边的的添加组织初始化的操作*/
       Public.Datalistbind(ds, this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
   }
}
