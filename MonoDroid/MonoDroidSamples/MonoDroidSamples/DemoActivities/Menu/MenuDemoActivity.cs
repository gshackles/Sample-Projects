using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace MonoDroidSamples.DemoActivities.Menu
{
    [Activity(Label = "Menu Demo")]
    public class MenuDemoActivity : Activity
    {
        private TextView _text;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.menu_demo);

            _text = FindViewById<TextView>(Resource.Id.text);
            RegisterForContextMenu(_text);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.options_menu, menu);

            return true;
        }

        public override bool OnPrepareOptionsMenu(IMenu menu)
        {
            return base.OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.refresh:
                    toast("Refresh");
                    return true;
                case Resource.Id.bookmarks:
                    toast("Bookmarks");
                    return true;
                case Resource.Id.share:
                    toast("Share");
                    return true;
                case Resource.Id.page_info:
                    toast("Page Info");
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            base.OnCreateContextMenu(menu, v, menuInfo);

            if (v == _text)
            {
                MenuInflater.Inflate(Resource.Menu.context_menu, menu);
                menu.SetHeaderTitle("Favorite browser?");
            }
        }

        public override bool OnContextItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.chrome:
                case Resource.Id.firefox:
                case Resource.Id.opera:
                case Resource.Id.safari:
                case Resource.Id.ie:
                    toast(item.Title.ToString());
                    return true;
                default:
                    return base.OnContextItemSelected(item);
            }
        }

        private void toast(string text)
        {
            Toast
                .MakeText(this, text, ToastLength.Short)
                .Show();
        }
    }
}