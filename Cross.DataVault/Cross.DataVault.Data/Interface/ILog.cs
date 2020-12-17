using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Data.Interface
{
    public interface ILog
    {
        string Log_ID_Ref { get; set; }
        string Process_ID_Ref { get; set; }
        string Contact_ID_Ref { get; set; }
        
        string Message { get; set; }
        string StackTrace { get; set; }

        DateTime Sys_Transaction { get; set; }
        DateTime Sys_Creation { get; set; }
    }
}
