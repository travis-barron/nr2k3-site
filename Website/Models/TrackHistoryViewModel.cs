using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class TrackHistoryViewModel
    {
        public List<RaceViewModel> races { get; set; }
        public string TrackLayout { get; set; }
        public string TrackIcon { get; set; }

        public TrackHistoryViewModel()
        {
            races = new List<RaceViewModel>();
        }
    }
}
