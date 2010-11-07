using System;
using Android.App;
using Android.Content;
using Android.Database.Sqlite;
using Android.Media;
using Android.Preferences;
using Android.Webkit;

namespace BrowserDemo
{
    public class CustomWebChromeClient : WebChromeClient
    {
        private Activity _context;
        private MediaPlayer _mediaPlayer;
        private HistoryDataHelper _historyDataHelper;

        public CustomWebChromeClient(Activity context, HistoryDataHelper historyDataHelper)
        {
            _context = context;
            _historyDataHelper = historyDataHelper;
        }

        public override void OnProgressChanged(WebView view, int newProgress)
        {
            base.OnProgressChanged(view, newProgress);

            _context.SetProgress(newProgress * 100);

            if (newProgress == 100)
            {
                _context.Title = view.Title;

                bool soundEnabled = PreferenceManager.GetDefaultSharedPreferences(_context.ApplicationContext).GetBoolean("sounds", false);

                if (soundEnabled)
                {
                    _mediaPlayer = MediaPlayer.Create(_context.ApplicationContext, Resource.raw.inception_horn);
                    _mediaPlayer.Completion += delegate { _mediaPlayer.Release(); };
                    _mediaPlayer.Start();
                }

                // add this page to the history
                using (SQLiteDatabase db = _historyDataHelper.WritableDatabase)
                {
                    var values = new ContentValues();
                    values.Put("Title", view.Title);
                    values.Put("Url", view.Url);
                    values.Put("Timestamp", DateTime.Now.Ticks);

                    db.Insert("history", null, values);
                }
            }
            else
            {
                _context.Title = _context.ApplicationContext.Resources.GetString(Resource.@string.title_loading);
            }
        }
    }
}