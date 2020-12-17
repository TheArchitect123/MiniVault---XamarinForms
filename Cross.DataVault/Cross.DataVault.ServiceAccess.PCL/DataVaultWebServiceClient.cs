using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using System.ServiceModel.Channels;

using Plugin.Connectivity;

using Cross.DataVault.ServiceAccess.PCL.DataVaultCloudService;

namespace Cross.DataVault.ServiceAccess
{
    public class DataVaultWebServiceClient : DataVaultServiceClient, IDisposable
    {
        protected IDataVaultService _Channel { get; set; }

        public DataVaultWebServiceClient() { }
        public DataVaultWebServiceClient(Binding binding, EndpointAddress endpointAddress) : base(binding, endpointAddress)
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
            {
                return Task.Factory.FromAsync(this.Channel.BeginIsServiceAvailable, this.Channel.EndIsServiceAvailable, TaskCreationOptions.None).Result;
            }
        }

        #region Data Operations
        public IdentityPacket _AddNote(Notes obj)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginAddNote, this.Channel.EndAddNote, obj, TaskCreationOptions.None).Result;
        }

        public IdentityPacket _DeleteNote_ByID(string id, string user_id)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginDeleteNote_ByID, this.Channel.EndDeleteNote_ByID, id, user_id, TaskCreationOptions.None).Result;
        }

        public IdentityPacket _DeleteNotes_ByIDs(List<string> ids)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginDeleteNotes_ByIDs, this.Channel.EndDeleteNotes_ByIDs, ids, TaskCreationOptions.None).Result;
        }

        public NotesResponsePacket _GetNotes_ByUserID(string id)
        {
            HasServiceAvailable();
            return Task<NotesResponsePacket>.Factory.FromAsync(this.Channel.BeginGetNotes_ByUserID, this.Channel.EndGetNotes_ByUserID, id, TaskCreationOptions.AttachedToParent).Result;
        }

        //Passwords
        public IdentityPacket _AddPassword(Passwords obj)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginAddPassword, this.Channel.EndAddPassword, obj, TaskCreationOptions.None).Result;
        }

        public PasswordsResponsePacket _GetPasswords_ByUserID(string id)
        {
            HasServiceAvailable();
            return Task<PasswordsResponsePacket>.Factory.FromAsync(this.Channel.BeginGetPasswords_ByUserID, this.Channel.EndGetPasswords_ByUserID, id, TaskCreationOptions.AttachedToParent).Result;
        }

        public IdentityPacket _DeletePassword_ByID(string id, string user_id)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginDeletePassword_ByID, this.Channel.EndDeletePassword_ByID, id, user_id, TaskCreationOptions.None).Result;
        }

        public IdentityPacket _DeletePasswords_ByIDs(List<string> ids)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginDeletePasswords_ByIDs, this.Channel.EndDeletePasswords_ByIDs, ids, TaskCreationOptions.AttachedToParent).Result;
        }

        //Contacts
        public IdentityPacket _AddContact(Contacts obj)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginAddContact, this.Channel.EndAddContact, obj, TaskCreationOptions.None).Result;
        }

        public ContactsResponsePacket _GetContacts_ByUserID(string id)
        {
            HasServiceAvailable();
            return Task<ContactsResponsePacket>.Factory.FromAsync(this.Channel.BeginGet_ContactsByUserID, this.Channel.EndGet_ContactsByUserID, id, TaskCreationOptions.AttachedToParent).Result;
        }

        public IdentityPacket _DeleteContact_ByID(string id, string user_id)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginDelete_ContactByID, this.Channel.EndDelete_ContactByID, id, user_id, TaskCreationOptions.None).Result;
        }

        public IdentityPacket _DeleteContacts_ByIDs(List<string> ids)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginDelete_ContactsByIDs, this.Channel.EndDelete_ContactsByIDs, ids, TaskCreationOptions.AttachedToParent).Result;
        }

        //Photos
        public IdentityPacket _AddPhoto(Photos obj)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginAddPhoto, this.Channel.EndAddPhoto, obj, TaskCreationOptions.None).Result;
        }

        public PhotosResponsePacket _GetPhotos_ByUserID(string id)
        {
            HasServiceAvailable();
            return Task<PhotosResponsePacket>.Factory.FromAsync(this.Channel.BeginGet_PhotoByUserID, this.Channel.EndGet_PhotoByUserID, id, TaskCreationOptions.AttachedToParent).Result;
        }

        public IdentityPacket _DeletePhoto_ByID(string id, string user_id)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginDelete_PhotoByID, this.Channel.EndDelete_PhotoByID, id, user_id, TaskCreationOptions.None).Result;
        }

        public IdentityPacket _DeletePhotos_ByIDs(List<string> ids)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginDelete_PhotosByIDs, this.Channel.EndDelete_PhotosByIDs, ids, TaskCreationOptions.AttachedToParent).Result;
        }

        #endregion

        #region Updates
        //notes
        public IdentityPacket _UpdateNote_ByID(Notes note)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginUpdateNote, this.Channel.EndUpdateNote, note, TaskCreationOptions.AttachedToParent).Result;
        }

        //Password
        public IdentityPacket _UpdatePassword_ByID(Passwords password)
        {
            HasServiceAvailable();
            return Task<IdentityPacket>.Factory.FromAsync(this.Channel.BeginUpdatePassword, this.Channel.EndUpdatePassword, password, TaskCreationOptions.AttachedToParent).Result;
        }

        public void Dispose()
        {
            this.Dispose();
        }
        #endregion
    }
}
