using System;
using System.Collections.Generic;
using System.Text;

namespace TSP.DataManager
{
   public  class AccountingGroupTypeManager:BaseObject
    {

        //static AccountingGroupTypeManager()
        //{
        //    _tableId = TableType.AccountingGroupType;
        //}
       public AccountingGroupTypeManager()
           : base()
       {
       }
       public AccountingGroupTypeManager(System.Data.DataSet ds)
            : base(ds)
        {
        }
       public static Permission GetUserPermission(int UserId, UserType ut)
       {
           return BaseObject.GetUserPermission(UserId, ut, TableType.AccountingGroupType);
       }
        protected override void InitAdapter()
        {
            global::System.Data.Common.DataTableMapping tableMapping = new global::System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "Accounting.GroupType";
            tableMapping.ColumnMappings.Add("GrpTypeId", "GrpTypeId");
            tableMapping.ColumnMappings.Add("GroupTypeName", "GroupTypeName");
            tableMapping.ColumnMappings.Add("UserId", "UserId");
            tableMapping.ColumnMappings.Add("ModifiedDate", "ModifiedDate");
            tableMapping.ColumnMappings.Add("LastTimeStamp", "LastTimeStamp");
            this.Adapter.TableMappings.Add(tableMapping);

            this.Adapter.SelectCommand = new global::System.Data.SqlClient.SqlCommand();
            this.Adapter.SelectCommand.Connection = this.Connection;
            this.Adapter.SelectCommand.CommandText = "dbo.spSelectGroupType";
            this.Adapter.SelectCommand.CommandType = global::System.Data.CommandType.StoredProcedure;

            this.Adapter.DeleteCommand = new global::System.Data.SqlClient.SqlCommand();
            this.Adapter.DeleteCommand.Connection = this.Connection;
            this.Adapter.DeleteCommand.CommandText = "dbo.spDeleteGroupType";
            this.Adapter.DeleteCommand.CommandType = global::System.Data.CommandType.StoredProcedure;
            this.Adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RETURN_VALUE", global::System.Data.SqlDbType.Variant, 0, global::System.Data.ParameterDirection.ReturnValue, 0, 0, null, global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GrpTypeId", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrpTypeId", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.Adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LastTimeStamp", global::System.Data.SqlDbType.Timestamp, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastTimeStamp", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this.Adapter.InsertCommand = new global::System.Data.SqlClient.SqlCommand();
            this.Adapter.InsertCommand.Connection = this.Connection;
            this.Adapter.InsertCommand.CommandText = "dbo.spInsertGroupType";
            this.Adapter.InsertCommand.CommandType = global::System.Data.CommandType.StoredProcedure;
            this.Adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RETURN_VALUE", global::System.Data.SqlDbType.Variant, 0, global::System.Data.ParameterDirection.ReturnValue, 0, 0, null, global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GrpTypeId", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrpTypeId", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GroupTypeName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroupTypeName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UserId", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserId", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ModifiedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ModifiedDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this.Adapter.UpdateCommand = new global::System.Data.SqlClient.SqlCommand();
            this.Adapter.UpdateCommand.Connection = this.Connection;
            this.Adapter.UpdateCommand.CommandText = "dbo.spUpdateGroupType";
            this.Adapter.UpdateCommand.CommandType = global::System.Data.CommandType.StoredProcedure;
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RETURN_VALUE", global::System.Data.SqlDbType.Variant, 0, global::System.Data.ParameterDirection.ReturnValue, 0, 0, null, global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GrpTypeId", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrpTypeId", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@GroupTypeName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GroupTypeName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UserId", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UserId", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ModifiedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ModifiedDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_GrpTypeId", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "GrpTypeId", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LastTimeStamp", global::System.Data.SqlDbType.Timestamp, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastTimeStamp", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

        }

       public override System.Data.DataTable DataTable
       {
           get
           {
               if ((this._dataTable == null))
               {

                   this._dataTable = new DataManager.AccountingDataSet.AccountingGroupTypeDataTable();
                   this.DataSet.Tables.Add(this._dataTable);
               }

               return this._dataTable;
           }
       }


