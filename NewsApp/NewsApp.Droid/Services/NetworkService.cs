using Android.App;
using Android.Content;
using Android.Net;
using NewsApp.Droid.Services;
using NewsApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkService))]
namespace NewsApp.Droid.Services
{
    public class NetworkService : INetworkService
    {
        public bool IsInternetAvailable()
        {
            var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var activeConnection = connectivityManager.ActiveNetworkInfo;
            return activeConnection != null && activeConnection.IsConnected;
        }
    }
}
