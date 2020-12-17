using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cross.DataVault.ModelObjects;

namespace Cross.DataVault.Services.DependencyServices.Social
{
    public interface IGoogle
    {
        LoggedIn_SiteUser Login();
    }
}
