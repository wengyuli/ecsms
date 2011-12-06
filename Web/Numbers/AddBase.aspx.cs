using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;
using System.Data;
using System.Collections;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
public partial class mybase_AddBase :PageBase
{
    public string strwhere = string.Empty;
    public ECSMS.BLL.EC_Numbers myNumbers = new ECSMS.BLL.EC_Numbers();
    public ECSMS.Model.EC_Numbers newNumbers = new ECSMS.Model.EC_Numbers();
    ECSMS.BLL.EC_NumbersGroup myNumbersGroup = new ECSMS.BLL.EC_NumbersGroup();
    ECSMS.Model.EC_NumbersGroup newNumbersGroup = new ECSMS.Model.EC_NumbersGroup();
    ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
    ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (!IsPostBack)
        {
           

            if (Public.GetUserId(this.Page) != "")
            {
                newUser = myUser.GetModel(Int32.Parse(Public.GetUserId(this.Page).ToString()));
                if (newUser != null)
                {
                    TreeNode Node = new TreeNode();
                    lbRole.Text = newUser.Role.ToString();
                    if (newUser.Role != 0)
                    {
                        Node = new TreeNode();
                        Node.Value = "my";
                        Node.Text = "我的数据库";
                        TrviewGroup.Nodes.Add(Node);

                        Node = new TreeNode();
                        Node.Value = "public";
                        Node.Text = "公共数据库";
                        TrviewGroup.Nodes.Add(Node);
                        this.PanelPrice.Visible = false;
                    }
                    else
                    {
                        Node.Value = "public";
                        Node.Text = "公共数据库";
                        TrviewGroup.Nodes.Add(Node);
                        this.PanelPrice.Visible = true;
                    }

                }
                this.PanelAddGroup.Visible = false;
                this.PanelAddmyBase.Visible = false;
                this.Panelist.Visible = false;
            }
            else
            {
                MessageBox.Show(this.Page, "请登录！");
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
            NodeArray[i] = new TreeNode(row["Name"].ToString(), row["Id"].ToString());
            NodeArray[i].Expanded = false;
            NodeArray[i].SelectAction = TreeNodeSelectAction.SelectExpand;
        }
        return NodeArray;
    }
    #endregion

