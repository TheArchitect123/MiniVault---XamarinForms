using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cross.DataVault.Data.Interface;

namespace Cross.DataVault.Services.Managers
{
    public interface IPasswordManager
    {
        //ADD
        void AddPassword<T>(T obj) where T :  IPasswords;
        void AddPasswords<T>(List<T> obj) where T : IPasswords;

        //Update
        void UpdatePassword<T>(T obj) where T : IPasswords;
        void UpdatePasswords<T>(List<T> obj) where T : IPasswords;

        //READ
        string Get_NewPasswordID();
        Password Get_PasswordByID<Password>(string id) where Password : IPasswords;
        List<Password> Get_PasswordByContactID<Password>(string id) where Password : IPasswords;

        //DELETE 
        void Delete_PasswordById(string id);
        void Delete_PasswordsByIds(List<string> ids);
        void Delete_AllPasswords();
        void Delete_AllPasswordsByContactID(string id);
    }
}
