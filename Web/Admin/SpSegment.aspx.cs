using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_SegmentAdd : PageBase
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
            BindSp();
            BindSpSegment();
        }
    }

    protected void BindSp()
    {
        ECSMS.BLL.EC_SmsSp sp = new ECSMS.BLL.EC_SmsSp();
        DataSet ds = sp.GetList("");
        Public.DropdownListBind(this.ddlsp, ds, "Name", "Id");
    }

    protected void BindSpSegment()
    {
        ECSMS.BLL.EC_SmsSegment seg = new ECSMS.BLL.EC_SmsSegment();
        DataSet ds = seg.GetList("SpId="+ ddlsp.SelectedValue +"");
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            string strSeg = string.Empty;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                strSeg += row["Segment"].ToString() + "#";
            }

            this.txtSegment.Text = strSeg;
        }
        else
        {
            this.txtSegment.Text = "";
        }

    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (txtSegment.Text != "")
        {
            //删除
            Maticsoft.DBUtility.DbHelperSQL.GetSingle("delete ec_smssegment where spid="+this.ddlsp.SelectedValue+"");
            //添加
            ECSMS.BLL.EC_SmsSegment mySeg = new ECSMS.BLL.EC_SmsSegment();
            ECSMS.Model.EC_SmsSegment newseg;

            string strSeg = txtSegment.Text;
            strSeg = strSeg.Replace(" ", "");
            string[] segs = strSeg.Split('#');
            for (int i = 0; i < segs.Length;i++ )
            {
                if (segs[i].ToString() != "")
                {
                    newseg = new ECSMS.Model.EC_SmsSegment();
                    newseg.SpId = int.Parse(this.ddlsp.SelectedValue);
                    newseg.Segment = segs[i].ToString();
                    mySeg.Add(newseg);
                }   
            }            

            Maticsoft.Common.MessageBox.Show(this,"更新成功！");
        }
        else
        {
            Maticsoft.Common.MessageBox.Show(this,"请填写号段后再进行更新。");
        }
    }

    protected void ddlsp_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindSpSegment();
    }



}