    protected void TrviewGroup_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.btnEditGroup.Visible = false;
        this.btndelGroup.Visible = false;
        string strsql = string.Empty;
        TreeNode SelectNode = this.TrviewGroup.SelectedNode;
        this.lbtnAddmyBase.Visible = true;
        this.lbtnAddmyBaseGroup.Visible = true;
        this.btnCusExport.Visible = true;
        this.btnImport.Visible = true;
        this.btnImportCus.Visible = true;
        this.btndel.Visible = true;
        this.lbtnAddmyBase.Visible = true;
        this.btnpubup.Visible = false;
        this.droppubup.Visible = false;
        this.lbSelect.Text = SelectNode.Value;
        this.lbTishi.Text = "您选择的当前分组为:【" + SelectNode.Text + "】";
        if ((TrviewGroup.SelectedNode.Value == "public"))
        {
            strwhere = " ParentId='-1' and UserId='sys'";
            strsql = " GroupId='-1' and UserId='sys'";
            this.lbmyBaseGroupId.Text = "-1";
            this.lbvalue.Text = "sys";
            this.lbPraseGroup.Text = "公共号码库";
            this.btndelGroup.Visible = false;
            this.btnEditGroup.Visible = false;
            if (lbRole.Text != "0")
            {
                
                this.lbtnAddmyBase.Visible = false;
                this.lbtnAddmyBaseGroup.Visible = false;
                this.btnCusExport.Visible = false;
                this.btnImport.Visible = false;
                this.btnImportCus.Visible = false;

            }
          
       }
        else if (TrviewGroup.SelectedNode.Value == "my")
        {
           
            strwhere = " ParentId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
            strsql = " GroupId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
            this.lbmyBaseGroupId.Text = "0";
            this.lbPraseGroup.Text = "我的数据库";
            this.btndelGroup.Visible = false;
            this.btnEditGroup.Visible = false;
            this.lbtnAddmyBase.Visible = false;
            this.btnImport.Visible = false;
        }
        else
        {
            
            newNumbersGroup = myNumbersGroup.GetModel(Int32.Parse(SelectNode.Value));
            this.lbTishi.Text += "本组的价格为【" + newNumbersGroup.Price + "】";
            this.btndelGroup.Visible = true;
            this.btnEditGroup.Visible = true;
            this.btndel.Visible = true;
            if (newNumbersGroup.UserId == "sys")
            {
                if (lbRole.Text != "0")
                {
                    this.lbtnAddmyBase.Visible = false;
                    this.lbtnAddmyBaseGroup.Visible = false;
                    this.btnCusExport.Visible = false;
                    this.btnImport.Visible = false;
                    this.btnImportCus.Visible = false;
                    this.btndelGroup.Visible =false;
                    this.btnEditGroup.Visible = false;
                    this.btndel.Visible = false;
                    this.btnpubup.Visible = true;
                    this.droppubup.Visible = true;
                }
                this.lbvalue.Text = "sys";
            }
            strwhere = " ParentId='" + SelectNode.Value + "'";
            strsql = " GroupId='" + SelectNode.Value + "'";
            this.lbmyBaseGroupId.Text = SelectNode.Value;
            this.lbPraseGroup.Text = SelectNode.Text;
            
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
        this.lbCount.Text = Public.ColumCount(strsql, "EC_Numbers").ToString();
        this.lbTishi.Text += "本组中共有:【" + this.lbCount.Text + "】号码";
        this.lbCount.Visible = false;
        this.lbParent.Text = SelectNode.Text;
        this.txtGroupName.Text = "";
        DataSet ds = myNumbers.GetList(strsql);
        /*选择组织之后右边的的添加组织初始化的操作*/
        this.lbtype.Text = "1";
        ShowControl();
        Public.Datalistbind(ds, this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);

      
    }
    protected void lbtnAddCums_Click(object sender, EventArgs e)
    {

        this.lbtype.Text = "3";
        this.PanelAddGroup.Visible = false;
        this.PanelAddmyBase.Visible = true;
        this.btnSave.Text = "保存";
        this.btnSave.CommandName = "add";
        MadeCumsVoid();
        this.Panelist.Visible = false;
        if (this.lbPraseGroup.Text == "")
        {
            this.btnSave.Enabled = false;
            MessageBox.Show(this.Page, "请在左侧选择你要添加的号码所属的分组！");
        }
        else
        {
            this.btnSave.Enabled = true;
        }
    }
    #region 添加用户控件值赋空值
    public void MadeCumsVoid()
    {
        this.txtMobile.Text = "";
        this.lbtype.Text = "3";
        this.txtRemark.Text = "";
        this.lbViewTishi.Visible = false;
        ShowControl();

    }
    #endregion
    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strsql = string.Empty;
        if (this.btnSave.CommandName == "edit")
        {
            newNumbers = myNumbers.GetModel(Int32.Parse(this.lbPraseId.Text));
        }
        TreeNode SelectNode = this.TrviewGroup.SelectedNode;
        if ((TrviewGroup.SelectedNode.Value == "public"))
        {
            newNumbers.GroupId = -1;
            newNumbers.UserId = "sys";


        }
        else if (TrviewGroup.SelectedNode.Value == "my")
        {
            newNumbers.GroupId = 0;
            if (Public.GetUserId(this.Page) != null)
            {
                newNumbers.UserId = Public.GetUserId(this.Page).ToString();

            }
        }
        else
        {   
            newNumbers.GroupId = Int32.Parse(this.lbmyBaseGroupId.Text);
             if (Public.GetUserId(this.Page) != null)
            {
                newNumbers.UserId = Public.GetUserId(this.Page).ToString();

            }


        }
        newNumbers.Remark = txtRemark.Text;
        if (this.btnSave.CommandName == "add")
        {
            newNumbers.Number = txtMobile.Text;

            int i = myNumbers.Add(newNumbers);
            if (i > 0)
            {
                MessageBox.Show(this.Page, "添加号码成功！");
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
            newNumbers.Number = txtMobile.Text;
            myNumbers.Update(newNumbers);
            MessageBox.Show(this.Page, "保存成功！");
            this.lbtype.Text = "1";
            ShowControl();
        }
      
        if ((TrviewGroup.SelectedNode.Value == "public"))
        {
            strwhere = " ParentId='-1' and UserId='sys'";
            strsql = " GroupId='-1' and UserId='sys'";
            this.lbmyBaseGroupId.Text = "-1";
            this.lbPraseGroup.Text = "公共数据库";

        }
        else if (TrviewGroup.SelectedNode.Value == "my")
        {
            strwhere = " ParentId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
            strsql = " GroupId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
            this.lbmyBaseGroupId.Text = "0";
            this.lbPraseGroup.Text = "我的数据库";
        }
        else
        {
            strwhere = " ParentId='" + SelectNode.Value + "'";
            strsql = " GroupId='" + SelectNode.Value + "'";
            this.lbmyBaseGroupId.Text = SelectNode.Value;
            this.lbPraseGroup.Text = SelectNode.Text;

        }
        DataSet ds = myNumbers.GetList(strsql);
        /*选择组织之后右边的的添加组织初始化的操作*/
        Public.Datalistbind(ds, this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
        this.panelPrasecon.Visible = true;
    }
    protected void btnSaveGruop_Click(object sender, EventArgs e)
    {
        newNumbersGroup.Name = txtGroupName.Text;
        if (this.TrviewGroup.SelectedNode.Value == "public")    //判断父组织是否为公共数据库
        {
            newNumbersGroup.UserId = "sys";
            newNumbersGroup.ParentId = -1;
            newNumbersGroup.Price = Int32.Parse( this.txtPrice.Text);
        }
        else if (this.TrviewGroup.SelectedNode.Value == "my")  //判断父组织是否为我的数据库
        {
            newNumbersGroup.UserId =Public.GetUserId(this.Page).ToString();
            newNumbersGroup.ParentId = 0;

        }
        else
        {
            newNumbersGroup.ParentId = Int32.Parse(this.TrviewGroup.SelectedNode.Value);
            ECSMS.Model.EC_NumbersGroup newNumbersNumbersforUser = new ECSMS.Model.EC_NumbersGroup();
            newNumbersNumbersforUser = myNumbersGroup.GetModel(Int32.Parse(this.TrviewGroup.SelectedNode.Value));
            if (newNumbersNumbersforUser.UserId == "sys")
            {
                newNumbersGroup.UserId ="sys";

            }
            else
            {
                newNumbersGroup.UserId=Public.GetUserId(this.Page).ToString();
            }
        }
        int i = myNumbersGroup.Add(newNumbersGroup);
        if (i != -1)
        {
            MessageBox.Show(this.Page, "添加数据库成功!");
            this.TrviewGroup.SelectedNode.ChildNodes.Add(new TreeNode(newNumbersGroup.Name, i.ToString()));
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
        this.txtPrice.Text = "";
        this.lbViewTishi.Visible = false;

    }
    #endregion
    protected void lbtnAddGroup_Click(object sender, EventArgs e)
    {
        this.lbtype.Text = "2";
        this.lbViewTishi.Visible = false;
        ShowControl();
        if (lbmyBaseGroupId.Text == "")
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
            DataSet ds = myNumbers.GetList(" GroupId='" + SelectNode.Value + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(this.Page, "对不起分组【" + SelectNode.Text + "】中存在号码，请先移除组内所有号码信息在删除该组！");
                return;
            }
            else
            {
                myNumbersGroup.Delete(Int32.Parse(SelectNode.Value.ToString()));
                MessageBox.Show(this.Page, "【" + SelectNode.Text + "】删除成功！");
                SelectNode.Parent.ChildNodes.Remove(SelectNode);
                this.lbtype.Text = "4";
                ShowControl();
            }
        }
    }
    protected void Dlist_EditCommand(object source, DataListCommandEventArgs e)
    {
        this.btnSave.CommandName = "edit";
        newNumbers = myNumbers.GetModel(Int32.Parse(e.CommandArgument.ToString()));
        this.lbPraseId.Text = newNumbers.Id.ToString();
        this.Panelist.Visible = false;
        this.PanelAddmyBase.Visible = true;
        this.lbPraseId.Text = e.CommandArgument.ToString();
        txtMobile.Text = newNumbers.Number.ToString();
        txtRemark.Text = newNumbers.Remark.ToString();
        if (newNumbers.GroupId > 0)
        {
            newNumbersGroup = myNumbersGroup.GetModel(newNumbers.GroupId.Value);

            this.lbmyBaseGroupId.Text = newNumbersGroup.Id.ToString();
        }
        else
        {
            if (this.TrviewGroup.SelectedNode.Text == "my")
                this.lbmyBaseGroupId.Text = "0";
            else
                this.lbmyBaseGroupId.Text = "-1";
        }
        this.lbPraseGroup.Text = this.TrviewGroup.SelectedNode.Text;
        this.btnSave.Visible = true;
        this.panelPrasecon.Visible = false;
        if ((TrviewGroup.SelectedNode.Value == "public"))
        {
            if (lbRole.Text != "0")
            {
                this.btnSave.Visible = false;
            }

        }
        else
        {
            if ((this.TrviewGroup.SelectedNode.Value == "my"))
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
                newNumbersGroup = myNumbersGroup.GetModel(Int32.Parse(TrviewGroup.SelectedNode.Value));
                if (newNumbersGroup.UserId == "sys")
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
                LinkButton myBaseid = (LinkButton)Dli.FindControl("lbtnEdit");
                if (chkitem.Checked)
                {
                    
                    myNumbers.Delete(Int32.Parse(myBaseid.CommandArgument));
                    MessageBox.Show(this.Page, "删除成功！");
                }
            }
            Public.Datalistbind(myNumbers.GetList("GroupId='" + lbmyBaseGroupId.Text + "'"), this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.Page, ex.Message.ToString());
        }
    }
    protected void btnCaneclGruop_Click(object sender, EventArgs e)
    {
        this.PanelAddGroup.Visible = false;
        this.PanelAddmyBase.Visible = false;
        this.Panelist.Visible = true;
    }
    protected void btnCaneclmyBase_Click(object sender, EventArgs e)
    {
        this.Panelist.Visible = true;
        this.PanelAddmyBase.Visible = false;
    }
    #region 根据条件决定那个panel显示
    /// <summary>
    /// 根据条件决定那个panel显示
    /// </summary>

