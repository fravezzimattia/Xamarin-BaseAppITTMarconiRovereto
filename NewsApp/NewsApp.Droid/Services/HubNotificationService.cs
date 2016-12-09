using System.Collections.Generic;
using System.Text;
using Android.App;
using Android.Content;
using Android.Util;
using Gcm.Client;
using WindowsAzure.Messaging;
using Android.Graphics;
using Android.Support.V4.App;
using System;
using Android.OS;
using NewsApp.Droid.Services;
using NewsApp.Services;

[assembly: Permission(Name = "com.microsoft.newsapp.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.microsoft.newsapp.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]

//GET_ACCOUNTS is needed only for Android versions 4.0.3 and below
[assembly: UsesPermission(Name = "android.permission.INTERNET")]
[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]
[assembly: Xamarin.Forms.Dependency(typeof(HubNotificationService))]
namespace NewsApp.Droid.Services
{
    [BroadcastReceiver(Permission = Gcm.Client.Constants.PERMISSION_GCM_INTENTS)]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_MESSAGE },Categories = new string[] { "com.microsoft.newsapp" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_REGISTRATION_CALLBACK },Categories = new string[] { "com.microsoft.newsapp" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_LIBRARY_RETRY },Categories = new string[] { "com.microsoft.newsapp" })]
    class HubNotificationService : GcmBroadcastReceiverBase<PushHandlerService>, IHubNotificationService
    {
        public static string[] SENDER_IDS = new string[] { MainActivity.SenderId };

        public const string TAG = "";
    }
    [Service] // Must use the service tag
    public class PushHandlerService : GcmServiceBase
    {
        public static string RegistrationID { get; private set; }
        private static NotificationHub Hub { get; set; }

        public PushHandlerService() : base(MainActivity.SenderId)
        {
            Log.Info(HubNotificationService.TAG, "PushHandlerService() constructor");
        }

        protected override void OnMessage(Context context, Intent intent)
        {
            Log.Info(HubNotificationService.TAG, "GCM Message Received!");




            var msg = new StringBuilder();

            if (intent != null && intent.Extras != null)
            {
                foreach (var key in intent.Extras.KeySet())
                    msg.AppendLine(key + "=" + intent.Extras.Get(key).ToString());
            }

            string messageText = intent.Extras.GetString("message");
            if (!string.IsNullOrEmpty(messageText))
            {

                createNotification("Nuovo messaggio dalla farmacia!", messageText);
            }
            else
            {
                createNotification("Unknown message details", msg.ToString());
            }

        }

        protected override void OnError(Context context, string errorId)
        {
            Log.Error(HubNotificationService.TAG, "GCM Error: " + errorId);
        }

        protected override void OnRegistered(Context context, string registrationId)
        {
            Log.Verbose(HubNotificationService.TAG, "GCM Registered: " + registrationId);
            RegistrationID = registrationId;

            //createNotification("PushHandlerService-GCM Registered...",
            //    "The device has been Registered!");



            Hub = new NotificationHub(MainActivity.NotificationHubName, MainActivity.ListenConnectionString, context);


            try
            {
                Hub.UnregisterAll(registrationId);
            }
            catch (Exception ex)
            {
                Log.Error(HubNotificationService.TAG, ex.Message);
            }

            //var tags = new List<string>() { "falcons" }; //create tags if you want
            try
            {
                var hubRegistration = Hub.Register(registrationId, null);
            }
            catch (Exception ex)
            {
                Log.Error(HubNotificationService.TAG, ex.Message);
            }
        }

        protected override void OnUnRegistered(Context context, string registrationId)
        {
            Log.Verbose(HubNotificationService.TAG, "GCM Unregistered: " + registrationId);

            //createNotification("GCM Unregistered...", "The device has been unregistered!");
        }

        void createNotification(string title, string desc)
        {
            //Create notification
            var notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;


            //Create an intent to show UI
            var uiIntent = new Intent(this, typeof(MainActivity));

            //Create the notification

            PendingIntent contentIntent = PendingIntent.GetActivity(this,
             0, uiIntent,
            (PendingIntentFlags)NotificationFlags.AutoCancel);

            NotificationCompat.Builder builder = new NotificationCompat.Builder(this);


            builder.SetContentIntent(contentIntent)

//                .SetSmallIcon(Resource.Drawable.arrowCategorieDOWN)
  //              .SetLargeIcon(BitmapFactory.DecodeResource(Resources, Resource.Drawable.Icon))
                .SetAutoCancel(true)
                .SetContentTitle(title)
                .SetContentText(desc)
                .SetDefaults((int)NotificationDefaults.Vibrate);

            Notification n = builder.Build();


            dialogNotify(title, desc);
            notificationManager.Notify(1, n);
        }

        protected void dialogNotify(string title, string message)
        {
            MainActivity.Instance.RunOnUiThread(() =>
            {
                AlertDialog.Builder dlg = new AlertDialog.Builder(MainActivity.Instance);
                AlertDialog alert = dlg.Create();
                alert.SetTitle(title);
                alert.SetButton("Ok", delegate
                {
                    alert.Dismiss();
                });
                alert.SetMessage(message);
                alert.Show();
            });
        }
    }
}