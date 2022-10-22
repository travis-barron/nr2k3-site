using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Website.racing;

namespace Website.Models
{
    public class DriverViewModel
    {
        public racing.Driver Driver { get; set; }
        public List<racing.Results> Results { get; set; }
        public Dictionary<int, int> rank { get; set; }
        public List<DriverTrackStats> TrackStats { get; set; }

        public DriverViewModel()
        {
            Driver = new racing.Driver();
            Results = new List<racing.Results>();
            rank = new Dictionary<int, int>();
            TrackStats = new List<DriverTrackStats>();
        }
    }

    public class DriverTrackStats
    {
        public racing.Track Track { get; set; }
        public int Races { get; set; }
        public int BestFinish { get; set; }
        public float AverageFinish { get; set; }
        public float AverageStart { get; set; }
        public int Laps { get; set; }
        public int LapsLed { get; set; }
        public int Poles { get; set; }
        public int DNFs { get; set; }
        public int Wins { get; set; }

        public DriverTrackStats()
        {
            Track = new racing.Track();
        }
    }

    public class TrackPerformanceStats
    {
        public string RaceYearNum { get; set; }
        public int Start { get; set; }
        public int Finish { get; set; }
        public int Laps { get; set; }
        public int Led { get; set; }
        public string Status { get; set; }
        public string TrackIcon { get; set; }
        public string TrackLayout { get; set; }
        public string TrackName { get; set; }
    }

    public class SeasonPerformanceStats
    {
        public string RaceName { get; set; }
        public string Track { get; set; }
        public int trackID { get; set; }
        public int Start { get; set; }
        public int Finish { get; set; }
        public int Laps { get; set; }
        public int Led { get; set; }
        public string Status { get; set; }
        public int RaceNum { get; set; }
    }
}
