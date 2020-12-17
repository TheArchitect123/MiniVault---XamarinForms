using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cross.DataVault.Contracts.Data;
using Cross.DataVault.Data.Server;

//Utitilies
using Cross.DataVault.Server.DataAccess.Utilities;

namespace Cross.DataVault.Server.DataAccess
{
    public class Notes_Manager
    {
        public static Notes CopyFromDTO(core_note obj)
        {
            Notes curr = new Notes();
            curr.Description = obj._description;
            curr.Subject = obj._subject;

            if (obj.sys_creation.HasValue)
                curr.Time_OfCreation = obj.sys_creation.Value;

            curr.User_ID = obj.id_user;
            curr.Note_ID = obj.note_id;

            return curr;
        }

        public static core_note CopyToDTO(Notes obj)
        {
            core_note curr = new core_note();
            curr._description = obj.Description;
            curr._subject = obj.Subject;

            curr.sys_transaction = DateTime.Now;

            curr.id_user = obj.User_ID;
            curr.note_id = Guid.NewGuid().ToString();

            return curr;
        }

        #region SET
        public static string AddNote(Notes note)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var curr = CopyToDTO(note);
                context.core_notes.InsertOnSubmit(curr);
                context.SubmitChanges();

                return curr.id_user;
            }
        }

        public static void AddNote_ByCollection(List<Notes> notes)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                notes.ForEach(w => { context.core_notes.InsertOnSubmit(CopyToDTO(w)); });
                context.SubmitChanges();
            }
        }
        #endregion

        #region Delete 
        public static void DeleteNote_ByID(string id, string user_id)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var curr = context.core_notes.FirstOrDefault(w => w.note_id == id && w.id_user == user_id);
                if (curr == null)
                    throw new ArgumentNullException("Cannot find the note specified on the server");
                else
                {
                    context.core_notes.DeleteOnSubmit(curr);
                    context.SubmitChanges();
                }
            }
        }

        public static void DeleteNotes_ByIDs(List<string> ids)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var curr = context.core_notes.Where(w => ids.Contains(w.note_id)).ToList();
                if (curr.Count == 0)
                    throw new ArgumentNullException("Cannot find the notes specified on the server");
                else
                {
                    context.core_notes.DeleteAllOnSubmit(curr);
                    context.SubmitChanges();
                }
            }
        }

        #endregion

        #region Update
        public static void UpdateNote(Notes note)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var curr = context.core_notes.SingleOrDefault(w => w.note_id == note.Note_ID);
                if (curr != null)
                {
                    curr._subject = note.Subject;
                    curr._description = note.Description;
                }
                else
                    throw new ArgumentNullException("Cannot find the specified note");

                context.SubmitChanges();
            }
        }

        public static void UpdateNotes_ByCollection(List<Notes> notes)
        {

        }
        #endregion


        #region GET

        //Single Methods
        public static Notes Get_NoteByID(string id)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var obj = (from note in context.core_notes
                           where
                           note.note_id == id
                           select note).SingleOrDefault();
                if (obj != null)
                    return CopyFromDTO(obj);
                else
                    return null;
            }
        }

        //Collection Methods
        public static List<Notes> Get_NotesByUserID(string id)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var obj = (from note in context.core_notes
                           where
                           note.id_user == id
                           select note).ToList().ConvertAll(w => CopyFromDTO(w));

                if (obj != null)
                    return obj;
                else
                    return null;
            }
        }

        public static List<Notes> Get_NotesByIDs(List<string> ids)
        {
            using (MiniVaultDataContext context = new MiniVaultDataContext(ConnectionString.DataVault_Test))
            {
                var obj = (from note in context.core_notes
                           where
                           ids.Contains(note.note_id)
                           select note).ToList().ConvertAll(w => CopyFromDTO(w));

                if (obj != null)
                    return obj;
                else
                    return null;
            }
        }


        #endregion

    }
}
