using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cross.DataVault.Data.Interface;

namespace Cross.DataVault.Services.Managers
{
    public interface IPhotoVideoManager
    {
        //INSERT
        void AddPhoto<Photo>(Photo obj) where Photo : IPhotoVideo;
        void AddPhoto_ByCollections<Photo>(List<Photo> items) where Photo : IPhotoVideo;

        void AddVideo<Video>(Video obj) where Video : IPhotoVideo;
        void AddVideo_ByCollections<Video>(List<Video> items) where Video : IPhotoVideo;
        
        /////////// PHOTO
        Photo GetPhoto_ByPhotoID<Photo>(string id) where Photo : IPhotoVideo;
        List<Photo> GetPhotos_ByPhotoIDs<Photo>(List<string> ids) where Photo : IPhotoVideo;
        List<Photo> GetPhotos_ByUserID<Photo>(string id) where Photo : IPhotoVideo;

        /////////// VIDEO
        Video GetVideo_ByPhotoID<Video>(string id) where Video : IPhotoVideo;
        List<Video> GetVideos_ByPhotoIDs<Video>(List<string> ids) where Video : IPhotoVideo;
        List<Video> GetVideos_ByUserID<Video>(string id) where Video : IPhotoVideo;

        //DELETE
        void ClearPhotos(); // clears all photos on the device
        void Delete_PhotoByID(string id);
        void Delete_PhotosByUserId(string id);  // clears photos belonging only for the site user ID
    }
}
