using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class ResultsEntry
    {
        public int Finish { get; set; }
        public int Start { get; set; }
        public int Led { get; set; }
        public int Points { get; set; }
        public int Laps { get; set; }
        public string Number { get; set; }
        public string Status { get; set; }
        public string DriverName { get; set; }
        public string HtmlFile { get; set; }
        public string RaceName { get; set; }
    }
}
