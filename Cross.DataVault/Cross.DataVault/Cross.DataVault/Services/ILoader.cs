using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Services
{
    public interface ILoader
    {
        void ShowLoader();
        void ShowLoader_WithStatus(string Status);

        void HideLoader();
    }
}
