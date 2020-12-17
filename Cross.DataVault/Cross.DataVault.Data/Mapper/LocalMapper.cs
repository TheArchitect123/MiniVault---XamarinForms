using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SER = Cross.DataVault.ServiceAccess.PCL.DataVaultCloudService;
using SER_ACC = Cross.DataVault.ServiceAccess.PCL.AccountManagerService;

using LOC = Cross.DataVault.Data;

namespace Cross.DataVault.Data.Mapper
{
    public static class LocalMapper
    {
        //To Local
        public static LOC.Notes MapNote_FromServer(SER.Notes obj)
        {
            LOC.Notes curr = new LOC.Notes();

            curr.Contact_ID_Ref = obj.User_ID;
            curr.Content_ID_Ref = obj.Note_ID;

            curr.Description = obj.Description;
            curr.Subject = obj.Subject;

            curr.Sys_Creation = obj.Time_OfCreation;

            return curr;
        }

        //To Server
        public static SER.Notes MapNote_ToServer(LOC.Notes obj)
        {
            SER.Notes curr = new SER.Notes();

            curr.User_ID = obj.Contact_ID_Ref;
            curr.Note_ID = obj.Content_ID_Ref;

            curr.Description = obj.Description;
            curr.Subject = obj.Subject;

            curr.Time_OfCreation = obj.Sys_Creation;

            return curr;
        }

        //Accounts
        public static SER_ACC.Account MapAccount_ToServer(LOC.Account obj)
        {
            SER_ACC.Account curr = new SER_ACC.Account();

            curr.Avatar = obj.Avatar;

            curr.First_Name = obj.FirstName;
            curr.Last_Name = obj.LastName;
            curr.Display_Name = obj.SiteUser_DisplayName;

            curr.Mobile = obj.Mobile;
            curr.Work = obj.Work;
            curr.Home = obj.Home;
            curr.Email = obj.Email;

            curr.Username = obj.Username;
            curr.Password = obj.Password;

            curr.User_ID = obj.Contact_ID_Ref;

            return curr;
        }

        //Passwords
        //To Local
        public static LOC.Passwords MapPassword_FromServer(SER.Passwords obj)
        {
            LOC.Passwords curr = new LOC.Passwords();

            curr.Contact_ID_Ref = obj.User_ID;
            curr.Password_ID = obj.Password_ID;

            curr.Description = obj.Password_Description;
            curr.Password = obj.Password_Hashed;

            curr.Sys_Creation = obj.Time_OfCreation;

            return curr;
        }

        //To Server
        public static SER.Passwords MapPassword_ToServer(LOC.Passwords obj)
        {
            SER.Passwords curr = new SER.Passwords();

            curr.User_ID = obj.Contact_ID_Ref;
            curr.Password_ID = obj.Password_ID;

            curr.Password_Description = obj.Description;
            curr.Password_Hashed = obj.Password;

            curr.Time_OfCreation = obj.Sys_Creation;

            return curr;
        }

        //Photos
        //To Local
        public static LOC.PhotoVideo MapPhoto_FromServer(SER.Photos obj)
        {
            LOC.PhotoVideo curr = new LOC.PhotoVideo();

            curr.User_ID = obj.User_ID;
            curr.Content_ID = obj.Photo_ID;

            curr.Photo = obj.Photo;

            curr.Sys_Creation = obj.Time_OfCreation;

            return curr;
        }

        //To Server
        public static SER.Photos MapPhoto_ToServer(LOC.PhotoVideo obj)
        {
            SER.Photos curr = new SER.Photos();

            curr.User_ID = obj.User_ID;
            curr.Photo_ID = obj.Content_ID;

            curr.Photo = obj.Photo;

            curr.Time_OfCreation = obj.Sys_Creation;

            return curr;
        }


        //Contacts
        //To Local
        public static LOC.Contact MapContact_FromServer(SER.Contacts obj)
        {
            LOC.Contact curr = new LOC.Contact();

            curr.Contact_ID = obj.User_ID;

            curr.Mobile = obj.Mobile;
            curr.Work = obj.Work;
            curr.Home = obj.Home;
            curr.Email = obj.Email;

            curr.First_Name = obj.First_Name;
            curr.Last_Name = obj.Last_Name;
            curr.SiteUser_DisplayName = obj.SiteUser_DisplayName;
            curr.Salutation = obj.Salutation;

            curr.Avatar = obj.Avatar;

            return curr;
        }

        //To Server
        public static SER.Contacts MapContact_ToServer(LOC.Contact obj)
        {
            SER.Contacts curr = new SER.Contacts();

            curr.Contact_ID = obj.User_ID;

            curr.Mobile = obj.Mobile;
            curr.Work = obj.Work;
            curr.Home = obj.Home;
            curr.Email = obj.Email;

            curr.First_Name = obj.First_Name;
            curr.Last_Name = obj.Last_Name;
            curr.SiteUser_DisplayName = obj.SiteUser_DisplayName;
            curr.Salutation = obj.Salutation;

            curr.Avatar = obj.Avatar;

            return curr;
        }

        //Diagnostics
        public static LOC.Log Map_LogsFromDTO(Exception ex, string logid, string processid)
        {
            Log curr = new Log();

            string Message = string.Empty;
            string StackTrace = string.Empty;

            curr.Log_ID_Ref = logid;
            curr.Process_ID_Ref = processid;

            if (ex.InnerException != null)
            {
                Message = ex.InnerException.Message;
                StackTrace = ex.InnerException.StackTrace;
            }
            else
            {
                Message = ex.Message;
                StackTrace = ex.StackTrace;
            }

            curr.Message = Message;
            curr.StackTrace = StackTrace;

            curr.Sys_Creation = DateTime.Now;
            curr.Sys_Transaction = DateTime.Now;

            return curr;
        }

        //Used for logging server responses on the client
        public static LOC.Log Map_LogWithError(string message, string stacktrace, string logid, string processid)
        {
            Log curr = new Log();

            curr.Log_ID_Ref = logid;
            curr.Process_ID_Ref = processid;

            curr.Message = message;
            curr.StackTrace = stacktrace;

            curr.Sys_Creation = DateTime.Now;
            curr.Sys_Transaction = DateTime.Now;

            return curr;
        }

        public static LOC.Log Map_LogWithMessage(string message, string logid, string processid)
        {
            Log curr = new Log();

            curr.Log_ID_Ref = logid;
            curr.Process_ID_Ref = processid;

            curr.Message = message;

            curr.Sys_Creation = DateTime.Now;
            curr.Sys_Transaction = DateTime.Now;

            return curr;
        }

    }
}
