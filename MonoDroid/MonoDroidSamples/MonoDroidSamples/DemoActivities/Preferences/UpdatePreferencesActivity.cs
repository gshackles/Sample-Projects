using Android.App;
using Android.OS;
using Android.Preferences;

namespace MonoDroidSamples.DemoActivities.Preferences
{
    [Activity(Label = "Update Preferences")]
    public class UpdatePreferencesActivity : PreferenceActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            AddPreferencesFromResource(Resource.Xml.settings);
        }
    }
}