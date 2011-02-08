using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace DatabaseDemo.Activities
{
    [Activity(Label = "Add Note")]
    public class AddNoteActivity : Activity
    {
        private EditText _title, _content;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.AddNote);

            _title = FindViewById<EditText>(Resource.Id.Title);
            _content = FindViewById<EditText>(Resource.Id.Content);

            FindViewById<Button>(Resource.Id.Save).Click += new EventHandler(Save_Click);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            ((DatabaseDemoApplication)Application).NoteRepository.AddNote(_title.Text.ToString(), _content.Text.ToString());

            Finish();
        }
    }
}