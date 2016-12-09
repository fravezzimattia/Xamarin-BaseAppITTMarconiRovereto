using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using NewsApp.Data.Repositories;
using NewsApp.Interfaces;
using NewsApp.Services;
using Xamarin.Forms;

namespace NewsApp.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public LayoutsViewModel LayoutsVm => ServiceLocator.Current.GetInstance<LayoutsViewModel>();
        public DisplayingViewModel DisplayingVm => ServiceLocator.Current.GetInstance<DisplayingViewModel>();
        public PagesViewModel PagesVm => ServiceLocator.Current.GetInstance<PagesViewModel>();
        public LoginViewModel LoginVm => ServiceLocator.Current.GetInstance<LoginViewModel>();
        public static INavigation Navigation { get; set; }
        public static Page CurrentPage { get; set; }
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            Resources.Resources.Culture = DependencyService.Get<ILocalize>()?.GetCurrentCultureInfo();

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LayoutsViewModel>();
            SimpleIoc.Default.Register<DisplayingViewModel>();
            SimpleIoc.Default.Register<PagesViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();

            SimpleIoc.Default.Register<INavigationService>(() => new NavigationService(Navigation));
            SimpleIoc.Default.Register<INewsRepository>(() => new NewsRepository());

            ISQLite sqLiteService = DependencyService.Get<ISQLite>();
            SimpleIoc.Default.Register<ISQLite>(() => sqLiteService);

            INetworkService networkService = DependencyService.Get<INetworkService>();
            SimpleIoc.Default.Register<INetworkService>(() => networkService);

            IHubNotificationService hubNotificationService = DependencyService.Get<IHubNotificationService>();
            SimpleIoc.Default.Register<IHubNotificationService>(() => hubNotificationService);
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}