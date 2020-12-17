using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Services.Description;

using Cross.DataVault.Contracts.Data;

namespace Cross.DataVault.RestService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDataVaultService" in both code and config file together.
    [ServiceContract]
    public interface IDataVaultService
    {
        [OperationContract]
        IdentityPacket AddNote_ByContactID(int id);
        [OperationContract]
        IdentityPacket AddNotes_ByContactID(List<int> ids);

        [OperationContract]
        AddAccount_ByUser();

    }
}
