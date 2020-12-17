using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Caliburn.Micro;

using Cross.DataVault.Data;
using Cross.DataVault.Data.Services;
using Cross.DataVault.Data.Interface;


namespace Cross.DataVault.Services.Managers
{
    public class ContactManager : IContactManager
    {
        //Access Handler - Used for accessing data of the database
        private IDatabase AccessHandler
        {
            get { return IoC.Get<IDatabase>(); }
        }

        public void AddContact_ByDetails<Person>(Person obj) where Person : IContact
        {
            AccessHandler.Insert(obj);
        }

        public void AddContacts_ByDetails<Person>(List<Person> obj) where Person : IContact
        {
            AccessHandler.InsertItems(obj);
        }


        public string Get_NewContactID()
        {
            return Guid.NewGuid().ToString();
        }


        public void ClearContacts()
        {
            AccessHandler.Execute("DELETE FROM Contact", new object[] { });
        }

        public void ClearContacts_ForUserID(string id)
        {
            AccessHandler.Execute($"DELETE FROM Contact WHERE User_ID = '{id}'", new object[] { });
        }

        public List<Person> Get_Contacts_ByTransaction<Person>(DateTime transaction) where Person : IContact
        {
            return AccessHandler.Get<Person>($"SELECT * FROM Contact WHERE Sys_Transaction >= {transaction}", new object[] { });
        }

        public List<Person> Get_Contacts_ByUserID<Person>(string id) where Person : IContact
        {
            return AccessHandler.Get<Person>($"SELECT * FROM Contact WHERE User_ID = '{id}'", new object[] { });
        }

        public Person Get_Contact_ByID<Person>(string id) where Person : IContact
        {
            return AccessHandler.Get<Person>($"SELECT * FROM Contact WHERE Contact_ID = '{id}'", new object[] { }).Single();
        }

        public void RemoveContact_ByCreation(DateTime creation)
        {
            AccessHandler.Execute($"DELETE FROM Contact WHERE Sys_Creation = {creation}", new object[] { });
        }

        public void RemoveContact_ByID(string id)
        {
            AccessHandler.Execute($"DELETE FROM Contact WHERE Contact_ID = '{id}'", new object[] { });
        }
    }
}
