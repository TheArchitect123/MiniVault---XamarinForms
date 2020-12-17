using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Data.Interface
{
    public interface IPhotoVideo
    {
        string User_ID { get; set; }
        string Content_ID { get; set; }

        string Photo_FilePath { get; set; }
        byte[] Photo { get; set; }

        string Video_FilePath { get; set; }
        byte[] Video { get; set; }

        string Author_FirstName { get; set; }
        string Author_LastName { get; set; }
        string Author_DisplayName { get; set; }
        string Author_ID { get; set; }

        string Description { get; set; }
        DateTime Sys_Creation { get; set; }
    }
}
