using Android.Content;
using Android.Database;
using Android.Views;
using Android.Widget;

namespace MonoDroidSamples.DemoActivities.Database
{
    public class NoteCursorAdapter : CursorAdapter
    {
        private LayoutInflater _inflater;

        public NoteCursorAdapter(Context context, ICursor cursor)
            : base(context, cursor)
        {
            _inflater = LayoutInflater.From(context);
        }

        public override void BindView(View view, Context context, ICursor cursor)
        {
            view.FindViewById<TextView>(Resource.Id.title).Text = 
                cursor.GetString(cursor.GetColumnIndex(NoteDatabaseConstants.TitleColumn));
        }

        public override View NewView(Context context, ICursor cursor, ViewGroup parent)
        {
            return _inflater.Inflate(Resource.Layout.note_list_item, parent, false);
        }
    }
}