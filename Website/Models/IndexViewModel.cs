using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Models
{
    public class IndexViewModel
    {
        public Website.Models.Driver HeadlineDriver { get; private set; }
        public List<Driver> Top10 { get; set; }
        public int CurrentYear { get; set; }
        public Website.racing.Event HeadlineEvent { get; set; }
        public string HeadlineTrack { get; set; }
        public string HeadlineRace { get; set; }
        public string MainHeadline { get; set; }
        public List<string> ChildHeadlines { get; set; }

        public IndexViewModel()
        {
            Top10 = new List<Driver>();
            ChildHeadlines = new List<string>();
        }

        public void SetHeadlineDriver(Website.racing.Driver driver, string number)
        {
            HeadlineDriver = new Website.Models.Driver()
            {
                Name = driver.Name,
                PrimaryColor = driver.PrimaryColor,
                SecondaryColor = driver.SecondaryColor,
                Number = number.ToString()
            };
        }
    }
}
