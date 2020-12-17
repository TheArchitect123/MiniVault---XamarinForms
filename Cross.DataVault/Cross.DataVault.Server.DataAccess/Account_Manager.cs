using System;
using System.Data.Linq.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Security;
using System.ServiceModel;
using System.Configuration;

using Cross.DataVault.Contracts.Data;
using Cross.DataVault.Data.Server;

//Utitilies
using Cross.DataVault.Server.DataAccess.Utilities;

namespace Cross.DataVault.Server.DataAccess
{
    public static class Account_Manager
    {
        public static Account CopyFromDTO(account obj)
        {
            Account curr = new Account();

            if (obj.avatar != null)
                curr.Avatar = obj.avatar.ToArray();

            curr.First_Name = obj.first_name;
            curr.Last_Name = obj.last_name;
            curr.Display_Name = obj.display_name;

            curr.Mobile = obj.mobile;
            curr.Work = obj._work;
            curr.Home = obj.home;
            curr.Email = obj.email;

            curr.User_ID = obj.id_User;

            return curr;
        }

        public static account CopyToDTO(Account obj)
        {
            var curr = new account();
            curr.avatar = obj.Avatar;

            curr.display_name = obj.Display_Name;
            curr.first_name = obj.First_Name;
            curr.last_name = obj.Last_Name;

            curr.mobile = obj.Mobile;
            curr.home = obj.Home;
            curr._work = obj.Work;
            curr.email = obj.Email;

            curr.sys_creation = DateTime.Now;
            curr.sys_transaction = DateTime.Now;

            curr.id_User = Guid.NewGuid().ToString();

            return curr;
        }

        #region Set
        public static string Add_AccountToStore(Account obj)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var account = (from item in context.accounts

                               where
                               item.email == obj.Username
                               select obj).SingleOrDefault();

                if (account == null)
                {
                    var curr = CopyToDTO(obj);
                    context.accounts.InsertOnSubmit(curr);
                    context.SubmitChanges();

                    //Generate ASP Membership
                    Membership.CreateUser(obj.Username, obj.Password, obj.Email);
                    return curr.id_User;
                }
                else
                    throw new FaultException("There is an account already with this email address. Please try again");
            }
        }
        #endregion

        #region Get
        public static Account Get_AccountFromStore(string username, string password)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var account = (from obj in context.accounts

                               where
                               obj.email == username
                               select obj).SingleOrDefault();

                if (account != null)
                {
                    if (Membership.ValidateUser(username, password))
                        return CopyFromDTO(account);
                    else
                        throw new FaultException("Invalid username or password. Please try signing in again");
                }
                else
                    throw new FaultException("There is no account found with these credentials. Please try again");
            }
        }
        #endregion
    }
}
