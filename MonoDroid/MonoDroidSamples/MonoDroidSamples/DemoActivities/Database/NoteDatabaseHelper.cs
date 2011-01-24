using Android.Content;
using Android.Database.Sqlite;

namespace MonoDroidSamples.DemoActivities.Database
{
    public class NoteDatabaseHelper : SQLiteOpenHelper
    {
        public NoteDatabaseHelper(Context context, string name, Android.Database.Sqlite.SQLiteDatabase.ICursorFactory factory, int version)
            : base(context, name, factory, version)
        {
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            db.ExecSQL(
                string.Format(@"
                    CREATE TABLE {0} (
                        {1} integer primary key autoincrement,
                        {2} text not null,
                        {3} text not null
                    )",
                    NoteDatabaseConstants.TableName,
                    NoteDatabaseConstants.IdColumn,
                    NoteDatabaseConstants.TitleColumn,
                    NoteDatabaseConstants.ContentColumn
                ));
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
            db.ExecSQL("DROP TABLE IF EXISTS " + NoteDatabaseConstants.TableName);

            OnCreate(db);
        }
    }
}