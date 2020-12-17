using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cross.DataVault.Data;
using Cross.DataVault.Data.Interface;


namespace Cross.DataVault.Services
{
    public interface ILogging
    {
        //ADD
        void AddLog<T>(T obj) where T: ILog;
        void AddLog_ByCollection<T>(List<T> objs) where T : ILog;

        //Read
        T GetLog_ByID<T>(string id) where T : ILog;
        T GetLog_ByTransactionTime<T>(DateTime curr) where T : ILog;


        List<T> GetLogs<T>() where T : ILog;
        List<T> GetLogs_ByContactID<T>(string id) where T : ILog;
        List<T> GetLogs_ByCreation<T>(DateTime obj) where T : ILog;

        //Delete
        void Clear_LogByID(string id);
        void Clear_LogsByContactID(string id);
    }
}
