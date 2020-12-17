using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Data.Interface
{
    public interface IMusic
    {
        string User_ID { get; set; }
        string Music_ID { get; set; }

        string Music_Name { get; set; }
        string AlbumTitle { get; set; }
        string AuthorName { get; set; }

        TimeSpan Duration { get; set; }
        DateTime ReleaseDate { get; set; }

        int Genre_Enum { get; set; }
        string Genre_Name { get; set; }

        DateTime Sys_Transaction { get; set; }
        DateTime Sys_Creation { get; set; }
    }
}
