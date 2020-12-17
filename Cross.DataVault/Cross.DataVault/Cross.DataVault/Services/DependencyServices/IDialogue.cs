using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cross.DataVault.Services.DependencyServices
{
    public interface IDialogue
    {
        void ShowAlert(string Title, string Message);
        void ShowAlert_WithAction(string Title, string Message, Action Action);

        void ShowAlert_WithCancel(string Title, string Message, string Cancel);
        void ShowAlert_WithCancelWithAction(string Title, string Message, string Cancel, Action Action);

        //Take Photos & Videos
        void ShowAlert_WithCameraOption(string Title, string Message, Action Photo, Action Video);

    }
}
