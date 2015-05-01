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
            var bootstrapper = new DefaultNancyBootstrapper();
            var browser = new Browser(bootstrapper);

            // When
            var result = browser.Get("/transit/timetable", with => { with.HttpRequest(); });

            // Then
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
//            Assert.Equal("", result.Body);
        }
    }
}