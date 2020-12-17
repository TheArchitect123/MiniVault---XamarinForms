using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;
using Cross.DataVault.Data.Interface;
namespace Cross.DataVault.Data
{
    public class Log : IEntity, ILog
    {
        [PrimaryKey, AutoIncrement]
        public int PrimaryKey { get; set; }

        public string Log_ID_Ref { get; set; }
        public string Process_ID_Ref { get; set; }

        public string Message { get; set; }
        public string StackTrace { get; set; }

        public DateTime Sys_Transaction { get; set; }
        public DateTime Sys_Creation { get; set; }
        string ILog.Contact_ID_Ref { get; set; }
    }
}
