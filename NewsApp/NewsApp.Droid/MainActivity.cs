using System;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using Gcm.Client;
using Debug = System.Diagnostics.Debug;

namespace NewsApp.Droid
{
    [Activity(Label = "NewsApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private const int RequestId = 0;
        //TODO ANDRODID - Sender ID is Google Api Poject Number
        public const string SenderId = "533819xxxxx";
        //TODO ANDRODID - ListenConnectionString take it from Azure portal when you create new NOTIFICATION HUB 
        public const string ListenConnectionString = "Endpoint=sb://xxxxxxxxxxxxxx.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=xxxxxx/XXXXXXXXXXXXXXXXXXXXXXXXXXXX=";
        //TODO ANDRODID - NotificationHubName take it from Azure portal when you create new NOTIFICATION HUB 
        public const string NotificationHubName = "xxxxxNotificationHub";


        public static MainActivity Instance;
        //permessi da richiedere
        private readonly string[] _permissionsLocation =
        {
                Manifest.Permission.AccessFineLocation,
        };

        private async Task<bool> ShowPermission()
        {
            ActivityCompat.RequestPermissions(this, _permissionsLocation, RequestId);
            return await Task.FromResult<bool>(true);
        }


        protected override async void OnCreate(Bundle bundle)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Instance = this;
            await ShowPermission();
            RegisterWithGcm();
            LoadApplication(new App());
        }


        public void RegisterWithGcm()
        {
            // Check to ensure everything's set up right
            GcmClient.CheckDevice(this);
            GcmClient.CheckManifest(this);

            // Register for push notifications
            Debug.WriteLine("ANDROID- REGISTER PUSH NORIFICATION");
            Log.Info("MainActivity", "Registering...");
            GcmClient.Register(this, SenderId);
        }
    }
}

