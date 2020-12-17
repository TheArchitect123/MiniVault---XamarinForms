using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cross.DataVault.Data.Server;
using CONT = Cross.DataVault.Contracts.Data;
using Cross.DataVault.Data;

namespace Cross.DataVault.AccountManagement.Mapper
{
    public static class LocalMapper
    {
        //Accounts
        public static CONT.Account MapAccount_FromServer(Account obj)
        {
            CONT.Account curr = new CONT.Account();

            if (obj.Avatar != null)
                curr.Avatar = obj.Avatar;

            curr.First_Name = obj.FirstName;
            curr.Last_Name = obj.LastName;
            curr.Display_Name = obj.SiteUser_DisplayName;

            curr.Mobile = obj.Mobile;
            curr.Work = obj.Work;
            curr.Home = obj.Home;
            curr.Email = obj.Email;

            curr.User_ID = obj.Contact_ID_Ref;

            return curr;
        }
    }
}
