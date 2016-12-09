using NewsApp.Droid.Services;
using System.Globalization;

[assembly: Xamarin.Forms.Dependency(typeof(Localize))]

namespace NewsApp.Droid.Services
{
    public class Localize : Interfaces.ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var androidLocale = Java.Util.Locale.Default;
            var netLanguage = androidLocale.ToString().Replace("_", "-");
            return new CultureInfo(netLanguage);
        }
    }
}