using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace MonoDroidSamples.DemoActivities.Database
{
    [Activity(Label = "View Note")]
    public class ViewNoteActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.view_note);

            FindViewById<TextView>(Resource.Id.title).Text = Intent.GetStringExtra("Title");
            FindViewById<TextView>(Resource.Id.content).Text = Intent.GetStringExtra("Content");
        }
    }
}