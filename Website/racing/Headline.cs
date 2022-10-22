using System;
using System.Collections.Generic;

namespace Website.racing
{
    public partial class Headline
    {
        public int HeadlineId { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public int? DriverId { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
