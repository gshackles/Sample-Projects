using System;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;

namespace MonoDroidSamples.DemoActivities.Services
{
    [Service]
    public class MusicService : Service
    {
        private MediaPlayer _player;
        private NotificationManager _notificationManager;

        private enum Notifications { Started };

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            _player = MediaPlayer.Create(this, Resource.Raw.volbeat);
            _player.Looping = false;

            _notificationManager = (NotificationManager)GetSystemService(NotificationService);

            var notification = new Notification(Resource.Drawable.icon, "Service started", DateTime.Now.Ticks);
            notification.Flags = NotificationFlags.NoClear;

            PendingIntent notificationIntent = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(ServiceActivity)), 0);
            notification.SetLatestEventInfo(this, "Music Service", "The music service has been started", notificationIntent);

            _notificationManager.Notify((int)Notifications.Started, notification);
        }

        public override void OnStart(Intent intent, int startId)
        {
            base.OnStart(intent, startId);

            _player.Start();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            _player.Stop();
            _notificationManager.CancelAll();
        }
    }
}