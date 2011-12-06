using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///PageBase 的摘要说明
/// </summary>
public class PageBase:System.Web.UI.Page
{
    public PageBase()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.Load += new System.EventHandler(PageBase_Load);
        this.Error += new System.EventHandler(PageBase_Error);
    }

    /// <summary>
    /// 错误处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void PageBase_Error(object sender, System.EventArgs e)
    {
        Exception currentError = Server.GetLastError();

        try
        {
            Response.Write(currentError.Message);
        }
        catch
        {

        }

        Server.ClearError();
    }

    /// <summary>
    /// 页面载入前
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void PageBase_Load(object sender, System.EventArgs e)
    {
        if (Public.GetUserId(this.Page) == "0")
        {
            string url = ResolveUrl("~/default.aspx");
            Response.Write("<script>alert('对不起，您本次的登录已超时，为了您的账户安全，请重新登录！');window.parent.location = '"+url+"';</script>");
        }
    }







}
