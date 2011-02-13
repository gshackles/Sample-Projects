using System.Threading;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Widget;
using TwitterSearcher;

namespace App.MonoDroid
{
    [Activity(Label = "Twitter Search", MainLauncher = true)]
    public class SearchActivity : Activity
    {
        private Searcher _searcher;
        private ListView _resultsList;
        private TextView _queryText;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.main);

            _searcher = new Searcher("http://search.twitter.com/search.atom?q=");
            //_searcher = new Searcher("http://10.0.2.2/search.xml?q=");
            
            _resultsList = FindViewById<ListView>(Resource.Id.results);
            _queryText = FindViewById<TextView>(Resource.Id.query);

            FindViewById<Button>(Resource.Id.search_button).Click += delegate
            {
                var progressDialog = ProgressDialog.Show(this, "Searching", "Please wait...", true);

                _searcher.Search(_queryText.Text.ToString(), results =>
                {
                    RunOnUiThread(delegate
                    {
                        _resultsList.Adapter = new TweetAdapter(this, results);
                        progressDialog.Hide();
                    });
                });
            };
        }
    }
}

