using GalaSoft.MvvmLight.Ioc;
using NewsApp.Services;
using NewsApp.ViewModel;
using Xamarin.Forms;

namespace NewsApp.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            ViewModelLocator.Navigation = Navigation;
            BindingContext = App.Locator.Main;
        }

        protected override void OnAppearing()
        {

            var vm = (MainViewModel) BindingContext;
            var networkService = SimpleIoc.Default.GetInstance<INetworkService>();
            vm.InternetCheck = !networkService.IsInternetAvailable() ? "Accertarsi di essere collegati a internet!" : "";

            base.OnAppearing();
        }


    }
}