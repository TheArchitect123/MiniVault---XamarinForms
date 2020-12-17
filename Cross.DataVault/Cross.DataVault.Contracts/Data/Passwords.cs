using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using System.Runtime.Serialization;

namespace Cross.DataVault.Contracts.Data
{
    [DataContract]
    public class Passwords
    {
        [DataMember]
        public string User_ID { get; set; }
        [DataMember]
        public string Password_ID { get; set; }
        [DataMember]
        public string Password_Hashed { get; set; }
        [DataMember]
        public string Password_Description { get; set; }

        [DataMember]
        public DateTime Time_OfCreation { get; set; }
    }
}
