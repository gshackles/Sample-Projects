using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Preferences;
using Android.Views;
using Android.Views.InputMethods;
using Android.Webkit;
using Android.Widget;

namespace BrowserDemo
{
    [Activity(Label = "@string/app_name", MainLauncher = true, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.KeyboardHidden)]
    public class BrowserActivity : Activity
    {
        private const int HISTORY_REQUEST_CODE = 42;

        private WebView _browser;
        private EditText _urlText;
        private HistoryDataHelper _historyDataHelper;
        
        public BrowserActivity(IntPtr handle)
            : base(handle)
        {
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            RequestWindowFeature(WindowFeatures.Progress);

            SetContentView(Resource.layout.main);

            _historyDataHelper = new HistoryDataHelper(this);

            _browser = FindViewById<WebView>(Resource.id.browser);
            _urlText = FindViewById<EditText>(Resource.id.url);
            Button goButton = FindViewById<Button>(Resource.id.go_button);

            _browser.Settings.JavaScriptEnabled = true;
            _browser.SetWebViewClient(new CustomWebViewClient(_urlText));
            _browser.SetWebChromeClient(new CustomWebChromeClient(this, _historyDataHelper));
            _browser.Touch += delegate { _browser.RequestFocus(); };

            goButton.Click += delegate { updateBrowser(); };

            _urlText.KeyPress += new EventHandler<View.KeyEventArgs>(_urlText_KeyPress);

            goToHomePageIfSet();
        }

        private void _urlText_KeyPress(object sender, View.KeyEventArgs e)
        {
            if (e.KeyCode == Keycode.Enter)
            {
                updateBrowser();

                e.ReturnValue = true;
            }
        }

        private void updateBrowser()
        {
            string url = _urlText.Text.ToString();

            if (url.Length == 0)
            {
                new AlertDialog.Builder(this)
                    .SetTitle(Resources.GetString(Resource.@string.invalid_url_alert_title))
                    .SetMessage(Resources.GetString(Resource.@string.invalid_url_alert_message))
                    .SetPositiveButton(Resources.GetString(Resource.@string.ok_button), null)
                    .Show();
            }
            else
            {
                InputMethodManager inputManager = (InputMethodManager)GetSystemService(InputMethodService);
                inputManager.HideSoftInputFromWindow(_urlText.WindowToken, HideSoftInputFlags.None);

                if (!url.StartsWith("http://"))
                {
                    url = "http://" + url;
                }

                _browser.RequestFocus();
                _browser.LoadUrl(url);
            }
        }

        public override void OnBackPressed()
        {
            if (_browser.CanGoBack())
            {
                _browser.GoBack();
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            base.OnCreateOptionsMenu(menu);

            new MenuInflater(this).Inflate(Resource.menu.options_menu, menu);

            return true;
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            base.OnPrepareOptionsMenu(menu);

            menu.FindItem(Resource.id.refresh).SetVisible(_browser.Progress == 100 && !string.IsNullOrEmpty(_urlText.Text.ToString()));
            menu.FindItem(Resource.id.stop).SetVisible(_browser.Progress != 100);
            menu.FindItem(Resource.id.home).SetVisible(!string.IsNullOrEmpty(getHomePageUrl()));

            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.id.refresh:
                    _browser.Reload();
                    break;
                case Resource.id.stop:
                    _browser.StopLoading();
                    break;
                case Resource.id.settings:
                    StartActivity(typeof(SettingsActivity));
                    break;
                case Resource.id.home:
                    goToHomePageIfSet();
                    break;
                case Resource.id.history:
                    var intent = new Intent(this, typeof(HistoryActivity));
                    StartActivityForResult(intent, HISTORY_REQUEST_CODE);
                    break;
                default:
                    return base.OnOptionsItemSelected(item);
            }

            return true;
        }

        private void goToHomePageIfSet()
        {
            string homePageUrl = getHomePageUrl();

            if (!string.IsNullOrEmpty(homePageUrl))
            {
                _urlText.Text = homePageUrl;

                updateBrowser();
            }
        }

        private string getHomePageUrl()
        {
            return PreferenceManager.GetDefaultSharedPreferences(ApplicationContext).GetString("home_url", "http://10.0.2.2");
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            if (requestCode == HISTORY_REQUEST_CODE && resultCode == Result.Ok)
            {
                _urlText.Text = data.GetStringExtra("url");
                updateBrowser();
            }
        }
    }
}