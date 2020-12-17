using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Cross.DataVault.Contracts.Data;
using Cross.DataVault.Contracts.Data.Response;
using Cross.DataVault.Services;

//Diagnostics
using Cross.DataVault.Server.DataAccess;

namespace DataVaultService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "DataVaultService_WCF" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select DataVaultService_WCF.svc or DataVaultService_WCF.svc.cs at the Solution Explorer and start debugging.
    public class DataVaultService_WCF : IDataVaultService
    {
        public bool IsServiceAvailable()
        {
            return true;
        }

        #region SET
        public IdentityPacket AddAccount(Account account)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.AddAccount(account);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }

        public IdentityPacket AddContact(Contacts contact)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    orc.AddContact(contact);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex, contact.User_ID);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }

        public IdentityPacket AddMusic(Music music)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    orc.AddMusic(music);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex, music.User_ID);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }

        public IdentityPacket AddNote(Notes note)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    orc.AddNote(note);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex, note.User_ID);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }

        public IdentityPacket AddPassword(Passwords password)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    orc.AddPassword(password);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex, password.User_ID);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }

        public IdentityPacket AddPhoto(Photos photo)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    orc.AddPhoto(photo);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex, photo.User_ID);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }
        #endregion

        #region Updates
        public IdentityPacket UpdatePassword(Passwords password)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.UpdatePassword(password);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }

        public IdentityPacket UpdateNote(Notes note)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.UpdateNote(note);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }

        public IdentityPacket UpdateNotes(Notes note)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.UpdateNotes(note);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }
        #endregion

        #region Delete 
        //Notes
        public IdentityPacket DeleteNote_ByID(string id, string user_id)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.DeleteNote_ByID(id, user_id);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }

        public IdentityPacket DeleteNotes_ByIDs(List<string> ids)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.DeleteNotes_ByIDs(ids);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }

        //Passwords

        public IdentityPacket DeletePassword_ByID(string id, string user_id)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.DeletePassword_ByID(id, user_id);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }

        public IdentityPacket DeletePasswords_ByIDs(List<string> ids)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.DeletePasswords_ByIDs(ids);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }

        public IdentityPacket Delete_ContactByID(string id, string user_id)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.Delete_ContactByID(id, user_id);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }

        public IdentityPacket Delete_ContactsByIDs(List<string> ids)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.Delete_ContactsByIDs(ids);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }


        public IdentityPacket Delete_PhotoByID(string id, string user_id)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.Delete_PhotoByID(id, user_id);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }

        public IdentityPacket Delete_PhotosByIDs(List<string> ids)
        {
            IdentityPacket packet = new IdentityPacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.Delete_PhotosByIDs(ids);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.Errors.Add(logs.Message);
            }

            return packet;
        }

        #endregion

        #region GET
        #region Notes
        public NotesResponsePacket GetNotes_ByIDs(List<string> ids)
        {
            NotesResponsePacket packet = new NotesResponsePacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.GetNotes_ByIDs(ids);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.ResponsePacket.Errors.Add(logs.Message);
            }

            return packet;
        }

        public NotesResponsePacket GetNotes_ByUserID(string id)
        {
            NotesResponsePacket packet = new NotesResponsePacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.GetNotes_ByUserID(id);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.ResponsePacket.Errors.Add(logs.Message);
            }

            return packet;
        }

        public NotesResponsePacket GetNote_ByID(string id)
        {
            NotesResponsePacket packet = new NotesResponsePacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.GetNote_ByID(id);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.ResponsePacket.Errors.Add(logs.Message);
            }

            return packet;
        }
        #endregion

        #region Passwords
        public PasswordsResponsePacket GetPasswords_ByIDs(List<string> ids)
        {
            PasswordsResponsePacket packet = new PasswordsResponsePacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.GetPasswords_ByIDs(ids);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.ResponsePacket.Errors.Add(logs.Message);
            }

            return packet;
        }

        public PasswordsResponsePacket GetPasswords_ByUserID(string id)
        {
            PasswordsResponsePacket packet = new PasswordsResponsePacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.GetPasswords_ByUserID(id);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.ResponsePacket.Errors.Add(logs.Message);
            }

            return packet;
        }

        public PasswordsResponsePacket GetPassword_ByID(string id)
        {
            PasswordsResponsePacket packet = new PasswordsResponsePacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.GetPassword_ByID(id);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.ResponsePacket.Errors.Add(logs.Message);
            }

            return packet;
        }

        #endregion

      
        #region Contacts
        public ContactsResponsePacket Get_ContactByID(string id)
        {
            ContactsResponsePacket packet = new ContactsResponsePacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.Get_ContactByID(id);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.ResponsePacket.Errors.Add(logs.Message);
            }

            return packet;
        }

        public ContactsResponsePacket Get_ContactsByIDs(List<string> ids)
        {
            ContactsResponsePacket packet = new ContactsResponsePacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.Get_ContactsByIDs(ids);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.ResponsePacket.Errors.Add(logs.Message);
            }

            return packet;
        }

        public ContactsResponsePacket Get_ContactsByUserID(string id)
        {
            ContactsResponsePacket packet = new ContactsResponsePacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.Get_ContactsByUserID(id);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.ResponsePacket.Errors.Add(logs.Message);
            }

            return packet;
        }
        #endregion

        #region Music
        public MusicResponsePacket Get_MusicByID(string id)
        {
            MusicResponsePacket packet = new MusicResponsePacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.Get_MusicByID(id);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.ResponsePacket.Errors.Add(logs.Message);
            }

            return packet;
        }

        public MusicResponsePacket Get_MusicByIDs(List<string> ids)
        {
            MusicResponsePacket packet = new MusicResponsePacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.Get_MusicByIDs(ids);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.ResponsePacket.Errors.Add(logs.Message);
            }

            return packet;
        }

        public MusicResponsePacket Get_MusicByUserID(string id)
        {
            MusicResponsePacket packet = new MusicResponsePacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.Get_MusicByUserID(id);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.ResponsePacket.Errors.Add(logs.Message);
            }

            return packet;
        }
        #endregion

        #region Photos
        public PhotosResponsePacket Get_PhotoByID(string id)
        {
            PhotosResponsePacket packet = new PhotosResponsePacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.Get_PhotoByID(id);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.ResponsePacket.Errors.Add(logs.Message);
            }

            return packet;
        }

        public PhotosResponsePacket Get_PhotoByIDs(List<string> ids)
        {
            PhotosResponsePacket packet = new PhotosResponsePacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.Get_PhotoByIDs(ids);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.ResponsePacket.Errors.Add(logs.Message);
            }

            return packet;
        }

        public PhotosResponsePacket Get_PhotoByUserID(string id)
        {
            PhotosResponsePacket packet = new PhotosResponsePacket();

            try
            {
                using (var orc = new DataVaultServiceOrc())
                    packet = orc.Get_PhotoByUserID(id);
            }
            catch (Exception ex)
            {
                var logs = new Log_DataManager(ex);
                logs.AddLog(logs);

                packet.ResponsePacket.Errors.Add(logs.Message);
            }

            return packet;
        }

        public AccountResponsePacket Get_Account_ViaAuthentication(string username, string password)
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
