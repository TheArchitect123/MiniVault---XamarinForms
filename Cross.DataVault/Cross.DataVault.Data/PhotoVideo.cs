using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;
using Cross.DataVault.Data.Interface;
namespace Cross.DataVault.Data
{
    public class PhotoVideo : IEntity, IPhotoVideo
    {
        [PrimaryKey, AutoIncrement]
        public int PrimaryKey { get; set; }

        public string User_ID { get; set; }
        public string Content_ID { get; set; }

        public string Photo_FilePath { get; set; }
        public byte[] Photo { get; set; }

        public string Video_FilePath { get; set; }
        public byte[] Video { get; set; }

        public string Author_FirstName { get; set; }
        public string Author_LastName { get; set; }
        public string Author_DisplayName { get; set; }
        public string Author_ID { get; set; }

        public string Description { get; set; }
        public DateTime Sys_Creation { get; set; }
    }
}
