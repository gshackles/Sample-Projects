using Android.Content;
using Android.Database.Sqlite;

namespace DatabaseDemo.DataAccess
{
    public class NoteDatabaseHelper : SQLiteOpenHelper
    {
        private const string DATABASE_NAME = "Notes";
        private const int DATABASE_VERSION = 1;

        public NoteDatabaseHelper(Context context)
            : base(context, DATABASE_NAME, null, DATABASE_VERSION)
        {
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(@"
                    CREATE TABLE Note (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Title TEXT NOT NULL,
                        Contents TEXT NOT NULL
                    )");
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL("DROP TABLE IF EXISTS Note");

            OnCreate(db);
        }
    }
}