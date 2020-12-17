using Android.App;
using Android.Content.PM;
using Android.OS;
using Caliburn.Micro;
using Android.Content;

using System.IO;

using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

//Services
using Cross.DataVault.Data.Services;
using Cross.DataVault.Services.DependencyServices;
using Cross.DataVault.Android.Services; //Platform
using XLabs.Platform.Device;

//Plugins
using Plugin.CurrentActivity;
using Plugin.Media;
using Plugin.Connectivity;
using Plugin.LocalNotification.Platform.Droid;
using Plugin.Toasts;
using Vapolia.Droid.Lib.Effects;

using Android.Runtime;
using ButtonCircle.FormsPlugin.Droid;

namespace Cross.DataVault.Android
{
    [Activity(
        Label = "Mini Vault",
        Icon = "@drawable/android",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private SimpleContainer _container;

        protected override void OnNewIntent(Intent intent)
        {
            LocalNotificationService.NotifyNotificationTapped(intent);
            base.OnNewIntent(intent);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
           
            //Initialize any plugins here
            CrossCurrentActivity.Current.Init(this, bundle);
            CrossMedia.Current.Initialize();
            PlatformGestureEffect.Init();
            ToastNotification.Init(this, null);

            ButtonCircleRenderer.Init();

            LoadApplication(IoC.Get<App>());
        }
    }
}

