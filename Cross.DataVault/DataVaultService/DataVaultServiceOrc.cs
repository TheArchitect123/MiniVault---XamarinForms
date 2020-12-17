using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;

using Cross.DataVault.Contracts.Data;
using Cross.DataVault.Contracts.Data.Response;
using Cross.DataVault.Services;

namespace DataVaultService
{
    public class DataVaultServiceOrc : IDataVaultService, IDisposable
    {
        DataVaultServiceBL _helper;
        public DataVaultServiceOrc()
        {
            _helper = new DataVaultServiceBL();
        }

        public bool IsServiceAvailable()
        {
            return true;
        }

        #region Set
        public IdentityPacket AddAccount(Account account)
        {
            IdentityPacket response = new IdentityPacket();

            #region Validation
            if (account == null)
                throw new FaultException("Account object cannot be null. Please contact the site administrator for assistance");
            if (string.IsNullOrWhiteSpace(account.Username))
                throw new FaultException("Username is invalid and cannot be null. Please contact the site administrator for assistance");
            if (string.IsNullOrWhiteSpace(account.Password))
                throw new FaultException("Password cannot be null. Please contact site administrator for assistance");
            if (string.IsNullOrWhiteSpace(account.First_Name))
                throw new FaultException("First name is invalid");
            if (string.IsNullOrWhiteSpace(account.Last_Name))
                throw new FaultException("Last name is invalid");
            #endregion

            if (string.IsNullOrWhiteSpace(account.Display_Name))
                account.Display_Name = String.Format("{0} {1}", account.First_Name, account.Last_Name);

            return response = _helper.AddAccount(account);
        }

        public IdentityPacket AddContact(Contacts contact)
        {
            IdentityPacket response = new IdentityPacket();

            #region Validation
            if (contact == null)
                throw new ArgumentNullException("Contact is invalid");
            #endregion

            return response = _helper.AddContact(contact);
        }

        public IdentityPacket AddMusic(Music music)
        {
            IdentityPacket response = new IdentityPacket();

            #region Validation
            if (music == null)
                throw new ArgumentNullException("Music is invalid");
            #endregion

            return response = _helper.AddMusic(music);
        }

        public IdentityPacket AddNote(Notes note)
        {
            IdentityPacket response = new IdentityPacket();

            #region Validation
            if (note == null)
                throw new ArgumentNullException("Note is invalid");
            if (string.IsNullOrWhiteSpace(note.Description))
                throw new ArgumentNullException("Description is invalid");
            if (string.IsNullOrWhiteSpace(note.Subject))
                throw new ArgumentNullException("Subject is invalid");
            #endregion

            return response = _helper.AddNote(note);
        }

        public IdentityPacket AddPassword(Passwords password)
        {
            IdentityPacket response = new IdentityPacket();

            #region Validation
            if (password == null)
                throw new ArgumentNullException("Password is invalid");
            if (string.IsNullOrWhiteSpace(password.Password_Hashed))
                throw new ArgumentNullException("Password is invalid");
            if (string.IsNullOrWhiteSpace(password.Password_Description))
                throw new ArgumentNullException("Description is invalid");
            #endregion

            return response = _helper.AddPassword(password);
        }

        public IdentityPacket AddPhoto(Photos photo)
        {
            IdentityPacket response = new IdentityPacket();

            #region Validation
            if (photo == null)
                throw new ArgumentNullException("Photo is invalid");
            if (photo.Photo == null)
                throw new ArgumentException("Photo content is invalid");
            #endregion

            return response = _helper.AddPhoto(photo);
        }

        #endregion

        #region Delete 

        public IdentityPacket DeleteNote_ByID(string id, string user_id)
        {
            IdentityPacket packet = new IdentityPacket();

            _helper.DeleteNote_ByID(id, user_id);

            return packet;
        }

        public IdentityPacket DeleteNotes_ByIDs(List<string> ids)
        {
            IdentityPacket packet = new IdentityPacket();
            _helper.DeleteNotes_ByIDs(ids);

            return packet;
        }

        //Passwords
        public IdentityPacket DeletePassword_ByID(string id, string user_id)
        {
            IdentityPacket packet = new IdentityPacket();
            _helper.DeletePassword_ByID(id, user_id);

            return packet;
        }

        public IdentityPacket DeletePasswords_ByIDs(List<string> ids)
        {
            IdentityPacket packet = new IdentityPacket();
            _helper.DeletePasswords_ByIDs(ids);

            return packet;
        }

        //Contacts
        public IdentityPacket Delete_ContactByID(string id, string user_id)
        {
            IdentityPacket packet = new IdentityPacket();
            _helper.Delete_ContactByID(id, user_id);

            return packet;
        }

        public IdentityPacket Delete_ContactsByIDs(List<string> ids)
        {
            IdentityPacket packet = new IdentityPacket();
            _helper.Delete_ContactsByIDs(ids);

            return packet;
        }

