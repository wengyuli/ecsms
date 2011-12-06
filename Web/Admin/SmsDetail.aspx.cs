using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class Admin_SmsDetail : System.Web.UI.Page
{ 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int role = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)));
            if (role != 0)
            {
                this.Page.Controls.Clear();
                Response.Write("您没有管理员的权限，拒绝访问。");
            }

            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                this.lblId.Text=Request.QueryString["id"].ToString();
                string strSql = string.Empty;
                strSql = "select top 1000 * from sendmsgtable where ServerID='"+this.lblId.Text+"' ";
                DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(strSql);
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    this.lblIsTimeSend.Text = ds.Tables[0].Rows[0]["timesend"].ToString() == "" ? "非定时短信" : "定时短信";
                    this.lblContentCharCount.Text = ds.Tables[0].Rows[0]["msgtitle"].ToString().Length.ToString();
                    this.lblNumbersCount.Text = ds.Tables[0].Rows[0]["numberscount"].ToString();
                    if (ds.Tables[0].Rows[0]["msgtype"].ToString() == "X")
                    {
                        this.txtContent.Text = ds.Tables[0].Rows[0]["msgtitle"].ToString();
                        this.txtNumbers.Text = ds.Tables[0].Rows[0]["phonenumber"].ToString()+"";
                        this.btnSend0.Visible = false;
                        this.lblNumber.Text = "发送需求：";
                        this.btnBack.PostBackUrl = "xsms.aspx";
                    }
                    else
                    {
                        int sendnum = int.Parse(ds.Tables[0].Rows[0]["sendnum"].ToString());
                        int numbersCount = int.Parse(ds.Tables[0].Rows[0]["numberscount"].ToString());
                        int exerCount = int.Parse(ds.Tables[0].Rows[0]["exernumbers"].ToString());
                        List<string> listOfDistinct = new List<string>();
                        foreach(DataRow row in ds.Tables[0].Rows)
                        {
                            listOfDistinct.Add(row["phonenumber"].ToString());
                        }
                        List<string> listResult = listOfDistinct.Distinct().ToList();
                        listResult.Take(exerCount).ToList().ForEach(m => this.txtExperNumbers.Text += m + "\r\n");
                        listResult.Skip(exerCount).ToList().ForEach(m => this.txtNumbers.Text += m + "\r\n");                     
                         
                        for (int i = 0; i < sendnum; i++)
                        {
                            this.txtContent.Text += ds.Tables[0].Rows[i]["MsgTitle"].ToString();
                        }    
                    }
                    this.lblSmstype.Text =new ECSMS.BLL.EC_SmsType().GetModel(ds.Tables[0].Rows[0]["msgtype"].ToString()).Name;
                   
                    this.lblExperNumCount.Text = "体验号码：" + ds.Tables[0].Rows[0]["exernumbers"].ToString()+"个";
                    this.lblSendTime.Text = ds.Tables[0].Rows[0]["sendtime"].ToString();
                    ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
                    ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
                    int userId = int.Parse(ds.Tables[0].Rows[0]["userid"].ToString());
                    newUser = myUser.GetModel(userId);
                    if (newUser == null)
                    {
                        if (userId == 0)
                        {
                            this.lblUserName.Text = "短信平台";
                        }
                        else
                        {
                            this.lblUserName.Text = "";
                        }
                    }
                    else
                    {
                        this.lblUserName.Text = newUser.Account;
                    }           
                }
            }
        }
    }
     

    protected void btnSend_Click(object sender, EventArgs e)
    {
        string strSql = string.Empty; 
        string strShow = string.Empty; 
        strSql = "update sendmsgtable set MsgStatus="+(int)ECSMS.Channel.SmsStatus.发送成功+",senttime='"+DateTime.Now+"' where ServerID='"+this.lblId.Text+"'";
        int count = Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(strSql);
        Maticsoft.Common.MessageBox.ShowAndRedirect(this, "已将此任务共【" + count + "】条记录状态处理为【发送成功】。", ResolveUrl(this.btnBack.PostBackUrl));
    }

    protected void btnSend0_Click(object sender, EventArgs e)
    { 
        string strSql = string.Empty; 
        string strShow = string.Empty;
        bool IsTimeSemd = this.lblIsTimeSend.Text == "定时短信"?true:false;
        strSql = "update sendmsgtable set MsgStatus=" + (IsTimeSemd ? (int)ECSMS.Channel.SmsStatus.定时待发 : (int)ECSMS.Channel.SmsStatus.等待发送) + ",senttime='" + DateTime.Now + "' where ServerID='" + this.lblId.Text + "'";
        int count = Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(strSql);
        Maticsoft.Common.MessageBox.ShowAndRedirect(this, "已将此任务共【" + count + "】条记录状态改变为【待发进入自动发送】。", ResolveUrl(this.btnBack.PostBackUrl));
    
    } 



    protected void btnExport_Click(object sender, EventArgs e)
    {
        string strSql = string.Empty;
        strSql = "select * from sendmsgtable where ServerID='"+this.lblId.Text+"' ";
        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(strSql);
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            StringBuilder strNumbers = new StringBuilder("");
            string strTemp = string.Empty;
            int sendnum = int.Parse(ds.Tables[0].Rows[0]["sendnum"].ToString());
            for (int i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {
                strNumbers.Append(ds.Tables[0].Rows[i]["phonenumber"].ToString() + "\r\n");
                if (sendnum > 1)
                {
                    i += sendnum - 1;
                }
            }
 
            GenerationCvsFile(strNumbers, "【" + this.lblUserName.Text + "】在【" + Convert.ToDateTime( this.lblSendTime.Text).ToString("yyyyMMddhhmmss") + "】发送的号码，数量【" + this.lblNumbersCount.Text + "】.txt", "application/ms-txt");
        }
    }




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
            Maticsoft.Common.MessageBox.Show(this.Page, ex.Message.ToString());
        }
    }
    protected void btnTest_Click(object sender, EventArgs e)
    {
        if (this.txtTestNumber.Text != "")
        {
            new ECSMS.Channel.LingTong().SendSms(this.txtTestNumber.Text, this.txtContent.Text);
            Maticsoft.Common.MessageBox.Show(this.Page,"已经发出！");
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this.Page, "请输入测试号码。");
        }
    }
}
