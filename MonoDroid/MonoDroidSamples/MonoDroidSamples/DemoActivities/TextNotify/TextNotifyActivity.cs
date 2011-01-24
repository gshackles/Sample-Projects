using Android.App;
using Android.OS;
using Android.Widget;
using System.Threading;

namespace MonoDroidSamples.DemoActivities.TextNotify
{
    [Activity(Label = "Text Notify Demo")]
    public class TextNotifyActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.text_notify);

            FindViewById<Button>(Resource.Id.toast_short).Click += delegate
            {
                Toast
                    .MakeText(this, "This is a short toast", ToastLength.Short)
                    .Show();
            };

            FindViewById<Button>(Resource.Id.toast_long).Click += delegate
            {
                Toast
                    .MakeText(this, "This is a longer toast", ToastLength.Long)
                    .Show();
            };

            FindViewById<Button>(Resource.Id.alert).Click += delegate
            {
                new AlertDialog.Builder(this)
                    .SetTitle("Alert!")
                    .SetMessage("This is the content of the alert")
                    .SetPositiveButton("Ok", delegate
                    {
                        Toast
                            .MakeText(this, "Clicked ok", ToastLength.Short)
                            .Show();
                    })
                    .SetNegativeButton("Cancel", delegate
                    {
                        Toast
                            .MakeText(this, "Clicked cancel", ToastLength.Short)
                            .Show();
                    })
                    .Show();
            };

            FindViewById<Button>(Resource.Id.progress).Click += delegate
            {
                var progressDialog = ProgressDialog.Show(this, "Running", "Please wait...", true);

                new Thread(new ThreadStart(delegate
                {
                    Thread.Sleep(5000);

                    RunOnUiThread(() => progressDialog.Hide());
                })).Start();
            };
        }
    }
}