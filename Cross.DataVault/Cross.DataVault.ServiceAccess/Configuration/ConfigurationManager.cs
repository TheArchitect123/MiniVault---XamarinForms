using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.None;
            binding.CloseTimeout = new TimeSpan(30, 0, 0);
            binding.OpenTimeout = new TimeSpan(30, 0, 0);
            binding.ReceiveTimeout = new TimeSpan(30, 0, 0);
            binding.SendTimeout = new TimeSpan(30, 0, 0);

            binding.MaxBufferSize = int.MaxValue;
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.MaxBufferPoolSize = int.MaxValue;

            binding.TransferMode = TransferMode.Buffered;
            
            return binding;
        }


        //Used for transmitting sensitive data. To be used with Token Based authentication. 
        //If token based authentication is configured, then the client will generate an XML token with the propert claims
        public static BasicHttpBinding SecurePublicBinding()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            binding.Security.Mode = BasicHttpSecurityMode.Message;
            binding.Security.Message.ClientCredentialType = BasicHttpMessageCredentialType.UserName;
            binding.CloseTimeout = new TimeSpan(30, 0, 0);
            binding.OpenTimeout = new TimeSpan(30, 0, 0);
            binding.ReceiveTimeout = new TimeSpan(30, 0, 0);
            binding.SendTimeout = new TimeSpan(30, 0, 0);

            binding.MaxBufferSize = int.MaxValue;
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.MaxBufferPoolSize = int.MaxValue;

            binding.TransferMode = TransferMode.Buffered;

            return binding;
        }

        public static NetTcpBinding SecureAdministratorBinding()
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;

            binding.CloseTimeout = new TimeSpan(30, 0, 0);
            binding.OpenTimeout = new TimeSpan(30, 0, 0);
            binding.ReceiveTimeout = new TimeSpan(30, 0, 0);
            binding.SendTimeout = new TimeSpan(30, 0, 0);

            binding.MaxBufferSize = int.MaxValue;
            binding.MaxReceivedMessageSize = int.MaxValue;
            binding.MaxBufferPoolSize = int.MaxValue;

            binding.TransferMode = TransferMode.Buffered;

            return binding;
        }
    }
}
