using System;
using System.Collections.Generic;

namespace Website.racing
{
    public partial class Track
    {
        public Track()
        {
            Event = new HashSet<Event>();
            Race = new HashSet<Race>();
        }

        public int TrackId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Layout { get; set; }
        public string Icon { get; set; }
        public float? Length { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<Race> Race { get; set; }
    }
}
