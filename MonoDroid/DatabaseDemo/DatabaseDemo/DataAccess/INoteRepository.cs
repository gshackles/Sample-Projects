using System.Collections.Generic;
using DatabaseDemo.Models;

namespace DatabaseDemo.DataAccess
{
    public interface INoteRepository
    {
        IList<Note> GetAllNotes();
        long AddNote(string title, string contents);
    }
}