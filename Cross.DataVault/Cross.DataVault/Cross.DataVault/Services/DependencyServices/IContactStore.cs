using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CORE = Cross.DataVault.Data.Interface;
using SERV_CORE = Cross.DataVault.Data.Services;

namespace Cross.DataVault.Services.DependencyServices
{
    public interface IContactStore 
    {
        //Reads all contacts from the data store
        List<Person> Get_ContactsFromStore<Person>() where Person : CORE.IContact;
    }
}
