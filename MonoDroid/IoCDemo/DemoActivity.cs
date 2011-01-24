using Android.App;
using Android.OS;
using Android.Widget;
using IoCDemo.Quotes;

namespace IoCDemo
{
    [Activity(Label = "IoC Demo", MainLauncher = true)]
    public class DemoActivity : Activity
    {
        private IMovieQuoteProvider _quoteProvider;
        private Button _generateButton;
        private TextView _quoteText;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            _quoteProvider = ((DemoApplication)Application).FunqContainer.Resolve<IMovieQuoteProvider>();
            //_quoteProvider = TinyIoC.TinyIoCContainer.Current.Resolve<IMovieQuoteProvider>();

            SetContentView(Resource.Layout.main);
            _generateButton = FindViewById<Button>(Resource.Id.generate);
            _quoteText = FindViewById<TextView>(Resource.Id.quote);

            _generateButton.Click += delegate 
            { 
                _quoteText.Text = _quoteProvider.GetQuote(); 
            };
        }
    }
}

