using System;
using System.Collections.Generic;

namespace Website.racing
{
    public partial class Schedule
    {
        public Schedule()
        {
            Event = new HashSet<Event>();
            Roster = new HashSet<Roster>();
        }

        public int ScheduleId { get; set; }
        public string Series { get; set; }
        public int Year { get; set; }
        public int IsActive { get; set; }
        public int? PlayoffSystemId { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Roster> Roster { get; set; }
    }
}
