using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Data.Interface
{
    public interface IAddress
    {
        string Contact_ID_Ref { get; set; }

        //Address
        string Unit { get; set; }
        string Number { get; set; }
        string StreetName { get; set; }
        string StreetType { get; set; }
        string Suburb { get; set; }
        string Postcode { get; set; }
        string State { get; set; }
        string Country { get; set; }
    
        DateTime Sys_Transaction { get; set; }
        DateTime Sys_Creation { get; set; }
    }
}
