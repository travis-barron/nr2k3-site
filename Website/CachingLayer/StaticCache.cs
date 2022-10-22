using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Website.CachingLayer
{
    [System.ComponentModel.DataObject]
    public class StaticCache
    {
        private static List<racing.Config> configs = null;
        private static List<racing.Driver> drivers = null;
        private static List<racing.Event> events = null;
        private static List<racing.Race> races = null;
        private static List<racing.Results> results = null;
        private static List<racing.Schedule> schedules = null;
        private static List<racing.Track> tracks = null;
        public static void LoadStaticCache()
        {
            var context = new racing.racingContext();
            configs = context.Config.ToList();
            drivers = context.Driver.ToList();
            events = context.Event.ToList();
            races = context.Race.ToList();
            results = context.Results.ToList();
            schedules = context.Schedule.ToList();
            tracks = context.Track.ToList();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public static List<racing.Event> GetEvents()
        {
            return events;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public static List<racing.Config> GetConfigs()
        {
            return configs;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public static List<racing.Driver> GetDrivers()
        {
            return drivers;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public static List<racing.Race> GetRaces()
        {
            return races;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public static List<racing.Results> GetResults()
        {
            return results;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public static List<racing.Track> GetTracks()
        {
            return tracks;
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public static List<racing.Schedule> GetSchedules()
        {
            return schedules;
        }
    }
}
