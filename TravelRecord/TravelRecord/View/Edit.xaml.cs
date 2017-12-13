using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using TravelRecord.ViewModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace TravelRecord.View
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class Edit : Page
    {
        public Edit()
        {
            this.InitializeComponent();
        }

        private void Location_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var access = await Geolocator.RequestAccessAsync();
            switch (access)
            {
                case GeolocationAccessStatus.Allowed:
                    // set some stuff up now.
                    tblStatus.Text = "Setting up location services";
                    myGeo = new Geolocator();
                    // myGeo.StatusChanged += MyGeo_StatusChanged;
                    //myGeo.PositionChanged not needed just now.
                    myGeo.DesiredAccuracy = PositionAccuracy.High;
                    break;
                case GeolocationAccessStatus.Denied:
                case GeolocationAccessStatus.Unspecified:
                    // ask the user for something here if things go wrong.
                    tblStatus.Text = "Can't access location services";
                    break;
                default:
                    break;
            }
            TextBlock ShowText;
            // get the current locations
            try
            {
                _pos = await myGeo.GetGeopositionAsync();
            }
            catch (Exception ex)
            {

                return;
            }
            BasicGeoposition myLocation = new BasicGeoposition
            {
                Longitude = _pos.Coordinate.Point.Position.Longitude,
                Latitude = _pos.Coordinate.Point.Position.Latitude
            };
            Geopoint pointToReverseGeocode = new Geopoint(myLocation);
            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);
            ShowText = new TextBlock();
            ShowText.Text = "Location: " + result.Locations[0].Address.Country + result.Locations[0].Address.District + result.Locations[0].Address.Town + result.Locations[0].Address.Street;




        }

        private void Submit_Tapped(object sender, TappedRoutedEventArgs e)
        {

        }
    }
}
