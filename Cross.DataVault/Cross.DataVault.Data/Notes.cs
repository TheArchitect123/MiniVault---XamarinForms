using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;
using Cross.DataVault.Data.Interface;
namespace Cross.DataVault.Data
{
    public class Notes : INotes, IEntity
    {
        [NotNull]
        public string Contact_ID_Ref { get; set; }
        public string Content_ID_Ref { get; set; }

        public string Description { get; set; }
        public string Subject { get; set; }

        public bool Flag_Notification { get; set; }

        public DateTime Sys_Transaction { get; set; }
        public DateTime Sys_Creation { get; set; }

        [PrimaryKey, AutoIncrement]
        public int PrimaryKey { get; set; }
    }
}
