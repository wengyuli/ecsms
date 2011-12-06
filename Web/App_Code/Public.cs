using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;
using System.Net.Mail;
using System.Web.UI.WebControls;

/// <summary>
///Public 的摘要说明
/// </summary>
public static class Public
{
    static string mailuser=System.Configuration.ConfigurationManager.AppSettings["mailuser"].ToString();
    static string mailpwd = System.Configuration.ConfigurationManager.AppSettings["mailpwd"].ToString();
    static string smtp = System.Configuration.ConfigurationManager.AppSettings["smtp"].ToString();
    static int port = int.Parse(System.Configuration.ConfigurationManager.AppSettings["port"].ToString());

    #region 取得cookie
    /// <summary>
    /// 取得Cookie
    /// </summary>
    /// <param name="page">当前页面</param>
    /// <returns>用户ID，若cookie失效则为0</returns>
    public static string GetUserId(System.Web.UI.Page page)
    {
        if ( page.Request.Cookies["UserId"]!= null)
        {
            return page.Request.Cookies["UserId"].Value;
        }
        else
        {
            if (page.Session["UserId"] != null && page.Session["UserId"] != "")
            {
                return page.Session["UserId"].ToString();
            }
            else
            {
                return "0";
            }
        }
    }
    #endregion

    #region 判断用户是否通过审核
    /// <summary>
    /// 判断用户是否通过审核
    /// </summary>
    /// <param name="userid"></param>
    /// <returns></returns>
    public static bool IsPassed(int userid)
    {
        ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
        ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
        newUser = myUser.GetModel(userid);
        if (newUser.State == 2)
        {
            return true;
        }
        else
        {
            return false;
        }        
    }
    #endregion

    #region 页面操作方法

    /// <summary>
    /// 根据查询条件返回有多少符合查询条件的记录数
    /// </summary>
    /// <param name="strWhere">where 之后的查询条件</param>
    /// <param name="strTableName">查询表明</param>
    /// <returns></returns>
    public static int ColumCount(string strWhere, string strTableName)
    {
        string strsql = "select  count(*) from " + strTableName + " where " + strWhere + "";
        object obj = Maticsoft.DBUtility.DbHelperSQL.GetSingle(strsql);
        if (obj != null)
        {
            return Int32.Parse(obj.ToString());
        }
        else
        {
            return 0;
        }
    }
    #endregion


    #region DataSet导出Excel
    /// <summary>
    /// DataSet导出Excel
    /// </summary>
    public static void ExportExcel(System.Web.UI.Control control, DataSet ds)
    {
        control.Page.Response.Clear();
        control.Page.Response.Buffer = true;
        control.Page.Response.ContentType = "application/vnd.ms-excel";
        control.Page.Response.Charset = "";
        control.Page.EnableViewState = false;


        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);


