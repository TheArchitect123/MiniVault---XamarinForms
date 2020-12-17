using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Provider;
using Android.App;
using Android.Database.Sqlite;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

//Data
using CORE = Cross.DataVault.Data;

using Cross.DataVault.Data.Interface;
using Cross.DataVault.Services.DependencyServices;

using Plugin.CurrentActivity;

namespace Cross.DataVault.Android.Services
{
    public class MusicReader : IMusicReader
    {
        public void AddMusic<Music>() where Music : IMusic
        {
            throw new NotImplementedException();
        }

        public void AddMusic<Music>(List<Music> cols) where Music : IMusic
        {
            throw new NotImplementedException();
        }

        public Music GetMusic<Music>() where Music : IMusic
        {
            throw new NotImplementedException();
        }

        public List<Music> GetMusic_Collection<Music>() where Music : IMusic
        {
            var Columns = new string[] { MediaStore.Audio.AudioColumns.Album, MediaStore.Audio.AudioColumns.Artist, MediaStore.Audio.GenresColumns.Name, MediaStore.Audio.AudioColumns.Title };
            List<CORE.Music> Musics = new List<CORE.Music>();

            ContentResolver resolver = CrossCurrentActivity.Current.Activity.ContentResolver;
            var musicLibrary_Path = MediaStore.Audio.Albums.InternalContentUri;

            var music = resolver.Query(musicLibrary_Path, null, null, null, null);
            if (music.MoveToFirst())
            {
                do
                {
                    try
                    {
                        //Query the collection of music in the store and add them to the collection
                        CORE.Music obj = new CORE.Music();
                        obj.AlbumTitle = music.GetString(music.GetColumnIndex(MediaStore.Audio.AudioColumns.Album));
                        obj.AuthorName = music.GetString(music.GetColumnIndex(MediaStore.Audio.AudioColumns.Artist));
                        obj.Music_Name = music.GetString(music.GetColumnIndex(MediaStore.Audio.AudioColumns.Title));

                        obj.ReleaseDate = new DateTime((long)music.GetDouble(music.GetColumnIndex(MediaStore.Audio.AudioColumns.DateAdded)), DateTimeKind.Local);
                        obj.Duration = TimeSpan.FromSeconds(music.GetDouble(music.GetColumnIndex(MediaStore.Audio.AudioColumns.Duration)));

                        Musics.Add(obj);
                    }
                    catch { }              
                } while (music.MoveToNext());

                //Close the cursor to dispose of any resources
                music.Close();
            }

            if (Musics.Count != 0)
                return (List<Music>)Convert.ChangeType(Musics, typeof(List<Music>));
            else
                return null;
        }

        public List<Music> GetMusic_CollectionFromTime<Music>(DateTime ReferenceDate) where Music : IMusic
        {
            throw new NotImplementedException();
        }
    }
}