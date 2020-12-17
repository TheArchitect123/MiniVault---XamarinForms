using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace Cross.DataVault.Contracts.Data
{
    [DataContract]
    public class IdentityPacket
    {
        [DataMember]
        public string Process_ID { get; set; }
        [DataMember]
        public string Content_ID { get; set; }
        [DataMember]
        public string Contact_ID { get; set; }

        [DataMember]
        public Account SiteUser { get; set; }

        /// <summary>
        /// Diagnostics
        /// </summary>
        [DataMember]
        public List<string> Errors { get; set; }
        [DataMember]
        public bool HasError { get; set; }

        public IdentityPacket()
        {
            Errors = new List<string>();
        }
    }
}
