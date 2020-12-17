using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Cross.DataVault.Contracts.Data
{
    [DataContract]
    public class Logs
    {
        [DataMember]
        public string Log_ID { get; set; }
        [DataMember]
        public string User_ID { get; set; }

        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public string StackTrace { get; set; }
    }
}
