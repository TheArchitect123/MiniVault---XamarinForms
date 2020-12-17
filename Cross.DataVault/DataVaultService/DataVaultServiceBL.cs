using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Cross.DataVault.Contracts.Data;

using DataVaultService.Security;
using Cross.DataVault.Server.DataAccess;

using Cross.DataVault.Services;
using Cross.DataVault.Contracts.Data.Response;

namespace DataVaultService
{
    public class DataVaultServiceBL : IDataVaultService
    {
        public bool IsServiceAvailable()
        {
            return true;
        }

        #region Set
        public IdentityPacket AddAccount(Account account)
        {
            //Authentication must be done before the service is called via using a password validator
            IdentityPacket response = new IdentityPacket();

            //Call Business Library and generate a new account here
            response.Contact_ID = Account_Manager.Add_AccountToStore(account);
            return response;
        }

        public IdentityPacket AddContact(Contacts contact)
        {
            IdentityPacket response = new IdentityPacket();

            //Add Contact
            response.Content_ID = Contacts_Manager.AddContact(contact);
            return response;
        }

        public IdentityPacket AddMusic(Music music)
        {
            IdentityPacket response = new IdentityPacket();

            //Add Music
            response.Content_ID = Music_Manager.AddMusic(music);
            return response;
        }

        public IdentityPacket AddNote(Notes note)
        {
            IdentityPacket response = new IdentityPacket();

            //Add Notes
            response.Content_ID = Notes_Manager.AddNote(note);
            return response;
        }

        public IdentityPacket AddPassword(Passwords password)
        {
            IdentityPacket response = new IdentityPacket();

            //Add Passwords
            Passwords_Manager.AddPassword(password);
            return response;
        }

        public IdentityPacket AddPhoto(Photos photo)
        {
            IdentityPacket response = new IdentityPacket();

            //Add Photo
            response.Content_ID = Photos_Manager.AddPhoto(photo);
            return response;
        }
        #endregion

        #region Delete
        //Notes
        public IdentityPacket DeleteNote_ByID(string id, string user_id)
        {
            IdentityPacket packet = new IdentityPacket();

            Notes_Manager.DeleteNote_ByID(id, user_id);

            return packet;
        }

        public IdentityPacket DeleteNotes_ByIDs(List<string> ids)
        {
            IdentityPacket packet = new IdentityPacket();

            Notes_Manager.DeleteNotes_ByIDs(ids);

            return packet;
        }

        //Passwords
        public IdentityPacket DeletePassword_ByID(string id, string user_id)
        {
            IdentityPacket packet = new IdentityPacket();
            Passwords_Manager.Delete_PasswordByID(id, user_id);

            return packet;
        }

        public IdentityPacket DeletePasswords_ByIDs(List<string> ids)
        {
            IdentityPacket packet = new IdentityPacket();
            Passwords_Manager.Delete_PasswordsByIDs(ids);

            return packet;
        }

        //Contacts
        public IdentityPacket Delete_ContactByID(string id, string user_id)
        {
            IdentityPacket packet = new IdentityPacket();
            Contacts_Manager.Remove_ContactByID(id, user_id);

            return packet;
        }

        public IdentityPacket Delete_ContactsByIDs(List<string> ids)
        {
            IdentityPacket packet = new IdentityPacket();
            Contacts_Manager.Remove_Contacts_ByIDs(ids);

            return packet;
        }

        public IdentityPacket Delete_PhotoByID(string id, string user_id)
        {
            IdentityPacket packet = new IdentityPacket();
            Photos_Manager.Remove_PhotoByID(id, user_id);

            return packet;
        }

        public IdentityPacket Delete_PhotosByIDs(List<string> ids)
        {
            IdentityPacket packet = new IdentityPacket();
            Photos_Manager.Remove_PhotosByIDs(ids);

            return packet;
        }

        #endregion

        #region Get
        #region Notes
        public NotesResponsePacket GetNotes_ByIDs(List<string> ids)
        {
            NotesResponsePacket response = new NotesResponsePacket();
            response._Notes = Notes_Manager.Get_NotesByIDs(ids);

            return response;
        }

