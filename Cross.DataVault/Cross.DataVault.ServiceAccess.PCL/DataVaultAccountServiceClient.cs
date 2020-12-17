using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ServiceModel;
using System.ServiceModel.Channels;

using Plugin.Connectivity;


using Cross.DataVault.ServiceAccess.PCL.AccountManagerService;

namespace Cross.DataVault.ServiceAccess
{
    public class DataVaultAccountServiceClient : AccountManagementClient, IDisposable
    {
        protected IAccountManagement _Channel { get; set; }

        public DataVaultAccountServiceClient() { }
        public DataVaultAccountServiceClient(Binding binding, EndpointAddress endpointAddress) : base(binding, endpointAddress)
        {
            //Subscribe to any network changes
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            //Throw an exception to cancel any operations if the internet gets disconnected -- Note: This throws a fault exception on the main thread
            if (!e.IsConnected)
                this.CloseAsync();
            else
                this.OpenAsync();
        }

        public bool HasServiceAvailable()
        {
            if (!CrossConnectivity.Current.IsConnected)
                throw new Exception("Cannot connect to the Data Vault server. There is no valid internet connection detected. Please contact site administrator for assistance");
            else
                return Task.Factory.FromAsync(this.Channel.BeginServiceAvailable, this.Channel.EndServiceAvailable, TaskCreationOptions.None).Result;
        }

        //Operations
        public IdentityPacket _Generate_AccountForUser(Account obj)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginGenerate_AccountForUser, this.Channel.EndGenerate_AccountForUser, obj, TaskCreationOptions.None).Result;
        }

        public IdentityPacket _Login_AccountForUserCredentials(string username, string password)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginGenerate_AccountForCredentials, this.Channel.EndGenerate_AccountForCredentials, username, password, TaskCreationOptions.None).Result;
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
