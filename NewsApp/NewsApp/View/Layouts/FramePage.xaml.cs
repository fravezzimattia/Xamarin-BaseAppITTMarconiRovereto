using Xamarin.Forms;

namespace NewsApp.View.Layouts
{
    public partial class FramePage : ContentPage
    {
        public FramePage()
        {
            InitializeComponent();
            Content = new Frame
            {
                Content = new Label {Text = "I'm a Frame!"},
                OutlineColor = Color.Silver,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center
            };
        }
    }
}
