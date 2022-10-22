using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class RaceViewModel
    {
        public string RaceNum { get; set; }
        public string Name { get; set; }
        public string Track { get; set; }
        public string Link { get; set; }        
        public string Pole { get; set; }
        public string Winner { get; set; }
        public string Year { get; set; }     
        public int EventId { get; set; }
        public bool HasResults { get; set; }
        public int Cautions { get; set; }
    }
}
