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
    public class Photos_Manager
    {
        #region DTO
        public static Photos CopyFromDTO(core_photo obj)
        {
            Photos curr = new Photos();

            if (obj.photo != null)
                curr.Photo = obj.photo.ToArray();

            curr.Photo_ID = obj.photo_id;
            curr.User_ID = obj.id_user;

            curr.Photo_MIME = obj.photo_mime;

            if (obj.sys_creation.HasValue)
                curr.Time_OfCreation = obj.sys_creation.Value;

            return curr;
        }

        public static core_photo CopyToDTO(Photos obj)
        {
            core_photo curr = new core_photo();

            if (obj.Photo != null)
                curr.photo = obj.Photo.ToArray();

            curr.photo_id = Guid.NewGuid().ToString();
            curr.id_user = obj.User_ID;

            curr.photo_mime = obj.Photo_MIME;

            curr.sys_creation = DateTime.Now;

            return curr;
        }

        #endregion


        #region SET
        public static string AddPhoto(Photos photo)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var curr = CopyToDTO(photo);
                context.core_photos.InsertOnSubmit(curr);
                context.SubmitChanges();

                return curr.photo_id;
            }
        }

        public static void AddPhotos_ByCollection(List<Photos> musics)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                musics.ForEach(w => { context.core_photos.InsertOnSubmit(CopyToDTO(w)); });
                context.SubmitChanges();
            }
        }
        #endregion

        #region Delete
        public static void Remove_PhotoByID(string id, string user_id)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var curr = context.core_photos.FirstOrDefault(w => w.photo_id == id && w.id_user == user_id);
                if (curr != null)
                {
                    context.core_photos.DeleteOnSubmit(curr);
                    context.SubmitChanges();
                }
                else
                    throw new ArgumentNullException("Photo cannot be found on the server");
            }
        }

        public static void Remove_PhotosByIDs(List<string> ids)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var curr = context.core_photos.Where(w => ids.Contains(w.photo_id)).ToList();
                if (curr != null)
                {
                    context.core_photos.DeleteAllOnSubmit(curr);
                    context.SubmitChanges();
                }
                else
                    throw new ArgumentNullException("Photo cannot be found on the server");
            }
        }
        #endregion

        #region GET

        //Single Methods
        public static Photos Get_PhotoByID(string id)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var obj = (from photo in context.core_photos
                           where
                           photo.photo_id == id
                           select photo).SingleOrDefault();
                if (obj != null)
                    return CopyFromDTO(obj);
                else
                    return null;
            }
        }

        //Collection Methods
        public static List<Photos> Get_PhotosByUserID(string id)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var obj = (from photo in context.core_photos
                           where
                           photo.id_user == id
                           select photo).ToList().ConvertAll(w => CopyFromDTO(w));

                if (obj != null)
                    return obj;
                else
                    return null;
            }
        }

        public static List<Photos> Get_PhotosByIDs(List<string> ids)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var obj = (from photo in context.core_photos
                           where
                           ids.Contains(photo.photo_id)
                           select photo).ToList().ConvertAll(w => CopyFromDTO(w));

                if (obj != null)
                    return obj;
                else
                    return null;
            }
        }


        #endregion
    }
}
