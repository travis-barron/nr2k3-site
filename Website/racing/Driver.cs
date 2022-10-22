using System;
using System.Collections.Generic;

namespace Website.racing
{
    public partial class Driver
    {
        public Driver()
        {
            Headline = new HashSet<Headline>();
            Results = new HashSet<Results>();
            Roster = new HashSet<Roster>();
        }

        public int DriverId { get; set; }
        public string Name { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }

        public virtual ICollection<Headline> Headline { get; set; }
        public virtual ICollection<Results> Results { get; set; }
        public virtual ICollection<Roster> Roster { get; set; }
    }
}
