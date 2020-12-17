using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;
using Cross.DataVault.Data.Interface;
namespace Cross.DataVault.Data
{
    public class Passwords : IPasswords, IEntity
    {
        public string Contact_ID_Ref { get; set; }
        public string Password_ID { get; set; }

        public string Password { get; set; }
        public string HashedPassword { get; set; }

        public string Description { get; set; }
        public string Subject { get; set; }
        public bool Flag_Hashed { get; set; }
        public DateTime Sys_Transaction { get; set; }
        public DateTime Sys_Creation { get; set; }

        [PrimaryKey, AutoIncrement]
        public int PrimaryKey { get; set; }
    }
}
