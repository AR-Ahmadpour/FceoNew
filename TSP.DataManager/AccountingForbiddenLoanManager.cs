using System;
using System.Collections.Generic;
using System.Text;

namespace TSP.DataManager
{
    public class AccountingForbiddenLoanManager : BaseObject
    {
        public AccountingForbiddenLoanManager()
            : base()
        {
        }

        public AccountingForbiddenLoanManager(System.Data.DataSet ds)
            : base(ds)
        {
        }

        public static Permission GetUserPermission(int UserId, UserType ut)
        {
            return BaseObject.GetUserPermission(UserId, ut, TableType.AccountingForbiddenLoan);   
        }

        protected override void InitAdapter()
        {
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "AccountingForbiddenLoan";
            tableMapping.ColumnMappings.Add("ForbiddenLoanId", "ForbiddenLoanId");
            tableMapping.ColumnMappings.Add("LoanConditionsId", "LoanConditionsId");
            tableMapping.ColumnMappings.Add("LoanId", "LoanId");
            tableMapping.ColumnMappings.Add("UserId", "UserId");
            tableMapping.ColumnMappings.Add("ModifiedDate", "ModifiedDate");
            tableMapping.ColumnMappings.Add("LastTimeStamp", "LastTimeStamp");
            this.Adapter.TableMappings.Add(tableMapping);

            this.Adapter.SelectCommand = new global::System.Data.SqlClient.SqlCommand();
            this.Adapter.SelectCommand.Connection = this.Connection;
            this.Adapter.SelectCommand.CommandText = "dbo.spSelectForbiddenLoan";
            this.Adapter.SelectCommand.CommandType = global::System.Data.CommandType.StoredProcedure;
            this.Adapter.SelectCommand.Parameters.Add("@ForbiddenLoanId", System.Data.SqlDbType.Int);
            this.Adapter.SelectCommand.Parameters.Add("@LoanConditionsId", System.Data.SqlDbType.Int);

            this.Adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this.Adapter.DeleteCommand.Connection = this.Connection;
            this.Adapter.DeleteCommand.CommandText = "dbo.spDeleteForbiddenLoan";
            this.Adapter.DeleteCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.Adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Variant, 0, System.Data.ParameterDirection.ReturnValue, 0, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ForbiddenLoanId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ForbiddenLoanId", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.Adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LastTimeStamp", System.Data.SqlDbType.Timestamp, 0, System.Data.ParameterDirection.Input, 0, 0, "LastTimeStamp", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this.Adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this.Adapter.InsertCommand.Connection = this.Connection;
            this.Adapter.InsertCommand.CommandText = "dbo.spInsertForbiddenLoan";
            this.Adapter.InsertCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Variant, 0, System.Data.ParameterDirection.ReturnValue, 0, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LoanConditionsId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoanConditionsId", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LoanId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoanId", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "UserId", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ModifiedDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "ModifiedDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this.Adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this.Adapter.UpdateCommand.Connection = this.Connection;
            this.Adapter.UpdateCommand.CommandText = "dbo.spUpdateForbiddenLoan";
            this.Adapter.UpdateCommand.CommandType = System.Data.CommandType.StoredProcedure;
            this.Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Variant, 0, System.Data.ParameterDirection.ReturnValue, 0, 0, null, System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LoanConditionsId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoanConditionsId", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LoanId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LoanId", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@UserId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "UserId", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ModifiedDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "ModifiedDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ForbiddenLoanId", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ForbiddenLoanId", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LastTimeStamp", System.Data.SqlDbType.Timestamp, 0, System.Data.ParameterDirection.Input, 0, 0, "LastTimeStamp", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this.Adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ForbiddenLoanId", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 0, 0, "ForbiddenLoanId", System.Data.DataRowVersion.Current, false, null, "", "", ""));

        }

        public override System.Data.DataTable DataTable
        {
            get
            {
                if ((this._dataTable == null))
                {
                    this._dataTable = new DataManager.AccountingDataSet.AccountingForbiddenLoanDataTable();
                    this.DataSet.Tables.Add(this._dataTable);
                }

                return this._dataTable;
            }
        }

        public void FindByForbiddenLoanId(int ForbiddenLoanId)
        {
            ResetAllParameters();
            this.Adapter.SelectCommand.Parameters["@ForbiddenLoanId"].Value = ForbiddenLoanId;
            Fill();
        }

        public void FindByLoanConditionsId(int LoanConditionsId)
        {
            ResetAllParameters();
            this.Adapter.SelectCommand.Parameters["@LoanConditionsId"].Value = LoanConditionsId;
            Fill();
        }
    }
}
