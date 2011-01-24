using Android.App;
using Android.OS;
using Android.Views.Animations;
using Android.Widget;

namespace MonoDroidSamples.DemoActivities.Animations
{
    [Activity(Label = "Animation Demo")]
    public class AnimationActivity : Activity
    {
        private TextView _text;
        private Animation _shake, _fadeOut, _fadeIn, _scale;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.animation_demo);

            _shake = AnimationUtils.LoadAnimation(this, Resource.Animation.shake);
            _fadeOut = AnimationUtils.LoadAnimation(this, Resource.Animation.fade_out);
            _fadeIn = AnimationUtils.LoadAnimation(this, Resource.Animation.fade_in);
            _scale = AnimationUtils.LoadAnimation(this, Resource.Animation.scale);
            _text = FindViewById<TextView>(Resource.Id.text);

            FindViewById<Button>(Resource.Id.shake_button).Click += (e, args) => 
                _text.StartAnimation(_shake);

            FindViewById<Button>(Resource.Id.fadeout_button).Click += (e, args) =>
            {
                _text.StartAnimation(_fadeOut);
                _text.Visibility = Android.Views.ViewStates.Invisible;
            };


            FindViewById<Button>(Resource.Id.fadein_button).Click += (e, args) =>
            {
                _text.Visibility = Android.Views.ViewStates.Visible;
                _text.StartAnimation(_fadeIn);
            };

            FindViewById<Button>(Resource.Id.scale_button).Click += (e, args) =>
                _text.StartAnimation(_scale);
        }
    }
}