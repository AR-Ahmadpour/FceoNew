using System; 
using System.Linq;
using System.Collections;
using DevExpress.Web;
using System.Data;

public partial class Employee_TechnicalServices_Project_ProjectTemporaryMunicipality : System.Web.UI.Page
{


    Boolean IsPageRefresh = false;
    int aa = 12;
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        this.DivReport.Visible = false;
        this.DivReport.Attributes.Add("onclick", "ChangeVisible(this)");
        this.DivReport.Attributes.Add("onmouseover", "ChangeIcon(this)");

        #region PageRefresh
        if (!IsPostBack)
        {
            ViewState["postids"] = System.Guid.NewGuid().ToString();
            Session["postid"] = ViewState["postids"].ToString();

            LoadTempProject();
        }
        else
        {
            if (!IsCallback && Session["postid"] != null)
            {
                if (ViewState["postids"].ToString() != Session["postid"].ToString()) { IsPageRefresh = true; }
                Session["postid"] = System.Guid.NewGuid().ToString(); ViewState["postids"] = Session["postid"];
            }
        }
        #endregion

        //if (Utility.GetCurrentUser_AgentId() != Utility.GetMainAgentId())
        //{
        //    ObjdsEmployee.FilterExpression = "AgentId=" + Utility.GetCurrentUser_AgentId();
        //}
        GridViewTemporaryMunicipality.JSProperties["cpIsPostBack"] = 0;
        GridViewTemporaryMunicipality.JSProperties["cpSelectedIndex"] = 0;

        if (!IsPostBack)
        {
            Session["SendBackDataTable_EmpWF"] = null;
            GridViewTemporaryMunicipality.JSProperties["cpIsPostBack"] = 1;
            
            //ObjdsEmployee.CacheDuration = Utility.GetCacheDuration();
            CheckTablePermission();
            CheckWorkFlowPermissionForChangeReq();
  
            this.ViewState["GridView"] = GridViewTemporaryMunicipality.ClientVisible;
      
            GridViewTemporaryMunicipality.JSProperties["cpIsReturn"] = 0;

        }
       
        SetPageFilter();
        SetGridRowIndex();