        public IdentityPacket Delete_PhotoByID(string id, string user_id)
        {
            IdentityPacket packet = new IdentityPacket();
            _helper.Delete_PhotoByID(id, user_id);

            return packet;
        }

        public IdentityPacket Delete_PhotosByIDs(List<string> ids)
        {
            IdentityPacket packet = new IdentityPacket();
            _helper.Delete_PhotosByIDs(ids);

            return packet;
        }

        #endregion

        #region Update

        //Passwords
        public IdentityPacket UpdatePassword(Passwords password)
        {
            IdentityPacket packet = new IdentityPacket();

            //Validation
            if (password == null)
                throw new FaultException("Password is invalid");
            
            return packet = _helper.UpdatePassword(password);
        }

        //notes
        public IdentityPacket UpdateNote(Notes note)
        {
            IdentityPacket packet = new IdentityPacket();

            //Validation
            if (note == null)
                throw new FaultException("Note is invalid");

            return packet = _helper.UpdateNote(note);
        }

        public IdentityPacket UpdateNotes(Notes note)
        {
            IdentityPacket packet = new IdentityPacket();

            return packet = _helper.UpdateNotes(note);
        }
        #endregion

        #region GET

        #region Notes
        public NotesResponsePacket GetNotes_ByIDs(List<string> ids)
        {
            NotesResponsePacket response = new NotesResponsePacket();

            //Validation
            if (ids == null)
                throw new FaultException("Notes ids cannot be null");
            if (ids.Count == 0)
                throw new FaultException("Please pass a collection of ids to query the content against");

            return response = _helper.GetNotes_ByIDs(ids);
        }

        public NotesResponsePacket GetNotes_ByUserID(string id)
        {
            NotesResponsePacket response = new NotesResponsePacket();

            //Validation
            return response = _helper.GetNotes_ByUserID(id);
        }

        public NotesResponsePacket GetNote_ByID(string id)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Passwords
        public PasswordsResponsePacket GetPasswords_ByIDs(List<string> ids)
        {
            PasswordsResponsePacket response = new PasswordsResponsePacket();

            return response = _helper.GetPasswords_ByIDs(ids);
        }

        public PasswordsResponsePacket GetPasswords_ByUserID(string id)
        {
            PasswordsResponsePacket response = new PasswordsResponsePacket();

            return response = _helper.GetPasswords_ByUserID(id);
        }

        public PasswordsResponsePacket GetPassword_ByID(string id)
        {
            PasswordsResponsePacket response = new PasswordsResponsePacket();

            return response = _helper.GetPassword_ByID(id);
        }
        #endregion

        public AccountResponsePacket Get_Account_ViaAuthentication(string username, string password)
        {
            throw new NotImplementedException();
        }

        #region Contacts
        public ContactsResponsePacket Get_ContactByID(string id)
        {
            ContactsResponsePacket response = new ContactsResponsePacket();

            return response = _helper.Get_ContactByID(id);
        }

        public ContactsResponsePacket Get_ContactsByIDs(List<string> ids)
        {
            ContactsResponsePacket response = new ContactsResponsePacket();

            return response = _helper.Get_ContactsByIDs(ids);
        }

        public ContactsResponsePacket Get_ContactsByUserID(string id)
        {
            ContactsResponsePacket response = new ContactsResponsePacket();

            return response = _helper.Get_ContactsByUserID(id);
        }
        #endregion

        #region Music
        public MusicResponsePacket Get_MusicByID(string id)
        {
            MusicResponsePacket response = new MusicResponsePacket();

            return response = _helper.Get_MusicByID(id);
        }

        public MusicResponsePacket Get_MusicByIDs(List<string> ids)
        {
            MusicResponsePacket response = new MusicResponsePacket();

            return response = _helper.Get_MusicByIDs(ids);
        }

        public MusicResponsePacket Get_MusicByUserID(string id)
        {
            MusicResponsePacket response = new MusicResponsePacket();

            return response = _helper.Get_MusicByUserID(id);
        }
        #endregion

        #region Photos
        public PhotosResponsePacket Get_PhotoByID(string id)
        {
            PhotosResponsePacket response = new PhotosResponsePacket();
            
            return response = _helper.Get_PhotoByID(id);
        }

        public PhotosResponsePacket Get_PhotoByIDs(List<string> ids)
        {
            PhotosResponsePacket response = new PhotosResponsePacket();

            return response = _helper.Get_PhotoByIDs(ids);
        }

        public PhotosResponsePacket Get_PhotoByUserID(string id)
        {
            PhotosResponsePacket response = new PhotosResponsePacket();

            return response = _helper.Get_PhotoByUserID(id);
        }
        #endregion
        
        #endregion

        #region Memory Management
        public void Dispose()
        {
            _helper = null;
        }
        #endregion
    }
}