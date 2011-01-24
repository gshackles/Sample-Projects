using System.Linq;
using System.Text;
using Android.App;
using Android.Locations;
using Android.OS;
using Android.Widget;
using Java.IO;

namespace MonoDroidSamples.DemoActivities.LocationDemo
{
    [Activity(Label = "Location Demo")]
    public class LocationActivity : Activity, ILocationListener
    {
        private TextView _locationText;
        private LocationManager _locationManager;
        private StringBuilder _builder;
        private Geocoder _geocoder;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.location_demo);

            _builder = new StringBuilder();
            _geocoder = new Geocoder(this);
            _locationText = FindViewById<TextView>(Resource.Id.location_text);
            _locationManager = (LocationManager)GetSystemService(LocationService);

            var criteria = new Criteria() { Accuracy = Accuracy.NoRequirement };
            string bestProvider = _locationManager.GetBestProvider(criteria, true);

            Location lastKnownLocation = _locationManager.GetLastKnownLocation(bestProvider);

            if (lastKnownLocation != null)
            {
                _locationText.Text = string.Format("Last known location, lat: {0}, long: {1}",
                                                   lastKnownLocation.Latitude, lastKnownLocation.Longitude);
            }

            _locationManager.RequestLocationUpdates(bestProvider, 5000, 2, this);
        }

        public void OnLocationChanged(Location location)
        {
            _builder.AppendLine(
                string.Format("Location updated, lat: {0}, long: {1}",
                              location.Latitude, location.Longitude)
            );
            
            try
            {
                Address address =
                    _geocoder
                        .GetFromLocation(location.Latitude, location.Longitude, 1)
                        .FirstOrDefault();

                if (address != null)
                {
                    _builder.AppendLine(" -> " + address.CountryName);
                }
            }
            catch (IOException io)
            {
                Android.Util.Log.Debug("LocationActivity", io.Message);
            }

            _locationText.Text = _builder.ToString();
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string provider, int status, Bundle extras)
        {
        }
    }
}