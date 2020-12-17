using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cross.DataVault.Contracts.Data;
using Cross.DataVault.Data.Server;

//Utitilies
using Cross.DataVault.Server.DataAccess.Utilities;

namespace Cross.DataVault.Server.DataAccess
{
    public class Contacts_Manager
    {


        #region DTO
        public static Contacts CopyFromDTO(core_contact obj)
        {
            Contacts curr = new Contacts();

            curr.Address_ID_Ref = obj.address_id;
            curr.Contact_ID = obj.contact_id;
            curr.User_ID = obj.id_user;

            curr.Mobile = obj.mobile;
            curr.Home = obj.home;
            curr.Work = obj._work;
            curr.Email = obj.email;

            if (obj.avatar != null)
                curr.Avatar = obj.avatar.ToArray();

            curr.Salutation = obj.salutation;
            curr.First_Name = obj.first_name;
            curr.Last_Name = obj.last_name;
            curr.SiteUser_DisplayName = obj.display_name;

            if (string.IsNullOrWhiteSpace(curr.SiteUser_DisplayName))
                curr.SiteUser_DisplayName = $"{obj.first_name} {obj.last_name}";

            return curr;
        }

        public static core_contact CopyToDTO(Contacts contact)
        {
            core_contact obj = new core_contact();
            obj.avatar = contact.Avatar;

            obj.id_user = contact.User_ID;

            obj.display_name = contact.SiteUser_DisplayName;
            obj.first_name = contact.First_Name;
            obj.last_name = contact.Last_Name;

            obj.mobile = contact.Mobile;
            obj.home = contact.Home;
            obj._work = contact.Work;

            obj.salutation = contact.Salutation;

            obj.sys_creation = DateTime.Now;
            obj.sys_transaction = DateTime.Now;

            obj.contact_id = Guid.NewGuid().ToString();

            return obj;
        }

        #endregion


        #region SET
        public static string AddContact(Contacts contact)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var curr = CopyToDTO(contact);
                context.core_contacts.InsertOnSubmit(curr);
                context.SubmitChanges();

                return curr.id_user;
            }
        }

        public static void AddContacts_ByCollection(List<Contacts> contacts)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                contacts.ForEach(w => { context.core_contacts.InsertOnSubmit(CopyToDTO(w)); });
                context.SubmitChanges();
            }
        }
        #endregion

        #region DELETE
        public static void Remove_ContactByID(string id, string user_id)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var curr = context.core_contacts.FirstOrDefault(w => w.contact_id == id && w.id_user == user_id);
                if (curr != null)
                {
                    context.core_contacts.DeleteOnSubmit(curr);
                    context.SubmitChanges();
                }
                else
                    throw new ArgumentNullException("Core Contact cannot be found on the server");
            }
        }

        public static void Remove_Contacts_ByIDs(List<string> ids)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var curr = context.core_contacts.Where(w => ids.Contains(w.contact_id)).ToList();
                if (curr != null)
                {
                    context.core_contacts.DeleteAllOnSubmit(curr);
                    context.SubmitChanges();
                }
                else
                    throw new ArgumentNullException("Core Contacts cannot be found on the server");
            }
        }
        #endregion

        #region GET

        //Single Methods
        public static Contacts Get_ContactByID(string id)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var obj = (from contact in context.core_contacts
                           where
                           contact.contact_id == id
                           select contact).SingleOrDefault();
                if (obj != null)
                    return CopyFromDTO(obj);
                else
                    return null;
            }
        }

        //Collection Methods
        public static List<Contacts> Get_ContactsByUserID(string id)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var obj = (from contact in context.core_contacts
                           where
                           contact.id_user == id
                           select contact).ToList().ConvertAll(w => CopyFromDTO(w));

                if (obj != null)
                    return obj;
                else
                    return null;
            }
        }

        public static List<Contacts> Get_ContactsByIDs(List<string> ids)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var obj = (from contact in context.core_contacts
                           where
                           ids.Contains(contact.contact_id)
                           select contact).ToList().ConvertAll(w => CopyFromDTO(w));

                if (obj != null)
                    return obj;
                else
                    return null;
            }
        }


        #endregion
    }
}
