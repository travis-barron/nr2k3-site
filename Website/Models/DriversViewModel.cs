using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class DriversViewModel
    {
        public List<Driver> drivers { get; set; }

        public DriversViewModel()
        {
            drivers = new List<Driver>();
        }
    }
}
