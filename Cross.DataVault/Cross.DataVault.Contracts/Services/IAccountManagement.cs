using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Services;

using Cross.DataVault.Contracts.Data;

namespace Cross.DataVault.Contracts.Services
{
    [ServiceContract]
    public interface IAccountManagement
    {
        [OperationContract]
        bool ServiceAvailable();

        //WRITE
        [OperationContract]
        IdentityPacket Generate_AccountForCredentials(string username, string password);

        [OperationContract]
        IdentityPacket Generate_AccountForEmail(string email, string password);

        [OperationContract]
        IdentityPacket Generate_AccountForUser(Account obj);

        [OperationContract]
        IdentityPacket Generate_AccountsForUsers(List<Account> objs);


        //DELETE
        [OperationContract]
        IdentityPacket Delete_AccountForUserID(int id);

        [OperationContract]
        IdentityPacket Delete_AccountsForUserIDs(List<int> ids);

        [OperationContract]
        IdentityPacket Disable_AccountsForUserID(int id);

        [OperationContract]
        IdentityPacket Disable_AccountsForUserIDs(List<int> ids);


        //Change Security -- Emails, Passwords, Usernames
        [OperationContract]
        IdentityPacket Change_PasswordForUserID(int id);

        [OperationContract]
        IdentityPacket Change_EmailForUserID(int id);

        [OperationContract]
        IdentityPacket Change_UsernameForUserID(int id);

        [OperationContract]
        IdentityPacket Change_PasswordForUserIDs(List<int> id);

        [OperationContract]
        IdentityPacket Change_EmailForUserIDs(List<int> id);

        [OperationContract]
        IdentityPacket Change_UsernameForUserIDs(List<int> id);
    }
}
