using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

using Cross.DataVault.Contracts.Data;

namespace DataVaultService.AccountManagement
{
    public class AccountManagementOrc : Cross.DataVault.Contracts.Services.IAccountManagement, IDisposable
    {
        AccountManagementBL _helper;

        //Initialization
        public AccountManagementOrc()
        {
            _helper = new AccountManagementBL();
        }

        public bool ServiceAvailable() { return true; }

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

        public IdentityPacket Delete_AccountForUserID(int id)
        {
            throw new NotImplementedException();
        }

        public IdentityPacket Delete_AccountsForUserIDs(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public IdentityPacket Disable_AccountsForUserID(int id)
        {
            throw new NotImplementedException();
        }

        public IdentityPacket Disable_AccountsForUserIDs(List<int> ids)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _helper = null;
        }

        public IdentityPacket Generate_AccountForCredentials(string username, string password)
        {
            IdentityPacket response = new IdentityPacket();
            //Validation
            return response = _helper.Generate_AccountForCredentials(username, password);
        }


        public IdentityPacket Generate_AccountForEmail(string email, string password)
        {
            throw new NotImplementedException();
        }

        public IdentityPacket Generate_AccountForUser(Account obj)
        {
            //Validation
            IdentityPacket response = new IdentityPacket();

            //Validation
            if (obj == null)
                throw new FaultException("Account is not valid and cannot be null", new FaultCode("E000"));
            if (string.IsNullOrWhiteSpace(obj.Email))
                throw new FaultException("Email is not valid", new FaultCode("E001"));
            if (string.IsNullOrWhiteSpace(obj.Username))
                throw new FaultException("Username is not valid", new FaultCode("E002"));
            if (string.IsNullOrWhiteSpace(obj.First_Name))
                throw new FaultException("First name is not valid");
            if (string.IsNullOrWhiteSpace(obj.Last_Name))
                throw new FaultException("Last name is not valid");

            obj.Display_Name = $"{obj.First_Name} {obj.Last_Name}";

            return response = _helper.Generate_SingleAccountForUser(obj);
        }

        public IdentityPacket Generate_AccountsForUsers(List<Account> objs)
        {
            throw new NotImplementedException();
        }
    }
}