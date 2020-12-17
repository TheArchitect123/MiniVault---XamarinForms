using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Services.DependencyServices
{
    public interface IShareContent
    {
        void OpenUp_ShareWindow();
        void OpenUp_ShareWindowWithContent(object data);
    }
}
