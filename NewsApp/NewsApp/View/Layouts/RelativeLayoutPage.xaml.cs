using Xamarin.Forms;

namespace NewsApp.View.Layouts
{
    public partial class RelativeLayoutPage : ContentPage
    {
        public RelativeLayoutPage()
        {
            InitializeComponent();

            var heading = new Label
            {
                Text = "RelativeLayout Example",
                TextColor = Color.Red,
            };

            var relativelyPositioned = new Label
            {
                Text = "Positioned relative to my parent."
            };

            var relativeLayout = new RelativeLayout();

            relativeLayout.Children.Add(heading, Constraint.RelativeToParent((parent) => 0));

            relativeLayout.Children.Add(relativelyPositioned,
                Constraint.RelativeToParent((parent) => parent.Width / 3),
                Constraint.RelativeToParent((parent) => parent.Height / 2));

            Content = relativeLayout;
        }
    }
}
