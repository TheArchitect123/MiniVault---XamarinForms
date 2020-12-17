using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Services
{
    public interface INotification
    {
        void Hide();

        void Show();
        void Show_WithTitle(string title, string description);
    }
}
