using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SQLite.Net.Attributes;
using Cross.DataVault.Data.Interface;

namespace Cross.DataVault.Data
{
    public class Address : IAddress, IEntity
    {
        [NotNull]
        public string Contact_ID_Ref { get; set; }

        public string Unit { get; set; }
        public string Number { get; set; }
        public string StreetName { get; set; }
        public string StreetType { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        [NotNull]
        public DateTime Sys_Transaction { get; set; }
        [NotNull]
        public DateTime Sys_Creation { get; set; }

        [PrimaryKey, AutoIncrement]
        public int PrimaryKey { get; set; }
    }
}
