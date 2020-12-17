using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

using Cross.DataVault.Server.DataAccess;
using Cross.DataVault.Contracts.Data;
using Cross.DataVault.AccountManagement.Mapper;
using LOC_MAPPER = Cross.DataVault.AccountManagement.Mapper;

namespace DataVaultService.AccountManagement
{
    public class AccountManagementBL
    {
        //Generate accounts for a single user
        public IdentityPacket Generate_SingleAccountForUser(Account user)
        {
            IdentityPacket response = new IdentityPacket();

            try
            {
                //Add account
                Account_Manager.Add_AccountToStore(user);
            }
            catch (Exception ex)
            {
                string Message = string.Empty;
                string StackTrace = string.Empty;

                if (ex.InnerException != null)
                {
                    Message = ex.InnerException.Message;
                    StackTrace = ex.InnerException.StackTrace;
                }
                else
                {
                    Message = ex.Message;
                    StackTrace = ex.StackTrace;
                }

                response.Errors.Add(String.Format("Failure to add account for account with Email: {0}. \n Diagnostics: {1} \n {2}", user.Email, Message, StackTrace));
                response.HasError = true;
            }
            finally
            {
                //Dispose of any objects here
            }

            return response;
        }

        //Generate accounts for a single user
        public IdentityPacket Generate_AccountForCredentials(string username, string password)
        {
            IdentityPacket response = new IdentityPacket();

            try
            {
                 response.SiteUser = Account_Manager.Get_AccountFromStore(username, password);
            }
            catch (Exception ex)
            {
                string Message = string.Empty;
                string StackTrace = string.Empty;

                if (ex.InnerException != null)
                {
                    Message = ex.InnerException.Message;
                    StackTrace = ex.InnerException.StackTrace;
                }
                else
                {
                    Message = ex.Message;
                    StackTrace = ex.StackTrace;
                }

                response.Errors.Add(String.Format("Cannot find the account specified"));
                response.HasError = true;
            }
            finally
            {
                //Dispose of any objects here
               
            }

            return response;
        }
    }
}