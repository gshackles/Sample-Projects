using System;
using System.Collections.Generic;
using DatabaseDemo.Models;
using Android.Content;
using Android.Database;

namespace DatabaseDemo.DataAccess
{
    public class StandardNoteRepository : INoteRepository
    {
        private NoteDatabaseHelper _helper;

        public StandardNoteRepository(Context context)
        {
            _helper = new NoteDatabaseHelper(context);
        }

        public IList<Note> GetAllNotes()
        {
            ICursor noteCursor = _helper.ReadableDatabase.Query("Note", null, null, null, null, null, null);
            var notes = new List<Note>();

            while (noteCursor.MoveToNext())
            {
                notes.Add(mapNote(noteCursor));
            }

            return notes;
        }

        public long AddNote(string title, string contents)
        {
            var values = new ContentValues();
            values.Put("Title", title);
            values.Put("Contents", contents);

            return _helper.WritableDatabase.Insert("Note", null, values);
        }

        private Note mapNote(ICursor cursor)
        {
            return new Note
            {
                Id = cursor.GetInt(0),
                Title = cursor.GetString(1),
                Contents = cursor.GetString(2)
            };
        }
    }
}