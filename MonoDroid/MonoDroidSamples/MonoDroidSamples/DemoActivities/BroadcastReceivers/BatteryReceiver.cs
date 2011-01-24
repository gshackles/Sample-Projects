using Android.Content;
using Android.Widget;

namespace MonoDroidSamples.DemoActivities.BroadcastReceivers
{
    public class BatteryReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            if (intent.Action == Intent.ActionPowerConnected)
            {
                Toast
                    .MakeText(context, "Power connected", ToastLength.Long)
                    .Show();
            }
            else if (intent.Action == Intent.ActionPowerDisconnected)
            {
                Toast
                    .MakeText(context, "Power disconnected", ToastLength.Long)
                    .Show();
            }
        }
    }
}