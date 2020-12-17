using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;
using Cross.DataVault.Data.Interface;
namespace Cross.DataVault.Data
{
    public class Document : IDocument, IEntity
    {
        [PrimaryKey, AutoIncrement]
        public int PrimaryKey { get; set; }

        public string Contact_ID_Ref { get; set; }

        public byte[] Attachment { get; set; }
        public string MIME { get; set; }
        public string FileName { get; set; }
        public int FileType { get; set; }

        [NotNull]
        public DateTime Sys_Transaction { get; set; }
        [NotNull]
        public DateTime Sys_Creation { get; set; }
    }
}
