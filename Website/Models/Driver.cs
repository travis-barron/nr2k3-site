using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class Driver
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public int Starts { get; set; }
        public int Points { get; set; }
        public int Wins { get; set; }
        public int Top5 { get; set; }
        public int Top10 { get; set; }
        public int Pole { get; set; }
        public int DNF { get; set; }
        public int Laps { get; set; }
        public int LapsLed { get; set; }
        public List<int> Finishes { get; set; }
        public float AvgFin { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }
        public int DriverId { get; set; }
    }
}
