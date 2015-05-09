using System;
using System.Collections.Generic;
using System.Linq;
using Nancy;
using Nancy.Testing;
using Xunit;

namespace RobPearson.NancySpike.Test
{
    public class TransitTimetableModuleTest
    {
        [Fact]
        public void Can_Get_Request()
        {
            // Given
            var browser = new Browser(with =>
            {
                with.Module<TransitTimetableModule>();
                with.EnableAutoRegistration();
            });

            // When
            var response = browser.Get("/transit/timetable/2015-05-2",
                with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                });

            // Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var trips = response.Body.DeserializeJson<IEnumerable<TransitTripDetail>>().ToList();
            Assert.Equal(2, trips.Count());
            Assert.Equal("CAB", trips[0].RouteShortName);
            Assert.Equal("Caboolture Line", trips[0].RouteLongName);
            Assert.Equal("Bald Hills", trips[0].DepartingStopName);
            Assert.Equal("Platform 1", trips[0].DepartingPlatform);
            Assert.Equal(new DateTime(2015, 05, 02, 08, 02, 00).ToString("s"), trips[0].DepartingTime.ToString("s"));
            Assert.Equal("12345.6, 5555.6", trips[0].DepartingLocation);
            Assert.Equal("Central", trips[0].ArrivingStopName);
            Assert.Equal("Platform 5", trips[0].ArrivingPlatform);
            Assert.Equal(new DateTime(2015, 05, 02, 08, 34, 00).ToString("s"), trips[0].ArrivingTime.ToString("s"));
            Assert.Equal("1235.77, 98171.1", trips[0].ArrivingLocation);

            Assert.Equal("CAB", trips[1].RouteShortName);
            Assert.Equal("Caboolture Line", trips[1].RouteLongName);
            Assert.Equal("Bald Hills", trips[1].DepartingStopName);
            Assert.Equal("Platform 1", trips[1].DepartingPlatform);
            Assert.Equal(new DateTime(2015, 05, 02, 08, 14, 00).ToString("s"), trips[1].DepartingTime.ToString("s"));
            Assert.Equal("12345.6, 5555.6", trips[1].DepartingLocation);
            Assert.Equal("Central", trips[1].ArrivingStopName);
            Assert.Equal("Platform 5", trips[1].ArrivingPlatform);
            Assert.Equal(new DateTime(2015, 05, 02, 08, 47, 00).ToString("s"), trips[1].ArrivingTime.ToString("s"));
            Assert.Equal("1235.77, 98171.1", trips[1].ArrivingLocation);
        }

        [Fact]
        public void Can_Post_Request()
        {
            // Given
            var trip = new FavouriteTrip
            {
                TripId = Guid.NewGuid().ToString(),
                DepartingStopId = "1234",
                DepartingChildStopIds = "221, 224, 225",
                DepartingStopName = "Bald Hills",
                DepartingLocation = "12345.6, 5555.6",
                ArrivingStopId = "4533",
                ArrivingChildStopIds = "551, 552, 553, 554, 555, 556",
                ArrivingLocation = "1235.77, 98171.1",
                ArrivingStopName = "Central"
            };
            var browser = new Browser(with =>
            {
                with.Module<TransitTimetableModule>();
                with.EnableAutoRegistration();
            });

            // When
            var response = browser.Post("/transit/FavouriteTrip",
                with =>
                {
                    with.HttpRequest();
                    with.JsonBody(trip);
                });

            // Then
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal("/transit/FavouriteTrip/1", response.Headers["Location"]);
        }
    }
}