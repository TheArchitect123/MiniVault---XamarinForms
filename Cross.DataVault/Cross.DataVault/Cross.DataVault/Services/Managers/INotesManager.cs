using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Cross.DataVault.Data.Interface;

namespace Cross.DataVault.Services.Managers
{
    public interface INotesManager
    {
        //ADD
        void AddNote<T>(T obj) where T : INotes;
        void AddNotes<T>(List<T> objs) where T : INotes;

        //Update
        void UpdateNote<T>(T obj) where T : INotes;
        void UpdateNotes<T>(List<T> objs) where T : INotes;

        //READ
        string Get_ContentID(); //Generated the latest note ID, for generating new content
        Note Get_NoteByID<Note>(string id) where Note : INotes;
        List<Note> Get_NotesByContactID<Note>(string id) where Note : INotes;

        //DELETE 
        void Delete_NoteById(string id);
        void Delete_NotesByIds(List<string> ids);
        void Delete_AllNotes();
        void Delete_AllNotesByContactID(string id);
    }
}
