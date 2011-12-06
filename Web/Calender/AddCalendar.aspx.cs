using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Calendar :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Request.QueryString["Id"] != null && Request.QueryString["Id"] != "")
            { 
                ECSMS.BLL.EC_Calendar myCal=new ECSMS.BLL.EC_Calendar();
                ECSMS.Model.EC_Calendar newCal=new ECSMS.Model.EC_Calendar();
                newCal = myCal.GetModel(int.Parse( Request.QueryString["Id"].ToString()));
                this.txtTitle.Text = newCal.Title;
                this.txtTime.Text = newCal.ToDoTime.ToString();
                this.txtContent.Text = newCal.Content;     
                
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try 
        {
            if (this.txtContent.Text != "" && txtTime.Text != "" && txtTitle.Text != "")
            {
                ECSMS.BLL.EC_Calendar myCal = new ECSMS.BLL.EC_Calendar();
                ECSMS.Model.EC_Calendar newCal = new ECSMS.Model.EC_Calendar();
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != "")
                {
                    newCal = myCal.GetModel(int.Parse(Request.QueryString["id"].ToString()));
                    newCal.Content = txtContent.Text;
                    newCal.IsDone = 0;
                    newCal.PostTime = DateTime.Now;
                    newCal.Title = txtTitle.Text;
                    newCal.ToDoTime = Convert.ToDateTime(txtTime.Text);
                    newCal.UserId = int.Parse(Public.GetUserId(this.Page));

                    myCal.Update(newCal);
                }
                else
                {
                    if (Convert.ToDateTime(this.txtTime.Text) < DateTime.Now.AddHours(1))
                    {
                        Maticsoft.Common.MessageBox.Show(this,"日程时间需比当前时间晚一小时，您可以选择【"+DateTime.Now.AddHours(1)+"】以后的时间。");
                        return;
                    }
                    newCal.Content = txtContent.Text;
                    newCal.IsDone = 0;
                    newCal.PostTime = DateTime.Now;
                    newCal.Title = txtTitle.Text;
                    newCal.ToDoTime = Convert.ToDateTime(txtTime.Text);
                    newCal.UserId = int.Parse(Public.GetUserId(this.Page));

                    myCal.Add(newCal);
                }               
                
                
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "日程增加成功，将于" + txtTime.Text + "进行提醒！", "ViewCalender.aspx");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "请完善内容后在增加日程！");
            }
        }
        catch (Exception ex)
        { 
            
        }
        
    }
}
