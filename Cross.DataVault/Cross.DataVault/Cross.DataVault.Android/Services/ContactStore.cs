using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Provider;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ACC = Android.Accounts;

using Caliburn.Micro;
//Data
using CORE = Cross.DataVault.Data;

using Cross.DataVault.Data.Interface;
using Cross.DataVault.Services.Managers;
using Cross.DataVault.Services.DependencyServices;

using Plugin.CurrentActivity;

namespace Cross.DataVault.Android.Services
{
    public class ContactStore : IContactStore
    {
        public List<Person> Get_ContactsFromStore<Person>() where Person : IContact
        {
            List<CORE.Contact> Contacts = new List<CORE.Contact>();

            ContentResolver resolver = CrossCurrentActivity.Current.Activity.ContentResolver;
            var contactLibrary_Path = ContactsContract.Contacts.ContentUri;
            var mobileContacts_Path = ContactsContract.CommonDataKinds.Phone.ContentUri;

            //Query the collection of music in the store and add them to the collection
            CORE.Contact obj = new CORE.Contact();

            var contactCursor = resolver.Query(contactLibrary_Path, null, null, null, null);
            if (contactCursor.MoveToFirst())
            {
                do
                {
                    try
                    {
                        obj.Mobile = contactCursor.GetString(contactCursor.GetColumnIndex(ContactsContract.PhoneLookupColumns.Number));
                        obj.Email = contactCursor.GetString(contactCursor.GetColumnIndex(ContactsContract.CommonDataKinds.Email.DisplayName));

                        obj.SiteUser_DisplayName = contactCursor.GetString(contactCursor.GetColumnIndex(ContactsContract.ContactsColumns.DisplayName));
                        obj.Contact_ID = IoC.Get<IContactManager>().Get_NewContactID();
                        obj.Avatar_FilePath = contactCursor.GetString(contactCursor.GetColumnIndex(ContactsContract.ContactsColumns.PhotoUri));
                        obj.Avatar = contactCursor.GetBlob(contactCursor.GetColumnIndex(ContactsContract.ContactsColumns.PhotoUri));
                        
                    }
                    catch { }

                } while (contactCursor.MoveToNext());

                var accounts = ACC.AccountManager.Get(CrossCurrentActivity.Current.Activity).GetAccounts().ToList();
                if (accounts.Count != 0)
                {
                    accounts.ForEach(w =>
                    {
                        
                    });

                    //Close the cursor to dispose of any resources
                


                    Contacts.Add(obj);
                }

                contactCursor.Close();
            }

            if (Contacts.Count != 0)
                return (List<Person>)Convert.ChangeType(Contacts, typeof(List<Person>));
            else
                return null;
        }
    }
}