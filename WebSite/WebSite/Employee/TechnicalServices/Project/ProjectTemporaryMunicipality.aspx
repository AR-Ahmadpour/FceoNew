<%@ Page Title="پروژه های دریافتی از شهرداری" Language="C#" MasterPageFile="~/MasterPagePortals.master" AutoEventWireup="true" CodeFile="ProjectTemporaryMunicipality.aspx.cs" Inherits="Employee_TechnicalServices_Project_ProjectTemporaryMunicipality" %>


<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxcb" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxwgv" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxuc" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxm" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxpc" %>
<%@ Register Assembly="TSP.WebControls" Namespace="TSP.WebControls" TagPrefix="TSPControls" %>
<%@ Register Assembly="DevExpress.Web.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dxe" %>

<%@ Register Assembly="PersianDateControls 2.0" Namespace="PersianDateControls" TagPrefix="pdc" %>
<%@ Register Assembly="AjaxControls" Namespace="AjaxControls" TagPrefix="asp" %>
<%@ Register Assembly="PersianDateControls 2.0" Namespace="PersianDateControls" TagPrefix="pdc" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="../../../UserControl/WFUserControl.ascx" TagName="WFUserControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="idcontent" style="width: 100%;" align="center">

        <TSPControls:CustomAspxCallbackPanel ID="CallbackPanelPage" runat="server" ClientInstanceName="CallbackPanelPage"
            HideContentOnCallback="false" OnCallback="CallbackPanelPage_Callback"
            Width="100%">

            <Images SpriteCssFilePath="~/App_Themes/Metropolis/{0}/sprite.css"></Images>

            <Styles CssPostfix="Metropolis" CssFilePath="~/App_Themes/Metropolis/{0}/styles.css"></Styles>
            <PanelCollection>
                <dxp:PanelContent ID="PanelContent1" runat="server">
                    <div style="text-align: right" id="DivReport" class="DivErrors" runat="server">
                        <asp:Label ID="LabelWarning" runat="server" Text="Label"></asp:Label>[<a class="closeLink"
                            href="#">بستن</a>]
                    </div>
                    <TSPControls:CustomASPxRoundPanelMenu ID="CustomASPxRoundPanelMenu1" runat="server"
                        Width="100%">
                        <ContentPaddings PaddingLeft="0px" PaddingTop="0px" PaddingRight="0px" PaddingBottom="0px"></ContentPaddings>

                        <HeaderStyle HorizontalAlign="Right"></HeaderStyle>
                        <PanelCollection>
                            <dxp:PanelContent>
                                <table>
                                    <tbody>
                                        <tr>
                                            <td>
                                                <TSPControls:CustomAspxButton IsMenuButton="true" runat="server" ToolTip="جدید"
                                                    CausesValidation="False" ID="BtnNew" AutoPostBack="False" EnableViewState="False"
                                                    EnableTheming="False" OnClick="BtnNew_Click">                                                    
                                                   
                                                    <Image Url="~/Images/icons/new.png">
                                                    </Image>

                                                    <HoverStyle Border-BorderColor="Gray" Border-BorderStyle="Outset" Border-BorderWidth="1px" BackColor="#FFE0C0"></HoverStyle>
                                                </TSPControls:CustomAspxButton>

                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </dxp:PanelContent>
                        </PanelCollection>
                    </TSPControls:CustomASPxRoundPanelMenu>
                    <dxwgv:ASPxGridViewExporter ID="ASPxGridViewExporter1" runat="server" GridViewID="GridViewTemporaryMunicipality">
                    </dxwgv:ASPxGridViewExporter>
                    <br />
                    <TSPControls:CustomAspxDevGridView SettingsDetail-ExportMode="Expanded" ID="GridViewTemporaryMunicipality"
                        runat="server" ClientInstanceName="GridViewTemporaryMunicipalityClient"
                        Width="100%" OnAutoFilterCellEditorInitialize="GridViewTemporaryMunicipality_AutoFilterCellEditorInitialize"
                        OnHtmlDataCellPrepared="GridViewTemporaryMunicipality_HtmlDataCellPrepared" KeyFieldName="Id"
                        DataSourceID="ObjdsTempProject"
                        OnFocusedRowChanged="GridViewTemporaryMunicipality_FocusedRowChanged" OnHtmlRowPrepared="GridViewTemporaryMunicipality_HtmlRowPrepared"
                        OnPageIndexChanged="GridViewTemporaryMunicipality_PageIndexChanged">


                        <ClientSideEvents FocusedRowChanged="function(s, e) {
	if(GridViewTemporaryMunicipalityClient.cpIsReturn!=1)
	{
		GridViewTemporaryMunicipalityClient.cpSelectedIndex=GridViewTemporaryMunicipalityClient.GetFocusedRowIndex();
			
	}
	else
	{
		GridViewTemporaryMunicipalityClient.cpIsReturn=0;	
	}

	if(GridViewTemporaryMunicipalityClient.cpIsPostBack!=1);
		//GridViewTemporaryMunicipalityClient.ExpandDetailRow(GridViewTemporaryMunicipalityClient.cpSelectedIndex);	
	else
		GridViewTemporaryMunicipalityClient.cpIsPostBack=0;
}"
                            DetailRowExpanding="function(s, e) {
	GridViewEmployeeClient.cpIsVisible=1;	
	if(GridViewEmployeeClient.cpIsReturn!=1)
	{
		GridViewTemporaryMunicipalityClient.cpSelectedIndex=GridViewTemporaryMunicipalityClient.GetFocusedRowIndex();
			
	}
	else
	{
		GridViewTemporaryMunicipalityClient.cpIsReturn=0;	
	}				
		GridViewTemporaryMunicipalityClient.SetFocusedRowIndex(GridViewTemporaryMunicipalityClient.cpSelectedIndex);

}"
                            DetailRowCollapsing="function(s, e) {
	GridViewTemporaryMunicipalityClient.cpIsVisible=0;
}" />

                        <SettingsPager AlwaysShowPager="True">
                            <AllButton Text="همه رکوردها"></AllButton>

                            <FirstPageButton Text="اولین صفحه"></FirstPageButton>

                            <LastPageButton Text="آخرین صفحه"></LastPageButton>

                            <NextPageButton Text="صفحه بعد"></NextPageButton>

                            <PrevPageButton Text="صفحه قبل"></PrevPageButton>

                            <Summary Text="صفحه: {0} از {1} (تعداد کل:{2})"></Summary>

                            <PageSizeItemSettings Items="10, 20, 50, 100" Visible="True"></PageSizeItemSettings>
                        </SettingsPager>

                        <Settings ShowHorizontalScrollBar="True" />
                        <SettingsDetail ExportMode="All" ShowDetailRow="True" AllowOnlyOneMasterRowExpanded="True"></SettingsDetail>

                        <SettingsBehavior ColumnResizeMode="Control" AllowFocusedRow="True" ConfirmDelete="True"></SettingsBehavior>

                        <SettingsCookies StoreGroupingAndSorting="False" StorePaging="False" StoreFiltering="False"></SettingsCookies>

                        <SettingsLoadingPanel Text="در حال بارگذاری"></SettingsLoadingPanel>

                        <SettingsText GroupPanel="جهت گروه بندی ستون مربوطه را به این قسمت بکشید" PopupEditFormCaption="تغییر رکورد" EmptyDataRow="هیچ داده ای وجود ندارد" CommandCancel="انصراف" CommandUpdate="ذخیره" CommandClearFilter="پاک کردن فیلتر" ConfirmDelete="آیا مطمئن به حذف این ردیف هستید؟" CommandEdit="ویرایش" CommandNew="جدید" CommandDelete="حذف" CommandSelect="انتخاب"></SettingsText>

                        <StylesPager>
                            <PageNumber HorizontalAlign="Center" VerticalAlign="Middle"></PageNumber>
                        </StylesPager>
                        <Columns>
                            <dxwgv:GridViewDataTextColumn FieldName="TaskId" Caption="انتقال" Name="WFState" Width="45px"
                                VisibleIndex="0">
                                <DataItemTemplate>
                                </DataItemTemplate>

                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="کد" FieldName="Id" VisibleIndex="0">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="شماره ارجاع" FieldName="ErjaNumber" VisibleIndex="1">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="کد نوسازی" FieldName="NosaziCode" VisibleIndex="2">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="نام نماینده مالکین" FieldName="OwnerAgentFullName" VisibleIndex="3">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="کد ملی نماینده مالکین" FieldName="OwnerAgentNationalCode" VisibleIndex="4">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="همراه نماینده مالکین" FieldName="OwnerAgentMobile" VisibleIndex="5">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="تاریخ ثبت" FieldName="RquestRegisterDate" VisibleIndex="6">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="تاریخ دریافت" Width="150px" FieldName="CreateDatefa" VisibleIndex="7">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="پلاک ثبتی اصلی" FieldName="MainPelakNumber" VisibleIndex="8">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="قطعه" FieldName="Piece" VisibleIndex="9">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="ناحیه" FieldName="Region" VisibleIndex="10">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewDataTextColumn Caption="پایان کار" FieldName="IsFinished" VisibleIndex="11">
                            </dxwgv:GridViewDataTextColumn>
                            <dxwgv:GridViewCommandColumn Caption=" " VisibleIndex="12" ShowClearFilterButton="true">
                            </dxwgv:GridViewCommandColumn>

                        </Columns>

                        <SettingsAdaptivity AdaptivityMode="HideDataCells"></SettingsAdaptivity>



                        <Styles CssPostfix="Metropolis" CssFilePath="~/App_Themes/Metropolis/{0}/styles.css">
                            <Header HorizontalAlign="Center"></Header>
                        </Styles>

                        <Images SpriteCssFilePath="~/App_Themes/Metropolis/{0}/sprite.css"></Images>
                    </TSPControls:CustomAspxDevGridView>


                    <asp:ObjectDataSource ID="ObjdsTempProject" runat="server" OldValuesParameterFormatString="original_{0}"
                      SelectMethod="GetShahrdariProjectForInsert" TypeName="TSP.DataManager.TechnicalServices.ProjectManager">
                    </asp:ObjectDataSource>



                </dxp:PanelContent>
            </PanelCollection>
            <SettingsLoadingPanel Text="در حال بارگذاری لطفا صبر نمایید..."></SettingsLoadingPanel>

            <ClientSideEvents EndCallback="function(s, e) {
if(CallbackPanelPage.cpDoPrint == 1)
{
    CallbackPanelPage.cpDoPrint = 0;
    window.open('../../Print.aspx');
}
}" />
        </TSPControls:CustomAspxCallbackPanel>

    </div>
</asp:Content>
