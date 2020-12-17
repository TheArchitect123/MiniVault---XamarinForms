using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Data.Interface
{
    public interface IPDF
    {
        string Contact_ID_Ref { get; set; }

        int FileType { get; set; }
        byte[] Content { get; set; }
        string MIME { get; set; }

        DateTime Sys_Transaction { get; set; }
        DateTime Sys_Creation { get; set; }
    }
}
