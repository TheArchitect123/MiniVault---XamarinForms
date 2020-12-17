using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Services
using Cross.DataVault.Data.Services;
using Cross.DataVault.Data.Interface;

//Web
using Cross.DataVault.ServiceAccess.PCL.DataVaultCloudService;
using Cross.DataVault.ServiceAccess.PCL.AccountManagerService;


namespace Cross.DataVault.Helpers
{
    public class DataVaultDataService
    {
        private IDatabase _dbContext;

        public DataVaultDataService(IDatabase dbContext)
        {

        }

        public void AddNote(Notes obj)
        {
           

        }

    }
}
