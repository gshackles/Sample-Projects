using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using MonoDroidSamples.DemoActivities.Animations;
using MonoDroidSamples.DemoActivities.Assets;
using MonoDroidSamples.DemoActivities.BroadcastReceivers;
using MonoDroidSamples.DemoActivities.ButtonClick;
using MonoDroidSamples.DemoActivities.Contacts;
using MonoDroidSamples.DemoActivities.Database;
using MonoDroidSamples.DemoActivities.Localization;
using MonoDroidSamples.DemoActivities.LocationDemo;
using MonoDroidSamples.DemoActivities.Menu;
using MonoDroidSamples.DemoActivities.OpenGL;
using MonoDroidSamples.DemoActivities.Preferences;
using MonoDroidSamples.DemoActivities.Services;
using MonoDroidSamples.DemoActivities.TextNotify;

namespace MonoDroidSamples
{
    [Activity(Label = "MonoDroid Samples", MainLauncher = true)]
    public class MenuActivity : ListActivity
    {
        private static MenuItem[] _menuItems = 
        { 
            new MenuItem("Button Click", typeof(ButtonClickActivity)),
            new MenuItem("Text Notifications", typeof(TextNotifyActivity)),
            new MenuItem("Contacts List", typeof(ContactsActivity)),
            new MenuItem("Pick a contact", typeof(PickContactActivity)),
            new MenuItem("Shared preferences", typeof(PreferencesActivity)),
            new MenuItem("Menus", typeof(MenuDemoActivity)),
            new MenuItem("Assets", typeof(AssetActivity)),
            new MenuItem("Database", typeof(NoteListActivity)),
            new MenuItem("Animations", typeof(AnimationActivity)),
            new MenuItem("Services", typeof(ServiceActivity)),
            new MenuItem("Localization", typeof(LocalizationActivity)),
            new MenuItem("OpenGL", typeof(OpenGLActivity)),
            new MenuItem("Broadcast Receiver", typeof(ReceiverActivity)),
            new MenuItem("Location", typeof(LocationActivity))
        };

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ListAdapter = new MenuItemAdapter(this, _menuItems);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            StartActivity(_menuItems[position].Type);
        }
    }
}

