using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Cross.DataVault.Contracts.Data
{
    [DataContract]
    public class Notes
    { 
        [DataMember]
        public string User_ID { get; set; }
        [DataMember]
        public string Note_ID { get; set; }

        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime Time_OfCreation { get; set; }
    }
}
