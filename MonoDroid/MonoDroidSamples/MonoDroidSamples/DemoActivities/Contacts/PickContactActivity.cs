using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Provider;

namespace MonoDroidSamples.DemoActivities.Contacts
{
    [Activity(Label = "Pick Contact Demo")]
    public class PickContactActivity : Activity
    {
        private const int PICK_CONTACT = 42;
        private Button _button;
        private TextView _contactName;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.pick_contact);

            _button = FindViewById<Button>(Resource.Id.button);
            _contactName = FindViewById<TextView>(Resource.Id.contact_name);

            _button.Click += delegate
            {
                var intent = new Intent(Intent.ActionPick, ContactsContract.Contacts.ContentUri); 
                StartActivityForResult(intent, PICK_CONTACT);
            };
        }

        protected override void  OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
 	        if (requestCode == PICK_CONTACT) 
            {
                string id = data.Data.LastPathSegment;
                var contacts = ManagedQuery(ContactsContract.Contacts.ContentUri, null, "_id = ?", new string[] { id }, null);
                contacts.MoveToFirst();

                _contactName.Text = "Got contact: " + contacts.GetString(contacts.GetColumnIndex("display_name"));
            }
        }
    }
}