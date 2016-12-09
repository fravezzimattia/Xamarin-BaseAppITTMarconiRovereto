using System.Globalization;
using Foundation;
using NewsApp.iOS.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]

namespace NewsApp.iOS.Services
{
    public class Localize : Interfaces.ILocalize
    {
        public CultureInfo GetCurrentCultureInfo()
        {
            var netLanguage = "it";
            var prefLanguageOnly = "it";
            CultureInfo ci;

            if (NSLocale.PreferredLanguages.Length > 0)
            {
                var pref = NSLocale.PreferredLanguages[0];
                prefLanguageOnly = pref.Substring(0, 2);
                netLanguage = pref.Replace("_", "-");
            }
            
            try
            {
                ci = new CultureInfo(netLanguage);
            }
            catch
            {
                // iOS locale not valid .NET culture (eg. "en-ES" : English in Spain)
                // fallback to first characters, in this case "en"
                ci = new CultureInfo(prefLanguageOnly);
            }
            return ci;
        }
    }
}