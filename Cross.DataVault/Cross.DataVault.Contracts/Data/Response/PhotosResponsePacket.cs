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
    public class PhotosResponsePacket
    {
        [DataMember]
        public IdentityPacket ResponsePacket { get; set; }

        //Data
        [DataMember]
        public Photos _Photo { get; set; }
        [DataMember]
        public List<Photos> _Photos { get; set; }

        public PhotosResponsePacket()
        {
            _Photos = new List<Photos>();
            ResponsePacket = new IdentityPacket();
        }
    }
}
