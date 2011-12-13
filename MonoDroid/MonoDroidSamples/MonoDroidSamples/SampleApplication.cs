using System;
using Android.App;
using Android.Runtime;
using MonoDroidSamples.DemoActivities.Database;

namespace MonoDroidSamples
{
    [Application]
    public class SampleApplication : Application
    {
        public NoteDatabaseAdapter NoteDatabaseAdapter { get; private set; }

        public SampleApplication(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            var helper = new NoteDatabaseHelper(this, NoteDatabaseConstants.DatabaseName, null, NoteDatabaseConstants.DatabaseVersion);
            NoteDatabaseAdapter = new NoteDatabaseAdapter(helper);
            NoteDatabaseAdapter.AddNote("Sample Title", "Sample content........");
        }
    }
}