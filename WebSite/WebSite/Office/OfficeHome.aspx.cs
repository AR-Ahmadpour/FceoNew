using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Office_OfficeHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["Login"] == null || Session["Login"].ToString() == "0")
        //{
        //    Response.Redirect("../Login.aspx?ReferPage=" + Request.Url.AbsoluteUri);
        //    return;
        //}
        if (!IsPostBack)
        {
          
        }
    }
 
    //protected void ASPxMenu1_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
    //{
    //    int Id = int.Parse(Utility.DecryptQS(OfId.Value));
    //    string  OfReId = "";

    //    TSP.DataManager.OfficeRequestManager ReqManager = new TSP.DataManager.OfficeRequestManager();
    //    ReqManager.FindByOfficeId(Id, 1, -1);//آخرین درخواست تایید شده
    //    if (ReqManager.Count > 0)
    //        OfReId = ReqManager[0]["OfReId"].ToString();
    //    else
    //    {
    //        ReqManager.FindByOfficeId(Id, -1, 0);//ثبت اولیه
    //        if (ReqManager.Count > 0)
    //            OfReId = ReqManager[0]["OfReId"].ToString();


    //    }

    //    switch (e.Item.Name)
    //    {
    //        case "Member":
    //            Response.Redirect("~/Office/OfficeInfo/OfficeMembers.aspx?OfId=" + OfId.Value + "&OfReId=" + Utility.EncryptQS(OfReId) + "&Mode=" + Utility.EncryptQS("Home"));
    //            break;
    //        case "Letters":
    //            Response.Redirect("~/Office/OfficeInfo/OfficeLetters.aspx?OfId=" + OfId.Value + "&OfReId=" + Utility.EncryptQS(OfReId) + "&Mode=" + Utility.EncryptQS("Home"));
    //            break;
    //        case "Agent":
    //            Response.Redirect("~/Office/OfficeInfo/OfficeAgent.aspx?OfId=" + OfId.Value + "&OfReId=" + Utility.EncryptQS(OfReId) + "&Mode=" + Utility.EncryptQS("Home"));
    //            break;
    //        case "Job":
    //            Response.Redirect("~/Office/OfficeInfo/OfficeJob.aspx?OfId=" + OfId.Value + "&OfReId=" + Utility.EncryptQS(OfReId) + "&Mode=" + Utility.EncryptQS("Home"));
    //            break;
    //        case "Financial":
    //            Response.Redirect("~/Office/OfficeInfo/OfficeFinancialStatus.aspx?OfId=" + OfId.Value + "&OfReId=" + Utility.EncryptQS(OfReId) + "&Mode=" + Utility.EncryptQS("Home"));
    //            break;
    //    }
    //}
}
