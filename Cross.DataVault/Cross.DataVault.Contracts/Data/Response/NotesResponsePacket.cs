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
    public class NotesResponsePacket
    {
        [DataMember]
        public IdentityPacket ResponsePacket { get; set; }

        //Data
        [DataMember]
        public Notes _Note { get; set; }

        [DataMember]
        public List<Notes> _Notes { get; set; }

        public NotesResponsePacket()
        {
            _Notes = new List<Notes>();
            ResponsePacket = new IdentityPacket();
        }
    }
}
