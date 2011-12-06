using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class PwdModify :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Public.GetUserRole(int.Parse(Public.GetUserId(this.Page))) == 0)
            {
                this.divadminpwd.Visible = true;
            }
            else
            {
                this.divadminpwd.Visible = false;
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.txtOldPwd.Text == "" || this.txtNewPwd1.Text == "" || this.txtNewPwd2.Text == "")
        {
            Maticsoft.Common.MessageBox.Show(this, "请将密码填写完整再提交。");
        }
        else
        {
            if (this.txtNewPwd1.Text != this.txtNewPwd2.Text)
            {
                Maticsoft.Common.MessageBox.Show(this, "两次填写密码不一致。");
            }
            else
            {
                ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
                ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
                if (Public.GetUserId(this.Page) != "0")
                {
                    int userid = int.Parse(Public.GetUserId(this.Page));
                    DataSet ds = myUser.GetList("id="+userid+" and pwd='"+this.txtOldPwd.Text+"'");
                    int count = ds.Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        newUser = myUser.GetModel(userid);
                        newUser.Pwd = this.txtNewPwd2.Text;
                        myUser.Update(newUser);
                        Maticsoft.Common.MessageBox.Show(this, "密码修改成功!您的新密码是【"+this.txtNewPwd1.Text+"】");
                    }
                    else
                    {
                        Maticsoft.Common.MessageBox.Show(this, "原密码输入错误。");
                    }                    
                }
            }
        }
    }
    protected void btnModify_Click(object sender, EventArgs e)
    {
        if (this.txtDelPwd.Text != "" && this.txtDelPwd1.Text != "" && this.txtDelPwd2.Text != "")
        {
            if (this.txtDelPwd1.Text == this.txtDelPwd2.Text)
            {
                ECSMS.BLL.EC_Config bll = new ECSMS.BLL.EC_Config();
                ECSMS.Model.EC_Config model = new ECSMS.Model.EC_Config();
                DataSet ds = bll.GetList(" delpwd='"+this.txtDelPwd.Text+"' ");
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    model = bll.GetModel(int.Parse(ds.Tables[0].Rows[0][0].ToString()));
                    model.DelPwd = this.txtDelPwd2.Text;
                    bll.Update(model);
                    Maticsoft.Common.MessageBox.Show(this, "密码修改成功！您的新密码是【" + this.txtDelPwd1.Text + "】");
                }
                else
                {
                    Maticsoft.Common.MessageBox.Show(this, "原密码输入错误！");
                }
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "两次输入的新密码不一致！");
            }
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this,"请填写完密码后在进行修改！");
        }
    }
}
