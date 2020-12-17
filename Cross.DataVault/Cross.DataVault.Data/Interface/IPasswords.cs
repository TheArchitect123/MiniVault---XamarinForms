using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Data.Interface
{
    public interface IPasswords
    {
        string Contact_ID_Ref { get; set; }
        string Password_ID { get; set; }

        string Password { get; set; } //If the user disables password hashing
        string HashedPassword { get; set; }

        string Description { get; set; }
        string Subject { get; set; }

        bool Flag_Hashed { get; set; }

        DateTime Sys_Transaction { get; set; }
        DateTime Sys_Creation { get; set; }
    }
}
