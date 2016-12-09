using System.Net.NetworkInformation;
using Windows.Networking.Connectivity;
using NewsApp.Services;
using NewsApp.UWP.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(NetworkService))]
namespace NewsApp.UWP.Services
{
    public class NetworkService : INetworkService
    {
        public bool IsInternetAvailable()
        {
            bool isConnected = NetworkInterface.GetIsNetworkAvailable();
            if (isConnected)
            {

                ConnectionProfile internetConnectionProfile = NetworkInformation.GetInternetConnectionProfile();
                NetworkConnectivityLevel connection = internetConnectionProfile.GetNetworkConnectivityLevel();
                return connection != NetworkConnectivityLevel.None && connection != NetworkConnectivityLevel.LocalAccess;
            }
            return false;
        }
    }
}
