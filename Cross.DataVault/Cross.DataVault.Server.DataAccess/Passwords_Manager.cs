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
    public class Passwords_Manager
    {
        #region DTO
        public static Passwords CopyFromDTO(core_password obj)
        {
            Passwords curr = new Passwords();
            curr.Password_Description = obj.password_description;
            curr.Password_Hashed = obj.password_hashed;

            if (obj.sys_creation.HasValue)
                curr.Time_OfCreation = obj.sys_creation.Value;

            curr.User_ID = obj.id_user;
            curr.Password_ID = obj.password_id;

            return curr;
        }

        public static core_password CopyToDTO(Passwords obj)
        {
            core_password curr = new core_password();
            curr.password_description = obj.Password_Description;
            curr.password_hashed = obj.Password_Hashed;

            curr.sys_creation = DateTime.Now;

            curr.id_user = obj.User_ID;
            curr.password_id = obj.Password_ID;

            return curr;
        }

        #endregion


        #region SET
        public static void AddPassword(Passwords password)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                context.core_passwords.InsertOnSubmit(CopyToDTO(password));
                context.SubmitChanges();
            }
        }

        public static void AddPassword_ByCollection(List<Passwords> passwords)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                passwords.ForEach(w => { context.core_passwords.InsertOnSubmit(CopyToDTO(w)); });
                context.SubmitChanges();
            }
        }
        #endregion

        #region Delete 
        public static void Delete_PasswordByID(string id, string user_id)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var curr = context.core_passwords.FirstOrDefault(w => w.password_id == id && w.id_user == user_id);
                if (curr != null)
                {
                    context.core_passwords.DeleteOnSubmit(curr);
                    context.SubmitChanges();
                }
                else
                    throw new ArgumentNullException($"Password cannot be found on the server via ID: {id}");
            }
        }

        public static void Delete_PasswordsByIDs(List<string> ids)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var curr = context.core_passwords.Where(w => ids.Contains(w.password_id)).ToList();
                if (curr.Count != 0)
                {
                    context.core_passwords.DeleteAllOnSubmit(curr);
                    context.SubmitChanges();
                }
                else
                    throw new ArgumentNullException($"Passwords cannot be found on the server");
            }
        }

        #endregion

        #region Update
        public static void UpdatePassword(Passwords password)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var curr = context.core_passwords.SingleOrDefault(w => w.password_id == password.Password_ID);
                if (curr != null)
                {
                    curr.password_hashed = password.Password_Hashed;
                    curr.password_description = password.Password_Description;
                }
                else
                    throw new ArgumentNullException("Cannot find the specified password");

                context.SubmitChanges();
            }
        }
        #endregion

        #region GET

        //Single Methods
        public static Passwords Get_PasswordByID(string id)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var obj = (from password in context.core_passwords
                           where
                           password.password_id == id
                           select password).SingleOrDefault();
                if (obj != null)
                    return CopyFromDTO(obj);
                else
                    return null;
            }
        }

        //Collection Methods
        public static List<Passwords> Get_PasswordsByUserID(string id)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var obj = (from password in context.core_passwords
                           where
                           password.id_user == id
                           select password).ToList().ConvertAll(w => CopyFromDTO(w));

                if (obj != null)
                    return obj;
                else
                    return null;
            }
        }

        public static List<Passwords> Get_PasswordsByIDs(List<string> ids)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var obj = (from password in context.core_passwords
                           where
                           ids.Contains(password.password_id)
                           select password).ToList().ConvertAll(w => CopyFromDTO(w));

                if (obj != null)
                    return obj;
                else
                    return null;
            }
        }


        #endregion
    }
}
