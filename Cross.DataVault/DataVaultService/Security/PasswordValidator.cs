using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Security;
using System.IdentityModel.Selectors;

using DataVaultService.Security;

namespace DataVaultService.Security
{
    public class PasswordValidator : UserNamePasswordValidator
    {
        //Validates credentials passed -- via message security header on each call to the server
        public override void Validate(string userName, string password)
        {
            MembershipManager.Authenticate(userName, password);
        }
    }
}