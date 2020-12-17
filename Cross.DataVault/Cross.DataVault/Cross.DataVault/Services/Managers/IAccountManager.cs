using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cross.DataVault.Data;
using Cross.DataVault.Data.Interface;

namespace Cross.DataVault.Services.Managers
{
    public interface IAccountManager
    {
        //ADD 
        void AddAccount_ByHashedPassword(Account curr);
        
        //Update
        void ChangePassword_ByContactID(string password);
        void Update_AccountGuidByUsername(string username, string contact_id);

        //REMOVE
        void RemoveAccount_ByContactID(string id);

        //READ
        string Get_AccountID();
        Store GetSiteUser_ByID<Store>(string id) where Store : IAccount;
        Store GetSiteUser_ByUsername<Store>(string username) where Store : IAccount;
        DateTime GetSiteUser_LastLogInByID(string id);
        

        //Security
        bool AuthenticateSiteUser_ByCredentials(string username, string password);
        bool Encrypt(); // Turns on data encryption 
        bool Encrypt_WhenOff(bool obj); // Turn on data encryption when device is off
        bool Encrypt_TurnOff(); //Turns off encryption, these usually happens when the user logs back in
    }
}
