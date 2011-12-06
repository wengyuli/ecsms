using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Admin_ValeCode : System.Web.UI.Page
{
    private void Page_Load(object sender, System.EventArgs e)
    {
        string checkCode = CreateRandomCode();
        Session["CheckCode"] = checkCode;
        CreateImage(checkCode);
    }

    private string CreateRandomCode()
    {
        string[] allChar = {"3","4","5","6","7","8","9","A","B","C","D","E","F","G","H","J","K","L","M","N","P","Q","R","S","T","U","W","X","Y"};
        Random rand = new Random();
        string str = string.Empty;
        for (int i = 0; i < 4;i++ )
        {
            str += allChar[rand.Next(29)];
        }
        return str;
    }

    private void CreateImage(string checkCode)
    {
        int iwidth = (int)(checkCode.Length * 15);
        System.Drawing.Bitmap image = new System.Drawing.Bitmap(iwidth, 30);
        Graphics g = Graphics.FromImage(image);
        Font f = new System.Drawing.Font("Arial", 13, System.Drawing.FontStyle.Bold);
        Brush b = new System.Drawing.SolidBrush(Color.White);
        g.Clear(Color.Blue);
        g.DrawString(checkCode, f, b, 3, 3);

        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        Response.ClearContent();
        Response.ContentType = "image/Jpeg";
        Response.BinaryWrite(ms.ToArray());
        g.Dispose();
        image.Dispose();
    }

}
