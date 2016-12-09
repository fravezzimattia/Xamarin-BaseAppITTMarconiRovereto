using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsApp.ViewModel;
using Xamarin.Forms;

namespace NewsApp.View.Layouts
{
    public partial class LayoutsPage : ContentPage
    {
        public LayoutsPage()
        {
            InitializeComponent();
            ViewModelLocator.Navigation = Navigation;
            BindingContext = App.Locator.LayoutsVm;
        }
    }
}
