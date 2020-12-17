using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;
using Cross.DataVault.Data.Interface;

namespace Cross.DataVault.Data
{
    public class Music : IMusic, IEntity
    {
        //ID
        public string User_ID { get; set; }
        public string Music_ID { get; set; }

        public string Music_Name { get; set; }
        public string AlbumTitle { get; set; }
        public string AuthorName { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Genre_Enum { get; set; }
        public string Genre_Name { get; set; }

        [NotNull]
        public DateTime Sys_Transaction { get; set; }
        [NotNull]
        public DateTime Sys_Creation { get; set; }

        [PrimaryKey, AutoIncrement]
        public int PrimaryKey { get; set; }
    }
}
