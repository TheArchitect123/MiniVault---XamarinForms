using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;
using Cross.DataVault.Data.Interface;

namespace Cross.DataVault.Data
{
    public class Contact : IContact, IEntity
    {
        [NotNull]
        public string Contact_ID { get; set; }
        [NotNull]
        public string User_ID { get; set; }

        public string Address_ID_Ref { get; set; }

        public string Salutation { get; set; }
        public string SiteUser_DisplayName { get; set; }

        public string First_Name { get; set; }
        public string Last_Name { get; set; }

        public string Mobile { get; set; }
        public string Home { get; set; }
        public string Work { get; set; }
        public string Email { get; set; }

        public byte[] Avatar { get; set; }
        public string Avatar_FilePath { get; set; }

        [NotNull]
        public DateTime Sys_Transaction { get; set; }

        [NotNull]
        public DateTime Sys_Creation { get; set; }

        [PrimaryKey, AutoIncrement]
        public int PrimaryKey { get; set; }
    }
}
