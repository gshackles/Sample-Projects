using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Widget;

namespace MonoDroidSamples.DemoActivities.Preferences
{
    [Activity(Label = "Preferences Demo")]
    public class PreferencesActivity : Activity
    {
        private Button _button;
        private TextView _preferenceData;
        private ISharedPreferences _preferences;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.preferences);

            _preferences = PreferenceManager.GetDefaultSharedPreferences(ApplicationContext);
            _button = FindViewById<Button>(Resource.Id.button);
            _preferenceData = FindViewById<TextView>(Resource.Id.preference_data);

            _button.Click += delegate
            {
                StartActivity(typeof(UpdatePreferencesActivity));
            };
        }

        protected override void OnResume()
        {
            base.OnResume();

            string homePageUrl = _preferences.GetString("home_url", "http://10.0.2.2");
            bool soundsEnabled = _preferences.GetBoolean("sounds", false);
            var builder = new StringBuilder();

            builder.AppendLine("Home Page: " + homePageUrl);
            builder.AppendLine("Sounds enabled: " + soundsEnabled);

            _preferenceData.Text = builder.ToString();
        }
    }
}