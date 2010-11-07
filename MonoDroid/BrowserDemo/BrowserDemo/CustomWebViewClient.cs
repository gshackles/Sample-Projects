using Android.Webkit;
using Android.Widget;

namespace BrowserDemo
{
    public class CustomWebViewClient : WebViewClient
    {
        private EditText _urlText;

        public CustomWebViewClient(EditText urlText)
            : base()
        {
            _urlText = urlText;
        }

        public override void OnPageStarted(WebView view, string url, Android.Graphics.Bitmap favicon)
        {
            base.OnPageStarted(view, url, favicon);

            _urlText.Text = url;
            _urlText.SetSelection(0);
        }
    }
}