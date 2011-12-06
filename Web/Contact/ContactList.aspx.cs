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
public partial class ContactList : PageBase
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

                this.btnSaveCus.CommandName = "add";
                strwhere = " UserId='" + Public.GetUserId(this.Page).ToString() + "'";
                DataSet ds = myCustomerGroup.GetList(strwhere);
                ListItem  Nitem = new ListItem("请选择名片夹", "-3",true);
                this.dropChangeGroup.Items.Add(Nitem);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ListItem item = new ListItem(row["Name"].ToString(), row["Id"].ToString());
                    this.dropChangeGroup.Items.Add(item);
                }
              Nitem = new ListItem("我的短信回访", "-1");
              this.dropChangeGroup.Items.Add(Nitem);
              Nitem = new ListItem("黑名单", "-2");
              this.dropChangeGroup.Items.Add(Nitem);
            }

        }

        this.lbViewTishi.Visible = false;

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
        DataTable dt=ds.Tables[0];
        TreeNode[] NodeArray = new TreeNode[dt.Rows.Count];
        for (int i = 0; i <dt.Rows.Count; i++)
        {
                DataRow row = ds.Tables[0].Rows[i];
                NodeArray[i] = new TreeNode(row["Name"].ToString(), row["Id"].ToString());
                NodeArray[i].Expanded = false;
                NodeArray[i].SelectAction =TreeNodeSelectAction.SelectExpand;
        }
        return NodeArray;
    }
    #endregion
   protected void TrviewGroup_SelectedNodeChanged(object sender, EventArgs e)
    {
        this.btnEditGroup.Visible = false;
        this.btndelGroup.Visible = false;
        this.lbtnAddCums.Visible = false;
        this.btnImport.Visible = false;
       TreeNode SelectNode=this.TrviewGroup.SelectedNode;
       if (Int32.Parse(SelectNode.Value) > 0)
       {
           this.btnEditGroup.Visible =true;
           this.btndelGroup.Visible = true;
           this.lbtnAddCums.Visible = true;
           this.btnImport.Visible = true;
       }
    
       strwhere = "ParentId='" + SelectNode.Value + "' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
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
       this.lbTishi.Visible = true;
       this.lbCount.Visible = true;
       this.lbTishi.Text = "【"+SelectNode.Text+"】组中共有:";
       strwhere = " GroupId='" + SelectNode.Value + "'and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
       this.lbCount.Text =Public.ColumCount(strwhere, "EC_Customer").ToString();
       ShowControl();
      
       this.lbParent.Text = SelectNode.Text;
       this.lbCusGroup.Text = SelectNode.Text;
       this.txtGroupName.Text = "";
       //this.txtRemark.Text = "";
       //this.lbParentId.Text = SelectNode.Value;
       //this.lbCusGroupId.Text = SelectNode.Value;
       this.PanelGroupOperate.Visible = true;
       this.PanelAddCums.Visible = false;
       this.PanelAddGroup.Visible = false;
       this.Panelist.Visible = true;
       this.PanelImport.Visible = false;
       this.PanelEditGroup.Visible = false;
       this.PanelGroupOperate.Visible = true;
       Public.Datalistbind(GetDataSet(" where GroupId='" + Int32.Parse(SelectNode.Value) + "' and EC_Customer.UserId='" + Public.GetUserId(this.Page).ToString() + "'"), this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
      
     
           /*选择组织之后右边的的添加组织初始化的操作*/
   }
   #region 删除选中项
   protected void btndel_Click(object sender, EventArgs e)
   {
       try
       {
           foreach (DataListItem Dli in this.Dlist.Items)
           {
               System.Web.UI.HtmlControls.HtmlInputCheckBox chkitem = (System.Web.UI.HtmlControls.HtmlInputCheckBox)Dli.FindControl("Chkitem");
               Label Custormid = (Label)Dli.FindControl("lbId");
               if (chkitem.Checked)
               {
                   myCustomer.Delete(Int32.Parse(Custormid.Text));
                   MessageBox.Show(this.Page, "删除成功！");
               }
           }
           Public.Datalistbind(GetDataSet(" where GroupId='" + Int32.Parse(this.TrviewGroup.SelectedNode.Value) + "' and EC_Customer.UserId='" + Public.GetUserId(this.Page).ToString() + "'"), this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
        }
       catch (Exception ex)
       {
           MessageBox.Show(this.Page, ex.Message.ToString());
       }
   }
   #endregion

   #region 发送短信
   protected void btnsms_Click(object sender, EventArgs e)
   {

   }
   #endregion
   protected void btnSaveGruop_Click(object sender, EventArgs e)
   {
       
       newCustomerGroup.Name = txtGroupName.Text;
       newCustomerGroup.ParentId =Int32.Parse(this.TrviewGroup.SelectedNode.Value);
       newCustomerGroup.Remark = txtRemark.Text;
       newCustomerGroup.UserId =Int32.Parse(Public.GetUserId(this.Page).ToString());
       int i=myCustomerGroup.Add(newCustomerGroup);
       if (i != -1)
       {
            MessageBox.Show(this.Page, "添加组成功!");
           this.TrviewGroup.SelectedNode.ChildNodes.Add(new TreeNode(newCustomerGroup.Name,i.ToString()));
           if (ChGroupKeep.Checked)
           {
               MadeGroupVoid();
           }
           else
           {
               Public.Datalistbind(GetDataSet(" where GroupId='" + Int32.Parse(this.TrviewGroup.SelectedNode.Value) + "' and EC_Customer.UserId='" + Public.GetUserId(this.Page).ToString() + "'"), this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
               this.lbtype.Text = "1";
               ShowControl();
               this.lbtype.Text = "2";

           }
       }
       else
       {
           MessageBox.Show(this.Page, "添加失败!");
       }

   }
   protected void lbtnAddGroup_Click(object sender, EventArgs e)
   {
       this.lbtype.Text = "3";
      
       ShowControl();
       if (lbParent.Text == "")
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
   protected void lbtnAddCums_Click(object sender, EventArgs e)
   {
       this.lbtype.Text = "2";
       ShowControl();
      
       this.btnSaveCus.Text = "保存";
       this.btnSaveCus.CommandName = "add";
       MadeCumsVoid();
     
       if (this.lbCusGroup.Text == "")
       {
           this.btnSaveCus.Enabled = false;
           MessageBox.Show(this.Page, "请在左侧选择你要添加的客户所属的父组织！");
       }
       else
       {
           this.btnSaveCus.Enabled = true;
       }
   }
   protected void btnSave_Click(object sender, EventArgs e)
   {
       if (this.btnSaveCus.CommandName == "edit")
       {
           newCustomer = myCustomer.GetModel(Int32.Parse(this.lbCusId.Text));
       }
       TimeSpan span;
       int Minutes;
       newCustomer.Name = txtName.Text;
       newCustomer.Birthday = txtBrithday.Text;
       if (txtBrithday.Text != "")
       {
           span = DateTime.Parse(txtBrithday.Text).Subtract(DateTime.Now);
           Minutes = span.Days * 1440 + span.Hours * 60 + span.Minutes;
           if (Minutes > 0)
           {
               MessageBox.Show(this.Page, "对不起请您输入正确的出生日期！");
               return;
           }
       }
       if (newCustomer.Name != "")
       {
           newCustomer.NickName = txtNickName.Text;

       }
       else
       {
           newCustomer.NickName = txtNickName.Text;
       }
       if ((ZLTStartTime.Text != "") && (ZLTStartTime.Text != ""))
       {
           newCustomer.StartDate = ((ZLTStartTime.Text == "") ? DateTime.Now : DateTime.Parse(ZLTStartTime.Text));
           newCustomer.EndDate = ((ZLTStopTime.Text == "") ? DateTime.Now : DateTime.Parse(ZLTStopTime.Text));
           span = newCustomer.EndDate.Value.Subtract(newCustomer.StartDate.Value);
           Minutes = span.Days * 1440 + span.Hours * 60 + span.Minutes;
           if (Minutes < 0)
           {
               MessageBox.Show(this.Page, "客户起始时间应晚于客户结束时间请检查！");
               return;
           }
       }
       else
       {
           newCustomer.StartDate = DateTime.Now;
           newCustomer.EndDate = DateTime.Now;

       }
       newCustomer.CompanyAddress = txtComAddress.Text;
       newCustomer.mobile2 = txtMobile2.Text;
       newCustomer.Positions = txtPositions.Text;
       newCustomer.Sex = this.rbtnSex.SelectedValue;
       newCustomer.Fax = txtfax.Text;
       newCustomer.HomeAddress = txtHomeAddress.Text;
       newCustomer.CardNumber = txtCardNumber.Text;
       newCustomer.Servicer = txtServicer.Text;
       newCustomer.RelationLevel = txtRelationLevel.Text;
       newCustomer.HomeTel = txtHomeTel.Text;
       newCustomer.Favrate = txtFavrate.Text;
       newCustomer.QQ = txtQQ.Text;
       newCustomer.CompanyName = txtCompany.Text;
       newCustomer.Website = txtWebSite.Text;
       newCustomer.Partment = txtDept.Text;
       newCustomer.Email = txtEmail.Text;
       newCustomer.GroupId = Int32.Parse(this.TrviewGroup.SelectedNode.Value);
       newCustomer.Telephone = txtTel.Text;
       newCustomer.PostCode = txtPCode.Text;
       if (this.btnSaveCus.CommandName == "add")
       {
           newCustomer.Mobile = txtMobile.Text;
           newCustomer.UserId = Int32.Parse(Public.GetUserId(this.Page).ToString());

           int i = myCustomer.Add(newCustomer);
           if (i != -1)
           {
               MessageBox.Show(this.Page, "客户添加成功!");
               if (this.ChCusKeep.Checked)
               {
                   MadeCumsVoid();
               }
               else
               {
                   Public.Datalistbind(GetDataSet(" where GroupId='" + Int32.Parse(this.TrviewGroup.SelectedNode.Value) + "' and EC_Customer.UserId='" + Public.GetUserId(this.Page).ToString() + "'"), this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
                   this.lbTishi.Text = "【" + this.TrviewGroup.SelectedNode.Text + "】组中共有:";
                   strwhere = " GroupId='" + this.TrviewGroup.SelectedNode.Value + "'";
                   this.lbCount.Text = Public.ColumCount(strwhere, "EC_Customer").ToString() + "客户";
                   this.lbtype.Text = "1";
                   ShowControl();
               }
           }
           else
           {
               MessageBox.Show(this.Page, "客户添加失败!");
           }
       }
       else
       {
           newCustomer.Mobile = txtMobile.Text;

           myCustomer.Update(newCustomer);
           MessageBox.Show(this.Page, "客户信息更新成功!");

           this.lbtype.Text = "1";
           Public.Datalistbind(GetDataSet(" where GroupId='" + Int32.Parse(this.TrviewGroup.SelectedNode.Value) + "' and EC_Customer.UserId='" + Public.GetUserId(this.Page).ToString() + "'"), this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);

           ShowControl();

       }
       lbCusGroupId.Text = "";


   }
   protected void Dlist_EditCommand(object source, DataListCommandEventArgs e)
   {
      this.btnSaveCus.CommandName = "edit";
      string str = ((Label)e.Item.FindControl("lbGroupId")).Text;
      if ((str != "0")&&(str != "-1")&&(str != "-2"))
      {
          newCustomerGroup = myCustomerGroup.GetModel(Int32.Parse(((Label)e.Item.FindControl("lbGroupId")).Text));
          lbCusGroupId.Text = newCustomerGroup.Id.ToString();
      }
      else
      {
          lbCusGroupId.Text = str;
      }
     
      this.Panelist.Visible=false;
      this.PanelAddCums.Visible = true;
      lbCusId.Text = e.CommandArgument.ToString();
      newCustomer=myCustomer.GetModel(Int32.Parse(this.lbCusId.Text));
      txtHomeAddress.Text = newCustomer.HomeAddress;
      txtHomeTel.Text = newCustomer.HomeTel;
      txtFavrate.Text = newCustomer.Favrate;
      txtMobile2.Text = newCustomer.mobile2;
      ZLTStartTime.Text = newCustomer.StartDate.Value.ToShortDateString();
      ZLTStopTime.Text = newCustomer.EndDate.Value.ToShortDateString();
      txtQQ.Text = newCustomer.QQ;
      txtWebSite.Text = newCustomer.Website;
      txtPositions.Text = newCustomer.Positions;
      txtfax.Text = newCustomer.Fax;
      this.txtDept.Text = newCustomer.Partment;
      this.txtWebSite.Text = newCustomer.Website;
      this.rbtnSex.SelectedValue = newCustomer.Sex;
      txtName.Text = newCustomer.Name;
      txtBrithday.Text=newCustomer.Birthday;
      txtNickName.Text = newCustomer.NickName;
      txtComAddress.Text= newCustomer.CompanyAddress;
      txtCompany.Text=newCustomer.CompanyName;
      txtEmail.Text=newCustomer.Email;
      txtCardNumber.Text = newCustomer.CardNumber ;
      txtServicer.Text= newCustomer.Servicer ;
      txtRelationLevel.Text =newCustomer.RelationLevel ;
      lbCusGroup.Text=newCustomerGroup.Name;
      txtMobile.Text=newCustomer.Mobile;
      this.PanelAddCumsCon.Visible = false;
      txtTel.Text=newCustomer.Telephone;
      txtPCode.Text=newCustomer.PostCode;
   }
   #region 判断手机号码是否重复
   /// 判断手机号码是否重复
   /// </summary>
   /// <param name="Mobile">您需要检查的手机号码</param>
   /// <param name="TableName">所在的表名</param>
   /// <param name="ColumnName">字段名</param>
   /// <returns>存在重复返回true不存在重复返回false</returns>
   public bool IsMobilerepeat(string Mobile,string TableName,string ColumnName)
   {
       string strsql = "select count(*) from " + TableName + "  where " + ColumnName + "='" + Mobile + "' and  UserId='" + Public.GetUserId(this.Page).ToString() + "'";
       object MobileCount = Maticsoft.DBUtility.DbHelperSQL.GetSingle(strsql);
       if (MobileCount != null)
       {

           int i = Int32.Parse(MobileCount.ToString());
           if (i > 0)
           {
               return true;
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
   #region 添加用户控件值赋空值
   public void MadeCumsVoid()
   {
       txtName.Text = "";
       txtNickName.Text = "";
       txtTel.Text = "";
       txtBrithday.Text = "";
       txtComAddress.Text = "";
       txtCompany.Text = "";
       txtEmail.Text = "";
       txtMobile.Text = "";
       txtPCode.Text = "";
       this.txtQQ.Text = "";
       this.txtMobile2.Text = "";
       this.txtFavrate.Text = "";
       this.txtHomeAddress.Text = "";
       this.txtHomeTel.Text = "";
       this.txtMobile2.Text = "";
       this.txtPositions.Text = "";
       this.txtDept.Text = "";
       this.txtfax.Text = "";
       this.txtWebSite.Text = "";
       txtCardNumber.Text ="";
       txtServicer.Text ="";
       txtRelationLevel.Text ="";
       this.rbtnSex.SelectedValue="男";
       this.ZLTStartTime.Text = "";
       this.ZLTStopTime.Text = "";
   }
   #endregion
   #region 添加组控件值赋空值
   public void MadeGroupVoid()
   {
       txtGroupName.Text = "";
       txtRemark.Text = "";
   }
   #endregion
   protected void lbtnBrithday_Click(object sender, EventArgs e)
   {
       try
       {
           this.PanelAddGroup.Visible = false;
           this.PanelAddCums.Visible = false;
           this.Panelist.Visible = true;
           this.PanelAddCums.Visible = false;
           this.PanelImport.Visible = false;

           strwhere = " where Birthday!='' and datediff(d,dateadd(year,year(GetDate())-year(Birthday),Birthday),GetDate())=0";
           Public.Datalistbind(GetDataSet(strwhere), this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
           if (Dlist.Items.Count == 0)
           {
               this.lbCount.Visible = false;
               this.PanelAddCums.Visible = false;
               this.PanelAddGroup.Visible = false;
               this.PanelGroupOperate.Visible = false;
               return;
           }
       }
       catch (Exception ex)
       { 
       
       }
   }
   protected void btnSelect_Click(object sender, EventArgs e)
   {
       try
       {
           string strsql = "where  EC_Customer.UserId='" + Public.GetUserId(this.Page).ToString() + "' and( dbo.EC_Customer.Name like '%" + Regex.Replace(txtSelect.Text, @"\s", "") + "%' or Mobile like '%" + Regex.Replace(txtSelect.Text, @"\s", "") + "%' or CompanyName like '%" + Regex.Replace(txtSelect.Text, @"\s", "") + "%')";
           Public.Datalistbind(GetDataSet(strsql), this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
           this.PanelAddCums.Visible = false;
           this.PanelAddGroup.Visible = false;
           this.PanelGroupOperate.Visible = false;
           if (this.Dlist.Items.Count > 0)
           {
               this.lbCount.Text = this.Dlist.Items.Count.ToString();
               lbTishi.Text = "在今天过生日的客户有:";
               this.lbTishi.Visible = true;
           }
           else
           {
               this.lbTishi.Visible = false;
               this.lbCount.Visible = false;
           }
       }
       catch (Exception ex)
       {

       }
   }
   protected void btnImport_Click(object sender, EventArgs e)
   {
       this.lbtype.Text = "5";
       ShowControl();
       
       this.btnCancer.Visible = false;
       this.btnConfirm.Visible = false;
   }
   protected void btnExport_Click(object sender, EventArgs e)
   {
       TreeNode SelectNode = this.TrviewGroup.SelectedNode;
       if (SelectNode == null)
       {
           MessageBox.Show(this.Page, "请先在左侧选择你所需要导出人员所在组！");
           return;
       }
       else
       {
           string strwhere = " GroupId='" + SelectNode.Value + "' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
           DataSet ds = myCustomer.GetList(strwhere);
           ECSMS.BLL.EC_CustomerGroup myGroup = new ECSMS.BLL.EC_CustomerGroup();
           ECSMS.Model.EC_CustomerGroup newGroup = new ECSMS.Model.EC_CustomerGroup();
           newGroup = myGroup.GetModel(int.Parse(SelectNode.Value));
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
           builder.Append("所属组,");
           builder.Append("\n");
           foreach (DataRow row in ds.Tables[0].Rows)
           {
               builder.Append(newGroup.Name + ",");
               builder.Append(row["Name"].ToString()+",");
               builder.Append(row["NickName"].ToString() + ",");
               builder.Append((row["Sex"].ToString()=="男")?"男"+",":"女" + ","); 
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
               builder.Append(row["Favrate"].ToString() + ",");
               builder.Append(SelectNode.Text + ",");
               builder.Append("\n");
           }
            string strfilename = "名片夹分组【"+SelectNode.Text+"】客户信息.csv";
            string strfiletype = "application/ms-excel";
            GenerationCvsFile(builder,strfilename,strfiletype);
           
       }

   }

   #region  输出各种文档
   /// <summary>
   ///  输出各种文档
    /// </summary>
    /// <param name="strtitlename">文件的内容(各项以逗号隔开 以"\n"结束)</param>
    /// <param name="strfilename">生成的文件名</param>
     /// <param name="strfilename">输出文件的类型为application/ms-excel || application/ms-word || application/ms-txt || application/ms-html</param>
   public void GenerationCvsFile(StringBuilder strbuilder,string strfilename,string strfiletype)
   {
       try
       {
           string strTemp = string.Format("attachment;filename={0}", Server.UrlEncode(strfilename));
           Response.ContentEncoding = Encoding.GetEncoding("GB2312");
           Response.ClearHeaders();
           Response.AppendHeader("Content-disposition", strTemp);
           Response.ContentType =strfiletype;
           Response.Write(strbuilder);
           Response.End();
       }
       catch (Exception ex)
       {
           MessageBox.Show(this.Page, ex.Message.ToString());
       }
   }
    #endregion 
    
   #region 导入客户信息
    /// <summary>
    /// 导入客户信息
    /// </summary>
    /// <param name="strColums">导入文档的标题数组与table的列要一一对应</param>
    /// <param name="strfilepath">导入文件的地址</param>
    /// <returns>返回由strColums为字表列以文件内容为表数据的table</returns>
   public DataTable ImportCus(string []strColums, string strfilepath)
   {
       FileStream fs = new FileStream(strfilepath, FileMode.Open, FileAccess.Read, FileShare.None);
       StreamReader sr = new StreamReader(fs, System.Text.Encoding.GetEncoding("GB2312"));
       DataTable table = new DataTable();
       for (int i = 0; i < strColums.Length; i++)
       {
           table.Columns.Add(new DataColumn(strColums[i], System.Type.GetType("System.String")));
       }
       string str = string.Empty;
       sr.ReadLine();
       str = sr.ReadLine();
       while (str != null)
       {

           DataRow row = table.NewRow();
           strColums = str.Split(',');
           for(int i=0;i<strColums.Length;i++)
           {
               row[i]=strColums[i].ToString();
           }
           str = sr.ReadLine();
           table.Rows.Add(row);
        
       }
      sr.Close();
      return table;
   }
    #endregion

   #region 判断是否为日期型数据
   /// <summary>
   /// 判断是否为日期型数据
   /// </summary>
   /// <param name="StrSource">需验证的字符串</param>
   /// <returns>是否为日期数据</returns>
   public bool IsDateTime(string StrSource)
   {
       return Regex.IsMatch(StrSource, @"^(\d{4})(\/|-)(\d{1,2})\2(\d{1,2})$");
   }

   #endregion

   #region 判断是否为Email
   /// <summary>
   /// 判断是否为Email
   /// </summary>
   /// <param name="StrSource">需验证的字符串</param>
   /// <returns>是否为Email数据</returns>
   public bool IsEmail(string StrSource)
   {
       return Regex.IsMatch(StrSource, @"^[0-9a-zA-Z]+@[0-9a-zA-Z]+[\.]{1}[0-9a-zA-Z]+[\.]?[0-9a-zA-Z]+$");
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

   #region 判断是否为电话
   /// <summary>
   /// 判断是否为电话
   /// </summary>
   /// <param name="StrSource">需验证的字符串</param>
   /// <returns>是否为电话数据</returns>
   public bool IsTel(string StrSource)
   {
       return Regex.IsMatch(StrSource, @"\d{3}-\d{8}|\d{4}-\d{7}");
   }
   #endregion

   #region 判断是否为邮编
   /// <summary>
   /// 判断是否为邮编
   /// </summary>
   /// <param name="StrSource">需验证的字符串</param>
   /// <returns>是否为邮编数据</returns>
   public bool IsPostCode(string StrSource)
   {
       return Regex.IsMatch(StrSource, @"^[-()0-9]{1,20}$");
   }
   #endregion

   protected void BtnTemplate_Click(object sender, EventArgs e)
   {
       try
       {
           string filePath =Server.MapPath("导入客户信息模板.xls");
           string strTemp = string.Format("attachment;filename={0}", Server.UrlEncode("导入客户信息模板.xls"));
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
   protected void btnImportCus_Click(object sender, EventArgs e)
   {
       string strfileExtension = System.IO.Path.GetExtension(this.FUploadCus.FileName).ToLower();
       if (strfileExtension != ".xls")
       {
           MessageBox.Show(this.Page, "文件类型上传不正确，只能上传execl文件！");
           return;
       }
       if (this.FUploadCus.FileContent.Length >5000000)
       {
           MessageBox.Show(this.Page, "对不起您只能上传文件大小小于四兆的文件！");
       }
       string str = string.Empty;
       string strvalue = string.Empty;
       string strfileName= Guid.NewGuid().ToString() + "&" + this.FUploadCus.FileName;
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
       DataTable table = new DataTable();
       table.Columns.Add(new DataColumn("Name", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("NickName", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("Sex", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("Birthday", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("Mobile", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("Mobile2", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("QQ", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("Positions", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("Email", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("PostCode", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("HomeTel", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("HomeAddress", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("CompanyName", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("Telephone", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("CompanyAddress", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("Website", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("Fax", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("CardNumber", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("Servicer", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("StartDate", System.Type.GetType("System.DateTime")));
       table.Columns.Add(new DataColumn("EndDate", System.Type.GetType("System.DateTime")));
       table.Columns.Add(new DataColumn("RelationLevel", System.Type.GetType("System.String")));
       table.Columns.Add(new DataColumn("Favrate", System.Type.GetType("System.String")));

       foreach (DataRow newrows in myds.Tables[0].Rows)
       {
           DataRow row = table.NewRow();
           row["Name"] = newrows[0].ToString();
           row["NickName"] = newrows[1].ToString();
           row["Sex"] = newrows[2].ToString();
           row["Birthday"] = newrows[3].ToString();
           row["Mobile"] = newrows[4].ToString();
           row["Mobile2"] = newrows[5].ToString();
           row["QQ"] = newrows[6].ToString();
           row["Positions"] = newrows[7].ToString();
           row["Email"] = newrows[8].ToString();
           row["PostCode"] = newrows[9].ToString();
           row["HomeTel"] = newrows[10].ToString();
           row["HomeAddress"] = newrows[11].ToString();
           row["CompanyName"] = newrows[12].ToString();
           row["Telephone"] = newrows[13].ToString();
           row["CompanyAddress"] = newrows[14].ToString();
           row["Fax"] = newrows[15].ToString();
           row["Email"] = newrows[16].ToString();
           row["CardNumber"] = newrows[17].ToString();
           row["Servicer"] = newrows[18].ToString();
        
           row["RelationLevel"] = newrows[21].ToString();
           row["Favrate"] = newrows[22].ToString();
           if (newrows[0].ToString() == "")
           {
               MessageBox.Show(this.Page, "导入失败您导入的文件中存在姓名为空的情况请检查！");
               delfile(filepath);
               return;
           }
           row["Name"] = newrows[0];
           if (newrows[1].ToString() == "")
           {
               MessageBox.Show(this.Page, "导入失败对不起您输入【" + newrows[0].ToString() + "】的称呼不能为空请检查！");
               delfile(filepath);
               return;
           }
           row["NickName"] = newrows[1];

           if (newrows[3].ToString() != "")
           {
               if (!IsDateTime(newrows[3].ToString()))
               {
                   MessageBox.Show(this.Page, "导入失败对不起您输入【" + newrows[0].ToString() + "】的生日不为日期型请按YYYY-MM-DD格式输入请检查！");
                   delfile(filepath);
                   return;
               }
               row["Birthday"] = newrows[3].ToString();
           }
           if (newrows[2].ToString() == "")
           {
               MessageBox.Show(this.Page, "导入失败对不起您输入【" + newrows[0].ToString() + "】的性别不能为空请检查！");
               delfile(filepath);
               return;
           }
           row["Sex"] = newrows[2];
           if (newrows[8].ToString() != "")
           {
               if (!IsEmail(newrows[8].ToString()))
               {
                   MessageBox.Show(this.Page, "导入失败对不起您输入【" + newrows[0].ToString() + "】的Email格式不正确请检查！");
                   delfile(filepath);
                   return;
               }
               row["Email"] = newrows[8].ToString();
           }
           if (newrows[9].ToString() != "")
           {
               if (!IsPostCode(newrows[9].ToString()))
               {
                   MessageBox.Show(this.Page, "导入失败对不起您输入【" + newrows[0].ToString() + "】的邮编格式不正确请检查！");
                   delfile(filepath);
                   return;
               }
               row["PostCode"] = newrows[9].ToString();
           }
           if (newrows[13].ToString() != "")
           {
               if (!IsPostCode(newrows[13].ToString()))
               {
                   MessageBox.Show(this.Page, "导入失败对不起您输入【" + newrows[0].ToString() + "】的公司电话号码格式不正确请检查！");
                   delfile(filepath);
                   return;
               }
               row["Telephone"] = newrows[13].ToString();
           }
           if (newrows[4].ToString() != "")
           {
               if (!IsMobile(newrows[4].ToString()))
               {
                   MessageBox.Show(this.Page, "导入失败对不起您输入【" + newrows[0].ToString() + "】的手机号码的格式不正确请检查！");
                   delfile(filepath);
                   return;
               }
               row["Mobile"] = newrows[4].ToString();
           }
           if (newrows[5].ToString() != "")
           {
               if (!IsMobile(newrows[5].ToString()))
               {
                   MessageBox.Show(this.Page, "导入失败对不起您输入【" + newrows[0].ToString() + "】的手机号码2的格式不正确请检查！");
                   delfile(filepath);
                   return;
               }
               row["Mobile"] = newrows[5].ToString();
           }
           if (newrows[19].ToString() != "")
           {
               if (!IsDateTime(newrows[19].ToString()))
               {
                   MessageBox.Show(this.Page, "导入失败对不起您输入【" + newrows[0].ToString() + "】的起始时间请按YYYY-MM-DD格式输入请检查！");
                   delfile(filepath);
                   return;
               }
               row["StartDate"] =DateTime.Parse( newrows[19].ToString());
           }
           else
           {
               row["StartDate"] = DateTime.Now;

           }
           if (newrows[20].ToString() != "")
           {
               if (!IsDateTime(newrows[20].ToString()))
               {
                   MessageBox.Show(this.Page, "导入失败对不起您输入【" + newrows[0].ToString() + "】的结束时间请按YYYY-MM-DD格式输入请检查！");
                   delfile(filepath);
                   return;
               }
               row["EndDate"] =DateTime.Parse( newrows[20].ToString());
           }
           else
           {
               row["EndDate"] = DateTime.Now;
           }
           TimeSpan span =DateTime.Parse(row["EndDate"].ToString()).Subtract(DateTime.Parse(row["StartDate"].ToString()));
           int   Minutes = span.Days * 1440 + span.Hours * 60 + span.Minutes;
           if (Minutes < 0)
           {
               MessageBox.Show(this.Page, "【" + newrows[0].ToString() + "】起始时间应晚于客户结束时间请检查！");
               return;
           }
           table.Rows.Add(row);
       }
       delfile(filepath);
       this.DlistImport.Visible = true;
       this.btnConfirm.Visible = true;
       this.btnCancer.Visible = true;
       this.DlistImport.DataSource = table;
       this.DlistImport.DataBind();
       
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
   protected void btnConfirm_Click(object sender, EventArgs e)
   {
       int i = 0;
       int GroupId = 0; 
       if (this.TrviewGroup.SelectedNode ==null)
       {
            MessageBox.Show(this.Page, "请先在左侧选择你所需要添加人员所属组！");
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
           table.Columns.Add(new DataColumn("Name", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("NickName", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("Sex", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("Birthday", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("Mobile", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("Mobile2", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("QQ", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("Positions", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("Email", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("PostCode", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("HomeTel", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("HomeAddress", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("CompanyName", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("Telephone", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("CompanyAddress", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("Website", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("Fax", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("CardNumber", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("Servicer", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("StartDate", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("EndDate", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("RelationLevel", System.Type.GetType("System.String")));
           table.Columns.Add(new DataColumn("Favrate", System.Type.GetType("System.String")));


           GroupId = Int32.Parse(this.TrviewGroup.SelectedNode.Value);
           Maticsoft.Common.MessageBox.ShowConfirm(this.btnConfirm, "你是否想往【" + TrviewGroup.SelectedNode.Text + "】添加人员！");
           foreach (DataListItem list in this.DlistImport.Items)
           {


               Label lbName = ((Label)list.FindControl("lbName"));
               string strItem = lbName.Text;
               if (strItem.Length > 2)
               {
                   newCustomer.Name = ((Label)list.FindControl("lbName")).ToolTip;
               }
               else
               {
                   newCustomer.Name = strItem;
               }
               Label lbNickName = ((Label)list.FindControl("lbNickName"));
               strItem = lbNickName.Text;
               if (strItem.Length > 2)
               {
                   newCustomer.NickName = ((Label)list.FindControl("lbNickName")).ToolTip;
               }
               else
               {
                   newCustomer.NickName = strItem;
               }

               Label lbMobile = ((Label)list.FindControl("lbMobile"));
               strItem = lbMobile.Text;
               if (strItem.Length > 4)
               {
                   newCustomer.Mobile = ((Label)list.FindControl("lbMobile")).ToolTip;
               }
               else
               {
                   newCustomer.Mobile = strItem;

               }
               Label lbBirthday = ((Label)list.FindControl("lbBirthday"));
               strItem = lbBirthday.Text;
               if (strItem.Length > 4)
               {
                   newCustomer.Birthday = ((Label)list.FindControl("lbBirthday")).ToolTip;
               }
               else
               {
                   newCustomer.Birthday = strItem;
               }
               Label lbComName = ((Label)list.FindControl("lbComName"));
               strItem = lbComName.Text;
               if (strItem.Length > 4)
               {
                   newCustomer.CompanyName = ((Label)list.FindControl("lbComName")).ToolTip;
               }
               else
               {
                   newCustomer.CompanyName = strItem;

               }
               Label lbCompanyAddress = ((Label)list.FindControl("lbCompanyAddress"));
               strItem = lbCompanyAddress.Text;
               if (strItem.Length > 4)
               {
                   newCustomer.CompanyAddress = ((Label)list.FindControl("lbCompanyAddress")).ToolTip;
               }
               else
               {
                   newCustomer.CompanyAddress = strItem;
               }
               Label lbEmail = ((Label)list.FindControl("lbEmail"));
               strItem = lbEmail.Text;
               if (strItem.Length > 8)
               {
                   newCustomer.Email = ((Label)list.FindControl("lbEmail")).ToolTip;
               }
               else
               {
                   newCustomer.Email = strItem;
               }
               Label lbPostCode = ((Label)list.FindControl("lbPostCode"));
               strItem = lbPostCode.Text;
               if (strItem.Length > 8)
               {
                   newCustomer.PostCode = ((Label)list.FindControl("lbPostCode")).ToolTip;
               }
               else
               {
                   newCustomer.PostCode = strItem;

               }
               newCustomer.Sex = ((Label)list.FindControl("lbSex")).Text;
               newCustomer.mobile2= ((Label)list.FindControl("lbMobile2")).Text;
               newCustomer.QQ = ((Label)list.FindControl("lbQQ")).Text;
               newCustomer.Telephone = ((Label)list.FindControl("lbTelephone")).Text;
               newCustomer.UserId = Int32.Parse(Public.GetUserId(this.Page).ToString());
               newCustomer.StartDate = DateTime.Parse(((Label)list.FindControl("lbStartDate")).Text);
               newCustomer.EndDate = DateTime.Parse(((Label)list.FindControl("lbEndDate")).Text);
               newCustomer.Positions = ((Label)list.FindControl("lbPositions")).Text;
               newCustomer.HomeTel = ((Label)list.FindControl("lbHomeTel")).Text;
               newCustomer.HomeAddress = ((Label)list.FindControl("lbHomeAddress")).Text;
               newCustomer.Website = ((Label)list.FindControl("lbWebsite")).Text;
               newCustomer.Fax = ((Label)list.FindControl("lbFax")).Text;
               newCustomer.CardNumber = ((Label)list.FindControl("lbCardNumber")).Text;
               newCustomer.Servicer = ((Label)list.FindControl("lbServicer")).Text;
               newCustomer.Favrate = ((Label)list.FindControl("lbFavrate")).Text;
               newCustomer.RelationLevel = ((Label)list.FindControl("lbRelationLevel")).Text;
               newCustomer.GroupId = GroupId;
               int result= myCustomer.Add(newCustomer);
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
               Public.Datalistbind(GetDataSet(" where GroupId='" + Int32.Parse(this.TrviewGroup.SelectedNode.Value) + "' and EC_Customer.UserId='" + Public.GetUserId(this.Page).ToString() + "'"), this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
               this.lbTishi.Text = "【" + this.TrviewGroup.SelectedNode.Text + "】组中共有:";
               strwhere = " GroupId='" + this.TrviewGroup.SelectedNode.Value + "'";
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
   protected void btnCancer_Click(object sender, EventArgs e)
   {
       this.DlistImport.Visible = false;
       this.btnConfirm.Visible = false;
       this.btnCancer.Visible = false;
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
       {
           string strwhere = " GroupId='" + SelectNode.Value + "' and UserId='" + Public.GetUserId(this.Page).ToString() + "'";
           DataSet ds = myCustomer.GetList(strwhere);
           StringBuilder builder = new StringBuilder();
           foreach(DataRow row in ds.Tables[0].Rows)
           {
               builder.Append(row["Mobile"].ToString()+"\r\n");
              
           }
           string strfilename="名片夹分组【"+SelectNode.Text+"】中所有客户的手机号码.txt";
           string strfiletype="application/ms-txt";
           GenerationCvsFile(builder,strfilename,strfiletype);
       }
   }
   protected void btndelGroup_Click(object sender, EventArgs e)
   {
       TreeNode SelectNode = this.TrviewGroup.SelectedNode;
         
       if (SelectNode.Value==null)
       {
           MessageBox.Show(this.Page, "请在左侧选择您要删除的组！");
       }
       else
       {
           DataSet ds = myCustomer.GetList(" GroupId='" + SelectNode.Value + "' and UserId='" + Public.GetUserId(this.Page).ToString() + "'");
          if (ds.Tables[0].Rows.Count > 0)
          {
              MessageBox.Show(this.Page, "对不起【" + SelectNode.Text + "】中存在客户信息请先移除组内所有客户在删除该组！");
              return;
          }
          else
          {
              myCustomerGroup.Delete(Int32.Parse(SelectNode.Value.ToString()));
              MessageBox.Show(this.Page, SelectNode.Text+"删除成功！");
          }
       
           SelectNode.Parent.ChildNodes.Remove(SelectNode);
           this.PanelGroupOperate.Visible =false;
           this.PanelAddCums.Visible = false;
           this.PanelAddGroup.Visible = false;
           this.Panelist.Visible =false;
           this.PanelGroupOperate.Visible = true;
           this.PanelImport.Visible = false;
           this.PanelGroupOperate.Visible =false;

                  
       }
   }
   protected void lbtnView_Click(object sender, EventArgs e)
   {
       TreeNode SelectNode = this.TrviewGroup.SelectedNode;
       this.lbtype.Text = "1";
       ShowControl();
       Public.Datalistbind(GetDataSet(" where GroupId='" + Int32.Parse(SelectNode.Value) + "' and EC_Customer.UserId='" + Public.GetUserId(this.Page).ToString() + "'"), this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);

       if (this.Dlist.Items.Count > 0)
       {
           this.Panelist.Visible = true;

       }
       else
       {
           this.Panelist.Visible = false;
           this.lbViewTishi.Text = "无记录";
       }
   }
   protected void Button1_Click(object sender, EventArgs e)
   {
       this.lbtype.Text = "1";
       this.PanelAddGroup.Visible = false;
       this.PanelAddCums.Visible = false;
       this.Panelist.Visible = true;
   }
   protected void Button2_Click(object sender, EventArgs e)
   {
       this.lbtype.Text = "1";
       this.PanelAddGroup.Visible = false;
       this.PanelAddCums.Visible = false;
       this.Panelist.Visible = true;
   }

   #region 根据条件决定那个panel显示
   /// <summary>
   /// 根据条件决定那个panel显示
   /// </summary>

   public void ShowControl()
   {
       switch (this.lbtype.Text)
       {
           case "1": this.PanelEditGroup.Visible =false; this.PanelAddGroup.Visible = false; this.PanelAddCums.Visible = false; this.Panelist.Visible = true; this.PanelGroupOperate.Visible = true; this.PanelImport.Visible = false; break;
           case "2": this.PanelEditGroup.Visible = false; this.PanelAddGroup.Visible = false; this.PanelAddCums.Visible = true; this.Panelist.Visible = false; this.PanelGroupOperate.Visible = true; this.PanelImport.Visible = false; break;
           case "3": this.PanelEditGroup.Visible = false; this.PanelAddGroup.Visible = true; this.PanelAddCums.Visible = false; this.Panelist.Visible = false; this.PanelGroupOperate.Visible = true; this.PanelImport.Visible = false; break;
           case "4": this.PanelEditGroup.Visible = true; this.PanelAddGroup.Visible = false; this.PanelAddCums.Visible = false; this.Panelist.Visible = false; this.PanelGroupOperate.Visible = true; this.PanelImport.Visible = false; break;
           case "5": this.PanelEditGroup.Visible = false; this.PanelAddGroup.Visible = false; this.PanelAddCums.Visible = false; this.Panelist.Visible = false; this.PanelGroupOperate.Visible = true; this.PanelImport.Visible = true; break;

       }
       TreeNode SelectNode = this.TrviewGroup.SelectedNode;
       if (SelectNode.Value == "-2")
       {
           this.lbtnAddGroup.Visible = false;
       }
       else
       {
           this.lbtnAddGroup.Visible = true;
       }
   }
   #endregion

   public DataSet GetDataSet(string strwhere)
   {
       string strsql = string.Empty;
       if (Int32.Parse(this.TrviewGroup.SelectedNode.Value) > 0)
       {
            strsql = "SELECT     dbo.EC_Customer.GroupId,dbo.EC_Customer.Name, dbo.EC_Customer.Mobile, dbo.EC_Customer.Id , " +
                          "  dbo.EC_Customer.NickName, dbo.EC_Customer.CompanyName, dbo.EC_CustomerGroup.Name as GroupName, " +
                          " dbo.EC_Customer.Sex,dbo.EC_Customer.QQ" +
                          " FROM         dbo.EC_Customer INNER JOIN" +
                          " dbo.EC_CustomerGroup ON dbo.EC_Customer.GroupId = dbo.EC_CustomerGroup.Id " + strwhere + " order by EC_Customer.id";

       }
       else
       {
          strsql = "SELECT     GroupId="+this.TrviewGroup.SelectedNode.Value+",dbo.EC_Customer.Name, dbo.EC_Customer.Mobile, dbo.EC_Customer.Id , " +
                         "  dbo.EC_Customer.NickName, dbo.EC_Customer.CompanyName,  GroupName='"+this.TrviewGroup.SelectedNode.Text+"', " +
                         " dbo.EC_Customer.Sex,dbo.EC_Customer.QQ" +
                         " FROM         dbo.EC_Customer " + strwhere + "  order by EC_Customer.id";
       } 
       DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(strsql);
       return ds;
   }
   protected void btnEditGroup_Click(object sender, EventArgs e)
   {
       this.lbtype.Text = "4";
       ShowControl();
       newCustomerGroup = myCustomerGroup.GetModel(Int32.Parse(this.TrviewGroup.SelectedNode.Value));
       this.txtEditGroupContent.Text = newCustomerGroup.Name;
      
   }
   protected void btnEditGroupSave_Click(object sender, EventArgs e)
   {
       TreeNode SelectNode = this.TrviewGroup.SelectedNode;

       newCustomerGroup = myCustomerGroup.GetModel(Int32.Parse(this.TrviewGroup.SelectedNode.Value));
       if (newCustomerGroup.Name !=  this.txtEditGroupContent.Text)
       {
           newCustomerGroup.Name = this.txtEditGroupContent.Text;
           myCustomerGroup.Update(newCustomerGroup);
           SelectNode.Text = this.txtEditGroupContent.Text;
           this.lbTishi.Text = "您选择的当前分组为:【" +  this.txtEditGroupContent.Text + "】 本组中共有:" + this.lbCount.Text + "短语";

       }
       MessageBox.Show(this.Page, "更新组成功！");
       this.lbtype.Text = "1";
       ShowControl();
   
   }
   protected void btnEditGroupBack_Click(object sender, EventArgs e)
   {
       this.lbtype.Text = "1";
       ShowControl();
   }
   protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
   {
       AspNetPager1.CurrentPageIndex = e.NewPageIndex;
       Public.Datalistbind(GetDataSet(" where GroupId='" + Int32.Parse(this.TrviewGroup.SelectedNode.Value) + "' and EC_Customer.UserId='" + Public.GetUserId(this.Page).ToString() + "'"), this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);


   }

   protected void btnChangeGroup_Click(object sender, EventArgs e)
   {
       try
       {
           if (this.dropChangeGroup.SelectedValue == "-3")
           {
               MessageBox.Show(this.Page, "请选择您要更换的名片夹！");
               return;
           }
           int i = 0;
           foreach (DataListItem Dli in this.Dlist.Items)
           {
               System.Web.UI.HtmlControls.HtmlInputCheckBox chkitem = (System.Web.UI.HtmlControls.HtmlInputCheckBox)Dli.FindControl("Chkitem");
               Label Custormid = (Label)Dli.FindControl("lbId");
               if (chkitem.Checked)
               {
                   i = i + 1;
                   newCustomer=myCustomer.GetModel(Int32.Parse(Custormid.Text));
                   newCustomer.GroupId=Int32.Parse(this.dropChangeGroup.SelectedValue);
                   myCustomer.Update(newCustomer);
                   MessageBox.Show(this.Page, "分组更换成功！");
               }
           }
           if (i == 0)
           {
               MessageBox.Show(this.Page, "请选择您需要更换名片夹的客户！");
           }
           Public.Datalistbind(GetDataSet(" where GroupId='" + Int32.Parse(this.TrviewGroup.SelectedNode.Value) + "' and EC_Customer.UserId='" + Public.GetUserId(this.Page).ToString() + "'"), this.Dlist, this.Panelist, this.lbViewTishi, AspNetPager1);
           this.dropChangeGroup.SelectedValue = "-3";
       }
       catch (Exception ex)
       {
           MessageBox.Show(this.Page, ex.Message.ToString());
       }
   }

   protected void DlistImport_ItemDataBound(object sender, DataListItemEventArgs e)
   {
       if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
       {
           Label lbName = ((Label)e.Item.FindControl("lbName"));
           string strItem = lbName.Text;
           if (strItem.Length > 2)
           {
               lbName.Text = strItem.Substring(0, 2) + ".....";
               lbName.ToolTip = strItem;
           }
           Label lbNickName = ((Label)e.Item.FindControl("lbNickName"));
           strItem = lbNickName.Text;
           if (strItem.Length > 2)
           {
               lbNickName.Text = strItem.Substring(0, 2) + ".....";
               lbNickName.ToolTip = strItem;
           }
           Label lbMobile = ((Label)e.Item.FindControl("lbMobile"));
           strItem = lbMobile.Text;
           if (strItem.Length > 4)
           {
               lbMobile.Text = strItem.Substring(0, 4) + ".....";
               lbMobile.ToolTip = strItem;
           }
           Label lbBirthday = ((Label)e.Item.FindControl("lbBirthday"));
           strItem = lbBirthday.Text;
           if (strItem.Length > 4)
           {
               lbBirthday.Text = strItem.Substring(0, 4) + ".....";
               lbBirthday.ToolTip = strItem;
           }
           Label lbComName = ((Label)e.Item.FindControl("lbComName"));
           strItem = lbComName.Text;
           if (strItem.Length > 4)
           {
               lbComName.Text = strItem.Substring(0, 4) + ".....";
               lbComName.ToolTip = strItem;
           }
           Label lbCompanyAddress = ((Label)e.Item.FindControl("lbCompanyAddress"));
           strItem = lbCompanyAddress.Text;
           if (strItem.Length > 4)
           {
               lbCompanyAddress.Text = strItem.Substring(0, 4) + ".....";
               lbCompanyAddress.ToolTip = strItem;
           }
           Label lbEmail = ((Label)e.Item.FindControl("lbEmail"));
           strItem = lbEmail.Text;
           if (strItem.Length > 8)
           {
               lbEmail.Text = strItem.Substring(0, 8) + ".....";
               lbEmail.ToolTip = strItem;
           }
           Label lbPostCode = ((Label)e.Item.FindControl("lbPostCode"));
           strItem = lbPostCode.Text;
           if (strItem.Length > 8)
           {
               lbPostCode.Text = strItem.Substring(0, 8) + ".....";
               lbPostCode.ToolTip = strItem;
           }
       }
   }
  
}
  