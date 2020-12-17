using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net;

namespace Cross.DataVault.Data.Services
{
    public interface IDatabase
    {
        SQLiteConnection _connection { get; set; }
        string _databasePath { get; set; }
        string _EnvironmentPath { get; set; }

        void CloseDatabase();
        void Delete(object objectToDelete);
        void Delete<T>(int id);

        List<PersistentType> Get<PersistentType>(string queryStatement, params object[] queryParameter);
        IEnumerable<PersistentType> GetAll<PersistentType>() where PersistentType : class, new();

        void BeginTransaction();
        void Commit();

        void Rollback();
        void RunInTransaction(Action action);

        void Insert<T>(T objectToInsert);
        void InsertOrReplace<T>(T objectToInsert);
        void InsertOrUpdate<T>(T obj);
        void CreateTable<T>();
        void DropTable<T>();
        void Update<T>(T objectToUpdate);

        void Execute(string query, params object[] args);

        T GetSingleItem<T>(Func<T, bool> condition) where T : class, new();
        IEnumerable<T> GetItems<T>(Func<T, bool> condition) where T : class, new();
        int InsertItems<T>(IEnumerable<T> items);
        int InsertOrReplaceItems<T>(IEnumerable<T> items);
        int UpdateItems<T>(IEnumerable<T> models);

        Task<List<PersistentType>> GetAsync<PersistentType>(string query);
        ScalarType GetScalar<ScalarType>(string query) where ScalarType : new();

        Task<ScalarType> GetScalarAsync<ScalarType>(string query) where ScalarType : new();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
