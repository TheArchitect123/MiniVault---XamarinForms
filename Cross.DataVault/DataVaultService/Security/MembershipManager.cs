using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Security;
using System.ServiceModel;

//Data Contracts
using Cross.DataVault.Contracts.Data;

namespace DataVaultService.Security
{
    public class MembershipManager
    {
        public static Account Get_SiteUser_ViaUsername(string username)
        {
            Account obj = new Account();
            var SiteUser = Membership.GetUser(username);

            if (SiteUser != null)
            {
                obj.Email = SiteUser.Email;
                obj.Username = SiteUser.UserName;
            }
            else
                throw new MemberAccessException("No site user exists. Please generate an account");

            return obj;
        }

        public static Account Get_SiteUser_ViaEmail(string email)
        {
            Account obj = new Account();
            var SiteUser = Membership.FindUsersByEmail(email);

            if (SiteUser != null)
            {
                if (SiteUser.Count != 0)
                {
                    obj.Email = SiteUser[email].Email;
                    obj.Username = SiteUser[email].UserName;
                }
            }
            else
                throw new MemberAccessException("No site user exists. Please generate an account");

            return obj;
        }

        //Validation
        public static bool Authenticate(string username, string password)
        {
            if (!Membership.ValidateUser(username, password))
                throw new MemberAccessException("Authentication failure. You account cannot be found on our database. Please register an account first");

            return true;
        }
    }
}