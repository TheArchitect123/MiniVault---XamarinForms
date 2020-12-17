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
    public class PhotoVideoManager : IPhotoVideoManager
    {
        private IDatabase AccessHandler
        {
            get { return IoC.Get<IDatabase>(); }
        }

        public string GetContentID_ByMax()
        {
            return Guid.NewGuid().ToString();
        }

        public void AddPhoto<Photo>(Photo obj) where Photo : IPhotoVideo
        {
            AccessHandler.Insert(obj);
        }

        public void AddPhoto_ByCollections<Photo>(List<Photo> items) where Photo : IPhotoVideo
        {
            AccessHandler.InsertItems(items);
        }

        public void AddVideo<Video>(Video obj) where Video : IPhotoVideo
        {
            try
            {
                if (AccessHandler.Get<Video>($"SELECT * FROM PhotoVideo WHERE Content_ID = '{obj.Content_ID}'", new object[] { }).SingleOrDefault() == null)
                    AccessHandler.Insert(obj);
            }
            catch { }
        }

        public void AddVideo_ByCollections<Video>(List<Video> items) where Video : IPhotoVideo
        {
            try
            {
                items.ForEach(w =>
                {
                    if (AccessHandler.Get<Video>($"SELECT * FROM PhotoVideo WHERE Content_ID = '{w.Content_ID}'", new object[] { }).SingleOrDefault() == null)
                        AccessHandler.Insert(w);
                });
            }
            catch { }
        }

        public void ClearPhotos()
        {
            AccessHandler.Execute($"DELETE FROM PhotoVideo", new object[] { });
        }

        public void Delete_PhotoByID(string id)
        {
            AccessHandler.Execute($"DELETE FROM PhotoVideo WHERE Content_ID = '{id}'", new object[] { });
        }

        public void Delete_PhotosByUserId(string id)
        {
            AccessHandler.Execute($"DELETE FROM PhotoVideo WHERE User_ID = '{id}'", new object[] { });
        }

        public List<Photo> GetPhotos_ByPhotoIDs<Photo>(List<string> ids) where Photo : IPhotoVideo
        {
            try
            {
                return AccessHandler.Get<Photo>($"SELECT * FROM PhotoVideo WHERE Content_ID IN {string.Join("', '", ids)}", new object[] { });
            }
            catch { return new List<Photo>(); }
        }

        public List<Photo> GetPhotos_ByUserID<Photo>(string id) where Photo : IPhotoVideo
        {
            try
            {
                return AccessHandler.Get<Photo>($"SELECT * FROM PhotoVideo WHERE User_ID = '{id}'", new object[] { }).ToList();
            }
            catch
            {
                return new List<Photo>();
            }
        }

        public Photo GetPhoto_ByPhotoID<Photo>(string id) where Photo : IPhotoVideo
        {
            return AccessHandler.Get<Photo>($"SELECT * FROM PhotoVideo WHERE Content_ID = '{id}'").Single();
        }

        public List<Video> GetVideos_ByPhotoIDs<Video>(List<string> ids) where Video : IPhotoVideo
        {
            try
            {
                return AccessHandler.Get<Video>($"SELECT * FROM PhotoVideo WHERE Content_ID IN {string.Join("', '", ids)}", new object[] { });
            }
            catch { return new List<Video>(); }
        }

        public List<Video> GetVideos_ByUserID<Video>(string id) where Video : IPhotoVideo
        {
            try
            {
                return AccessHandler.Get<Video>($"SELECT * FROM PhotoVideo WHERE User_ID = '{id}'", new object[] { }).ToList();
            }
            catch
            {
                return new List<Video>();
            }
        }

        public Video GetVideo_ByPhotoID<Video>(string id) where Video : IPhotoVideo
        {
            return AccessHandler.Get<Video>($"SELECT * FROM PhotoVideo WHERE Content_ID = '{id}'").Single();
        }
    }
}
