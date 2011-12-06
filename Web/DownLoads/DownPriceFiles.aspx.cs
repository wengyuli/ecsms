using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DownLoads_DownPriceFiles : PageBase
{
    ECSMS.BLL.EC_DownLoad bll = new ECSMS.BLL.EC_DownLoad();
    ECSMS.Model.EC_DownLoad model = new ECSMS.Model.EC_DownLoad();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
        {
            this.lblId.Text = Request.QueryString["id"].ToString();
            
            model = bll.GetModel(int.Parse(this.lblId.Text));
            this.lblPrice.Text = model.Price.Replace("A", Public.GetProNameByLetter("A")).Replace("B", Public.GetProNameByLetter("B")).Replace("C", Public.GetProNameByLetter("C")).Replace("D", Public.GetProNameByLetter("D")).Replace("E", Public.GetProNameByLetter("E"));
            this.lblPrice.Text = this.lblPrice.Text.Replace("|",",");
            this.lblRemark.Text = model.Remark;

            this.lblLeaveNum.Text = Public.GetUserLeaveSms(int.Parse(Public.GetUserId(this.Page)));
        }
    }
    protected void btnDown_Click(object sender, EventArgs e)
    {
        string strPro = ddlPro.SelectedValue;
        int userLeaveNum=int.Parse( Public.GetUserLeaveSms(int.Parse(Public.GetUserId(this.Page)),strPro));
        model = bll.GetModel(int.Parse(this.lblId.Text));
        string[] strArr = model.Price.Split('|');
        int DownPrice=0;
        foreach(string str in strArr)
        {
            if (str.Contains(strPro))
            {
                string[] arr = str.Split('-');
                DownPrice = int.Parse(arr[1].ToString());
                break;
            }
        }
        if (userLeaveNum >= DownPrice)
        {
            Maticsoft.DBUtility.DbHelperSQL.ExecuteSql("update ec_usersmsaccount set leavenum=leavenum-" + DownPrice + " where userid=" + Public.GetUserId(this.Page) + " and smstype='" + strPro + "'");
            this.btnDown.Enabled = false;
            this.lblDownLink.Text="<a href='files/"+model.FullFileName+"'>【请在本连接上使用右键的“目标另存为...”下载本连接】</a>";
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this,"您的【"+this.ddlPro.SelectedItem.Text+"】余额为【"+userLeaveNum+"】，不够下载所需的额度，请改换其他产品进行下载。");
        }
    }
}
