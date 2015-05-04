using System;
using System.Collections.Generic;
using Nancy;

namespace RobPearson.NancySpike
{
    /// <summary>
    ///     Transit Timetable Module
    ///     https://api.maplepixel.com.au/transit/timetable
    /// </summary>
    public class TransitTimetableModule : NancyModule
    {
        public TransitTimetableModule()
        {
            Get["/transit/timetable/{timestamp}"] = p => GetTransitTimeTable(p.timestamp);
        }

        private IEnumerable<TransitTripDetail> GetTransitTimeTable(DateTime timestamp)
        {
            var timetable = new List<TransitTripDetail>();

            var trip1 = new TransitTripDetail
            {
                RouteShortName = "CAB",
                RouteLongName = "Caboolture Line",
                DepartingStopName = "Bald Hills",
                DepartingPlatform = "Platform 1",
                DepartingTime = new DateTime(timestamp.Year, timestamp.Month, timestamp.Day, 08, 02, 00),
                DepartingLocation = "12345.6, 5555.6",
                ArrivingStopName = "Central",
                ArrivingPlatform = "Platform 5",
                ArrivingTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 08, 34, 00),
                ArrivingLocation = "1235.77, 98171.1"
            };

            var trip2 = new TransitTripDetail
            {
                RouteShortName = "CAB",
                RouteLongName = "Caboolture Line",
                DepartingStopName = "Bald Hills",
                DepartingPlatform = "Platform 1",
                DepartingTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 08, 14, 00),
                DepartingLocation = "12345.6, 5555.6",
                ArrivingStopName = "Central",
                ArrivingPlatform = "Platform 5",
                ArrivingTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 08, 47, 00),
                ArrivingLocation = "1235.77, 98171.1"
            };

            timetable.Add(trip1);
            timetable.Add(trip2);

            return timetable;
        }
    }

    public class TransitTripDetail
    {
        public string RouteShortName { get; set; }
        public string RouteLongName { get; set; }
        public string DepartingStopName { get; set; }
        public string DepartingPlatform { get; set; }
        public DateTime DepartingTime { get; set; }
        public string DepartingLocation { get; set; }
        public string ArrivingStopName { get; set; }
        public string ArrivingPlatform { get; set; }
        public DateTime ArrivingTime { get; set; }
        public string ArrivingLocation { get; set; }
    }
}