using System;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Widget;

namespace MonoDroidSamples.DemoActivities.Database
{
    [Activity(Label = "Add Note")]
    public class AddNoteActivity : Activity
    {
        private EditText _title, _content;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.add_note);

            _title = FindViewById<EditText>(Resource.Id.note_title);
            _content = FindViewById<EditText>(Resource.Id.note_content);

            FindViewById<Button>(Resource.Id.save_note).Click += new EventHandler(AddNoteActivity_Click);
        }

        void AddNoteActivity_Click(object sender, EventArgs e)
        {
            ((SampleApplication)Application).NoteDatabaseAdapter.AddNote(getText(_title), getText(_content));

            Finish();
        }

        // workaround for https://bugzilla.novell.com/show_bug.cgi?id=648893
        private string getText(EditText view)
        {
            return new string(view.Text.ToArray());
        }
    }
}