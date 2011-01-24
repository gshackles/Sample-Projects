using Android.Content;
using Android.Database;
using Android.Database.Sqlite;

namespace MonoDroidSamples.DemoActivities.Database
{
    public class NoteDatabaseAdapter
    {
        private SQLiteDatabase _database;
        private NoteDatabaseHelper _helper;

        public NoteDatabaseAdapter(NoteDatabaseHelper helper)
        {
            _helper = helper;
            _database = _helper.WritableDatabase;
        }

        public void AddNote(string title, string content)
        {
            var values = new ContentValues();
            values.Put(NoteDatabaseConstants.TitleColumn, title);
            values.Put(NoteDatabaseConstants.ContentColumn, content);

            _database.Insert(NoteDatabaseConstants.TableName, null, values);
        }

        public ICursor GetAllNotes()
        {
            return _database.Query(NoteDatabaseConstants.TableName, null, null, null, null, null, null);
        }
    }
}