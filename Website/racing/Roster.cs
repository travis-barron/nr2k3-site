using System;
using System.Collections.Generic;

namespace Website.racing
{
    public partial class Roster
    {
        public int RosterId { get; set; }
        public int ScheduleId { get; set; }
        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}