    public void ShowControl()
    {
        switch (this.lbtype.Text)
        {
            case "1": this.PanelEditGroup.Visible = false; this.PaneoPerate.Visible = true; this.PanelAddmyBase.Visible = false; this.PanelAddGroup.Visible = false; this.Panelist.Visible = true; this.PanelImport.Visible = false; break;
            case "2": this.PanelEditGroup.Visible = false; this.PaneoPerate.Visible = true; this.PanelAddmyBase.Visible = false; this.PanelAddGroup.Visible = true; this.Panelist.Visible = false; this.PanelImport.Visible = false; break;
            case "3": this.PanelEditGroup.Visible = false; this.PaneoPerate.Visible = true; this.PanelAddmyBase.Visible = true; this.PanelAddGroup.Visible = false; this.Panelist.Visible = false; this.PanelImport.Visible = false; break;
            case "4": this.PanelEditGroup.Visible = false; this.PaneoPerate.Visible = false; this.PanelAddmyBase.Visible = false; this.PanelAddGroup.Visible = false; this.Panelist.Visible = false; this.PanelImport.Visible = false; break;
            case "5": this.PanelEditGroup.Visible = false; this.PaneoPerate.Visible = true; this.PanelAddmyBase.Visible = false; this.PanelAddGroup.Visible = false; this.Panelist.Visible = false; this.PanelImport.Visible = false; break;
            case "6": this.PanelEditGroup.Visible = true; this.PaneoPerate.Visible = true; this.PanelAddmyBase.Visible = false; this.PanelAddGroup.Visible = false; this.Panelist.Visible = false; this.PanelImport.Visible = false; break;
            case "7": this.PanelEditGroup.Visible = false; this.PaneoPerate.Visible = true; this.PanelAddmyBase.Visible = false; this.PanelAddGroup.Visible = false; this.Panelist.Visible = false; this.PanelImport.Visible = true; break;

        }
    }
    #endregion
    protected void btnEditGroup_Click(object sender, EventArgs e)
    {
        this.lbtype.Text = "6";
        ShowControl();
        this.lbViewTishi.Visible = false;
        if (lbmyBaseGroupId.Text == "")
        {
            this.btnSaveGruop.Enabled = false;
            MessageBox.Show(this.Page, "请在左侧选择你要添加的分组的父组织！");
            this.txtEditGroupName.Text = "";
        }
        else
        {
            newNumbersGroup = myNumbersGroup.GetModel(Int32.Parse(this.TrviewGroup.SelectedValue));
            if (newNumbersGroup.UserId == "sys")
            {
                this.PanelEditPrice.Visible =true;
            }
            else{
                  this.PanelEditPrice.Visible =false;
            }
          
            this.txtEditGroupName.Text = newNumbersGroup.Name;
            this.txtEditPrice.Text = newNumbersGroup.Price.ToString();
            this.btnEditGroup.Enabled = true;
        }
    }
    protected void btnEditGroupName_Click(object sender, EventArgs e)
    {
        TreeNode SelectNode = this.TrviewGroup.SelectedNode;

        newNumbersGroup = myNumbersGroup.GetModel(Int32.Parse(this.TrviewGroup.SelectedNode.Value));
        if (newNumbersGroup.Name != this.txtEditGroupName.Text)
        {
            newNumbersGroup.Name = this.txtEditGroupName.Text;

            newNumbersGroup.Price =Int32.Parse(this.txtEditPrice.Text);
            myNumbersGroup.Update(newNumbersGroup);
            SelectNode.Text = this.txtEditGroupName.Text;
            this.lbTishi.Text = "您选择的当前分组为:【" + this.txtEditGroupName.Text + "】 本组中共有:" + this.lbCount.Text + "号码";

        }
        MessageBox.Show(this.Page, "更新数据库成功！");
        this.lbtype.Text = "1";
        ShowControl();


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
    protected void btnEditBack_Click(object sender, EventArgs e)
    {
        this.lbtype.Text = "1";
        ShowControl();
    }
    protected void btnCusExport_Click(object sender, EventArgs e)
    {
        TreeNode SelectNode = this.TrviewGroup.SelectedNode;
        if (SelectNode == null)
        {
            MessageBox.Show(this.Page, "请先在左侧选择你所需要导出人员所在组！");
            return;
        }
        else
        { string strwhere=string.Empty;
        if (this.TrviewGroup.SelectedNode.Value == "public")    //判断父组织是否为公共数据库
        {
            strwhere = " GroupId='-1' and UserId='sys'";

        }
        else if (this.TrviewGroup.SelectedNode.Value == "my")  //判断父组织是否为我的数据库
        {

            strwhere = " GroupId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
        }
        else
        {
            strwhere = " GroupId='" + SelectNode.Value + "' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
        } 
            DataSet ds = myNumbers.GetList(strwhere);
            StringBuilder builder = new StringBuilder();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                builder.Append(row["Number"].ToString() + "\r\n");

            }
            string strfilename = "我的数据库分组【" + SelectNode.Text + "】中所有的手机号码.txt";
            string strfiletype = "application/ms-txt";
            GenerationCvsFile(builder, strfilename, strfiletype);
        }
    }
    protected void btnConfirm_Click(object sender, EventArgs e)
    {
        int i = 0;
        int GroupId = 0;
        string strsql=string.Empty;
        if (this.TrviewGroup.SelectedNode == null)
        {
            MessageBox.Show(this.Page, "请先在左侧选择你所需要添加号码所属组！");
            return;
        }
        else if (Public.GetUserId(this.Page) == null)
        {
            MessageBox.Show(this.Page, "对不起请您先登录！");
            return;
        }
        else
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Number", System.Type.GetType("System.String")));
            table.Columns.Add(new DataColumn("Remark", System.Type.GetType("System.String")));
            if ((TrviewGroup.SelectedNode.Value == "public"))
            {
               GroupId = -1;
            }
            else if (TrviewGroup.SelectedNode.Value == "my")
            {
                GroupId = 0;
            }
            else
            {
                GroupId = Int32.Parse(this.TrviewGroup.SelectedNode.Value);
            }
         
            Maticsoft.Common.MessageBox.ShowConfirm(this.btnConfirm, "你是否想往" + TrviewGroup.SelectedNode.Text + "添加人员！");
            if ((TrviewGroup.SelectedNode.Value == "public"))
            {
                newNumbers.UserId = "sys";
                newNumbers.GroupId=-1;
                strsql = " GroupId='-1' and UserId='sys'";


            }
            else if (TrviewGroup.SelectedNode.Value == "my")
            {
                newNumbers.UserId = Public.GetUserId(this.Page).ToString();
                newNumbers.GroupId = 0;
                strsql = " GroupId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
            }
            else
            {
                newNumbers.UserId = Public.GetUserId(this.Page).ToString();
                newNumbers.GroupId =Int32.Parse(TrviewGroup.SelectedNode.Value);
                strsql = " GroupId='" + TrviewGroup.SelectedNode.Value + "'";


            }
            foreach (DataListItem list in this.DlistImport.Items)
            {
                newNumbers.Number = ((Label)list.FindControl("lbNumber")).Text;
                newNumbers.Remark = ((Label)list.FindControl("lbRemark")).Text;
                //if (IsMobilerepeat(newNumbers.Number, "EC_Numbers", "Number"))
                //{
                //    MessageBox.Show(this.Page, "对不起您输入的手机号码" + newNumbers.Number + "与系统中已有的手机号码存在重复已被过滤！");
                //    continue;
                //}
                int result =myNumbers.Add(newNumbers);
                if (result < 0)
                {
                    MessageBox.Show(this.Page, "对不起导入失败请重新导入");
                    return;
                }
                i = i + 1;

            }
            if (i == DlistImport.Items.Count)
            {

                MessageBox.Show(this.Page, "导入成功！");
                this.DlistImport.DataSource = table;
                this.DlistImport.DataBind();



                
                DataSet ds = myNumbers.GetList(strsql);
                /*选择组织之后右边的的添加组织初始化的操作*/
                Public.Datalistbind(ds, this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);

                this.lbTishi.Text = "【" + this.TrviewGroup.SelectedNode.Text + "】组中共有:";
                strwhere = " GroupId='" + GroupId + "'";
                this.lbCount.Text = Public.ColumCount(strwhere, "EC_Customer").ToString() + "客户";
                this.lbtype.Text = "1";
                ShowControl();
            }
            else
            {
                MessageBox.Show(this.Page, "对不起导入失败请重新导入");
                return;
            }
        }
    }
    protected void btnImportCus_Click(object sender, EventArgs e)
    {
        string strfileExtension = System.IO.Path.GetExtension(this.FUploadCus.FileName).ToLower();
        if (strfileExtension != ".xls")
        {
            MessageBox.Show(this.Page, "文件类型上传不正确，只能上传execl文件！");
            return;
        }
        if (this.FUploadCus.FileContent.Length > 5000000)
        {
            MessageBox.Show(this.Page, "对不起您只能上传文件大小小于四兆的文件！");
        }
        string str = string.Empty;
        string strvalue = string.Empty;
        string strfileName = Guid.NewGuid().ToString() + "&" + this.FUploadCus.FileName;
        string filepath = Server.MapPath("upload") + "\\" + strfileName;
        this.FUploadCus.SaveAs(filepath);
        StringBuilder builder = new StringBuilder();
        string excelconnstring = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + "";
        excelconnstring += @";Extended Properties=""Excel 8.0;HDR=NO""";
        DataSet myds = new DataSet();
        using (System.Data.OleDb.OleDbConnection excelconn = new System.Data.OleDb.OleDbConnection(excelconnstring))
        {
            string sql = "select * from [sheet1$]";
            System.Data.OleDb.OleDbDataAdapter mycomm = new System.Data.OleDb.OleDbDataAdapter(sql, excelconn);
            mycomm.Fill(myds, "ss");

        }
        myds.Tables[0].Rows.RemoveAt(0);
        DataTable Dtable = myds.Tables[0].Copy();
        for(int i=0;i<myds.Tables[0].Rows.Count;i++)
        {
            DataRow newrows = myds.Tables[0].Rows[i];
            string strMobile = newrows[0].ToString();
            //if (newrows[0].ToString() == "")
            //{
            //    MessageBox.Show(this.Page, "导入失败您导入的文件中存在手机号码为空的情况请检查！");
            //    delfile(filepath);
            //    return;
            //}
            //else
            //{
            //    if (!IsMobile(newrows[0].ToString()))
            //    {
            //        MessageBox.Show(this.Page, "导入失败对不起您输入" + newrows[0].ToString() + "的手机号码的格式不正确请检查！");
            //        delfile(filepath);
            //        return;
            //    }
            //}
            
            
        }
        DataTable table = new DataTable();
        table.Columns.Add(new DataColumn("Number", System.Type.GetType("System.String")));
        table.Columns.Add(new DataColumn("Remark", System.Type.GetType("System.String")));
        foreach (DataRow newrows in myds.Tables[0].Rows)
        {
            DataRow row = table.NewRow();
            row["Number"] = "暂无";
            row["Remark"] = "暂无";

            row["Number"] = newrows[0];

            row["Remark"] = newrows[1].ToString();
            table.Rows.Add(row);
        }
        delfile(filepath);
        this.DlistImport.Visible = true;
        this.btnConfirm.Visible = true;
        this.btnCancer.Visible = true;
        this.DlistImport.DataSource = table;
        this.DlistImport.DataBind();
        this.DlistImport.Visible = true;
        this.btnConfirm.Visible = true;
        this.btnCancer.Visible = true;

    }
    public void delfile(string filepath)
    {
        if (System.IO.File.Exists(filepath))
        {
            try
            {
                System.IO.File.Delete(filepath);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
    #region 判断手机号码是否重复
    /// 判断手机号码是否重复
    /// </summary>
    /// <param name="Mobile">您需要检查的手机号码</param>
    /// <param name="TableName">所在的表名</param>
    /// <param name="ColumnName">字段名</param>
    /// <returns>存在重复返回true不存在重复返回false</returns>
    public bool IsMobilerepeat(string Mobile, string TableName, string ColumnName)
    {
        string strsql = "select count(*) from " + TableName + "  where " + ColumnName + "='" + Mobile + "'";
        object MobileCount = Maticsoft.DBUtility.DbHelperSQL.GetSingle(strsql);
        if (MobileCount != null)
        {

            int i = Int32.Parse(MobileCount.ToString());
            if (i > 0)
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region 判断是否为手机
    /// <summary>
    /// 判断是否为手机
    /// </summary>
    /// <param name="StrSource">需验证的字符串</param>
    /// <returns>是否为手机数据</returns>
    public bool IsMobile(string StrSource)
    {
        if (StrSource.Length == 11)
        {
            return Regex.IsMatch(StrSource, @"^1[358]\d{9}$");
        }
        else
        {
            return Regex.IsMatch(StrSource, @"^(\d{4})+(\d{8})+$");
        }
    }
    #endregion
    protected void btnImport_Click(object sender, EventArgs e)
    {
        this.lbtype.Text = "7";
        ShowControl();
        this.DlistImport.Visible = false;
        this.lbViewTishi.Visible = false;
        this.btnConfirm.Visible = false;
        this.btnCancer.Visible = false;
    }
    protected void BtnTemplate_Click(object sender, EventArgs e)
    {
        try
        {
            string filePath = Server.MapPath("导入手机号码模板.xls");
            string strTemp = string.Format("attachment;filename={0}", Server.UrlEncode("导入手机号码模板.xls"));
            Response.ContentEncoding = Encoding.GetEncoding("GB2312");
            Response.ClearHeaders();
            Response.ContentType = "application/ms-excel";
            Response.AppendHeader("Content-Disposition", strTemp);
            Response.BinaryWrite(File.ReadAllBytes(filePath));
            Response.End();
            Response.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(this.Page, ex.Message.ToString());
        }

    }
    protected void btnCancer_Click(object sender, EventArgs e)
    {
        this.DlistImport.Visible = false;
        this.btnConfirm.Visible = false;
        this.btnCancer.Visible = false;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        string strsql = string.Empty;
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        TreeNode SelectNode = this.TrviewGroup.SelectedNode;
        if ((TrviewGroup.SelectedNode.Value == "public"))
        {
            strwhere = " ParentId='-1' and UserId='sys'";
            strsql = " GroupId='-1' and UserId='sys'";
            this.lbmyBaseGroupId.Text = "-1";
            this.lbPraseGroup.Text = "公共数据库";

        }
        else if (TrviewGroup.SelectedNode.Value == "my")
        {
            strwhere = " ParentId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
            strsql = " GroupId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
            this.lbmyBaseGroupId.Text = "0";
            this.lbPraseGroup.Text = "我的数据库";
        }
        else
        {
            strwhere = " ParentId='" + SelectNode.Value + "'";
            strsql = " GroupId='" + SelectNode.Value + "'";
            this.lbmyBaseGroupId.Text = SelectNode.Value;
            this.lbPraseGroup.Text = SelectNode.Text;

        }
        DataSet ds = myNumbers.GetList(strsql);
        Public.Datalistbind(ds, this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
        /*选择组织之后右边的的添加组织初始化的操作*/
    }
    protected void Dlist_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {

            if ((this.TrviewGroup.SelectedNode.Value == "my"))
            {
                
            }
            else if (TrviewGroup.SelectedNode.Value == "public")
            {
                
            }
            else
            {
                newNumbersGroup = myNumbersGroup.GetModel(Int32.Parse(TrviewGroup.SelectedNode.Value));
                if (newNumbersGroup.UserId == "sys")
                {
                    if (lbRole.Text != "0")
                    {
                        if (newNumbersGroup.Price > 1)
                        {
                           ((Label)e.Item.FindControl("lbNum")).Text="***********";

                        }

                    }
                }
            }

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        


        TreeNode SelectNode = this.TrviewGroup.SelectedNode;
        if (SelectNode == null)
        {
            MessageBox.Show(this.Page, "请先在左侧选择你所需要导出人员所在组！");
            return;
        }
        else
        {
            int price=0;
            string strwhere = string.Empty;
            if (this.TrviewGroup.SelectedNode.Value == "public")    //判断父组织是否为公共数据库
            {
                strwhere = "  GroupId='-1' and UserId='sys'";

            }
            else if (this.TrviewGroup.SelectedNode.Value == "my")  //判断父组织是否为我的数据库
            {

                strwhere = "  GroupId='0' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
            }
            else
            {
                strwhere = "  GroupId='" + SelectNode.Value + "'";
                newNumbersGroup = myNumbersGroup.GetModel(Int32.Parse(TrviewGroup.SelectedNode.Value));
                price = newNumbersGroup.Price.Value;
            
            }
            DataSet ds = myNumbers.GetList(strwhere);

            ECSMS.BLL.EC_UserSmsAccount myAccount = new ECSMS.BLL.EC_UserSmsAccount();
            ECSMS.Model.EC_UserSmsAccount newAccount = new ECSMS.Model.EC_UserSmsAccount();
            DataSet newds = myAccount.GetList(" userid=" + Public.GetUserId(this.Page) + " and smstype='" + this.droppubup.SelectedValue + "' ");
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                if (int.Parse(newds.Tables[0].Rows[0]["LeaveNum"].ToString()) >= (price * ds.Tables[0].Rows.Count))
                {
                    Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(" update ec_usersmsaccount set leavenum=leavenum-" + price * ds.Tables[0].Rows.Count + " where  userid=" + Public.GetUserId(this.Page) + " and smstype='" + this.droppubup.SelectedValue + "'  ");
               
                }
                else
                {
                    Maticsoft.Common.MessageBox.Show(this, "对不起，您在【" + price * ds.Tables[0].Rows.Count + "】余额【" + newds.Tables[0].Rows[0]["leavenum"].ToString() + "】不够发送本次短信，请充值或选择其他短信产品。");
                    return;
                }
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "对不起，您在【" + price * ds.Tables[0].Rows.Count + "】没有余额，请充值或选择其他短信产品。");
                return;
            } 



            StringBuilder builder = new StringBuilder();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                builder.Append(row["Number"].ToString() + "\r\n");

            }
            string strfilename = "我的数据库分组【" + SelectNode.Text + "】中所有的手机号码.txt";
            string strfiletype = "application/ms-txt";
            GenerationCvsFile(builder, strfilename, strfiletype);
        }
    }
}
