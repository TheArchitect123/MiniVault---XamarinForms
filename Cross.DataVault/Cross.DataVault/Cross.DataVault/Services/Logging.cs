using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cross.DataVault.Data;
using Cross.DataVault.Data.Interface;
using Cross.DataVault.Data.Services;

namespace Cross.DataVault.Services
{
    public class Logging : ILogging
    {
        public IDatabase AccessHelper
        {
            get
            {
                return Caliburn.Micro.IoC.Get<IDatabase>();
            }
        }

        public void AddLog<T>(T obj) where T : ILog
        {
            AccessHelper.Insert(obj);
        }

        public void AddLog_ByCollection<T>(List<T> objs) where T : ILog
        {
            AccessHelper.InsertItems(objs);
        }

        public void Clear_LogByID(string id)
        {
            AccessHelper.Execute($"DELETE FROM Log WHERE Log_ID_Ref = {id}");
        }

        public void Clear_LogsByContactID(string id)
        {
            AccessHelper.Execute($"DELETE FROM Log WHERE Contact_ID_Ref = {id}");
        }
        
        public List<T> GetLogs<T>() where T : ILog
        {
            return AccessHelper.Get<T>($"SELECT * FROM Log").ToList();
        }

        public List<T> GetLogs_ByContactID<T>(string id) where T : ILog
        {
            return AccessHelper.Get<T>($"SELECT * FROM Log WHERE Contact_ID_Ref = {id}").ToList();
        }

        public List<T> GetLogs_ByCreation<T>(DateTime obj) where T : ILog
        {
            return null;
        }

        public T GetLog_ByID<T>(string id) where T : ILog
        {
            return AccessHelper.Get<T>($"SELECT * FROM Log WHERE Log_ID_Ref = {id}").SingleOrDefault();
        }

        public T GetLog_ByTransactionTime<T>(DateTime curr) where T : ILog
        {
            return AccessHelper.Get<T>($"SELECT * FROM Log WHERE Sys_Creation = {curr}").SingleOrDefault();
        }
    }
}
