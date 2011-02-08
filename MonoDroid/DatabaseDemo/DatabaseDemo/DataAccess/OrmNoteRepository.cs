using System.Collections.Generic;
using System.Linq;
using Android.Content;
using DatabaseDemo.Models;
using SQLite;

namespace DatabaseDemo.DataAccess
{
    public class OrmNoteRepository : INoteRepository
    {
        private NoteDatabaseHelper _helper;

        public OrmNoteRepository(Context context)
        {
            _helper = new NoteDatabaseHelper(context);
        }

        public IList<Note> GetAllNotes()
        {
            using (var database = new SQLiteConnection(_helper.WritableDatabase.Path))
            {
                return database
                        .Table<Note>()
                        .ToList();
            }
        }

        public long AddNote(string title, string contents)
        {
            using (var database = new SQLiteConnection(_helper.WritableDatabase.Path))
            {
                return database.Insert(new Note
                {
                    Title = title,
                    Contents = contents
                });
            }
        }
    }
}