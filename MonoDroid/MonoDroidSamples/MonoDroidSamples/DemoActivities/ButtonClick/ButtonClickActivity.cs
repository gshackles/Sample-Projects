using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace MonoDroidSamples.DemoActivities.ButtonClick
{
    [Activity(Label = "Button Click Demo")]
    public class ButtonClickActivity : Activity
    {
        private Button _button;
        private TextView _text;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.button_click);

            _button = FindViewById<Button>(Resource.Id.button);
            _text = FindViewById<TextView>(Resource.Id.text);

            _button.Click += delegate
            {
                _text.Text = "Last clicked at: " + DateTime.Now.ToString();
            };
        }
    }
}