using Plugin.Geolocator;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Fabrikam
{
    public partial class MapsPage : ContentPage
    {
        public MapsPage()
        {
            InitializeComponent();

            DisplayMap();
        }
        /*
         * Method to display the map.  Shows current location of user and a custom pin 
         * pointing to fabrikam
         */ 
        public async void DisplayMap()
        {
            var curlocator = CrossGeolocator.Current;   // current location
            var Userposition = await curlocator.GetPositionAsync(10000);    // position of user
            // map object
            var map = new Map(
                MapSpan.FromCenterAndRadius(
                    new Position(Userposition.Latitude, Userposition.Longitude), Distance.FromMiles(1)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            // custom pin
            var fabrikamLocation = new Position(-36.849194, 174.765194); // Latitude, Longitude
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = fabrikamLocation,
                Label = "Fabrikam Foods",
                Address = "203 Queen Street"
            };
            map.Pins.Add(pin);
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;
        }
    }
}
