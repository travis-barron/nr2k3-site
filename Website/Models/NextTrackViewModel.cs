using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class NextTrackViewModel
    {
        public string image { get; set; }
        public float trackLength { get; set; }
        public string trackType { get; set; }
        public string previousWinner { get; set; }
        public int laps { get; set; }
        public string mostWins { get; set; }
        public string mostLed { get; set; }
    }
}
