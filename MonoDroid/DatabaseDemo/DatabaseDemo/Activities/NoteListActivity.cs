using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace DatabaseDemo.Activities
{
    [Activity(Label = "Database Demo", MainLauncher = true)]
    public class NoteListActivity : Activity
    {
        private ListView _list;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.NoteList);

            _list = FindViewById<ListView>(Resource.Id.List);

            FindViewById<Button>(Resource.Id.AddNote).Click += delegate
            {
                StartActivity(typeof(AddNoteActivity));
            };

            _list.ItemClick += new System.EventHandler<ItemEventArgs>(_list_ItemClick);
        }

        protected override void OnResume()
        {
            base.OnResume();

            refreshNotes();
        }

        private void refreshNotes()
        {
            var notes = ((DatabaseDemoApplication)Application).NoteRepository.GetAllNotes();
            _list.Adapter = new NoteListAdapter(this, notes);
        }

        private void _list_ItemClick(object sender, ItemEventArgs e)
        {
            var note = ((NoteListAdapter)_list.Adapter).GetNote(e.Position);

            var intent = new Intent();
            intent.SetClass(this, typeof(ViewNoteActivity));
            intent.PutExtra("Title", note.Title);
            intent.PutExtra("Contents", note.Contents);

            StartActivity(intent);
        }
    }
}

