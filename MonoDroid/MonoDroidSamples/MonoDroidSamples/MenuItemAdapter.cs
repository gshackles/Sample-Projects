using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;

namespace MonoDroidSamples
{
    public class MenuItemAdapter : BaseAdapter
    {
        private IEnumerable<MenuItem> _items;
        private Activity _context;

        public MenuItemAdapter(Activity context, IEnumerable<MenuItem> items)
        {
            _context = context;
            _items = items;
        }

        public override int Count
        {
            get { return _items.Count(); }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var textView = new TextView(_context);

            textView.Text = _items.ElementAt(position).Label;
            textView.SetPadding(5, 10, 0, 10);

            return textView;
        }
    }
}