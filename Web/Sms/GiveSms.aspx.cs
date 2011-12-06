using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class GiveSms :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (this.Page.PreviousPage == null)
            {
                this.Page.Controls.Clear();
                this.Page.Response.Write("请通过正常途径进入本页面。");
                return;
            }
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != ""
                && Public.GetUserId(this.Page) != "0")
            {                
                this.lblId.Text = Request.QueryString["id"].ToString();
                ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
                ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
                newUser = myUser.GetModel(int.Parse(this.lblId.Text));                
                this.lblAccount.Text = newUser.Account;
                this.lblName.Text = newUser.Name;
                this.trOperType.Visible = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) != 0 ? false: true ;
                BindSmsCount();
                LoadSmsTypes();
                if (Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0)
                {
                    if (newUser.Role == 1)
                    {
                        this.btnBack.PostBackUrl = "~/admin/users.aspx?type=agent";
                    }
                    else
                    {
                        this.btnBack.PostBackUrl = "~/admin/users.aspx?type=user";
                    }
                }
                else
                {
                    this.btnBack.PostBackUrl = "~/usermanage.aspx?type=user";
                }
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this,"请通过合法途径访问本页面！",ResolveUrl("~/default.aspx"));
            }
        }
    }
    void LoadSmsTypes()
    {
        ECSMS.BLL.EC_SmsType MySmstype = new ECSMS.BLL.EC_SmsType();
        List<ECSMS.Model.EC_SmsType> smsTypes = MySmstype.GetModelList("");
        this.ddlSmsType.DataSource = smsTypes;
        this.ddlSmsType.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {      
        if(!Maticsoft.Common.PageValidate.IsNumber(this.txtCount.Text))
        {
            Maticsoft.Common.MessageBox.Show(this,"充值条数应为正整数！");
            return;
        }      

        int smsCount = 0;//充值短信数量
        int giverLeaveCount = 0;//给的人的余额
        int receiverLeaveCount = 0;//得的人的余额

        smsCount = int.Parse(this.txtCount.Text);
        ECSMS.BLL.EC_UserSmsAccount bll = new ECSMS.BLL.EC_UserSmsAccount();
        ECSMS.Model.EC_UserSmsAccount model = new ECSMS.Model.EC_UserSmsAccount();
        DataSet ds = bll.GetList("userid=" + Public.GetUserId(this.Page) + " and smstype='" + ddlSmsType.SelectedValue + "' ");
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            giverLeaveCount=int.Parse(ds.Tables[0].Rows[0]["leavenum"].ToString());
        }

        ds = bll.GetList("userid=" + this.lblId.Text + " and smstype='" + ddlSmsType.SelectedValue + "'");
        count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            receiverLeaveCount = int.Parse(ds.Tables[0].Rows[0]["leavenum"].ToString());
        }

        if (giverLeaveCount < smsCount)
        {
            Maticsoft.Common.MessageBox.Show(this, "您在【" + this.ddlSmsType.Text + "】中的余额为【"+giverLeaveCount+"】，不能充值【" + smsCount + "】！");
            return;
        }


        if (this.ddlOperType.SelectedValue == "sub")
        {
            if (receiverLeaveCount < smsCount)
            {
                Maticsoft.Common.MessageBox.Show(this,"此用户的余额为【"+receiverLeaveCount+"】，无法扣值【"+smsCount+"】");
                return;
            }
        }
        //扣自己的值
        string strRealCount="0"; 
        strRealCount = this.ddlOperType.SelectedValue == "add" ? smsCount.ToString() : "-" + smsCount.ToString();
        Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("update ec_usersmsaccount set leavenum=leavenum-" + strRealCount + " where userid=" + Public.GetUserId(this.Page) + " and smstype='" + this.ddlSmsType.SelectedValue + "'");

        //给对方充值
        ds = bll.GetList("userid=" + this.lblId.Text + " and smstype='" + ddlSmsType.SelectedValue + "'");
        count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            model = bll.GetModel(int.Parse(ds.Tables[0].Rows[0]["id"].ToString()));
            model.LeaveNum = model.LeaveNum + int.Parse(strRealCount);
            bll.Update(model);
        }
        else
        {
            model.InitNum = smsCount;
            model.LargessNum = 0;
            model.LeaveNum = smsCount;
            model.SmsType = ddlSmsType.SelectedValue;
            model.UserId = int.Parse(this.lblId.Text);
            bll.Add(model);
        }   

        BindSmsCount();
        //写入充值记录
        ECSMS.BLL.EC_SmsAssignLog myLog = new ECSMS.BLL.EC_SmsAssignLog();
        ECSMS.Model.EC_SmsAssignLog newLog = new ECSMS.Model.EC_SmsAssignLog();
        newLog.ActType = this.ddlOperType.SelectedValue=="sub"?"sub":"add";
        newLog.FromUserId = int.Parse( Public.GetUserId(this.Page).ToString());
        newLog.IsPay = 1;
        newLog.OperTime = DateTime.Now;
        newLog.Remark = this.txtRemark.Text.Trim();
        newLog.SmsCount = int.Parse(this.txtCount.Text);
        newLog.SmsType = this.ddlSmsType.SelectedValue;
        newLog.ToUserId = int.Parse(this.lblId.Text);
        newLog.LeaveNum = receiverLeaveCount + int.Parse(strRealCount);
        myLog.Add(newLog);

        if (cbContinue.Checked)
        {
            Maticsoft.Common.MessageBox.Show(this, "充值账户：【" + this.lblAccount.Text + "】\\r\\n\\r\\n充值产品：【" + this.ddlSmsType.SelectedItem.Text + "】\\r\\n\\r\\n充值条数：【" + strRealCount + "】\\r\\n\\r\\n当前余额：【"+newLog.LeaveNum+"】\\r\\n\\r\\n充值时间：【" + DateTime.Now + "】\\r\\n\\r\\n\\r\\n充值成功！\\r\\n");
        }
        else
        { 
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "充值账户：【" + this.lblAccount.Text + "】\\r\\n\\r\\n充值产品：【" + this.ddlSmsType.SelectedItem.Text + "】\\r\\n\\r\\n充值条数：【" + strRealCount + "】\\r\\n\\r\\n当前余额：【"+newLog.LeaveNum+"】\\r\\n\\r\\n充值时间：【" + DateTime.Now + "】\\r\\n\\r\\n\\r\\n充值成功！\\r\\n", ResolveUrl(this.btnBack.PostBackUrl));
        }
        

    }

    protected void BindSmsCount()
    {
        ECSMS.BLL.EC_UserSmsAccount myAccount = new ECSMS.BLL.EC_UserSmsAccount();
        DataSet ds = myAccount.GetList("userid=" + this.lblId.Text);
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            this.lblSmsTotal.Text = "";
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                this.lblSmsTotal.Text += Public.GetProNameByLetter( row["smstype"].ToString()) + "【" + row["LeaveNum"].ToString() + "】条,<br>";
            }
        }
        else
        {
            this.lblSmsTotal.Text = "未分配短信";
        }
    }
}
