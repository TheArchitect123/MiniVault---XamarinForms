using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Cross.DataVault.Contracts.Data;

namespace Cross.DataVault.Contracts.Data.Response
{
    [DataContract]
    public class ContactsResponsePacket
    {
        [DataMember]
        public IdentityPacket ResponsePacket { get; set; }
        
        //Data
        [DataMember]
        public Contacts _Contact { get; set; }
        [DataMember]
        public List<Contacts> _Contacts { get; set; }

        public ContactsResponsePacket()
        {
            _Contacts = new List<Contacts>();
            ResponsePacket = new IdentityPacket();
        }
    }
}
