using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Cross.DataVault.Contracts.Data
{
    [DataContract]
    public class Contacts
    {
        [DataMember]
        public string User_ID { get; set; }
        [DataMember]
        public string Contact_ID { get; set; }

        [DataMember]
        public int? Address_ID_Ref { get; set; }

        [DataMember]
        public string Salutation { get; set; }
        [DataMember]
        public string SiteUser_DisplayName { get; set; }

        [DataMember]
        public string First_Name { get; set; }
        [DataMember]
        public string Last_Name { get; set; }

        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Home { get; set; }
        [DataMember]
        public string Work { get; set; }
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public byte[] Avatar { get; set; }
    }
}