        this.DivReport.Visible = false;
        this.DivReport.Attributes.Add("onclick", "ChangeVisible(this)");
        this.DivReport.Attributes.Add("onmouseover", "ChangeIcon(this)");
    }

    string PageMode = "";


    protected void CallbackPanelPage_Callback(object source, DevExpress.Web.CallbackEventArgsBase e)
    {
        CallbackPanelPage.JSProperties["cpDoPrint"] = 0;

        String[] Parameter = e.Parameter.Split(';');
        string ReqName = Parameter[0];
        switch (ReqName)
        {
            case "Print":
                GridViewTemporaryMunicipality.DetailRows.CollapseAllRows();
                CallbackPanelPage.JSProperties["cpDoPrint"] = 1;
                break;
        }
        //Response.Redirect("ProjectInsert.aspx?PageMode=" + Utility.EncryptQS("New"));
    }

    #region Grd Employee
    protected void GridViewTemporaryMunicipality_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
    {
        //Comment  By Ar.Ahmadpour
        //if (e.DataColumn.FieldName == "CreateDate")
        //    e.Cell.Style["direction"] = "ltr";

        //if (e.DataColumn.FieldName == "TaskId")
        //{
        //    DevExpress.Web.ASPxImage btnWFState = (DevExpress.Web.ASPxImage)GridViewTemporaryMunicipality.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.GridViewDataColumn)GridViewTemporaryMunicipality.Columns["WFState"], "btnWFState");
        //    if (btnWFState != null)
        //    {
        //        if (Utility.IsDBNullOrNullValue(e.GetValue("WFTaskType")))
        //        {
        //            btnWFState.ToolTip = "تعریف نشده";
        //            btnWFState.ImageUrl = "~/Images/WFUnNounState.png";
        //            return;
        //        }

        //        if (int.Parse(e.GetValue("WFTaskType").ToString()) == (int)TSP.DataManager.WorkFlowTaskType.StartingTask)
        //        {
        //            btnWFState.ToolTip = e.GetValue("TaskName").ToString();
        //            btnWFState.ImageUrl = "~/Images/WFStart.png";
        //        }
        //        else if (int.Parse(e.GetValue("WFTaskType").ToString()) == (int)TSP.DataManager.WorkFlowTaskType.MeddleTask)
        //        {
        //            btnWFState.ToolTip = e.GetValue("TaskName").ToString();
        //            btnWFState.ImageUrl = "~/Images/WFInProcess.png";
        //        }
        //        else if (int.Parse(e.GetValue("WFTaskType").ToString()) == (int)TSP.DataManager.WorkFlowTaskType.ConfirmingAndEndProccessTask)
        //        {
        //            btnWFState.ToolTip = e.GetValue("TaskName").ToString();
        //            btnWFState.ImageUrl = "~/Images/WFConfirmAndEnd.png";
        //        }
        //        else if (int.Parse(e.GetValue("WFTaskType").ToString()) == (int)TSP.DataManager.WorkFlowTaskType.RejectingingAndEndProccessTask)
        //        {
        //            btnWFState.ToolTip = e.GetValue("TaskName").ToString();
        //            btnWFState.ImageUrl = "~/Images/WFREjectAndEnd.png";
        //        }
        //        else
        //        {
        //        }
        //    }
        //}
    }

    protected void GridViewTemporaryMunicipality_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
    {
        //Comment By Ar.Ahmadpour
        if (e.RowType != GridViewRowType.Data)
            return;

       // e.Row.BackColor = System.Drawing.Color.LightCyan;
       
    }

    //   protected void GridViewTemporaryMunicipality_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
    //  {
    // GridViewTemporaryMunicipality.DataBind();
    //  }


    //protected void GridViewDetails_AutoFilterCellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
    //{
    //    if (e.Column.FieldName == "CreateDate")
    //        e.Editor.Style["direction"] = "ltr";
    //}
    protected void GridViewTemporaryMunicipality_PageIndexChanged(object sender, EventArgs e)
    {
        GridViewTemporaryMunicipality.JSProperties["cpIsPostBack"] = 1;
        LoadTempProject();
    }

    protected void GridViewTemporaryMunicipality_FocusedRowChanged(object sender, EventArgs e)
    {
        SetGridRowIndex();
    }

    protected void GridViewTemporaryMunicipality_AutoFilterCellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
    {
        if (e.Column.FieldName == "CreateDate" || e.Column.FieldName == "CreateDatefa")
            e.Editor.Style["direction"] = "ltr";
    }
    #endregion

    #region Grd EmployeeRequest
    protected void GridViewDetails_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
    {
        if (e.DataColumn.FieldName == "CreateDate"  || e.DataColumn.FieldName == "CreateDatefa")
            e.Cell.Style["direction"] = "ltr";


        //if (e.DataColumn.FieldName == "TaskId")
        //{
        //    DevExpress.Web.ASPxGridView GridViewRequest = (DevExpress.Web.ASPxGridView)GridViewTemporaryMunicipality.FindDetailRowTemplateControl(GridViewTemporaryMunicipality.FocusedRowIndex, "GridViewRequest");
        //    if (GridViewRequest != null)
        //    {
        //        DevExpress.Web.ASPxImage btnWFState = (DevExpress.Web.ASPxImage)GridViewRequest.FindRowCellTemplateControl(e.VisibleIndex, (DevExpress.Web.GridViewDataColumn)GridViewRequest.Columns["WFState"], "btnWFState");
        //        if (btnWFState != null)
        //        {
        //            if (Utility.IsDBNullOrNullValue(e.GetValue("WFTaskType")))
        //            {
        //                btnWFState.ToolTip = "تعریف نشده";
        //                btnWFState.ImageUrl = "~/Images/WFUnNounState.png";
        //                return;
        //            }

        //            if (int.Parse(e.GetValue("WFTaskType").ToString()) == (int)TSP.DataManager.WorkFlowTaskType.StartingTask)
        //            {
        //                btnWFState.ToolTip = e.GetValue("TaskName").ToString();
        //                btnWFState.ImageUrl = "~/Images/WFStart.png";
        //            }
        //            else if (int.Parse(e.GetValue("WFTaskType").ToString()) == (int)TSP.DataManager.WorkFlowTaskType.MeddleTask)
        //            {
        //                btnWFState.ToolTip = e.GetValue("TaskName").ToString();
        //                btnWFState.ImageUrl = "~/Images/WFInProcess.png";
        //            }
        //            else if (int.Parse(e.GetValue("WFTaskType").ToString()) == (int)TSP.DataManager.WorkFlowTaskType.ConfirmingAndEndProccessTask)
        //            {
        //                btnWFState.ToolTip = e.GetValue("TaskName").ToString();
        //                btnWFState.ImageUrl = "~/Images/WFConfirmAndEnd.png";
        //            }
        //            else if (int.Parse(e.GetValue("WFTaskType").ToString()) == (int)TSP.DataManager.WorkFlowTaskType.RejectingingAndEndProccessTask)
        //            {
        //                btnWFState.ToolTip = e.GetValue("TaskName").ToString();
        //                btnWFState.ImageUrl = "~/Images/WFREjectAndEnd.png";
        //            }
        //            else
        //            {
        //            }
        //        }
        //    }
        //}
    }


    protected void GridViewDetails_AutoFilterCellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
    {
        if (e.Column.FieldName == "CreateDate")
            e.Editor.Style["direction"] = "ltr";
    }

    protected void GridViewDetails_BeforePerformDataSelect(object sender, EventArgs e)
    {
        Session["Id"] = (sender as ASPxGridView).GetMasterRowKeyValue();
        string temp = (sender as ASPxGridView).GetMasterRowKeyValue().ToString();
        int Index =  GridViewTemporaryMunicipality.FindVisibleIndexByKeyValue(Int32.Parse(temp));
        GridViewTemporaryMunicipality.FocusedRowIndex = Index;
        PageMode = "New";
        
    }
    #endregion

    #endregion

    #region Methods


    private void SetError(Exception err)
    {
        if (err.GetType() == typeof(System.Data.SqlClient.SqlException))
        {
            System.Data.SqlClient.SqlException se = (System.Data.SqlClient.SqlException)err;

            if (se.Number == 2601)
            {
                this.DivReport.Visible = true;
                this.LabelWarning.Text = "اطلاعات تکراری می باشد";
            }
            else if (se.Number == 2627)
            {
                this.DivReport.Visible = true;
                this.LabelWarning.Text = "کد تکراری می باشد";
            }
            else if (se.Number == 547)
            {
                this.DivReport.Visible = true;
                this.LabelWarning.Text = "به علت وجود اطلاعات وابسته امکان حذف نمی باشد.";
            }
            else
            {
                this.DivReport.Visible = true;
                this.LabelWarning.Text = "خطایی در ذخیره انجام گرفته است";
            }
        }
        else
        {
            this.DivReport.Visible = true;
            this.LabelWarning.Text = "خطایی در ذخیره انجام گرفته است";
        }
    }

    #region WF
    private int FindNmcId(int TaskId)
    {
        int UserId = Utility.GetCurrentUser_UserId();
        TSP.DataManager.NezamChartManager NezamChartManager = new TSP.DataManager.NezamChartManager();
        TSP.DataManager.LoginManager LoginManager = new TSP.DataManager.LoginManager();

        int NmcId = -1;
        NmcId = NezamChartManager.FindNmcId(UserId, TaskId, LoginManager);
        if (NmcId > 0)
        {
            return NmcId;
        }
        else
        {
            DivReport.Visible = true;
            LabelWarning.Text = "کاربری با مشخصات جاری در چارت سازمانی وجود ندارد.";
            return (-1);
        }
    }

    private Boolean CheckPermissionForRequest(int EmpId)
    {
        TSP.DataManager.EmployeeRequestManager EmployeeRequestManager = new TSP.DataManager.EmployeeRequestManager();
        EmployeeRequestManager.SelectLastVersion(EmpId, 0);
        if (EmployeeRequestManager.Count == 0)
        {
            return true;
        }
        else
        {
            DivReport.Visible = true;
            LabelWarning.Text = "امکان درخواست تغییرات وجود ندارد.کارمند انتخاب شده دارای درخواست معلق می باشد.";
            return false;
        }
    }

    private Boolean CheckPermitionForDelete(int TableId)
    {
        return TSP.DataManager.WorkFlowPermission.CheckWFPermissionForDeleteRequest(TableId, (int)TSP.DataManager.WorkFlows.EmployeeRequestConfirming
         , (int)TSP.DataManager.WorkFlowTask.SaveEmployeeInfo, Utility.GetCurrentUser_UserId(), (int)TSP.DataManager.WorkFlowStateNmcIdType.NmcId);
         

    }

    private Boolean CheckPermitionForEdit(int TableId)
    {
        TSP.DataManager.TaskDoerManager TaskDoerManager = new TSP.DataManager.TaskDoerManager();
        TSP.DataManager.WorkFlowTaskManager WorkFlowTaskManager = new TSP.DataManager.WorkFlowTaskManager();
        TSP.DataManager.WorkFlowStateManager WorkFlowStateManager = new TSP.DataManager.WorkFlowStateManager();
        WorkFlowStateManager.ClearBeforeFill = true;
        int TaskOrder = -1;
        int TaskCode = (int)TSP.DataManager.WorkFlowTask.SaveEmployeeInfo;
        WorkFlowTaskManager.FindByTaskCode(TaskCode);
        if (WorkFlowTaskManager.Count > 0)
        {
            TaskOrder = int.Parse(WorkFlowTaskManager[0]["TaskOrder"].ToString());
            if (TaskOrder != 0)
            {
                int TableType = (int)TSP.DataManager.TableCodes.EmployeeRequest;
                DataTable dtWorkFlowLastState = WorkFlowStateManager.SelectLastState(TableType, TableId);
                if (dtWorkFlowLastState.Rows.Count > 0)
                {
                    int CurrentTaskCode = int.Parse(dtWorkFlowLastState.Rows[0]["TaskCode"].ToString());
                    int CurrentNmcId = int.Parse(dtWorkFlowLastState.Rows[0]["NmcId"].ToString());
                    int CurrentNmcIdType = int.Parse(dtWorkFlowLastState.Rows[0]["NmcIdType"].ToString());
                    int CurrentTaskId = int.Parse(dtWorkFlowLastState.Rows[0]["TaskId"].ToString());
                    int CurrentWorkFlowCode = int.Parse(dtWorkFlowLastState.Rows[0]["WorkFlowCode"].ToString());

                    if (CurrentTaskCode == TaskCode)
                    {
                        DataTable dtWorkFlowState = WorkFlowStateManager.SelectByTableType(TableType, TableId);
                        if (dtWorkFlowState.Rows.Count > 0)
                        {
                            int FirstTaskCode = int.Parse(dtWorkFlowState.Rows[0]["TaskCode"].ToString());
                            //  int UserId = int.Parse(dtWorkFlowState.Rows[0]["UserId"].ToString());

                            // if (UserId == Utility.GetCurrentUser_UserId())
                            // {
                            int Permission = TaskDoerManager.CheckWorkFlowPermissionForEditInfo(TableType, TableId, TaskCode, Utility.GetCurrentUser_UserId());
                            if (Permission > 0)
                                return true;
                            else
                                return false;
                            //}
                            //else
                            //{
                            //    return false;
                            //}
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    private void CheckWorkFlowPermissionForChangeReq()
    {

        TSP.DataManager.TaskDoerManager TaskDoerManager = new TSP.DataManager.TaskDoerManager();

        int SaveWorkCode = (int)TSP.DataManager.WorkFlowTask.SaveEmployeeInfo;
        int Permission = -1;
        int TableType = (int)TSP.DataManager.TableCodes.EmployeeRequest;
        Permission = TaskDoerManager.CheckWorkFlowPermissionForSaveInfo(TableType, SaveWorkCode, Utility.GetCurrentUser_UserId());
        //if (Permission > 0)
        //{
        //    btnChangeReq.Enabled = true;
        //    btnChangeReq2.Enabled = true;
        //}
        //else
        //{
        //    btnChangeReq.Enabled = false;
        //    btnChangeReq2.Enabled = false;
        //}

     
    }
    #endregion

    //protected void Delete(int EmpReId)
    //{
    //    TSP.DataManager.TransactionManager trans = new TSP.DataManager.TransactionManager();
    //    TSP.DataManager.EmployeeRequestManager ReqManager = new TSP.DataManager.EmployeeRequestManager();
    //    TSP.DataManager.WorkFlowStateManager WorkFlowStateManager = new TSP.DataManager.WorkFlowStateManager();
    //    trans.Add(ReqManager);
    //    trans.Add(WorkFlowStateManager);
    //    try
    //    {
    //        ReqManager.FindByCode(EmpReId);
    //        if (ReqManager.Count == 1)
    //        {
    //            trans.BeginSave();

    //            ReqManager[0].Delete();
    //            ReqManager.Save();

    //            int WfCode = (int)TSP.DataManager.WorkFlows.EmployeeRequestConfirming;
    //            WorkFlowStateManager.SelectByWorkFlowCodeForDelete(WfCode, EmpReId);
    //            if (WorkFlowStateManager.Count > 0)
    //            {
    //                int c = WorkFlowStateManager.Count;
    //                for (int i = 0; i < c; i++)
    //                    WorkFlowStateManager[0].Delete();

    //                WorkFlowStateManager.Save();
    //            }
    //            trans.EndSave();
    //            GridViewTemporaryMunicipality.DataBind();
    //            this.DivReport.Visible = true;
    //            this.LabelWarning.Text = "حذف درخواست با موفقیت انجام شد";
    //        }
    //        else
    //        {
    //            this.DivReport.Visible = true;
    //            this.LabelWarning.Text = "خطایی در بازخوانی اطلاعات رخ داده است";
    //        }


    //    }
    //    catch (Exception err)
    //    {
    //        trans.CancelSave();

    //        if (err.GetType() == typeof(System.Data.SqlClient.SqlException))
    //        {
    //            System.Data.SqlClient.SqlException se = (System.Data.SqlClient.SqlException)err;
    //            if (se.Number == 547)
    //            {
    //                this.DivReport.Visible = true;
    //                this.LabelWarning.Text = "به علت وجود اطلاعات وابسته امکان حذف نمی باشد.";
    //            }
    //            else
    //            {
    //                this.DivReport.Visible = true;
    //                this.LabelWarning.Text = "خطایی در حذف انجام گرفته است";
    //            }
    //        }
    //        else
    //        {
    //            this.DivReport.Visible = true;
    //            this.LabelWarning.Text = "خطایی در حذف انجام گرفته است";
    //        }
    //    }
    //}

    private void CheckTablePermission()
    {
        TSP.DataManager.Permission per = TSP.DataManager.EmployeeManager.GetUserPermission(Utility.GetCurrentUser_UserId(), (TSP.DataManager.UserType)Utility.GetCurrentUser_LoginType());
      
        GridViewTemporaryMunicipality.ClientVisible = per.CanView;
        //btnAutoUserRight.Enabled = per.CanView;
        //  btnAutoUserRight2.Enabled = per.CanView;
    }

    #region FilteringMethod
    private void SetPageFilter()
    {
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["GrdFlt"]))
            {
                string GrdFlt = Utility.DecryptQS(Request.QueryString["GrdFlt"].ToString());

                if (!string.IsNullOrEmpty(GrdFlt))
                    GridViewTemporaryMunicipality.FilterExpression = GrdFlt;
            }
        }

    }


    protected void BtnRefresh_Click(object sender, EventArgs e)
    {
        LoadTempProject();
    }
    protected void BtnNew_Click(object sender, EventArgs e)
    {
        if (IsPageRefresh)
            return;

        //string GridFilterString = GridViewTemporaryMunicipality.FilterExpression;        

        if (GridViewTemporaryMunicipality.FocusedRowIndex > -1)
        {
            string[] parm = new string[6];
            parm[0] = "Id";
            parm[1] = "OwnerAgentFullName";
            parm[2] = "OwnerAgentNationalCode";
            parm[3] = "OwnerAgentMobile";
            parm[4] = "ErjaNumber";
            parm[5] = "NosaziCode";
            var row=GridViewTemporaryMunicipality.GetRowValues(GridViewTemporaryMunicipality.FocusedRowIndex, parm);
            // DataRow row = GridViewTemporaryMunicipality.GetDataRow(GridViewTemporaryMunicipality.FocusedRowIndex);
            object[] objectArray = (object[])row;
            if (objectArray[0] == null)
            {
                SetGridRowIndex();
                this.DivReport.Visible = true;
                this.LabelWarning.Text = "لطفاً ابتدا یک پروژه را انتخاب نمائید.";
                LoadTempProject();
            }
            else
            {
               
                Response.Redirect("ProjectInsert.aspx?&PageMode=" + Utility.EncryptQS("New")+
                    "&PrjReId=-1"+
                    "&ProjectId=-1"+
                    "&TempId=" + objectArray[0].ToString());
                //+"&GrdFlt=" + Utility.EncryptQS(GridFilterString)
            }
        }
        else
        {
            this.DivReport.Visible = true;
            this.LabelWarning.Text = "ردیفی انتخاب نشده است.";
            LoadTempProject();
        }
    }

    private int SetGridRowIndex()
    {
        int Index = -1;
        if (!IsPostBack)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["PostId"]))
            {
                string PostId = Utility.DecryptQS(Request.QueryString["PostId"].ToString());
                if (!string.IsNullOrEmpty(PostId))
                {
                    int PostKeyValue = int.Parse(PostId);

                    GridViewTemporaryMunicipality.DataBind();
                    Index = GridViewTemporaryMunicipality.FindVisibleIndexByKeyValue(PostKeyValue);
                    int PageIndex = -1;
                    if (Index >= 0)
                        PageIndex = Index / GridViewTemporaryMunicipality.SettingsPager.PageSize;
                    if (PageIndex >= 0)
                        GridViewTemporaryMunicipality.PageIndex = PageIndex;
                    if (Index >= 0)
                    {
                        GridViewTemporaryMunicipality.JSProperties["cpSelectedIndex"] = Index;
                        GridViewTemporaryMunicipality.DetailRows.ExpandRow(Index);
                        GridViewTemporaryMunicipality.FocusedRowIndex = Index;
                        GridViewTemporaryMunicipality.JSProperties["cpIsReturn"] = 1;
                    }
                }
            }
        }
        return Index;
    }

    private void ShowMessage(string Message)
    {
        this.DivReport.Attributes.Add("Style", "display:block");
        this.LabelWarning.Text = Message;
    }


    private void LoadTempProject()
    {
        //TSP.DataManager.TechnicalServices.ProjectManager proj = new TSP.DataManager.TechnicalServices.ProjectManager();
        //GridViewTemporaryMunicipality.DataSource = proj.GetShahrdariProjectForInsert();
        //GridViewTemporaryMunicipality.DataBind();
    }
    #endregion
    #endregion





}