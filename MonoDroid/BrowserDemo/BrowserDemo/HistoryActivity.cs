using System;
using Android.App;
using Android.Content;
using Android.Database;
using Android.Database.Sqlite;
using Android.OS;
using Android.Widget;

namespace BrowserDemo
{
    [Activity(Label = "@string/history_activity_label")]
    public class HistoryActivity : ListActivity
    {
        private HistoryDataHelper _historyDataHelper;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.history);

            _historyDataHelper = new HistoryDataHelper(this);

            ListAdapter = new SimpleCursorAdapter(this, Resource.Layout.history_item, getHistory(),
                                                  new string[] { "Title" },
                                                  new int[] { Resource.Id.page_title });
        }

        protected override void OnListItemClick(ListView l, Android.Views.View v, int position, long id)
        {
            base.OnListItemClick(l, v, position, id);
            var selectedItem = (ICursor)l.GetItemAtPosition(position);
            string url = selectedItem.GetString(selectedItem.GetColumnIndexOrThrow("Url"));

            var intent = new Intent();
            intent.PutExtra("url", url);

            SetResult(Result.Ok, intent);
            Finish();
        }

        private ICursor getHistory()
        {
            using (SQLiteDatabase db = _historyDataHelper.ReadableDatabase)
            {
                ICursor cursor = db.Query("history", new string[] { "_id", "Title", "Url", "Timestamp" }, null, null, null, null, "Timestamp DESC");
                StartManagingCursor(cursor);

                return cursor;
            }
        }
    }
}