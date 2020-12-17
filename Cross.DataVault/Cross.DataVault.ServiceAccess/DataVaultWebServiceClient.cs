using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using System.ServiceModel.Channels;

using Plugin.Connectivity;

using Cross.DataVault.ServiceAccess.DataVaultCloudService;

namespace Cross.DataVault.ServiceAccess
{
    public class DataVaultWebServiceClient : DataVaultServiceClient
    {
        protected IDataVaultService _Channel { get; set; }

        public DataVaultWebServiceClient() { }
        public DataVaultWebServiceClient(Binding binding, string endpointAddress)
        {
            if (!string.IsNullOrWhiteSpace(endpointAddress))
                this.Endpoint.Address = new EndpointAddress(endpointAddress);

            //Configure the Binding here
            this._Channel = (new ChannelFactory<IDataVaultService>(binding, this.Endpoint.Address)).CreateChannel();

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
                return this._Channel.IsServiceAvailable();
        }

        #region Data Operations
        public IdentityPacket _AddNote(Notes obj)
        {
            HasServiceAvailable();
            return this._Channel.AddNote(obj);
        }

        #region Notes


        #endregion

        #region Photos

        #endregion

        #region Passwords

        #endregion

        #region Contacts

        #endregion

        #region Music


        #endregion
        #endregion
    }
}
