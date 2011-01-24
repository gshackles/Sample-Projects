using Android.App;
using Android.OS;

namespace MonoDroidSamples.DemoActivities.Localization
{
    [Activity(Label = "@string/localization_label")]
    public class LocalizationActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.localization_demo);
        }
    }
}