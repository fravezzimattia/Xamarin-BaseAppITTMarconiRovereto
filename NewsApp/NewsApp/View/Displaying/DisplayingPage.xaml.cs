using NewsApp.ViewModel;
using Xamarin.Forms;

namespace NewsApp.View.Displaying
{
    public partial class DisplayingPage : ContentPage
    {
        public DisplayingPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.DisplayingVm;
        }

        protected override void OnAppearing()
        {
            var vm = (DisplayingViewModel) this.BindingContext;
            vm.Init();
        }
    }
}
