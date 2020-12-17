using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Data.Interface
{
    public interface IAccount
    {
        string Username { get; set; }
        string Password { get; set; }

        string Contact_ID_Ref { get; set; }
        string Address_ID_Ref { get; set; }

        string SiteUser_DisplayName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }

        string Mobile { get; set; }
        string Home { get; set; }
        string Work { get; set; }
        string Email { get; set; }

        string Avatar_FilePath { get; set; }
        byte[] Avatar { get; set; } //Local Avatar Byte collection

        DateTime Sys_Transaction { get; set; }
        DateTime Sys_Creation { get; set; }
    }
}
