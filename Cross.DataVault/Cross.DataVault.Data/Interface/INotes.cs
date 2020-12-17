using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Data.Interface
{
    public interface INotes
    {
        string Contact_ID_Ref { get; set; }

        string Description { get; set; }
        string Subject { get; set; }

        bool Flag_Notification { get; set; } //Whether the user requires raising a notification after this

        DateTime Sys_Transaction { get; set; }
        DateTime Sys_Creation { get; set; }
    }
}
