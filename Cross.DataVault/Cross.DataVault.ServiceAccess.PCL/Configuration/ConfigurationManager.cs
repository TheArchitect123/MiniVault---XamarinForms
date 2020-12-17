using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using System.ServiceModel;

namespace Cross.DataVault.ServiceAccess.Configuration
{
    public static class ConfigurationManager
    {
        //To be read by the Constants Page
        public static EndpointAddress Address { get; set; }

        //Insecure, with transport security disabled - Only to be used as a last resort. If security SSL handshake takes too long
        public static BasicHttpBinding InSecurePublicBinding()
        {
            TimeSpan DefaultTimeout = TimeSpan.FromSeconds(5);

            //Configure Service Client 
            BasicHttpBinding clientBinding = new BasicHttpBinding();

            clientBinding.Security.Mode = BasicHttpSecurityMode.None;
            clientBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

            clientBinding.CloseTimeout = DefaultTimeout;
            clientBinding.OpenTimeout = DefaultTimeout;
            clientBinding.ReceiveTimeout = DefaultTimeout;
            clientBinding.SendTimeout = DefaultTimeout;
      //      clientBinding.ReaderQuotas = XmlDictionaryReaderQuotas.Max;
            clientBinding.MaxBufferSize = int.MaxValue;
            clientBinding.MaxReceivedMessageSize = int.MaxValue;
            clientBinding.MaxBufferPoolSize = int.MaxValue;
            clientBinding.AllowCookies = false;
            
            return clientBinding;
        }


        //Used for transmitting sensitive data. To be used with Token Based authentication. 
        //If token based authentication is configured, then the client will generate an XML token with the propert claims
        public static BasicHttpBinding SecurePublicBinding()
        {
            TimeSpan DefaultTimeout = TimeSpan.FromSeconds(5);

            //Configure Service Client 
            BasicHttpBinding clientBinding = new BasicHttpBinding();

            clientBinding.Security.Mode = BasicHttpSecurityMode.Transport;
            clientBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;

            clientBinding.CloseTimeout = DefaultTimeout;
            clientBinding.OpenTimeout = DefaultTimeout;
            clientBinding.ReceiveTimeout = DefaultTimeout;
            clientBinding.SendTimeout = DefaultTimeout;
    //        clientBinding.ReaderQuotas = XmlDictionaryReaderQuotas.Max;
            clientBinding.MaxBufferSize = int.MaxValue;
            clientBinding.MaxReceivedMessageSize = int.MaxValue;
            clientBinding.MaxBufferPoolSize = int.MaxValue;
            clientBinding.AllowCookies = false;

            return clientBinding;
        }

        public static NetTcpBinding SecureAdministratorBinding()
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;

            binding.CloseTimeout = new TimeSpan(0, 0, 30);
            binding.OpenTimeout = new TimeSpan(0, 0, 30);
            binding.ReceiveTimeout = new TimeSpan(0, 0, 30);
            binding.SendTimeout = new TimeSpan(0, 0, 30);

            binding.MaxBufferSize = int.MaxValue;
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.MaxBufferPoolSize = int.MaxValue;

            binding.TransferMode = TransferMode.Buffered;

            return binding;
        }
    }
}
