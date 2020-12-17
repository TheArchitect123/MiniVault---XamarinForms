using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Data.Interface
{
    public interface IDocument
    {
        string Contact_ID_Ref { get; set; }

        byte[] Attachment { get; set; }
        string MIME { get; set; }

        string FileName { get; set; }
        int FileType { get; set; }
        
        DateTime Sys_Transaction { get; set; }
        DateTime Sys_Creation { get; set; }
    }
}
