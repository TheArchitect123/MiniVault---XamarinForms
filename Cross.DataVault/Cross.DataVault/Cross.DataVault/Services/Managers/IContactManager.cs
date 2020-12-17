using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CORE = Cross.DataVault.Data.Interface;

namespace Cross.DataVault.Services.Managers
{
    //Reads and writes to the contacts store for the current account
    public interface IContactManager
    {
        void AddContact_ByDetails<Person>(Person obj) where Person: CORE.IContact;
        void AddContacts_ByDetails<Person>(List<Person> obj) where Person : CORE.IContact;

        string Get_NewContactID();
        Person Get_Contact_ByID<Person>(string id) where Person : CORE.IContact;
        List<Person> Get_Contacts_ByUserID<Person>(string id) where Person : CORE.IContact;
        List<Person> Get_Contacts_ByTransaction<Person>(DateTime transaction) where Person : CORE.IContact;

        void ClearContacts(); // Clear all contacts for all site users
        void ClearContacts_ForUserID(string id);
        void RemoveContact_ByID(string id);
        void RemoveContact_ByCreation(DateTime creation);

    }
}
