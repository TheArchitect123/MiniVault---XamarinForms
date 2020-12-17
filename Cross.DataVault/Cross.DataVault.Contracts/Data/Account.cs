using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Cross.DataVault.Contracts.Data
{
    [DataContract]
    public class Account
    {
        [DataMember]
        public string User_ID { get; set; }

        [DataMember]
        public string Mobile { get; set; }
        [DataMember]
        public string Home { get; set; }
        [DataMember]
        public string Work { get; set; }
        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string First_Name { get; set; }
        [DataMember]
        public string Last_Name { get; set; }
        [DataMember]
        public string Display_Name { get; set; }

        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public byte[] Avatar { get; set; }
    }
}
