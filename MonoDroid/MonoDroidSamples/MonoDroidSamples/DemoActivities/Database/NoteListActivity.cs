using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Widget;

namespace MonoDroidSamples.DemoActivities.Database
{
    [Activity(Label = "Database Demo")]
    public class NoteListActivity : Activity
    {
        private ListView _list;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.note_list);

            _list = FindViewById<ListView>(Resource.Id.list);

            FindViewById<Button>(Resource.Id.add_note).Click += delegate
            {
                StartActivity(typeof(AddNoteActivity));
            };

            _list.ItemClick += new System.EventHandler<ItemEventArgs>(_list_ItemClick);
        }

        void _list_ItemClick(object sender, ItemEventArgs e)
        {
            ICursor item = (ICursor)_list.Adapter.GetItem(e.Position);

            var intent = new Intent();
            intent.SetClass(this, typeof(ViewNoteActivity));
            intent.PutExtra("Title", item.GetString(item.GetColumnIndex(NoteDatabaseConstants.TitleColumn)));
            intent.PutExtra("Content", item.GetString(item.GetColumnIndex(NoteDatabaseConstants.ContentColumn)));

            StartActivity(intent);
        }

        protected override void OnResume()
        {
            base.OnResume();

            refreshNotes();
        }

        private void refreshNotes()
        {
            ICursor notes = ((SampleApplication)Application).NoteDatabaseAdapter.GetAllNotes();
            _list.Adapter = new NoteCursorAdapter(this, notes);
        }
    }
}