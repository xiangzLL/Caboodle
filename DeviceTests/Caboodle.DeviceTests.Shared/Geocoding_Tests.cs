﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.Caboodle;
using Xunit;

namespace Caboodle.DeviceTests
{
    public class Geocoding_Tests
    {
        public Geocoding_Tests()
        {
            Geocoding.MapKey = "RJHqIE53Onrqons5CNOx~FrDr3XhjDTyEXEjng-CRoA~Aj69MhNManYUKxo6QcwZ0wmXBtyva0zwuHB04rFYAPf7qqGJ5cHb03RCDw1jIW8l";
        }

        [Theory]
        [InlineData(47.673988, -122.121513)]
        public async Task Get_Placemarks_LatLong(double latitude, double longitude)
        {
            var placemarks = await Geocoding.GetPlacemarksAsync(latitude, longitude);

            Assert.NotNull(placemarks);
            Assert.True(placemarks.Any());
        }

        [Theory]
        [InlineData(47.673988, -122.121513)]
        public async Task Get_Placemarks_Location(double latitude, double longitude)
        {
            var placemarks = await Geocoding.GetPlacemarksAsync(new Location(latitude, longitude));

            Assert.NotNull(placemarks);
            Assert.True(placemarks.Any());
        }

        [Theory]
        [InlineData("Microsoft Building 25 Redmond WA USA")]
        public async Task Get_Locations(string address)
        {
            var locations = await Geocoding.GetLocationsAsync(address);

            Assert.NotNull(locations);
            Assert.True(locations.Any());
        }
    }
}
