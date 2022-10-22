using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class RaceResultsViewModel
    {
        public List<RaceViewModel> Events { get; set; }
        public int ShowRaceModal { get; set; }

        public RaceResultsViewModel()
        {
            Events = new List<RaceViewModel>();
        }
    }
}
