using System;
using System.Collections.Generic;
using Nancy;
using Nancy.ModelBinding;

namespace RobPearson.NancySpike
{
    /// <summary>
    ///     Transit Module
    ///     https://api.maplepixel.com.au/transit/
    /// </summary>
    public class TransitTimetableModule : NancyModule
    {
        public TransitTimetableModule()
        {
            Get["/transit/timetable/{timestamp}"] = p => GetTransitTimeTable(p.timestamp);

            Post["/transit/FavouriteTrip"] = p =>
            {
                // TODO: This should probably be in something like a settings module
                var trip = this.Bind<FavouriteTrip>();

                // TODO: Repo should be injected
                var settingsRepo = new SettingsRepository();
                var id = settingsRepo.SaveFavouriteTrip(trip);

                // TODO: Add url to response for new resource
                return HttpStatusCode.OK;
            };
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
                ArrivingTime = new DateTime(timestamp.Year, timestamp.Month, timestamp.Day, 08, 34, 00),
                ArrivingLocation = "1235.77, 98171.1"
            };

            var trip2 = new TransitTripDetail
            {
                RouteShortName = "CAB",
                RouteLongName = "Caboolture Line",
                DepartingStopName = "Bald Hills",
                DepartingPlatform = "Platform 1",
                DepartingTime = new DateTime(timestamp.Year, timestamp.Month, timestamp.Day, 08, 14, 00),
                DepartingLocation = "12345.6, 5555.6",
                ArrivingStopName = "Central",
                ArrivingPlatform = "Platform 5",
                ArrivingTime = new DateTime(timestamp.Year, timestamp.Month, timestamp.Day, 08, 47, 00),
                ArrivingLocation = "1235.77, 98171.1"
            };

            timetable.Add(trip1);
            timetable.Add(trip2);

            return timetable;
        }
    }

    public interface ISettingsRepository
    {
        int SaveFavouriteTrip(FavouriteTrip trip);
    }

    public class SettingsRepository : ISettingsRepository
    {
        public int SaveFavouriteTrip(FavouriteTrip trip)
        {
            // Do nothing for now
            return 1;
        }
    }

    public class FavouriteTrip
    {
        public string TripId { get; set; }
        public string DepartingStopId { get; set; }
        public string DepartingChildStopIds { get; set; }
        public string DepartingStopName { get; set; }
        public string DepartingLocation { get; set; }
        public string ArrivingStopId { get; set; }
        public string ArrivingChildStopIds { get; set; }
        public string ArrivingLocation { get; set; }
        public string ArrivingStopName { get; set; }
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