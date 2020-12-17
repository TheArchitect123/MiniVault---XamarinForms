using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ServiceModel;
using System.ServiceModel.Channels;

using Plugin.Connectivity;

using Cross.DataVault.ServiceAccess.AccountManagerService;

namespace Cross.DataVault.ServiceAccess
{
    public class DataVaultAccountServiceClient : AccountManagementClient
    {
        protected IAccountManagement _Channel { get; set; }

        public DataVaultAccountServiceClient() { }
        public DataVaultAccountServiceClient(Binding binding, string endpointAddress)
        {
            if (!string.IsNullOrWhiteSpace(endpointAddress))
                this.Endpoint.Address = new EndpointAddress(endpointAddress);

            _Channel = new ChannelFactory<IAccountManagement>(binding, this.Endpoint.Address).CreateChannel();
            //Configure the Binding here

            //Subscribe to any network changes
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            //Throw an exception to cancel any operations if the internet gets disconnected -- Note: This throws a fault exception on the main thread
            if (!e.IsConnected)
                this.Close();
        }

        public bool HasServiceAvailable()
        {
            if (!CrossConnectivity.Current.IsConnected)
                throw new SystemException("Cannot connect to the Data Vault server. There is no valid internet connection detected. Please contact site administrator for assistance");
            else
                return this._Channel.ServiceAvailable();
        }

        //Operations
        public IdentityPacket _Generate_AccountForUser(Account obj)
        {
            HasServiceAvailable();
            return this._Channel.Generate_AccountForUser(obj);
        }
    }
}
