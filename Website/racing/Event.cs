using System;
using System.Collections.Generic;

namespace Website.racing
{
    public partial class Event
    {
        public Event()
        {
            Results = new HashSet<Results>();
        }

        public int EventId { get; set; }
        public int RaceId { get; set; }
        public int TrackId { get; set; }
        public int ScheduleId { get; set; }
        public int RaceNum { get; set; }
        public int? Cautions { get; set; }

        public virtual Race Race { get; set; }
        public virtual Schedule Schedule { get; set; }
        public virtual Track Track { get; set; }
        public virtual ICollection<Results> Results { get; set; }
    }
}
