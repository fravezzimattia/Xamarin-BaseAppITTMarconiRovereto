using System.Globalization;
using NewsApp.UWP.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]

namespace NewsApp.UWP.Services
{
    public class Localize : Interfaces.ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            return CultureInfo.CurrentCulture;
        }
    }
}