        System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
        dg.DataSource = ds;
        dg.DataBind();
        dg.RenderControl(oHtmlTextWriter);
        control.Page.Response.Charset = "utf-8";
        control.Page.Response.Write(oStringWriter.ToString());
        control.Page.Response.End();
    }


    #endregion

    #region  输出各种文档
    /// <summary>
    ///  输出各种文档
    /// </summary>
    /// <param name="strtitlename">文件的内容(各项以逗号隔开 以"\n"结束)</param>
    /// <param name="strfilename">生成的文件名</param>
    /// <param name="strfilename">输出文件的类型为application/ms-excel || application/ms-word || application/ms-txt || application/ms-html</param>
    public static void ExportFiles(System.Web.UI.Page page,System.Text.StringBuilder strbuilder, string strfilename, string strfiletype)
    {
        try
        {
            string strTemp = string.Format("attachment;filename={0}", page.Server.UrlEncode(strfilename));
            page.Response.ContentEncoding =System.Text.Encoding.GetEncoding("GB2312");
            page.Response.ClearHeaders();
            page.Response.AppendHeader("Content-disposition", strTemp);
            page.Response.ContentType = strfiletype;
            page.Response.Write(strbuilder);
            page.Response.End();
        }
        catch (Exception ex)
        {
            Maticsoft.Common.MessageBox.Show(page, ex.Message.ToString());
        }
    }
    #endregion 

    #region 绑定DataList
    /// <summary>
    /// 绑定DataList
    /// </summary>
    /// <param name="ds">需绑定的DataSet</param>
    /// <param name="Dlist">绑定的DataList</param>
    /// <param name="lbtishi">用于提示的Label</param>
    public static void Datalistbind(DataSet ds, System.Web.UI.WebControls.DataList Dlist, System.Web.UI.WebControls.Panel PanelList, System.Web.UI.WebControls.Label lbtishi, Wuqi.Webdiyer.AspNetPager AspNetPager1)
    {
        Dlist.DataSource = ds;
        Dlist.DataBind();
        if (Dlist.Items.Count > 0)
        {
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = ds.Tables[0].DefaultView;
            pds.AllowPaging = true;

            AspNetPager1.RecordCount = ds.Tables[0].DefaultView.Count;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            Dlist.DataSource = pds;
            Dlist.DataBind();


            PanelList.Visible = true;
            lbtishi.Visible = false;
        }
        else
        {
            PanelList.Visible = false;
            lbtishi.Visible = true;
            lbtishi.Text = "无记录";
        }


    }
    #endregion

    #region DataSet绑定DropDownList
    /// <summary>
    /// 将DataSet中的内容绑定到DropdownList;itemText、itemValue分别对应ListItem的Text、Value
    /// </summary>
    public static void DropdownListBind(System.Web.UI.WebControls.DropDownList ddl, System.Data.DataSet ds, string itemText, string itemValue)
    {
        try
        {
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    ddl.Items.Add(new System.Web.UI.WebControls.ListItem(row[itemText].ToString(), row[itemValue].ToString()));
                }
            }
        }
        catch (Exception ex)
        {
            
        }
    }
    #endregion

    #region 发送邮件
    public static void MailSend(string subject,string content,string toaddress)
    {
        try 
        {
            SmtpClient client = new SmtpClient();
            MailMessage message = new MailMessage();
            message.From = new MailAddress( mailuser);
            message.To.Add(toaddress);
            message.ReplyTo = new MailAddress(mailuser);
            message.Subject = subject;
            message.Body = content;
            message.IsBodyHtml = false; 
            client.Host = smtp;
            client.Port = port;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential basicAuthenticationInfo = new System.Net.NetworkCredential(mailuser, mailpwd);
            client.Credentials = basicAuthenticationInfo;
            client.EnableSsl = true;
            client.Send(message);
        }
        catch (Exception ex)
        {
            
        }
        
    }
    #endregion

    #region 发送系统短信
    public static void SendSystemSms(string phoneNumber,string content) 
    {        
        ECSMS.Model.SendMsgTable newSend = new ECSMS.Model.SendMsgTable();
        ECSMS.BLL.SendMsgTable mySend = new ECSMS.BLL.SendMsgTable();
        newSend.PhoneNumber = phoneNumber;
        newSend.MsgTitle = content;
        newSend.SpId = GetNumerSp(phoneNumber);
        newSend.MsgStatus = (int)ECSMS.Channel.SmsStatus.等待发送;
        newSend.MsgType = "A"; 
        newSend.ExerNumbers = 0;
        newSend.NumbersCount = 1;
        newSend.SendNum = 1;
        newSend.SendTime = DateTime.Now; 
        ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
        DataSet ds = myUser.GetList(" account='ecsms' ");
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            newSend.UserId = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());            
        } 
        Random rand = new Random();
        newSend.ServerID = DateTime.Now.ToString("yyyyMMddHHmmss") + newSend.UserId.ToString() + rand.Next(11, 99).ToString();
        mySend.Add(newSend);        
    }

    #endregion

    #region 返回用户角色
    /// <summary>
    /// 返回用户角色3个人2集团1代理0管理员
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static int GetUserRole(int userId)
    {
        ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
        ECSMS.Model.EC_User model = new ECSMS.Model.EC_User();
        model = bll.GetModel(userId);
        return model.Role.Value;
    }
    #endregion

    #region 返回用户姓名
    public static string GetUserName(int userId)
    {
        ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
        ECSMS.Model.EC_User model = new ECSMS.Model.EC_User();
        model = bll.GetModel(userId);
        if (model != null)
        {
            return model.Name;
        }
        else
        {
            return "";
        }
    }
    #endregion

    #region 返回用户帐号
    public static string GetUserAccount(int userId)
    {
        ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
        ECSMS.Model.EC_User model = new ECSMS.Model.EC_User();
        model = bll.GetModel(userId);
        if (model != null)
        {
            return model.Account;
        }
        else
        {
            return "";
        }
    }
    #endregion

    #region 返回用户权限
    /// <summary>
    /// 返回用户权限默认值(在新增用户时使用)
    /// </summary>
    /// <returns></returns>
    public static int GetUserMaxCount()
    {
        ECSMS.BLL.EC_Config myConfig = new ECSMS.BLL.EC_Config();
        ECSMS.Model.EC_Config newConfig = new ECSMS.Model.EC_Config();
        newConfig = myConfig.GetModel(1);
        return newConfig.UserMax.Value;
    }
    /// <summary>
    /// 返回平台权限
    /// </summary>
    /// <returns></returns>
    public static int GetPlatMaxCount()
    {
        ECSMS.BLL.EC_Config myConfig = new ECSMS.BLL.EC_Config();
        ECSMS.Model.EC_Config newConfig = new ECSMS.Model.EC_Config();
        DataSet ds = myConfig.GetAllList();
        return int.Parse(ds.Tables[0].Rows[0]["PlatMax"].ToString());
    }
    /// <summary>
    /// 返回某一用户的单次发送权限
    /// </summary>
    /// <returns></returns>
    public static int GetUserMaxCount(int UserId)
    {
        ECSMS.Model.EC_User model = new ECSMS.Model.EC_User();
        ECSMS.BLL.EC_User bll = new ECSMS.BLL.EC_User();
        model = bll.GetModel(UserId);
        return model.MaxSendNum.Value;
    }
    
    #endregion

    #region 返回用户短信账户余额

    /// <summary>
    /// 返回用户某产品的余额
    /// </summary> 
    public static string GetUserLeaveSms(int UserId,string SmsType)
    {
        ECSMS.BLL.EC_UserSmsAccount myAccount = new ECSMS.BLL.EC_UserSmsAccount();
        DataSet dsAccount = myAccount.GetList(" userid= " + UserId+" and smstype='"+SmsType+"' ");
        int count = dsAccount.Tables[0].Rows.Count;
        string strResult = "0";
        if (count > 0)
        {
            strResult = dsAccount.Tables[0].Rows[0]["leavenum"].ToString();
        }
        return strResult;
    }


    /// <summary>
    /// 返回用户余额
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public static string GetUserLeaveSms(int userId)
    {
        ECSMS.BLL.EC_UserSmsAccount myAccount = new ECSMS.BLL.EC_UserSmsAccount();
        DataSet dsAccount = myAccount.GetList(" userid= "+userId);
        int count = dsAccount.Tables[0].Rows.Count;
        string strResult = string.Empty;
        if (count > 0)
        { 
            foreach(DataRow row in dsAccount.Tables[0].Rows)
            {
                strResult += GetProNameByLetter( row["smstype"].ToString()) + row["leavenum"].ToString()+",";
            }            
        }
        return strResult;
    }

    #endregion

    #region 返回用户提醒额度
    public static int GetUserAwokeNum(int UserId)
    {
        ECSMS.BLL.EC_User myUser = new ECSMS.BLL.EC_User();
        ECSMS.Model.EC_User newUser = new ECSMS.Model.EC_User();
        newUser = myUser.GetModel(UserId);
        if (newUser != null)
        {
            return newUser.AwokeNum.Value;
        }
        else
        {
            return 0;
        } 
    }
    #endregion

    #region 返回短信发送状态
    //public static string GetSendState(string strState)
    //{
    //    string state = string.Empty;
    //    switch (strState)
    //    {
    //        case "0": state = "已提交"; break;
    //        case "1": state = "发送成功"; break;
    //        case "-1": state = "发送失败"; break;
    //        case "2": state = "已提交"; break;
    //        case "3": state = "发送成功"; break;
    //        case "4": state = "发送失败"; break;
    //        case "5": state = "已提交"; break;
    //    }
    //    return state;
    //}
    #endregion

    #region 根据数字或者字母得到短信产品名称

    public static string GetProNameByLetter(string strLetter)
    {
        ECSMS.BLL.EC_SmsType mySmsType = new ECSMS.BLL.EC_SmsType();
        ECSMS.Model.EC_SmsType newSmsType = new ECSMS.Model.EC_SmsType();
        newSmsType = mySmsType.GetModel(strLetter);
        return newSmsType.Name; 
    }
    #endregion

    #region 检验某个词是否属于某通道的禁用关键词
    /// <summary>
    /// 检验某个词是否属于某通道的禁用关键词
    /// </summary>
    /// <param name="Word"></param>
    /// <param name="ChannelCode"></param>
    /// <returns>true表示属于</returns>
    public static bool IsForbiddenWord(string Word,string ChannelCode)
    {
        ECSMS.BLL.EC_ForbidWord bll = new ECSMS.BLL.EC_ForbidWord();
        ECSMS.Model.EC_ForbidWord model = new ECSMS.Model.EC_ForbidWord();
        DataSet ds = bll.GetList(" name like '%" + Word + "%' and ChannelCode='" + ChannelCode + "' ");
        bool IsForbidden = true;
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            IsForbidden = true;
        }
        else
        {
            IsForbidden = false;
        }
        return IsForbidden;
    }
    #endregion

    #region 得到所有运营商号段
    /// <summary>
    /// 得到所有运营商的号段
    /// </summary>
    /// <returns></returns>
    public static List<string> GetAllSegment()
    {
        List<string> listSeg = new List<string>();//存放运营商号段
        ECSMS.BLL.EC_SmsSegment seg = new ECSMS.BLL.EC_SmsSegment();
        DataSet ds = seg.GetList("");
        int count = ds.Tables[0].Rows.Count;
        if (count > 0)
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (row["segment"].ToString() != "")
                {
                    listSeg.Add(row["segment"].ToString());
                }
            }

            return listSeg;
        }
        else
        {
            return new List<string>();
        }        
    }
    #endregion 

    #region 号码分拣
    /// <summary>
    /// 传入一串逗号分隔的手机号，返回值list[0]里是以逗号分隔的移动号，list[1]联通，list[2]电信，list[3]其他
    /// </summary>
    /// <param name="numbers">以逗号间隔</param>
    /// <returns>以逗号间隔</returns>
    public static List<string> NumberSplit(string numbers)
    {
        List<string> listCM = new List<string>();//移动
        List<string> listCU = new List<string>();//联通
        List<string> listCT = new List<string>();//电信
        List<string> listCN = new List<string>();//网通
        string strSql = "select * from ec_smssegment order by spid";
        DataSet ds = Maticsoft.DBUtility.DbHelperSQL.Query(strSql);
        int count = ds.Tables[0].Rows.Count;
        if(count>0)
        {
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                switch (row["spid"].ToString())
                {
                    case "1": listCM.Add(row["segment"].ToString()); break;
                    case "2": listCU.Add(row["segment"].ToString()); break;
                    case "3": listCT.Add(row["segment"].ToString()); break;
                    case "4": listCN.Add(row["segment"].ToString()); break;
                }
            }
        }
        ///分隔运营商号码到list
        numbers = numbers.Replace(" ", "");
        string[] arrNumber = numbers.Split(',');
        List<string> list1 = new List<string>();
        List<string> list2 = new List<string>();
        List<string> list3 = new List<string>();
        List<string> list4 = new List<string>();
        foreach(string num in arrNumber)
        {
            if(num!="")
            {
                if (listCM.Contains(num.Substring(0, 3)))
                {
                    list1.Add(num);
                }
                if (listCU.Contains(num.Substring(0, 3)))
                {
                    list2.Add(num);
                }
                if (listCT.Contains(num.Substring(0, 3)))
                {
                    list3.Add(num);
                }
                if (listCN.Contains(num.Substring(0, 1)))
                {
                    list4.Add(num);
                }
            }            
        }
        ///将分隔后的号码赋值给listResult
        List<string> listResult = new List<string>();
        string str = string.Empty;
        foreach(string num in list1)
        {
            str += num+",";
        }
        listResult.Add(str.Substring(0, str.Length - 1));

        str = string.Empty;
        foreach (string num in list2)
        {
            str += num + ",";
        }
        listResult.Add(str.Substring(0, str.Length - 1));

        str = string.Empty;
        foreach (string num in list3)
        {
            str += num + ",";
        }
        listResult.Add(str.Substring(0, str.Length - 1));

        str = string.Empty;
        foreach (string num in list4)
        {
            str += num + ",";
        }
        listResult.Add(str.Substring(0, str.Length-1));

        return listResult;
    }


    #endregion

    #region 判断号码的运营商
    /// <summary>
    /// 根据号码得到运营商ID，运营商ID,1移动，2联通，3电信，4小灵通，0异常、找不到
    /// </summary>
    /// <param name="number">手机号码</param>
    /// <returns>运营商ID,1移动，2联通，3电信，0小灵通，0异常、找不到</returns>
    public static int GetNumerSp(string number)
    {
        try
        {
            ECSMS.BLL.EC_SmsSegment bll = new ECSMS.BLL.EC_SmsSegment();
            if (number.Length > 3)
            {
                number = number.Substring(0, 3);
                if (number.Substring(0, 1) == "0")
                {
                    return 0;
                }
                else
                {
                    DataSet ds = bll.GetList("Segment='" + number + "'");
                    int count = ds.Tables[0].Rows.Count;
                    if (count > 0)
                    {
                        return int.Parse(ds.Tables[0].Rows[0]["spid"].ToString());
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            else
            {
                return 0;
            }
        }
        catch
        {
            return 0;
        }
    }
    #endregion

    #region 万众通道（账号dlqiann0，密码88888888，电信测801产品，彩信测116产品，卡发短信测802）
    /// <summary>
    /// 发送短信
    /// </summary>
    public static string wanzhong_SendSMS(string Userid, string Content, string Numbers)
    { 
        if (0 == 0)
        {
            return "ok";
        }
        else
        {
            return "no";
        }        
    }
    /// <summary>
    /// 查询短信发送状态
    /// </summary>
    /// <returns></returns>
    public static string wanzhong_QuerySendState()
    { 
        return "";
    }
    /// <summary>
    /// 查询账户余额
    /// </summary>
    /// <returns></returns>
    public static string wanzhong_QueryAccount()
    { 
        return "";
    }
    #endregion

    #region 凌凯通道
    /// <summary>
    /// 群发短信
    /// </summary>
    /// <returns></returns>
    public static string lingkai_SendSms()
    { 
        return "";
    }
    /// <summary>
    /// 查询余额
    /// </summary>
    /// <returns></returns>
    public static string lingkai_QuerySms()
    { 
        return "";
    }
    /// <summary>
    /// 接收短信
    /// </summary>
    /// <returns></returns>
    public static string lingkai_ReceiveSms()
    { 
        return "";
    }
    #endregion

    

}
