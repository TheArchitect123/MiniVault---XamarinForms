using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.ModelObjects
{
    public class LoggedIn_SiteUser
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Display_Name { get; set; }

        public string Mobile { get; set; }
        public string Work { get; set; }
        public string Home { get; set; }
        public string Email { get; set; }
    }
}
