using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Data.Interface
{
    public interface IContact
    {
        string Contact_ID { get; set; }
        string User_ID { get; set; }

        string Address_ID_Ref { get; set; }

        string Salutation { get; set; }
        string SiteUser_DisplayName { get; set; }
        string First_Name { get; set; }
        string Last_Name { get; set; }

        string Mobile { get; set; }
        string Home { get; set; }
        string Work { get; set; }
        string Email { get; set; }

        DateTime Sys_Transaction { get; set; }
        DateTime Sys_Creation { get; set; }
    }
}
