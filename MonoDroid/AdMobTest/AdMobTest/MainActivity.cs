using Android.App;
using Android.OS;
using Android.Widget;
using Android.Views;

namespace AdMobTest
{
    [Activity(Label = "AdMobTest", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private View _adView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            AdMobHelper.RegisterEmulatorAsTestDevice();

            _adView = FindViewById(Resource.Id.Ad);

            FindViewById<Button>(Resource.Id.RefreshAd).Click += delegate
            {
                AdMobHelper.RequestFreshAd(_adView);
            };
        }
    }
}