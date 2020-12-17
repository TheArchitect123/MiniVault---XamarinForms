using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cross.DataVault.Contracts.Data;
using Cross.DataVault.Data.Server;

//Utitlies
using Cross.DataVault.Server.DataAccess.Utilities;

namespace Cross.DataVault.Server.DataAccess
{
    public class Log_DataManager
    {
        //
        public string User_ID { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }

        #region Initialization
        public Log_DataManager(Exception ex)
        {
            if (ex.InnerException != null)
            {
                this.Message = ex.InnerException.Message;
                this.StackTrace = ex.InnerException.StackTrace;
            }
            else
            {
                this.Message = ex.Message;
                this.StackTrace = ex.StackTrace;
            }
        }

        public Log_DataManager(Exception ex, string id)
        {
            this.User_ID = id;
            if (ex.InnerException != null)
            {
                this.Message = ex.InnerException.Message;
                this.StackTrace = ex.InnerException.StackTrace;
            }
            else
            {
                this.Message = ex.Message;
                this.StackTrace = ex.StackTrace;
            }
        }
        #endregion


        public logs_data CopyToDTO()
        {
            logs_data obj = new logs_data();
            obj.id_user = this.User_ID.ToString();

            obj.stacktrace = this.StackTrace;
            obj._message = this.Message;


            obj.sys_creation = DateTime.Now;
            obj.sys_transaction = DateTime.Now;

            //Generate Log ID
            obj.log_id = Guid.NewGuid().ToString();

            return obj;
        }

        #region SET
        public void AddLog_ByLog(Logs curr)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                context.logs_datas.InsertOnSubmit(CopyToDTO());
                context.SubmitChanges();
            }
        }

        public void AddLog(Log_DataManager curr)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            { 
                context.logs_datas.InsertOnSubmit(CopyToDTO());
                context.SubmitChanges();
            }
        }
        #endregion
    }
}
