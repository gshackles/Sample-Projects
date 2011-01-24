using Android.App;
using Android.Content;
using Android.OS;

namespace MonoDroidSamples.DemoActivities.BroadcastReceivers
{
    [Activity(Label = "Receiver Demo")]
    public class ReceiverActivity : Activity
    {
        private BatteryReceiver _receiver;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.receiver_demo);

            _receiver = new BatteryReceiver();
            var intentFilter = new IntentFilter(Intent.ActionPowerConnected);
            intentFilter.AddAction(Intent.ActionPowerDisconnected);

            RegisterReceiver(_receiver, intentFilter);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            UnregisterReceiver(_receiver);
        }
    }
}