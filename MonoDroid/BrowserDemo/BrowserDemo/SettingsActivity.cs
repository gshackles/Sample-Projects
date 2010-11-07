using System;
using Android.App;
using Android.OS;
using Android.Preferences;

namespace BrowserDemo
{
    [Activity(Label = "@string/settings_activity_label")]
    public class SettingsActivity : PreferenceActivity
    {
        public SettingsActivity(IntPtr handle)
            : base(handle)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            AddPreferencesFromResource(Resource.xml.settings);
        }
    }
}