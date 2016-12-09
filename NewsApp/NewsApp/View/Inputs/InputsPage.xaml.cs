using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace NewsApp.View.Inputs
{
    public partial class InputsPage : ContentPage
    {
        public InputsPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            DisplayAlert("CLICK BOTTONE", "cliccato un bottone", "Ok", "Annulla");
        }
    }
}
