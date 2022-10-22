using System;
using System.Collections.Generic;

namespace Website.racing
{
    public partial class Results
    {
        public int RowId { get; set; }
        public int EventId { get; set; }
        public int DriverId { get; set; }
        public int Start { get; set; }
        public int Finish { get; set; }
        public int Led { get; set; }
        public int Points { get; set; }
        public string Status { get; set; }
        public int Laps { get; set; }
        public string Number { get; set; }

        public virtual Driver Driver { get; set; }
        public virtual Event Event { get; set; }
    }
}
