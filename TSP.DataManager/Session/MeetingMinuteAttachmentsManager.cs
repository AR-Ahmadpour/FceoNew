﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSP.DataManager.Session
{
    public class MeetingMinuteAttachmentsManager:BaseObject
    {
        public static Permission GetUserPermission(int UserId, UserType ut)
        {
            return BaseObject.GetUserPermission(UserId, ut, TableType.Session_MeetingMinuteAttachments);
        }

        protected override void InitAdapter()
        {
            global::System.Data.Common.DataTableMapping tableMapping = new global::System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "MeetingMinuteAttachments";
            tableMapping.ColumnMappings.Add("AttachId", "AttachId");
            tableMapping.ColumnMappings.Add("MinuteId", "MinuteId");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("AttachFile", "AttachFile");
            tableMapping.ColumnMappings.Add("UserId", "UserId");
            tableMapping.ColumnMappings.Add("ModifiedDate", "ModifiedDate");
            tableMapping.ColumnMappings.Add("LastTimeStamp", "LastTimeStamp");
            tableMapping.ColumnMappings.Add("Description", "Description");
            this.Adapter.TableMappings.Add(tableMapping);

            this.Adapter.SelectCommand = new global::System.Data.SqlClient.SqlCommand();
            this.Adapter.SelectCommand.Connection = this.Connection;
            this.Adapter.SelectCommand.CommandText = "dbo.spSelectSession_MeetingMinuteAttachments";
            this.Adapter.SelectCommand.CommandType = global::System.Data.CommandType.StoredProcedure;
            this.Adapter.SelectCommand.Parameters.Add("@AttachId", System.Data.SqlDbType.Int, 4);
            this.Adapter.SelectCommand.Parameters.Add("@MinuteId", System.Data.SqlDbType.Int, 4);

            this.Adapter.DeleteCommand = new global::System.Data.SqlClient.SqlCommand();
            this.Adapter.DeleteCommand.Connection = this.Connection;
            this.Adapter.DeleteCommand.CommandText = "dbo.spDeleteSession_MeetingMinuteAttachments";
            this.Adapter.DeleteCommand.CommandType = global::System.Data.CommandType.StoredProcedure;
            this.Adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RETURN_VALUE", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.ReturnValue, 10, 0, null, global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AttachId", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 10, 0, "AttachId", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.Adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LastTimeStamp", global::System.Data.SqlDbType.Timestamp, 8, global::System.Data.ParameterDirection.Input, 0, 0, "LastTimeStamp", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.Adapter.InsertCommand = new global::System.Data.SqlClient.SqlCommand();
            this.Adapter.InsertCommand.Connection = this.Connection;
            this.Adapter.InsertCommand.CommandText = "dbo.spInsertSession_MeetingMinuteAttachments";
            this.Adapter.InsertCommand.CommandType = global::System.Data.CommandType.StoredProcedure;
            this.Adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RETURN_VALUE", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.ReturnValue, 10, 0, null, global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MinuteId", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 10, 0, "MinuteId", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 127, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AttachFile", global::System.Data.SqlDbType.NVarChar, 511, global::System.Data.ParameterDirection.Input, 0, 0, "AttachFile", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NVarChar, 511, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UserId", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 10, 0, "UserId", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ModifiedDate", global::System.Data.SqlDbType.DateTime, 8, global::System.Data.ParameterDirection.Input, 23, 3, "ModifiedDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand = new global::System.Data.SqlClient.SqlCommand();
            this.Adapter.UpdateCommand.Connection = this.Connection;
            this.Adapter.UpdateCommand.CommandText = "dbo.spUpdateSession_MeetingMinuteAttachments";
            this.Adapter.UpdateCommand.CommandType = global::System.Data.CommandType.StoredProcedure;
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RETURN_VALUE", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.ReturnValue, 10, 0, null, global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MinuteId", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 10, 0, "MinuteId", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 127, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AttachFile", global::System.Data.SqlDbType.NVarChar, 511, global::System.Data.ParameterDirection.Input, 0, 0, "AttachFile", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NVarChar, 511, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UserId", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 10, 0, "UserId", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ModifiedDate", global::System.Data.SqlDbType.DateTime, 8, global::System.Data.ParameterDirection.Input, 23, 3, "ModifiedDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AttachId", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 10, 0, "AttachId", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LastTimeStamp", global::System.Data.SqlDbType.Timestamp, 8, global::System.Data.ParameterDirection.Input, 0, 0, "LastTimeStamp", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AttachId", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 10, 0, "AttachId", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
       
        }

        public override System.Data.DataTable DataTable
        {
            get
            {
                if ((this._dataTable == null))
                {
                    this._dataTable = new DataManager.Session.SessionDataSet.MeetingMinuteAttachmentsDataTable();
                    this.DataSet.Tables.Add(this._dataTable);
                }

                return this._dataTable;
            }
        }

        public void FindById(int Id)
        {
            ResetAllParameters();
            this.Adapter.SelectCommand.Parameters["@AttachId"].Value = Id;
            Fill();
        }

        [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, true)]
        public DataTable FindByMinuteId(int MinuteId)
        {
            ResetAllParameters();
            this.Adapter.SelectCommand.Parameters["@MinuteId"].Value = MinuteId;
            Fill();
            return this.DataTable;
        }
    }
}
