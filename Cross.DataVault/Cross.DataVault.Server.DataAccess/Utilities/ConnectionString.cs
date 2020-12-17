using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace Cross.DataVault.Server.DataAccess.Utilities
{
    public static class ConnectionString
    {
        public static string DataVault_Test = ConfigurationManager.ConnectionStrings["MiniVaultConnectionString"].ConnectionString;
        
    }
}