        public NotesResponsePacket GetNotes_ByUserID(string id)
        {
            NotesResponsePacket response = new NotesResponsePacket();
            response._Notes = Notes_Manager.Get_NotesByUserID(id);

            return response;
        }

        public NotesResponsePacket GetNote_ByID(string id)
        {
            NotesResponsePacket response = new NotesResponsePacket();
            response._Note = Notes_Manager.Get_NoteByID(id);

            return response;
        }
        #endregion


        #region Passwords
        public PasswordsResponsePacket GetPasswords_ByIDs(List<string> ids)
        {
            PasswordsResponsePacket response = new PasswordsResponsePacket();
            response._Passwords = Passwords_Manager.Get_PasswordsByIDs(ids);

            return response;
        }

        public PasswordsResponsePacket GetPasswords_ByUserID(string id)
        {
            PasswordsResponsePacket response = new PasswordsResponsePacket();
            response._Passwords = Passwords_Manager.Get_PasswordsByUserID(id);

            return response;
        }

        public PasswordsResponsePacket GetPassword_ByID(string id)
        {
            PasswordsResponsePacket response = new PasswordsResponsePacket();
            response._Password = Passwords_Manager.Get_PasswordByID(id);

            return response;
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
            response._Contact = Contacts_Manager.Get_ContactByID(id);

            return response;
        }

        public ContactsResponsePacket Get_ContactsByIDs(List<string> ids)
        {
            ContactsResponsePacket response = new ContactsResponsePacket();
            response._Contacts = Contacts_Manager.Get_ContactsByIDs(ids);

            return response;
        }

        public ContactsResponsePacket Get_ContactsByUserID(string id)
        {
            ContactsResponsePacket response = new ContactsResponsePacket();
            response._Contacts = Contacts_Manager.Get_ContactsByUserID(id);

            return response;
        }
        #endregion

        #region Music
        public MusicResponsePacket Get_MusicByID(string id)
        {
            MusicResponsePacket response = new MusicResponsePacket();
            response._Music = Music_Manager.Get_MusicByID(id);

            return response;
        }

        public MusicResponsePacket Get_MusicByIDs(List<string> ids)
        {
            MusicResponsePacket response = new MusicResponsePacket();
            response._Musics = Music_Manager.Get_MusicsByIDs(ids);

            return response;
        }

        public MusicResponsePacket Get_MusicByUserID(string id)
        {
            MusicResponsePacket response = new MusicResponsePacket();
            response._Musics = Music_Manager.Get_MusicsByUserID(id);

            return response;
        }
        #endregion

        public PhotosResponsePacket Get_PhotoByID(string id)
        {
            PhotosResponsePacket response = new PhotosResponsePacket();
            response._Photo = Photos_Manager.Get_PhotoByID(id);

            return response;
        }

        public PhotosResponsePacket Get_PhotoByIDs(List<string> ids)
        {
            PhotosResponsePacket response = new PhotosResponsePacket();
            response._Photos = Photos_Manager.Get_PhotosByIDs(ids);

            return response;
        }

        public PhotosResponsePacket Get_PhotoByUserID(string id)
        {
            PhotosResponsePacket response = new PhotosResponsePacket();
            response._Photos = Photos_Manager.Get_PhotosByUserID(id);

            return response;
        }
        #endregion

        #region Updates
        //Passwords
        public IdentityPacket UpdatePassword(Passwords password)
        {
            IdentityPacket packet = new IdentityPacket();

            Passwords_Manager.UpdatePassword(password);

            return packet;
        }

        //Notes
        public IdentityPacket UpdateNote(Notes note)
        {
            IdentityPacket packet = new IdentityPacket();

            Notes_Manager.UpdateNote(note);

            return packet;
        }

        public IdentityPacket UpdateNotes(Notes note)
        {
            IdentityPacket packet = new IdentityPacket();

            return packet;
        }

        #endregion

    }
}