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
        public void Should_return_status_ok_when_route_exists()
        {
            // Given
            var browser = new Browser(with => with.Module(new TransitTimetableModule()));

            // When
            var response = browser.Get("/transit/timetable/2015-05-02",
                with =>
                {
                    with.HttpRequest();
                    with.Header("Accept", "application/json");
                });

            // Then
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var trips = response.Body.DeserializeJson<IEnumerable<TransitTripDetail>>().ToList();
            Assert.Equal(2, trips.Count());
            Assert.Equal("CAB", trips.ElementAt(0).RouteShortName);
            Assert.Equal("Caboolture Line", trips.ElementAt(0).RouteLongName);
            // TODO: Add more asserts
        }
    }
}