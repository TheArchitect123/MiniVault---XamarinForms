using Caliburn.Micro;
using Shared = Cross.DataVault; // required for VSTemplate

namespace Cross.DataVault.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(IoC.Get<Shared.App>());
        }
    }
}
