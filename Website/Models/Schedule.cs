using System;
using System.Collections.Generic;
using LumenWorks.Framework.IO.Csv;
using System.Data;
using System.IO;

namespace Website.Models 
{
    public class Schedule {

        public Schedule() {
            
        }

        public List<Track> LoadSchedule(string year) {
            List<Track> _schedule = new List<Track>();
            
            string scheduleFile = "./wwwroot/Data/" + year + "/schedule.csv";

            var scheduleTable = new DataTable();
            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(scheduleFile)), true))
                {
                    scheduleTable.Load(csvReader);

                    for(int i = 0; i < scheduleTable.Rows.Count; i++) {
                        _schedule.Add(new Track() { 
                            RaceNum = Int32.Parse(scheduleTable.Rows[i][0].ToString()),
                            RaceName = scheduleTable.Rows[i][1].ToString(),
                            Name = scheduleTable.Rows[i][2].ToString()});
                    }
                }

            return _schedule;
        }
    }
}