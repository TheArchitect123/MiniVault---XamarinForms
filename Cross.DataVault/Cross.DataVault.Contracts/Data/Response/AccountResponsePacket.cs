using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cross.DataVault.Contracts.Data;
using System.Runtime.Serialization;

namespace Cross.DataVault.Contracts.Data.Response
{
    [DataContract]
    public class AccountResponsePacket
    {
        [DataMember]
        public IdentityPacket ResponsePacket { get; set; }


        //Contents && Collections
        [DataMember]
        Account _Account { get; set; }

        public AccountResponsePacket()
        {
            ResponsePacket = new IdentityPacket();
        }
    }
}
