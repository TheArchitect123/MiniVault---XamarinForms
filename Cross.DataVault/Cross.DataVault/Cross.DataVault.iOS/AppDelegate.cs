using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Caliburn.Micro;

using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;

//Services
using Cross.DataVault.Services.DependencyServices;
using Cross.DataVault.Data.Services;
using Cross.DataVault.iOS.Services;
using XLabs.Platform.Device;

//Plugins
using ButtonCircle.FormsPlugin.iOS;
using Plugin.Permissions;
using Plugin.LocalNotification.Platform.iOS;
using Vapolia.Ios.Lib.Effects;
using Plugin.Messaging;
using Plugin.Toasts;

namespace Cross.DataVault.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private readonly CaliburnAppDelegate appDelegate = new CaliburnAppDelegate();

        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            LocalNotificationService.NotifyNotificationTapped(notification);
        }

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            //Pluugins
            ButtonCircleRenderer.Init();
            PlatformGestureEffect.Init();
            ToastNotification.Init();
            LocalNotificationService.Init();

            //Generate Sqlite Connection and store the dependency in the container for later use, by the Networkers Business Helper
            var SqlitePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "DataVault.db");
            SQLiteConnection connection = new SQLiteConnection(new SQLitePlatformIOS(), SqlitePath, false);
            Database context = new Database(SqlitePath, System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), connection);

            var container = IoC.Get<SimpleContainer>();
            container.Instance<IDatabase>(context);

            //Dependency Services
            container.PerRequest<IDialogue, Dialogue>();
            container.PerRequest<IShareContent, ShareContent>();
            container.PerRequest<IMusicReader, MusicReader>();
            container.PerRequest<IContactStore, ContactStore>();
            container.PerRequest<IToastNotificator, ToastNotification>();
            container.Instance<IDevice>(AppleDevice.CurrentDevice);

            LoadApplication(new App(container));

            return base.FinishedLaunching(app, options);
        }
    }
}
