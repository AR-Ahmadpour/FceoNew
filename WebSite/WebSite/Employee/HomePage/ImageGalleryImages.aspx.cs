﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DevExpress.Web;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

public partial class Employee_HomePage_ImageGalleryImages : System.Web.UI.Page
{
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Request.QueryString["Album"]))
        {
            Response.Redirect("ImageGalleryAlbum.aspx");
            return;
        }

        int AlbumId = -1;
        try
        {
            AlbumId = Convert.ToInt32(Utility.DecryptQS(Request.QueryString["Album"]).ToString());
        }
        catch
        {
            this.Response.Redirect("~/ErrorPage.aspx?ErrorNo=" + ((int)ErrorCodes.ErrorType.PageInputsNotValid).ToString());
            return;
        }

        if (!IsPostBack)
        {

            TSP.DataManager.Permission per = TSP.DataManager.GalleryImagesManager.GetUserPermission(Utility.GetCurrentUser_UserId(), (TSP.DataManager.UserType)Utility.GetCurrentUser_LoginType());

            BtnNew.Enabled = per.CanNew;
            btnNew2.Enabled = per.CanNew;
            btnEdit.Enabled = per.CanEdit;
            btnEdit2.Enabled = per.CanEdit;
            btnDelete.Enabled = per.CanDelete;
            btnDelete2.Enabled = per.CanDelete;
            GridViewImages.Visible = per.CanView;

            Session["GalleryImagesFileAddress"] = null;

            this.ViewState["BtnEdit"] = btnEdit.Enabled;
            this.ViewState["BtnDelete"] = btnDelete.Enabled;
            this.ViewState["BtnNew"] = BtnNew.Enabled;

            AlbumId = Convert.ToInt32(Utility.DecryptQS(Request.QueryString["Album"]).ToString());
            ObjdsImages.SelectParameters[0].DefaultValue = AlbumId.ToString();
            GridViewImages.DataBind();

            try
            {
                TSP.DataManager.GalleryAlbumsManager AlbumsManager = new TSP.DataManager.GalleryAlbumsManager();
                AlbumsManager.FindById(AlbumId);
                GridViewImages.SettingsText.Title = "آلبوم: " + AlbumsManager[0]["AlbumName"].ToString();
            }
            catch (Exception) { }
        }

        if (this.ViewState["BtnEdit"] != null)
            this.btnEdit.Enabled = this.btnEdit2.Enabled = (bool)this.ViewState["BtnEdit"];
        if (this.ViewState["BtnDelete"] != null)
            this.btnDelete.Enabled = this.btnDelete.Enabled = (bool)this.ViewState["BtnDelete"];
        if (this.ViewState["BtnNew"] != null)
            this.BtnNew.Enabled = this.btnNew2.Enabled = (bool)this.ViewState["BtnNew"];

        GridViewImages.JSProperties["cpMessage"] = "";

        Page.ClientScript.RegisterStartupScript(GetType(), "Key", "<script>document.getElementById('" + DivReport.ClientID + "').style.visibility='hidden'; </script>");
        this.DivReport.Attributes.Add("onclick", "ChangeVisible(this)");
        this.DivReport.Attributes.Add("onmouseover", "ChangeIcon(this)");
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int ImageId = -1;
        if (GridViewImages.FocusedRowIndex > -1)
        {
            String OldImage = "";
            try
            {
                DataRow Row = GridViewImages.GetDataRow(GridViewImages.FocusedRowIndex);
                ImageId = Convert.ToInt32(Row["ImageId"]);
                TSP.DataManager.GalleryImagesManager ImagesManager = new TSP.DataManager.GalleryImagesManager();
                ImagesManager.FindById(ImageId);
                if (ImagesManager.Count > 0)
                {
                    OldImage = ImagesManager[0]["ImgUrl"].ToString();
                    ImagesManager[0].Delete();

                    int cn = ImagesManager.Save();
                    if (cn > 0)
                    {
                        GridViewImages.DataBind();
                        ShowMessage("ذخیره انجام شد.");
                    }
                    else
                    {
                        ShowMessage("خطایی در ذخیره انجام گرفته است.");
                    }
                }
                else
                {
                    ShowMessage("اطلاعات مورد نظر توسط کاربر دیگری تغییر یافته است.");
                }
            }
            catch (Exception err)
            {
                ShowMessage("خطایی در ذخیره انجام گرفته است.");
            }
            try
            {
                System.IO.File.Delete(MapPath(OldImage));
                System.IO.File.Delete(MapPath(OldImage.Replace("Fullsize", "Thumbs")));
            }
            catch (Exception) { }
        }
    }

    protected void GridViewImages_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        e.Cancel = true;
        if (Page.IsValid)
        {
            InsertImage(e);
        }
    }

    protected void GridViewImages_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        e.Cancel = true;
        EditImage(e);
    }

    protected void GridViewImages_RowValidating(object sender, DevExpress.Web.Data.ASPxDataValidationEventArgs e)
    {
        if (e.IsNewRow)
        {
            if (Session["GalleryImagesFileAddress"] == null)
                AddError(e.Errors, GridViewImages.Columns["ImgUrl"], "تصویر انتخاب نشده است");
        }

        if (e.Errors.Count > 0) e.RowError = "تصویر انتخاب نشده است";
    }

    protected void UploaderImg_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
    {
        try
        {
            e.CallbackData = SaveImage(e.UploadedFile);
        }
        catch (Exception ex)
        {
            e.IsValid = false;
            e.ErrorText = ex.Message;
        }
    }
    #endregion

    #region Methods
    protected string SaveImage(UploadedFile uploadedFile)
    {
        string ret = "";
        if (uploadedFile.IsValid)
        {
            do
            {
                System.IO.FileInfo ImageType = new System.IO.FileInfo(uploadedFile.PostedFile.FileName);
                ret = System.IO.Path.GetRandomFileName() + ImageType.Extension;
            } while (System.IO.File.Exists(MapPath("~/Image/Gallery/Fullsize/") + ret) == true || System.IO.File.Exists(MapPath("~/Image/Temp/") + ret) == true);
            string tempFileName = MapPath("~/Image/Temp/") + ret;
            uploadedFile.SaveAs(tempFileName, true);
            Session["GalleryImagesFileAddress"] = tempFileName;
        }
        return ret;
    }

    void AddError(Dictionary<GridViewColumn, string> errors, GridViewColumn column, string errorText)
    {
        if (errors.ContainsKey(column)) return;
        errors[column] = errorText;
    }

    private void InsertImage(DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
    {
        TSP.DataManager.GalleryImagesManager ImagesManager = new TSP.DataManager.GalleryImagesManager();
        try
        {
            if (Session["GalleryImagesFileAddress"] != null && String.IsNullOrEmpty(Session["GalleryImagesFileAddress"].ToString()) == false && System.IO.File.Exists(Session["GalleryImagesFileAddress"].ToString()) == true)
            {
                SaveThumb(Session["GalleryImagesFileAddress"].ToString(), MapPath("~/Image/Gallery/Thumbs/") + System.IO.Path.GetFileName(Session["GalleryImagesFileAddress"].ToString()));
                //System.IO.File.Copy(Session["GalleryImagesFileAddress"].ToString(), MapPath("~/Image/Gallery/Thumbs/") + System.IO.Path.GetFileName(Session["GalleryImagesFileAddress"].ToString()));
                System.IO.File.Move(Session["GalleryImagesFileAddress"].ToString(), MapPath("~/Image/Gallery/Fullsize/") + System.IO.Path.GetFileName(Session["GalleryImagesFileAddress"].ToString()));
            }
            else
            {
                GridViewImages.JSProperties["cpMessage"] = "خطایی در انتقال تصویر انجام گرفته است.";
                return;
            }

            DataRow Row = ImagesManager.NewRow();
            if (e.NewValues["ImageName"] != null && String.IsNullOrEmpty(e.NewValues["ImageName"].ToString().Trim()) == false)
                Row["ImageName"] = e.NewValues["ImageName"].ToString();
            Row["AlbumId"] = Utility.DecryptQS(Request.QueryString["Album"]).ToString();
            Row["ImgUrl"] = "~/Image/Gallery/Fullsize/" + System.IO.Path.GetFileName(Session["GalleryImagesFileAddress"].ToString());
            Row["UploadDate"] = Utility.GetDateOfToday();
            Row["UserId"] = Utility.GetCurrentUser_UserId();
            Row["ModifiedDate"] = DateTime.Now;
            ImagesManager.AddRow(Row);
            int cn = ImagesManager.Save();
            if (cn > 0)
            {
                GridViewImages.JSProperties["cpMessage"] = "ذخیره انجام شد.";
            }
            else
            {
                GridViewImages.JSProperties["cpMessage"] = "خطایی در ذخیره انجام گرفته است";
            }
            GridViewImages.DataBind();
            GridViewImages.CancelEdit();
            Session["GalleryImagesFileAddress"] = null;
        }
        catch (Exception err)
        {
            GridViewImages.CancelEdit();

            if (err.GetType() == typeof(System.Data.SqlClient.SqlException))
            {
                System.Data.SqlClient.SqlException se = (System.Data.SqlClient.SqlException)err;
                if (se.Number == 2601)
                {
                    GridViewImages.JSProperties["cpMessage"] = "اطلاعات تکراری می باشد";
                }
                else if (se.Number == 2627)
                {
                    GridViewImages.JSProperties["cpMessage"] = "کد درس تکراری می باشد.";
                }
                else
                {
                    GridViewImages.JSProperties["cpMessage"] = "خطایی در ذخیره انجام گرفته است";
                }
            }
            else
            {
                GridViewImages.JSProperties["cpMessage"] = "خطایی در ذخیره انجام گرفته است";
            }
            GridViewImages.JSProperties["cpMessage"] += err.Message;
        }

    }

    private void EditImage(DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
    {
        String OldImage = "";
        try
        {
            if (Session["GalleryImagesFileAddress"] != null && String.IsNullOrEmpty(Session["GalleryImagesFileAddress"].ToString()) == false && System.IO.File.Exists(Session["GalleryImagesFileAddress"].ToString()) == true)
            {
                SaveThumb(Session["GalleryImagesFileAddress"].ToString(), MapPath("~/Image/Gallery/Thumbs/") + System.IO.Path.GetFileName(Session["GalleryImagesFileAddress"].ToString()));
                //System.IO.File.Copy(Session["GalleryImagesFileAddress"].ToString(), MapPath("~/Image/Gallery/Thumbs/") + System.IO.Path.GetFileName(Session["GalleryImagesFileAddress"].ToString()));
                System.IO.File.Move(Session["GalleryImagesFileAddress"].ToString(), MapPath("~/Image/Gallery/Fullsize/") + System.IO.Path.GetFileName(Session["GalleryImagesFileAddress"].ToString()));
            }

            TSP.DataManager.GalleryImagesManager ImagesManager = new TSP.DataManager.GalleryImagesManager();
            ImagesManager.FindById(Convert.ToInt32(e.Keys[0]));
            DataRow Row = ImagesManager[0];

            if (Row != null)
            {
                OldImage = Row["ImgUrl"].ToString();

                Row.BeginEdit();

                if (e.NewValues["ImageName"] != null && String.IsNullOrEmpty(e.NewValues["ImageName"].ToString().Trim()) == false)
                    Row["ImageName"] = e.NewValues["ImageName"].ToString();
                else
                    Row["ImageName"] = DBNull.Value;
                if (Session["GalleryImagesFileAddress"] != null)
                    Row["ImgUrl"] = "~/Image/Gallery/Fullsize/" + System.IO.Path.GetFileName(Session["GalleryImagesFileAddress"].ToString());
                Row["UserId"] = Utility.GetCurrentUser_UserId();
                Row["ModifiedDate"] = DateTime.Now;
                Row.EndEdit();
                int cn = ImagesManager.Save();
                if (cn > 0)
                {
                    GridViewImages.JSProperties["cpMessage"] = "ذخیره انجام شد.";
                    GridViewImages.DataBind();
                }
                else
                {
                    GridViewImages.JSProperties["cpMessage"] = "خطایی در ذخیره انجام گرفته است.";
                }

            }
            GridViewImages.DataBind();
            GridViewImages.CancelEdit();
        }
        catch (Exception err)
        {
            GridViewImages.CancelEdit();

            if (err.GetType() == typeof(System.Data.SqlClient.SqlException))
            {
                System.Data.SqlClient.SqlException se = (System.Data.SqlClient.SqlException)err;
                if (se.Number == 2601)
                {
                    GridViewImages.JSProperties["cpMessage"] = "اطلاعات تکراری می باشد";
                }
                else if (se.Number == 2627)
                {
                    GridViewImages.JSProperties["cpMessage"] = "کد درس تکراری می باشد.";
                }
                else
                {
                    GridViewImages.JSProperties["cpMessage"] = "خطایی در ذخیره انجام گرفته است";
                }
            }
            else
            {
                GridViewImages.JSProperties["cpMessage"] = "خطایی در ذخیره انجام گرفته است";
            }
        }
        try
        {
            System.IO.File.Delete(MapPath(OldImage));
            System.IO.File.Delete(MapPath(OldImage.Replace("Fullsize", "Thumbs")));
        }
        catch (Exception)
        {
        }
    }

    void SaveThumb(String Path, String Destination)
    {
        System.Drawing.Image imgInput = Utility.GetImage(Utility.GetFileBytes(Path));
        Graphics gInput = Graphics.FromImage(imgInput);
        System.Drawing.Imaging.ImageFormat ImageFormat = imgInput.RawFormat;

        System.Drawing.Image imgPhoto = ScaleImageToFixedSize(imgInput, 179, 100);
        imgPhoto.Save(Destination, ImageFormat);
        imgPhoto.Dispose();
    }

    System.Drawing.Image ScaleImageToFixedSize(System.Drawing.Image imgPhoto, int Width, int Height)
    {
        int sourceWidth = imgPhoto.Width;
        int sourceHeight = imgPhoto.Height;
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;

        float nPercent = 0;
        float nPercentW = 0;
        float nPercentH = 0;

        nPercentW = ((float)Width / (float)sourceWidth);
        nPercentH = ((float)Height / (float)sourceHeight);
        if (nPercentH < nPercentW)
        {
            nPercent = nPercentH;
            destX = System.Convert.ToInt16((Width -
                          (sourceWidth * nPercent)) / 2);
        }
        else
        {
            nPercent = nPercentW;
            destY = System.Convert.ToInt16((Height - (sourceHeight * nPercent)) / 2);
        }

        int destWidth = (int)(sourceWidth * nPercent);
        int destHeight = (int)(sourceHeight * nPercent);

        Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
        bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

        Graphics grPhoto = Graphics.FromImage(bmPhoto);
        grPhoto.Clear(Color.White);
        grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

        grPhoto.DrawImage(imgPhoto,
            new Rectangle(destX, destY, destWidth, destHeight),
            new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
            GraphicsUnit.Pixel);

        grPhoto.Dispose();
        return bmPhoto;
    }

    void ShowMessage(String Message)
    {
        this.DivReport.Visible = true;
        this.LabelWarning.Text = Message;
    }
    #endregion
}
