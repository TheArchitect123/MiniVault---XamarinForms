using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Services.DependencyServices
{
    public class CameraPacket
    {
        public string MIME { get; set; }
        public string FilePath { get; set; }
        public byte[] File { get; set; }
        public string FileExtension { get; set; }

        public int AuthorID { get; set; }
        public string Author_DisplayName { get; set; }
        public string Author_FirstName { get; set; }
        public string Author_LastName { get; set; }

        public string Device_DisplayName { get; set; }
        public string Device_OS { get; set; }
        public string Device_Type { get; set; }

        public int Screen_Resolution { get; set; }
        public int Screen_Width { get; set; }
        public int Screen_Height { get; set; }
        
        public DateTime Sys_Creation { get; set; }
    }
}
