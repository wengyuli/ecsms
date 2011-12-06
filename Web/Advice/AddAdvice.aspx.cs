using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Advice_AddAdvice : PageBase
{
    ECSMS.BLL.EC_Advice bll = new ECSMS.BLL.EC_Advice();
    ECSMS.Model.EC_Advice model = new ECSMS.Model.EC_Advice();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Public.GetUserId(this.Page) != "0")
            {
                this.lblUserId.Text = Public.GetUserId(this.Page);
                if (Public.GetUserRole(int.Parse(this.lblUserId.Text)) == 0)
                {
                    this.btnAdd.Visible = false;
                    this.Button1.PostBackUrl = "advicelist.aspx";
                }
            }
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
            {
                model = bll.GetModel(int.Parse(Request.QueryString["id"].ToString()));
                var user = new ECSMS.BLL.EC_User().GetModel(model.UserId.Value);
                this.txtContent.Text = model.Content + "\r\n\r\n【提交用户：" + user.Name + "；电话：" + user.Mobile + "；QQ：" + user.QQ+"】";                
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (this.txtContent.Text != "")
        {         
            model.Content = txtContent.Text+"投诉人："+Public.GetUserName(int.Parse(Public.GetUserId(this.Page)));
            model.State = 0;
            model.SubmitTime=DateTime.Now;
            model.UserId = int.Parse(this.lblUserId.Text);
            model.DoneTime = DateTime.Now;
            bll.Add(model);
            this.txtContent.Text = "";
            Maticsoft.Common.MessageBox.ShowAndRedirect(this,"您的投诉建议已经提交成功！我们会尽快处理，谢谢！",ResolveUrl( this.Button1.PostBackUrl));
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this,"请填写完内容后再提交！");
        }
    }
}
