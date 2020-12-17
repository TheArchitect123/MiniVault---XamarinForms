using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Cross.DataVault.Services;
using Cross.DataVault.Utils;
using Cross.DataVault.ViewModels;

//Services 
using Cross.DataVault.Services.Managers;
using Cross.DataVault.Services.DependencyServices;
using Cross.DataVault.ServiceAccess;

//Configuration -- Services
using Cross.DataVault.ServiceAccess.Configuration;

//Plugins
using Plugin.Connectivity;

namespace Cross.DataVault
{
    public partial class App : FormsApplication
    {
        public readonly SimpleContainer _container;

        public App(SimpleContainer container)
        {
            InitializeComponent();

            this._container = container;
            
            // TODO: Register additional viewmodels and services
            _container
                .PerRequest<IContactManager, ContactManager>()
                .PerRequest<IPhotoVideoManager, PhotoVideoManager>()
                .PerRequest<IAccountManager, AccountManager>()
                .PerRequest<IDocumentManager, DocumentManager>()
                .PerRequest<IMusicManager, MusicManager>()
                .PerRequest<INotesManager, NotesManager>()
                .PerRequest<IPasswordManager, PasswordManager>()
                .PerRequest<IPDFManager, PDFManager>()

                .PerRequest<INotification, Notification>()
                .PerRequest<ILogging, Logging>()
                .PerRequest<ILoader, Loader>() // Progress Loader - Could be a problem for Android

                //Caliburn Services
                .Singleton<IEventAggregator, EventAggregator>()

                .PerRequest<PhotoViewerViewModel>()
                .PerRequest<EmailViewModel>()
                .PerRequest<ContactsDetailViewModel>()
                .PerRequest<SearchViewModel>()
                .PerRequest<ContactsViewModel>()
                .PerRequest<HomeViewModel>()
                .PerRequest<LoginViewModel>()
                .PerRequest<MusicViewModel>()
                .PerRequest<NotesViewModel>()
                .PerRequest<PasswordViewModel>()
                .PerRequest<PDFViewModel>()
                .PerRequest<PhotosVideosViewModel>()
                .PerRequest<RegisterViewModel>()
                .PerRequest<DocumentsViewModel>()
                .PerRequest<SplashScreenViewModel>()

                //View Models -- For adding Content 
                .PerRequest<NotesCreatorViewModel>()
                .PerRequest<PasswordCreatorViewModel>()
                ;

            // setup root page as a navigation page
            PrepareViewFirst();

            container.GetInstance<INavigationService>()
                  .For<SplashScreenViewModel>()
                  .Navigate(false);
        }

        #region ioC Management
     
        protected override void PrepareViewFirst(NavigationPage navigationPage)
        {
            _container.Instance<INavigationService>(new NavigationPageAdapter(navigationPage));
        }

        #endregion

        #region Application Lifecycles
        protected override void OnStart()
        {
            // Handle when your app starts

            // Force container to create instances of all IApplicationServices by calling toArray()
            var services = _container.GetAllInstances<IApplicationService>().ToArray();
            foreach (var service in services)
                service.Initialize();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes


        }
        #endregion
    }
}
