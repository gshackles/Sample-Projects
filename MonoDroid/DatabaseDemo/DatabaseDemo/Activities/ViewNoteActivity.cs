using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace DatabaseDemo.Activities
{
    [Activity(Label = "View Note")]
    public class ViewNoteActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ViewNote);

            FindViewById<TextView>(Resource.Id.Title).Text = Intent.GetStringExtra("Title");
            FindViewById<TextView>(Resource.Id.Content).Text = Intent.GetStringExtra("Contents");
        }
    }
}