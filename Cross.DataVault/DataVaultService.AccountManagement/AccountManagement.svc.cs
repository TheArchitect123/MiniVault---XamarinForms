using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Cross.DataVault.Server.DataAccess;
using Cross.DataVault.Contracts.Data;
using Cross.DataVault.AccountManagement.Mapper;

namespace DataVaultService.AccountManagement
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AccountManagement" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AccountManagement.svc or AccountManagement.svc.cs at the Solution Explorer and start debugging.
    public class AccountManagement : Cross.DataVault.Contracts.Services.IAccountManagement
    {
        public bool ServiceAvailable() { return true; }

        #region Change
        public IdentityPacket Change_EmailForUserID(int id)
        {
            throw new NotImplementedException();
        }

        public IdentityPacket Change_EmailForUserIDs(List<int> id)
        {
            throw new NotImplementedException();
        }

        public IdentityPacket Change_PasswordForUserID(int id)
        {
            throw new NotImplementedException();
        }

        public IdentityPacket Change_PasswordForUserIDs(List<int> id)
        {
            throw new NotImplementedException();
        }

        public IdentityPacket Change_UsernameForUserID(int id)
        {
            throw new NotImplementedException();
        }

        public IdentityPacket Change_UsernameForUserIDs(List<int> id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Delete
        public IdentityPacket Delete_AccountForUserID(int id)
        {
            throw new NotImplementedException();
        }

        public IdentityPacket Delete_AccountsForUserIDs(List<int> ids)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Disable Account
        public IdentityPacket Disable_AccountsForUserID(int id)
        {
            throw new NotImplementedException();
        }

        public IdentityPacket Disable_AccountsForUserIDs(List<int> ids)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Create Account
        public IdentityPacket Generate_AccountForCredentials(string username, string password)
        {
            //Authenticates if user exists. This gets called when the user logs into the device for the first time and retrieves the site user account details
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new AccountManagementOrc())
                    packet = orc.Generate_AccountForCredentials(username, password);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);
            }

            return packet;
        }

        public IdentityPacket Generate_AccountForEmail(string email, string password)
        {
            throw new NotImplementedException();
        }

        public IdentityPacket Generate_AccountForUser(Account obj)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new AccountManagementOrc())
                    packet = orc.Generate_AccountForUser(obj);
            }
            catch (Exception ex)
            {
                string Message = "";
                string StackTrace = "";

                if(ex.InnerException != null)
                {
                    Message = ex.InnerException.Message;
                    StackTrace = ex.InnerException.StackTrace;
                }
                else
                {
                    Message = ex.Message;
                    StackTrace = ex.StackTrace;
                }

                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.Errors.Add(Message);
            }

            return packet;
        }

        public IdentityPacket Generate_AccountsForUsers(List<Account> objs)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new AccountManagementOrc())
                    packet = orc.Generate_AccountsForUsers(objs);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);
            }

            return packet;
        }
        #endregion
    }
}
