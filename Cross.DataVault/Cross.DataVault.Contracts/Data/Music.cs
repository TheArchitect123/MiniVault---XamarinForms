using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Cross.DataVault.Contracts.Data
{
    [DataContract]
    public class Music
    {
        [DataMember]
        public string User_ID { get; set; }
        [DataMember]
        public string Music_ID { get; set; }

        [DataMember]
        public string Music_Name { get; set; }
        [DataMember]
        public byte[] Music_Content { get; set; }

        [DataMember]
        public string Artist { get; set; }

        [DataMember]
        public DateTime ReleaseDate { get; set; }
        [DataMember]
        public TimeSpan LengthOfMusic { get; set; }

        [DataMember]
        public DateTime Date_OfCreation { get; set; }
        [DataMember]
        public TimeSpan Duration { get; set; }
    }
}
