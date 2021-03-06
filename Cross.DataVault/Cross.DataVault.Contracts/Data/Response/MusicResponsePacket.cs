﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;
using Cross.DataVault.Contracts.Data;

namespace Cross.DataVault.Contracts.Data.Response
{
    [DataContract]
    public class MusicResponsePacket
    {
        [DataMember]
        public IdentityPacket ResponsePacket { get; set; }

        //Data
        [DataMember]
        public Music _Music { get; set; }

        [DataMember]
        public List<Music> _Musics { get; set; }

        public MusicResponsePacket()
        {
            _Musics = new List<Music>();
            ResponsePacket = new IdentityPacket();
        }
    }
}
