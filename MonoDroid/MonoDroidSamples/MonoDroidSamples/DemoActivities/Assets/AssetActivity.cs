using System.IO;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Widget;

namespace MonoDroidSamples.DemoActivities.Assets
{
    [Activity(Label = "Assets Demo")]
    public class AssetActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.assets_demo);

            FindViewById<TextView>(Resource.Id.font_text).Typeface =
                Typeface.CreateFromAsset(Assets, "digital-7.ttf");

            using (var reader = new StreamReader(Assets.Open("loremipsum.txt")))
            {
                FindViewById<TextView>(Resource.Id.lorem).Text = reader.ReadToEnd();
            }
        }
    }
}