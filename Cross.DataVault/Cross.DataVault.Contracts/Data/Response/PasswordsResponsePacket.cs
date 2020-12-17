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
    public class PasswordsResponsePacket
    {
        [DataMember]
        public IdentityPacket ResponsePacket { get; set; }

        //Data  
        [DataMember]
        public Passwords _Password { get; set; }
        [DataMember]
        public List<Passwords> _Passwords { get; set; }

        public PasswordsResponsePacket() {
            _Passwords = new List<Passwords>();
            ResponsePacket = new IdentityPacket();
        }
    }
}
