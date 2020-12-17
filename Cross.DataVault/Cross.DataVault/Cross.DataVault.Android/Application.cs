using Android.App;
using Android.Runtime;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Reflection;

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
using Plugin.Toasts;
using Plugin.Connectivity;
using Vapolia.Droid.Lib.Effects;
using ButtonCircle.FormsPlugin.Droid;

namespace Cross.DataVault.Android
{
    //You can specify additional application information in this attribute
    [Application(Debuggable = false)]
    public class MainApplication : CaliburnApplication
    {
        private SimpleContainer _container;

        public MainApplication(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
            Console.Write("");
        }

        public override void OnCreate()
        {
            base.OnCreate();

            Initialize();
        }

        protected override void Configure()
        {
            _container = new SimpleContainer();
            _container.Instance(_container);

            _container.Singleton<App>();
            // TODO: Register any Platform-Specific abstractions here
            //Generate Sqlite Connection and store the dependency in the container for later use, by the Networkers Business Helper
            var SqlitePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "DataVault.db");
            SQLiteConnection connection = new SQLiteConnection(new SQLitePlatformAndroid(), SqlitePath, false);
            Database context = new Database(SqlitePath, System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), connection);

            _container.Instance<IDatabase>(context);
            _container.PerRequest<IDialogue, Dialogue>();
            _container.PerRequest<IContactStore, ContactStore>();
            _container.PerRequest<IMusicReader, MusicReader>();
            _container.PerRequest<IToastNotificator, ToastNotification>();
            _container.Instance<IDevice>(AndroidDevice.CurrentDevice);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            // Get a list of all assemblies that will be used by the IoC container
            return new[]
            {
                GetType().Assembly,
                typeof(App).Assembly
            };
        }

        #region Caliburn IoC Methods
        protected override void BuildUp(object instance)
        {
            if (_container != null)
                _container.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            if (_container != null)
                return _container.GetAllInstances(service);

            return null;
        }

        protected override object GetInstance(Type service, string key)
        {
            if (_container != null)
                return _container.GetInstance(service, key);
            return null;
        }
        #endregion
    }
}