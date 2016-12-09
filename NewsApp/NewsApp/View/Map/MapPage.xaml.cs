using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace NewsApp.View.Map
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            try
            {
                var position = new Position(double.Parse("45.91094", CultureInfo.InvariantCulture), double.Parse("11.04166999999999", CultureInfo.InvariantCulture));
                var distance = new Distance(200);
                MappaDemo.MoveToRegion(MapSpan.FromCenterAndRadius(position, distance));
                MappaDemo.MapType = MapType.Street;
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = "ITT MARCONI ROVERETO",
                    Address = "Via S. Ilario"
                };
                MappaDemo.Pins.Add(pin);
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ERR::" + ex.Message);
            }
        }



    }
}
