using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Data.Interface
{
    public interface IEntity
    {
        int PrimaryKey { get; set; }
    }
}
