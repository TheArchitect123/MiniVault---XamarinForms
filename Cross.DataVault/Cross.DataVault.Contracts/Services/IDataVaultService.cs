using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Cross.DataVault.Contracts.Data;
using Cross.DataVault.Contracts.Data.Response;

namespace Cross.DataVault.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IDataVaultService" in both code and config file together.
    [ServiceContract]
    public interface IDataVaultService
    {
        [OperationContract]
        bool IsServiceAvailable();

        #region Notes
        //SET
        [OperationContract]
        IdentityPacket AddNote(Notes note);
        [OperationContract]
        IdentityPacket DeleteNote_ByID(string id, string user_id);
        [OperationContract]
        IdentityPacket DeleteNotes_ByIDs(List<string> ids);

        //GET
        [OperationContract]
        NotesResponsePacket GetNote_ByID(string id);
        [OperationContract]
        NotesResponsePacket GetNotes_ByIDs(List<string> ids);
        [OperationContract]
        NotesResponsePacket GetNotes_ByUserID(string id);

        //Updates
        [OperationContract]
        IdentityPacket UpdateNote(Notes note);
        [OperationContract]
        IdentityPacket UpdateNotes(Notes note);

        #endregion

        #region Passwords
        //SET
        [OperationContract]
        IdentityPacket AddPassword(Passwords password);
        [OperationContract]
        IdentityPacket DeletePassword_ByID(string id, string user_id);
        [OperationContract]
        IdentityPacket DeletePasswords_ByIDs(List<string> ids);

        //Update
        [OperationContract]
        IdentityPacket UpdatePassword(Passwords password);

        //GET
        [OperationContract]
        PasswordsResponsePacket GetPasswords_ByUserID(string id);

        [OperationContract]
        PasswordsResponsePacket GetPassword_ByID(string id);

        [OperationContract]
        PasswordsResponsePacket GetPasswords_ByIDs(List<string> ids);
        #endregion

        #region Accounts
        [OperationContract]
        IdentityPacket AddAccount(Account account);

        [OperationContract]
        AccountResponsePacket Get_Account_ViaAuthentication(string username, string password); //Authenticates the user - -will use message security with token based authentication

        #endregion
        //Bug Reports

        #region Contacts
        //SET
        [OperationContract]
        IdentityPacket AddContact(Contacts contact);
        [OperationContract]
        IdentityPacket Delete_ContactByID(string id, string user_id);
        [OperationContract]
        IdentityPacket Delete_ContactsByIDs(List<string> ids);

        //GET
        [OperationContract]
        ContactsResponsePacket Get_ContactByID(string id);
        [OperationContract]
        ContactsResponsePacket Get_ContactsByUserID(string id);
        [OperationContract]
        ContactsResponsePacket Get_ContactsByIDs(List<string> ids);

        #endregion

        #region Music
        //SET
        [OperationContract]
        IdentityPacket AddMusic(Music music);

        //GET
        [OperationContract]
        MusicResponsePacket Get_MusicByID(string id);
        [OperationContract]
        MusicResponsePacket Get_MusicByUserID(string id);
        [OperationContract]
        MusicResponsePacket Get_MusicByIDs(List<string> ids);
        #endregion

        #region Photos
        //SET
        [OperationContract]
        IdentityPacket AddPhoto(Photos photo);
        [OperationContract]
        IdentityPacket Delete_PhotoByID(string id, string user_id);
        [OperationContract]
        IdentityPacket Delete_PhotosByIDs(List<string> ids);


        //GET
        [OperationContract]
        PhotosResponsePacket Get_PhotoByID(string id);
        [OperationContract]
        PhotosResponsePacket Get_PhotoByUserID(string id);
        [OperationContract]
        PhotosResponsePacket Get_PhotoByIDs(List<string> ids);

        #endregion
    }
}
