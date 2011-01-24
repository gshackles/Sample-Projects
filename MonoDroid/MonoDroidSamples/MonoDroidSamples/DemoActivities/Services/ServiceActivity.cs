using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace MonoDroidSamples.DemoActivities.Services
{
    [Activity(Label = "Service Demo")]
    public class ServiceActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.service_demo);

            FindViewById<Button>(Resource.Id.start_service).Click += delegate
            {
                StartService(new Intent(this, typeof(MusicService)));
            };

            FindViewById<Button>(Resource.Id.stop_service).Click += delegate
            {
                StopService(new Intent(this, typeof(MusicService)));
            };
        }
    }
}