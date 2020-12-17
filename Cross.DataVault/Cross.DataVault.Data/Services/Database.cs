using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;

using Cross.DataVault.Data;

namespace Cross.DataVault.Data.Services
{
    public class Database : IDatabase
    {
        public SQLiteConnection _connection { get; set; }
        public string _databasePath { get; set; }
        public string _EnvironmentPath { get; set; }

        public Database(string databasePath, string environmentPath, SQLiteConnection connection)
        {
            if (_connection == null)
                _connection = connection;
            if (string.IsNullOrWhiteSpace(_databasePath))
                _databasePath = databasePath;

            _EnvironmentPath = environmentPath;

            _connection.BusyTimeout = new TimeSpan(1, 0, 0);

            //Check if tables exist then create them if not
            //Parent Tables
            if (!_connection.GetTableInfo("Account").Any())
                _connection.CreateTable<Account>();
            if (!_connection.GetTableInfo("Address").Any())
                _connection.CreateTable<Address>();

            if (!_connection.GetTableInfo("Contact").Any())
                _connection.CreateTable<Contact>();
            if (!_connection.GetTableInfo("Document").Any())
                _connection.CreateTable<Document>();
            if (!_connection.GetTableInfo("Log").Any())
                _connection.CreateTable<Log>();
            if (!_connection.GetTableInfo("Music").Any())
                _connection.CreateTable<Music>();
            if (!_connection.GetTableInfo("Notes").Any())
                _connection.CreateTable<Notes>();

            if (!_connection.GetTableInfo("Passwords").Any())
                _connection.CreateTable<Passwords>();
            if (!_connection.GetTableInfo("PDF").Any())
                _connection.CreateTable<PDF>();
            if (!_connection.GetTableInfo("PhotoVideo").Any())
                _connection.CreateTable<PhotoVideo>();

            //Search 
            //if (!_connection.GetTableInfo("Search").Any())
            //    _connection.CreateTable<Search>();
        }


        public virtual void BeginTransaction()
        {
            _connection.BeginTransaction();
        }

        public virtual void CloseDatabase()
        {
            _connection.Close();
        }

        public virtual void Commit()
        {
            _connection.Commit();
        }

        public virtual void CreateTable<T>()
        {
            _connection.CreateTable<T>();
        }

        public virtual void Delete(object objectToDelete)
        {
            _connection.Delete(objectToDelete);
        }

        public virtual void Delete<T>(int id)
        {
            _connection.Delete<T>(id);
        }

        public virtual void DropTable<T>()
        {
            _connection.DropTable<T>();
        }

        public virtual void Execute(string query, params object[] args)
        {
            if (_connection != null)
                _connection.CreateCommand(query, args).ExecuteNonQuery();
        }

        public virtual List<PersistentType> Get<PersistentType>(string queryStatement, params object[] queryParameter)
        {
            if (_connection != null)
                return _connection.CreateCommand(queryStatement, queryParameter).ExecuteQuery<PersistentType>().ToList();

            return null;
        }

        public virtual IEnumerable<PersistentType> GetAll<PersistentType>(string query) where PersistentType : class, new()
        {
            if (_connection != null)
                return _connection.CreateCommand(query).ExecuteQuery<PersistentType>().AsEnumerable();

            return null;
        }

        public virtual Task<List<PersistentType>> GetAsync<PersistentType>(string query)
        {
            return _connection.CreateCommand(query).ExecuteScalar<Task<List<PersistentType>>>();
        }

        public virtual IEnumerable<T> GetItems<T>(Func<T, bool> condition) where T : class, new()
        {

            return null;
        }

        public virtual ScalarType GetScalar<ScalarType>(string query) where ScalarType : new()
        {
            return _connection.ExecuteScalar<ScalarType>(query);
        }

        public virtual Task<ScalarType> GetScalarAsync<ScalarType>(string query) where ScalarType : new()
        {
            return _connection.ExecuteScalar<Task<ScalarType>>(query);
        }

        public virtual T GetSingleItem<T>(Func<T, bool> condition) where T : class, new()
        {
            if (_connection != null)
                return _connection.Get<T>(condition);

            return null;
        }

        public virtual void Insert<T>(T objectToInsert)
        {
            _connection.Insert(objectToInsert);
        }

        public virtual int InsertItems<T>(IEnumerable<T> items)
        {
            _connection.InsertAll(items);

            return 0;
        }

        public virtual void InsertOrUpdate<T>(T obj)
        {
            _connection.InsertOrReplace(obj);
        }

        public virtual void Rollback()
        {
            _connection.Rollback();
        }

        public virtual void RunInTransaction(Action action)
        {
            _connection.RunInTransaction(() => { action.Invoke(); });
        }

        public virtual void SaveChanges()
        {
            _connection.Commit();
        }

        public virtual Task SaveChangesAsync()
        {
            return Task.Run(() => { _connection.Commit(); });
        }


        public virtual void Update<T>(T objectToUpdate)
        {
            _connection.Update(objectToUpdate);
        }

        public virtual int UpdateItems<T>(IEnumerable<T> models)
        {
            return _connection.UpdateAll(models);
        }

        IEnumerable<PersistentType> IDatabase.GetAll<PersistentType>()
        {
            return null;
        }

        public IEnumerable<PersistentType> GetAll<PersistentType>() where PersistentType : class, new()
        {
            throw new NotImplementedException();
        }

        public void InsertOrReplace<T>(T objectToInsert)
        {
            _connection.InsertOrReplace(objectToInsert);
        }

        public int InsertOrReplaceItems<T>(IEnumerable<T> items)
        {
            return _connection.InsertOrReplaceAll(items);
        }
    }
}
