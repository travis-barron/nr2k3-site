using Website.racing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class TrackStatsViewModel
    {
        public List<TSVTrack> trackList { get; set; }

        public class TSVTrack
        {
            public racing.Track Track { get; set; }
            public string PreviousWinner { get; set; }
            public int RaceCount { get; set; }
            public List<racing.Schedule> Schedules { get; set; }
            public List<AllTimeWinner> AllTimeWinner { get; set; }
            public List<AllTimeLeaders> AllTimeLeader { get; set; }

            public TSVTrack()
            {
                Schedules = new List<racing.Schedule>();
                AllTimeWinner = new List<AllTimeWinner>();
            }
            
        }

        public TrackStatsViewModel()
        {
            trackList = new List<TSVTrack>();
        }
    }
}
