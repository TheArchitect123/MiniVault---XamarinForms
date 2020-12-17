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
    public class Music_Manager
    {

        #region DTO
        public static Music CopyFromDTO(core_music obj)
        {
            Music curr = new Music();

            curr.Artist = obj.artist;

            if (obj.duration_ticks.HasValue)
                curr.Duration = TimeSpan.FromSeconds(obj.duration_ticks.Value);

            curr.User_ID = obj.id_user;
            curr.Music_ID = obj.music_id;

            curr.Music_Name = obj.music_name;
            curr.Music_Content = obj.music_content.ToArray();

            if (obj.release_date.HasValue)
                curr.ReleaseDate = obj.release_date.Value;

            return curr;
        }

        public static core_music CopyToDTO(Music obj)
        {
            core_music curr = new core_music();

            curr.artist = obj.Artist;

            curr.duration_ticks = obj.Duration.Seconds;

            curr.id_user = obj.User_ID;
            curr.music_id = Guid.NewGuid().ToString();

            curr.music_name = obj.Music_Name;
            curr.music_content = obj.Music_Content;

            curr.release_date = obj.ReleaseDate;

            return curr;
        }

        #endregion


        #region SET
        public static string AddMusic(Music music)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                //Clean up the code
                var curr = CopyToDTO(music);
                context.core_musics.InsertOnSubmit(curr);
                context.SubmitChanges();

                return curr.music_id;
            }
        }


        public static void AddMusics_ByCollection(List<Music> musics)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                musics.ForEach(w => { context.core_musics.InsertOnSubmit(CopyToDTO(w)); });
                context.SubmitChanges();
            }
        }
        #endregion

        #region GET

        //Single Methods
        public static Music Get_MusicByID(string id)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var obj = (from music in context.core_musics
                           where
                           music.music_id == id
                           select music).SingleOrDefault();
                if (obj != null)
                    return CopyFromDTO(obj);
                else
                    return null;
            }
        }

        //Collection Methods
        public static List<Music> Get_MusicsByUserID(string id)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var obj = (from music in context.core_musics
                           where
                           music.id_user == id
                           select music).ToList().ConvertAll(w => CopyFromDTO(w));

                if (obj != null)
                    return obj;
                else
                    return null;
            }
        }

        public static List<Music> Get_MusicsByIDs(List<string> ids)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var obj = (from music in context.core_musics
                           where
                           ids.Contains(music.music_id)
                           select music).ToList().ConvertAll(w => CopyFromDTO(w));

                if (obj != null)
                    return obj;
                else
                    return null;
            }
        }


        #endregion
    }
}
