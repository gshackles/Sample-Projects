using System;
using Android.App;
using DatabaseDemo.DataAccess;

namespace DatabaseDemo
{
    [Application]
    public class DatabaseDemoApplication : Application
    {
        public INoteRepository NoteRepository { get; set; }

        public DatabaseDemoApplication(IntPtr handle)
            : base(handle)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            //NoteRepository = new StandardNoteRepository(this);
            NoteRepository = new OrmNoteRepository(this);
        }
    }
}