       [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
       [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
       [global::System.ComponentModel.DataObjectMethodAttribute(global::System.ComponentModel.DataObjectMethodType.Delete, true)]
       public virtual int Delete(int Original_GrpTypeId, byte[] Original_LastTimeStamp)
       {
           this.Adapter.DeleteCommand.Parameters[1].Value = ((int)(Original_GrpTypeId));
           if ((Original_LastTimeStamp == null))
           {
               throw new global::System.ArgumentNullException("Original_LastTimeStamp");
           }
           else
           {
               this.Adapter.DeleteCommand.Parameters[2].Value = ((byte[])(Original_LastTimeStamp));
           }
           global::System.Data.ConnectionState previousConnectionState = this.Adapter.DeleteCommand.Connection.State;
           if (((this.Adapter.DeleteCommand.Connection.State & global::System.Data.ConnectionState.Open)
                       != global::System.Data.ConnectionState.Open))
           {
               this.Adapter.DeleteCommand.Connection.Open();
           }
           try
           {
               int returnValue = this.Adapter.DeleteCommand.ExecuteNonQuery();
               return returnValue;
           }
           finally
           {
               if ((previousConnectionState == global::System.Data.ConnectionState.Closed))
               {
                   this.Adapter.DeleteCommand.Connection.Close();
               }
           }
       }

       [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
       [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
       [global::System.ComponentModel.DataObjectMethodAttribute(global::System.ComponentModel.DataObjectMethodType.Insert, true)]
       public virtual int Insert(int GrpTypeId, string GroupTypeName, int UserId, System.DateTime ModifiedDate)
       {
           this.Adapter.InsertCommand.Parameters[1].Value = ((int)(GrpTypeId));
           if ((GroupTypeName == null))
           {
               throw new global::System.ArgumentNullException("GroupTypeName");
           }
           else
           {
               this.Adapter.InsertCommand.Parameters[2].Value = ((string)(GroupTypeName));
           }
           this.Adapter.InsertCommand.Parameters[3].Value = ((int)(UserId));
           this.Adapter.InsertCommand.Parameters[4].Value = ((System.DateTime)(ModifiedDate));
           global::System.Data.ConnectionState previousConnectionState = this.Adapter.InsertCommand.Connection.State;
           if (((this.Adapter.InsertCommand.Connection.State & global::System.Data.ConnectionState.Open)
                       != global::System.Data.ConnectionState.Open))
           {
               this.Adapter.InsertCommand.Connection.Open();
           }
           try
           {
               int returnValue = this.Adapter.InsertCommand.ExecuteNonQuery();
               return returnValue;
           }
           finally
           {
               if ((previousConnectionState == global::System.Data.ConnectionState.Closed))
               {
                   this.Adapter.InsertCommand.Connection.Close();
               }
           }
       }

       [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
       [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
       [global::System.ComponentModel.DataObjectMethodAttribute(global::System.ComponentModel.DataObjectMethodType.Update, true)]
       public virtual int Update(int GrpTypeId, string GroupTypeName, int UserId, System.DateTime ModifiedDate, int Original_GrpTypeId, byte[] Original_LastTimeStamp)
       {
           this.Adapter.UpdateCommand.Parameters[1].Value = ((int)(GrpTypeId));
           if ((GroupTypeName == null))
           {
               throw new global::System.ArgumentNullException("GroupTypeName");
           }
           else
           {
               this.Adapter.UpdateCommand.Parameters[2].Value = ((string)(GroupTypeName));
           }
           this.Adapter.UpdateCommand.Parameters[3].Value = ((int)(UserId));
           this.Adapter.UpdateCommand.Parameters[4].Value = ((System.DateTime)(ModifiedDate));
           this.Adapter.UpdateCommand.Parameters[5].Value = ((int)(Original_GrpTypeId));
           if ((Original_LastTimeStamp == null))
           {
               throw new global::System.ArgumentNullException("Original_LastTimeStamp");
           }
           else
           {
               this.Adapter.UpdateCommand.Parameters[6].Value = ((byte[])(Original_LastTimeStamp));
           }
           global::System.Data.ConnectionState previousConnectionState = this.Adapter.UpdateCommand.Connection.State;
           if (((this.Adapter.UpdateCommand.Connection.State & global::System.Data.ConnectionState.Open)
                       != global::System.Data.ConnectionState.Open))
           {
               this.Adapter.UpdateCommand.Connection.Open();
           }
           try
           {
               int returnValue = this.Adapter.UpdateCommand.ExecuteNonQuery();
               return returnValue;
           }
           finally
           {
               if ((previousConnectionState == global::System.Data.ConnectionState.Closed))
               {
                   this.Adapter.UpdateCommand.Connection.Close();
               }
           }
       }

       [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
       [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
       [global::System.ComponentModel.DataObjectMethodAttribute(global::System.ComponentModel.DataObjectMethodType.Update, true)]
       public virtual int Update(string GroupTypeName, int UserId, System.DateTime ModifiedDate, int Original_GrpTypeId, byte[] Original_LastTimeStamp)
       {
           return this.Update(Original_GrpTypeId, GroupTypeName, UserId, ModifiedDate, Original_GrpTypeId, Original_LastTimeStamp);
       }




    }
}
