using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;

using Cross.DataVault.Data.Interface;
using Cross.DataVault.Data.Services;

//Tables
using Cross.DataVault.Data;

namespace Cross.DataVault.Services.Managers
{
    public class PasswordManager : IPasswordManager
    {
        public IDatabase _Database
        {
            get
            {
                return IoC.Get<IDatabase>();
            }
        }

        public void AddPassword<T>(T obj) where T : IPasswords
        {
            _Database.Insert(obj);
        }

        public void AddPasswords<T>(List<T> obj) where T : IPasswords
        {
            _Database.InsertItems(obj);
        }

        public void UpdatePassword<T>(T obj) where T : IPasswords
        {
            _Database.Update(obj);
        }
        public void UpdatePasswords<T>(List<T> obj) where T : IPasswords
        {
            _Database.UpdateItems(obj);
        }

        public void Delete_AllPasswords()
        {
            _Database.Execute("DELETE FROM Passwords", new object[] { });
        }

        public void Delete_PasswordById(string id)
        {
            _Database.Execute($"DELETE FROM Passwords WHERE Password_ID = '{id}'", new object[] { });
        }

        public void Delete_PasswordsByIds(List<string> ids)
        {
            foreach (var id in ids)
                _Database.Execute($"DELETE FROM Passwords WHERE Password_ID = '{id}'", new object[] { });
        }

        public void Delete_AllPasswordsByContactID(string id)
        {
            _Database.Execute($"DELETE FROM Passwords WHERE Contact_ID_Ref = '{id}'", new object[] { });
        }

        public List<Password> Get_PasswordByContactID<Password>(string id) where Password : IPasswords
        {
            return _Database.Get<Password>($"SELECT * FROM Passwords WHERE Contact_ID_Ref = '{id}'", new object[] { });
        }

        public Password Get_PasswordByID<Password>(string id) where Password : IPasswords
        {
            return _Database.Get<Password>($"SELECT * FROM Passwords WHERE Password_ID = '{id}'", new object[] { }).SingleOrDefault();
        }

        public string Get_NewPasswordID()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
