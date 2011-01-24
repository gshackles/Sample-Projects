using Android.App;
using Android.Content;
using Android.Database;
using Android.Net;
using Android.OS;
using Android.Provider;
using Android.Widget;

namespace MonoDroidSamples.DemoActivities.Contacts
{
    [Activity(Label = "Contacts Demo")]
    public class ContactsActivity : Activity
    {
        private ListView _list;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.contacts_list);

            _list = FindViewById<ListView>(Resource.Id.contact_list);

            var contacts = ManagedQuery(ContactsContract.Contacts.ContentUri, null, null, null, null);

            _list.Adapter = 
                new SimpleCursorAdapter(
                    this, 
                    Resource.Layout.contacts_item, 
                    contacts, 
                    new string[] { ContactsContract.ContactsColumnsConsts.DisplayName }, 
                    new int[] { Resource.Id.contact_name });
            _list.ItemClick += new System.EventHandler<ItemEventArgs>(_list_ItemClick);
        }

        void _list_ItemClick(object sender, ItemEventArgs e)
        {
            var item = (ICursor)_list.Adapter.GetItem(e.Position);
            int id = item.GetInt(item.GetColumnIndex("_id"));
            var intent = new Intent(Intent.ActionView);
            var uri = Uri.WithAppendedPath(ContactsContract.Contacts.ContentUri, id.ToString());

            intent.SetData(uri);
            StartActivity(intent);
        }
    }
}