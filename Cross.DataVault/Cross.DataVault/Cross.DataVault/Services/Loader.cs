using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cross.DataVault.Services
{
    //Calls Messaging Center, which each view subscribes to, and Shows or Hides the Loader Views
    public class Loader : ILoader
    {
        public const string _ShowLoader = "_ShowLoader";
        public const string _HideLoader = "_HideLoader";

        public void HideLoader()
        {
            MessagingCenter.Send<Loader>(this, _HideLoader);
        }

        public void ShowLoader()
        {
            MessagingCenter.Send<Loader>(this, _ShowLoader);
        }

        public void ShowLoader_WithStatus(string Status)
        {
            MessagingCenter.Send<Loader, string>(this, _ShowLoader, Status);
        }
    }
}
