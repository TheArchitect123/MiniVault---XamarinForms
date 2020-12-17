using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Services
{
    public class Notification : INotification
    {
        public void Hide()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
           
        }

        public void Show_WithTitle(string title = "Issue Encountered", string description = "An unknown issue has been discovered")
        {
        }
    }
}
