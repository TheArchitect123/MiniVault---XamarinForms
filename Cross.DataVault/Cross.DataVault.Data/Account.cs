using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite.Net.Attributes;
using Cross.DataVault.Data.Interface;

namespace Cross.DataVault.Data
{
    public class Account : IAccount, IEntity
    {
        [NotNull]
        [Required]
        public string Username { get; set; }
        [NotNull]
        [Required]
        public string Password { get; set; }

        [NotNull]
        public string Contact_ID_Ref { get; set; }
        public string Address_ID_Ref { get; set; }

       
        public string SiteUser_DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Home { get; set; }
        public string Work { get; set; }
        public string Email { get; set; }

        //Services
        public string Credentials_ServiceID { get; set; }

        //Avatar
        public string Avatar_FilePath { get; set; }
        public byte[] Avatar { get; set; }

        public int MembershipTypeEnum { get; set; }
        public string MembershipTypeName { get; set; }

        public DateTime RecentLogin { get; set; }
        [NotNull]
        [Required]
        public DateTime Sys_Transaction { get; set; }
        [NotNull]
        [Required]
        public DateTime Sys_Creation { get; set; }

        [Unique]
        [PrimaryKey, AutoIncrement]
        public int PrimaryKey { get; set; }

    }
}
