using System;
using System.Collections.Generic;

namespace Website.racing
{
    public partial class Race
    {
        public Race()
        {
            Event = new HashSet<Event>();
        }

        public int RaceId { get; set; }
        public string Name { get; set; }
        public int Laps { get; set; }
        public int TrackId { get; set; }

        public virtual Track Track { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }
}
