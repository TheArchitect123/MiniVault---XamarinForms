using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Contacts;

using Caliburn.Micro;

//Services
using Cross.DataVault.Services.DependencyServices;
using Cross.DataVault.Services.Managers;
//Data
using Cross.DataVault.Data.Interface;
using Cross.DataVault.Data;

namespace Cross.DataVault.iOS.Services
{
    public class ContactStore : IContactStore
    {
        public List<Person> Get_ContactsFromStore<Person>() where Person : IContact
        {
            List<Person> Contacts = new List<Person>();
        
            CNContactStore contacts = new CNContactStore();
            NSError error;
            contacts.RequestAccess(CNEntityType.Contacts, (access, issue) =>
            {
                if (issue != null)
                {
                    if (access)
                    {
                        var curr = contacts.GetUnifiedContacts(null, new NSString[] { }, out error);

                        if (curr.Length != 0)
                        {
                            Contact obj = new Contact();
                            foreach (var item in curr)
                            {
                                obj.First_Name = item.NamePrefix;
                                obj.Last_Name = item.NameSuffix;
                                obj.SiteUser_DisplayName = item.GivenName;
                                obj.Contact_ID = IoC.Get<IContactManager>().Get_NewContactID();

                                if (item.EmailAddresses.Length != 0)
                                    obj.Email = item.EmailAddresses[0].Value;

                                if (item.PhoneNumbers.Length != 0)
                                    obj.Mobile = item.PhoneNumbers[0].Value.StringValue;

                                Contacts.Add((Person)Convert.ChangeType(obj, typeof(Person)));
                            }
                        }
                    }
                }
            });

            if (Contacts.Count != 0)
                return Contacts;
            else
                return null;
        }
    }
}