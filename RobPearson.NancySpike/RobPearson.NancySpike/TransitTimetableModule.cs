using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;

namespace RobPearson.NancySpike
{
    /// <summary>
    /// Transit Timetable Module
    /// https://api.maplepixel.com.au/transit/timetable
    /// </summary>
    public class TransitTimetableModule : NancyModule
    {
        public TransitTimetableModule()
    {
        // would capture routes to /products/list sent as a GET request
        Get["/transit/timetable"] = parameters => {
            return "All Transit Times for today";
        };
    }
    }
}