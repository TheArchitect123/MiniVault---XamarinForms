using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Caliburn.Micro;
using Cross.DataVault.Data.Interface;
using Cross.DataVault.Data.Services;


namespace Cross.DataVault.Services.Managers
{
    public class MusicManager : IMusicManager
    {
        //Access Handler - Used for accessing data of the database
        private IDatabase AccessHandler
        {
            get { return IoC.Get<IDatabase>(); }
        }

        public void AddMusic<Music>(Music obj) where Music : IMusic
        {
            AccessHandler.InsertOrReplace(obj);
        }

        public void AddMusic_FromCollection<Music>(List<Music> objs) where Music : IMusic
        {
            AccessHandler.InsertOrReplaceItems(objs);
        }

        public void DeleteMusic_ByID(string id)
        {
            AccessHandler.Execute($"DELETE FROM Music WHERE Music_ID = '{id}'");
        }

        public void DeleteMusic_ByIDs(List<string> ids)
        {
            AccessHandler.Execute($"DELETE FROM Music WHERE Music_ID IN {string.Join("','", ids)}");
        }

        public void DeleteMusic_ByUserID(string id)
        {
            AccessHandler.Execute($"DELETE FROM Music WHERE User_ID = '{id}'");
        }

        public void DeleteMusic_ByUserIDs(List<string> ids)
        {
            AccessHandler.Execute($"DELETE FROM Music WHERE User_ID IN {string.Join("','", ids)}");
        }

        public List<Music> GetMusicCollection_ByContactID<Music>(string id) where Music : IMusic
        {
            return AccessHandler.Get<Music>($"SELECT * FROM User_ID = '{id}'", new object[] { }).ToList();
        }

        public List<Music> GetMusicCollection_ByDateTime<Music>(DateTime reference) where Music : IMusic
        {
            return AccessHandler.Get<Music>($"SELECT * FROM ReleaseDate >= {reference}", new object[] { }).ToList();
        }

        public Music GetMusic_ByID<Music>(string id) where Music : IMusic
        {
            return AccessHandler.Get<Music>($"SELECT * FROM Music_ID = '{id}'", new object[] { }).SingleOrDefault();
        }
    }
}
