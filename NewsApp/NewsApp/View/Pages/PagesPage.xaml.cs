using Xamarin.Forms;

namespace NewsApp.View.Pages
{
    public partial class PagesPage : ContentPage
    {
        public PagesPage()
        {
            InitializeComponent();

            BindingContext = App.Locator.PagesVm;
        }
    }
}