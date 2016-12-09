using NewsApp.iOS.Services;
using NewsApp.Services;

[assembly: Xamarin.Forms.Dependency(typeof(NetworkService))]

namespace NewsApp.iOS.Services
{
    public class NetworkService : INetworkService
    {
        public bool IsInternetAvailable()
        {
            NetworkStatus status = Reachability.InternetConnectionStatus();
            return status == NetworkStatus.ReachableViaWiFiNetwork ||
                   status == NetworkStatus.ReachableViaCarrierDataNetwork;
        }
    }
}