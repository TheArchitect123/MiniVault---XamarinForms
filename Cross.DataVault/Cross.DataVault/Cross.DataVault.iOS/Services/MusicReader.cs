using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using CoreMedia;
using MediaPlayer;

using Cross.DataVault.Services.DependencyServices;
using Cross.DataVault.Data.Interface;
using CORE = Cross.DataVault.Data;


namespace Cross.DataVault.iOS.Services
{
    public class MusicReader : IMusicReader
    {
        public void AddMusic<Music>() where Music : IMusic
        {
            //Add Music to the vault
        }

        public void AddMusic<Music>(List<Music> cols) where Music : IMusic
        {
            //Add collection of music to the vault
        }

        public Music GetMusic<Music>() where Music : IMusic
        {
            throw new NotImplementedException();
        }


        //Querying against the itunes library will only work on devices
        public List<Music> GetMusic_Collection<Music>() where Music : IMusic
        {
            //read a collection of songs from the vault

            List<CORE.Music> Musics = new List<CORE.Music>();

            //Query from the iTunes library and add them to the collection
            MPMediaQuery itunesQuery = new MPMediaQuery();
            var music = itunesQuery.Items;

            foreach (var item in music)
            {
                CORE.Music obj = new CORE.Music();
                obj.AlbumTitle = item.AlbumTitle;
                obj.AuthorName = item.Artist;

                obj.Duration = TimeSpan.FromSeconds(item.PlaybackDuration);
                obj.Genre_Name = item.Genre;

                obj.Music_Name = item.Title;

                obj.Sys_Creation = DateTime.Now;
                obj.Sys_Transaction = DateTime.Now;

                Musics.Add(obj);
            }

            if (Musics.Count == 0)
                return null;
            else
                return (List<Music>)Convert.ChangeType(Musics, typeof(List<Music>));
        }

        public List<Music> GetMusic_CollectionFromTime<Music>(DateTime ReferenceDate) where Music : IMusic
        {
            //read a collection of songs from the vault
            return null;
        }
    }
}