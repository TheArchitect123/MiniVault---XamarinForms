using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cross.DataVault.Data.Interface;

namespace Cross.DataVault.Services.Managers
{ 
    //Handles  Insert, Delete, Get Operations for the Music Library of the Vault
    public interface IMusicManager
    {
        //Insert
        void AddMusic<Music>(Music obj) where Music : IMusic;
        void AddMusic_FromCollection<Music>(List<Music> objs) where Music : IMusic;

        //Get
        Music GetMusic_ByID<Music>(string id) where Music : IMusic;
        List<Music> GetMusicCollection_ByContactID<Music>(string id) where Music : IMusic;
        List<Music> GetMusicCollection_ByDateTime<Music>(DateTime reference) where Music : IMusic;

        //Delete
        void DeleteMusic_ByID(string id);
        void DeleteMusic_ByIDs(List<string> ids);
        void DeleteMusic_ByUserID(string id);
        void DeleteMusic_ByUserIDs(List<string> ids);
    }
}
