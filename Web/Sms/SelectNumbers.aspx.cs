using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class SelectNumbers :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnReadNumbers_Click(object sender, EventArgs e)
    {
        try
        {
            if (this.fileUp.HasFile&&this.fileUp.PostedFile.ContentType=="text/plain")
            { 
                Random r = new Random();
                string url = Server.MapPath("~/temp/") + r.Next(11111,9999999) +this.fileUp.FileName;
                this.fileUp.SaveAs(url);
                StreamReader sr = new StreamReader(url);
                this.txtNumbers.Text = sr.ReadToEnd(); 
                this.Page.RegisterStartupScript(
                    "onload",
                    "<script>window.onload=function(){ getNumber();}</script>");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this,"请选择.txt文件进行号码导入。");
            }
        }
        catch (Exception ex)
        {
            Maticsoft.Common.MessageBox.Show(this, ex.Message);
        }
    }
}
