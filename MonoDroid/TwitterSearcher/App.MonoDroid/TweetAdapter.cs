using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using TwitterSearcher;

namespace App.MonoDroid
{
    public class TweetAdapter : BaseAdapter
    {
        private Activity _context;
        private IEnumerable<Tweet> _tweets;

        public TweetAdapter(Activity context, IEnumerable<Tweet> tweets)
        {
            _context = context;
            _tweets = tweets;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = (convertView 
                            ?? _context.LayoutInflater.Inflate(
                                    Resource.Layout.tweet_item, parent, false)
                        ) as LinearLayout;
            var tweet = _tweets.ElementAt(position);

            view.FindViewById<TextView>(Resource.Id.tweet_text).Text = tweet.Title;
            view.FindViewById<TextView>(Resource.Id.tweet_author).Text = tweet.Author;
            view.FindViewById<TextView>(Resource.Id.tweet_published).Text = tweet.Published.ToString("f");
            
            return view;
        }

        public override int Count
        {
            get { return _tweets.Count(); }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
    }
}