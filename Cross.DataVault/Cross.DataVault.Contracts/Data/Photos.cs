using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Cross.DataVault.Contracts.Data
{
    [DataContract]
    public class Photos
    {
        [DataMember]
        public string User_ID { get; set; }
        [DataMember]
        public string Photo_ID { get; set; }

        [DataMember]
        public byte[] Photo { get; set; }
        [DataMember]
        public string Photo_MIME { get; set; }

        [DataMember]
        public DateTime Time_OfCreation { get; set; }
    }
}
