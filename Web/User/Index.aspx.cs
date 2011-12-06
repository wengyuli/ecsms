using System;

public partial class User_Index : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Init();
            //this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "onload", "<script>window.onload=openBroad();</script>");
            
        }
    }
    void Init()
    {
        int role = Public.GetUserRole(int.Parse(Public.GetUserId(this.Page)));
        if (role == 0 || role == 1)
        {
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "对不起，您不是用户身份，请登录后进行操作。", "login.aspx");
            return;
        }

        if (Public.GetUserId(this.Page) != "0")
        {
            ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
            ECSMS.Model.EC_User model = new ECSMS.Model.EC_User();
            model = bll.GetModel(int.Parse(Public.GetUserId(this.Page)));
            if (model.Role == 2)//如果是集团用户则显示用户管理项
            {
                this.divManageUser.Visible = true;
                this.divgivelog.Visible = true;
                this.divWaitSms.Visible = true;
            }
        }
    }
    protected void btnQuit_Click(object sender, EventArgs e)
    {
        Response.Cookies["UserId"].Value = "0";
        Response.Cookies["UserId"].Expires = DateTime.Now.AddMilliseconds(10);
        Server.Transfer("login.aspx");
    }
}
