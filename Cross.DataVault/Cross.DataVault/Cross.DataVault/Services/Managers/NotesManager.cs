using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Caliburn.Micro;
using Caliburn.Micro.Xamarin.Forms;

using Cross.DataVault.Data.Interface;
using Cross.DataVault.Data.Services;

//Tables
using Cross.DataVault.Data;

namespace Cross.DataVault.Services.Managers
{
    public class NotesManager : INotesManager
    {
        public IDatabase _Database
        {
            get
            {
                return IoC.Get<IDatabase>();
            }
        }

        public void AddNote<T>(T obj) where T : INotes
        {
            if (_Database != null)
                _Database.Insert(obj);
        }

        public void AddNotes<T>(List<T> objs) where T : INotes
        {
            if (_Database != null)
                _Database.InsertItems(objs);
        }

        //Update
        public void UpdateNote<T>(T obj) where T : INotes
        {
            _Database.Update(obj);
        }
        public void UpdateNotes<T>(List<T> objs) where T : INotes
        {
            _Database.UpdateItems(objs);
        }


        public void Delete_AllNotes()
        {
            _Database.Execute($"DELETE FROM Notes", new object[] { });
        }

        public void Delete_AllNotesByContactID(string id)
        {
            _Database.Execute($"DELETE FROM Notes WHERE Contact_ID_Ref = '{id}'", new object[] { });
        }

        public void Delete_NoteById(string id)
        {
            _Database.Execute($"DELETE FROM Notes WHERE Content_ID_Ref = '{id}'");
        }

        public void Delete_NotesByIds(List<string> ids)
        {
            foreach (var id in ids)
                _Database.Execute($"DELETE FROM Notes WHERE Content_ID_Ref = '{id}'", new object[] { });
        }

        public string Get_ContentID()
        {
            return Guid.NewGuid().ToString();
        }

        public Note Get_NoteByID<Note>(string id) where Note : INotes
        {
            return _Database.Get<Note>($"SELECT * FROM Notes WHERE Content_ID_Ref = '{id}'", new object[] { }).SingleOrDefault();
        }

        public List<Note> Get_NotesByContactID<Note>(string id) where Note : INotes
        {
            return _Database.Get<Note>($"SELECT * FROM Notes WHERE Contact_ID_Ref = '{id}'", new object[] { }).ToList();
        }
    }
}
