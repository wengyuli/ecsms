using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;

public partial class TestWebservice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(Convert.ToInt32(ECSMS.Channel.Product.A));
        //DataTable dt = new DataTable();
        //dt.Columns.Add("name");
        //dt.Columns.Add("age");
        //dt.Rows.Add("wengyuli", "20");
        //dt.Rows.Add("xiejianjun", "21");
        //dt.Rows.Add("wengyujing", "22");
        //dt.Rows.Add("wengyudong", "24");
        //DataSet ds = new DataSet();
        //ds.Tables.Add(dt);
        //this.Repeater1.DataSource = ds;
        //this.Repeater1.DataBind();
        //Random rand=new Random();
        //string strNumbers=string.Empty;
        //for(int i=0;i<100000;i++)
        //{
        //    strNumbers+="13567"+rand.Next(111111,999999)+"\r\n";
        //}
        
        //System.IO.File.AppendAllText("c:/numbers.txt",strNumbers);

        //Response.Write(Convert.ToDateTime("2010-02-05 12:09 ").AddHours(1) > DateTime.Now);
        //Public.MailSend("商信宝注册确认邮件", "恭喜您注册成功！", "191349433@qq.com,wengyuli@gmail.com");

        //万众的  电信  万众  
        //http://wt.umob.cn/submitdata/Service.asmx
        //测试账号dlqiann0，密码88888888，
        //电信测试801产品，彩信测试116产品，
        //卡发短信测试802

        //*********************************************
        //凌凯的  移动 联通 
        //http://inolink.com/WS/LinkWS.asmx
        //TCJK00002  939055
        //15890688866
        //13203853002
        //037166629926
        //给你提供3个不同类型的号码

        //*********************************************
        //恒光的  卡发   
        //http://61.236.127.170:801/sms/smsservice.asmx
        //HY瑞晓信息   66222261

        //wanzhong.Service1 ser = new wanzhong.Service1();
        //wanzhong.CSubmitState state = ser.g_Submit("dlqiann0", "88888888", "", "801", "13629843286,15938734792", "你好啊！");
        
        //Response.Write("提交状态:"+state.State+"<br> 短信编号:"+state.MsgID);

        //wanzhong.CSendState sendstate = ser.g_QuerySendState("dlqiann0", "091208183345003");
        //Response.Write(sendstate.State);

        //wanzhong.CRemain rem = ser.Sm_GetRemain("dlqiann0", "88888888", "", "801");
        //Response.Write(rem.State+" "+rem.Remain);


    }
}
