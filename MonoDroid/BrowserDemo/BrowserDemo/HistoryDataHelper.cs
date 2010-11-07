using Android.Content;
using Android.Database.Sqlite;

namespace BrowserDemo
{
    public class HistoryDataHelper : SQLiteOpenHelper
    {
        private const int _currentVersion = 1;

        public HistoryDataHelper(Context context) : base(context, "history", null, _currentVersion)
        {
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(@"
                CREATE TABLE history (
                    _id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT NOT NULL,
                    Url TEXT NOT NULL,
                    Timestamp INT NOT NULL
                )
                ");
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL("DROP TABLE IF EXISTS history");

            OnCreate(db);
        }
    }
}