using System;
using Caliburn.Micro;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cross.DataVault.Data;
using Cross.DataVault.Data.Services;
using Cross.DataVault.Data.Interface;

namespace Cross.DataVault.Services.Managers
{
    public class AccountManager : IAccountManager
    {
        //Access Handler - Used for accessing data of the database
        private IDatabase AccessHandler
        {
            get { return IoC.Get<IDatabase>(); }
        }

        #region Operations
        void IAccountManager.AddAccount_ByHashedPassword(Account curr)
        {
            //Hash Password here
            if (curr == null)
                throw new ArgumentNullException("Account cannot be null. Please contact site administrator for assistance");

            if (AccessHandler != null)
            {
                var StoreResult = AccessHandler.Get<Account>("SELECT * FROM Account");

                if (StoreResult.Count(w => w.Password == curr.Password && w.Username.Equals(curr.Username, StringComparison.OrdinalIgnoreCase)) == 0)
                    AccessHandler.Insert(curr);
                else
                    throw new InvalidOperationException("This account already exists. Please try another username and password");
            }
            else
                throw new ArgumentNullException("Dependency cannot be null. Please review the iOC container and contact site administrator for assistance");
        }

        public bool AuthenticateSiteUser_ByCredentials(string username, string password)
        {
            //Check against the local store before checking against the server member store. If the account does not exist, then prompt the user to generate an account

            //Hash the password first, then compare it against the credential store via one way encryption
            var StoreResult = AccessHandler.Get<Account>("SELECT * FROM Account");

            if (StoreResult.Count(w => w.Password == password && w.Username.Equals(username, StringComparison.OrdinalIgnoreCase)) == 0)
                return false;
            else
                return true;
        }

        public void ChangePassword_ByContactID(string password)
        {

        }

        public string Get_AccountID()
        {
            return Guid.NewGuid().ToString();
        }

        public bool Encrypt()
        {
            //Encrypt all data on the device
            return true;
        }

        public bool Encrypt_TurnOff()
        {
            //Decrypt all data on the device
            return true;
        }

        public bool Encrypt_WhenOff(bool obj)
        {
            //Encrypt when device is off
            return true;
        }

        public string GetSiteUserID_ByMax()
        {
            return Guid.NewGuid().ToString();
        }

        public Store GetSiteUser_ByID<Store>(string id) where Store : IAccount
        {
            var SiteUser = AccessHandler.Get<Account>($"SELECT * FROM Account WHERE Contact_ID_Ref = '{id}'").SingleOrDefault();

            if (SiteUser != null)
                return (Store)Convert.ChangeType(SiteUser, typeof(Store));
            else
                throw new ArgumentNullException("Site User cannot be found. Please contact site administrator for assistance");

        }


        Store IAccountManager.GetSiteUser_ByUsername<Store>(string username)
        {
            //Username must ignore lower case
            var SiteUser = AccessHandler.Get<Account>($"SELECT * FROM Account WHERE Username = '{username}'").SingleOrDefault();

            if (SiteUser != null)
                return (Store)Convert.ChangeType(SiteUser, typeof(Store));
            else
                throw new ArgumentNullException("Site User cannot be found. Please contact site administrator for assistance");
        }

        public DateTime GetSiteUser_LastLogInByID(string id)
        {
            return AccessHandler.Get<Account>($"SELECT * FROM Account WHERE Contact_ID_Ref = '{id}'").SingleOrDefault().RecentLogin;
        }

        public void RemoveAccount_ByContactID(string id)
        {
            var SiteUser = AccessHandler.Get<Account>($"SELECT * FROM Account WHERE Contact_ID_Ref = '{id}'").SingleOrDefault();

            if (SiteUser != null)
                AccessHandler.Delete(SiteUser);
            else
                throw new ArgumentNullException("Site User cannot be found. Please contact site administrator for assistance");
        }

        public void Update_AccountGuidByUsername(string username, string contact_id)
        {
            var SiteUser = AccessHandler.Get<Account>($"SELECT * FROM Account WHERE Username = '{username}'").SingleOrDefault();
            SiteUser.Contact_ID_Ref = contact_id;

            if (SiteUser != null)
                AccessHandler.Update(SiteUser);
            else
                throw new ArgumentNullException("Site User cannot be found. Please contact site administrator for assistance");
        }


        #endregion
    }
}
