using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Website.Models;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using System.Data;
using Website.Models;
using Newtonsoft.Json;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<string[]> pageModel = new List<string[]>();
            string[] years = Directory.GetDirectories("./Data");
            string[] files = Directory.GetDirectories("./" + years.Last() + "/csv");
            pageModel.Add(years);
            pageModel.Add(files);

            return View(pageModel);            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult RaceResults(string year)
        {
            List<RaceViewModel> files = new List<RaceViewModel>();
            List<Track> Schedule = new Schedule().LoadSchedule(year);

            string[] race_files = Directory.GetFiles("Data/" + year + "/RaceResults");

            int count = 1;

            foreach(string race in race_files)
            {
                var new_race = new RaceViewModel();

                new_race.RaceNum = count.ToString();
                new_race.Name = Schedule.Where(t => t.RaceNum == count).First().RaceName.ToString();
                new_race.Link = race;
                new_race.Track = Schedule.Where(t => t.RaceNum == count).First().Name;
                new_race.Year = year;

                string csv_file = "./Data/" + year + "/csv/" + Path.GetFileNameWithoutExtension(race) + ".csv";

                var csvTable = new DataTable();
                using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(csv_file)), true))
                {
                    csvTable.Load(csvReader);

                    for(int i = 0; i < csvTable.Rows.Count; i++)
                    {
                        if(csvTable.Rows[i][1].ToString() == "1")
                        {
                            new_race.Pole = csvTable.Rows[i][3].ToString();                            
                        }

                        if(csvTable.Rows[i][0].ToString() == "1")
                        {
                            new_race.Winner = csvTable.Rows[i][3].ToString();
                        }

                        if(new_race.Pole != null && new_race.Winner != null)
                        {
                            break;
                        }
                    }

                    files.Add(new_race);
                }

                count++;
            }
            
            ViewBag.Year = year;
            return View(files);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<JsonResult> GetWeeks(string year) {
            return new JsonResult(Directory.GetDirectories("./Data/" + year + "/csv").ToArray<string>());
        }

        [HttpGet]
        public async Task<JsonResult> GetYears() {
            return new JsonResult(Directory.GetDirectories("./Data/").ToArray<string>());
        }

        [HttpGet]
        public async Task<JsonResult> GetTop10(string year)
        {
            List<Driver> Drivers = new List<Driver>();

            string[] files = Directory.GetFiles("./Data/" + year + "/csv");
            foreach (string f in files)
            {
                var csvTable = new DataTable();
                using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(f)), true))
                {
                    csvTable.Load(csvReader);

                    for (int i = 0; i < csvTable.Rows.Count; i++)
                    {
                        if (Drivers.Any(d => d.Name == csvTable.Rows[i][3].ToString()))
                        {
                            var driver = Drivers.Where(d => d.Name == csvTable.Rows[i][3].ToString()).First();
                            driver.Laps += Int32.Parse(csvTable.Rows[i][4].ToString());
                            driver.LapsLed += Int32.Parse(csvTable.Rows[i][5].ToString());
                            driver.Points += Int32.Parse(csvTable.Rows[i][6].ToString());
                            driver.DNF += csvTable.Rows[i][7].ToString() == "Running" ? 0 : 1;
                            driver.Wins += csvTable.Rows[i][0].ToString() != "1" ? 0 : 1;
                            driver.Top5 += Int32.Parse(csvTable.Rows[i][0].ToString()) <= 5 ? 1 : 0;
                            driver.Top10 += Int32.Parse(csvTable.Rows[i][0].ToString()) <= 10 ? 1 : 0;
                            driver.Pole += csvTable.Rows[i][1].ToString() != "1" ? 0 : 1;
                            driver.Starts += 1;
                            driver.Finishes.Add(Int32.Parse(csvTable.Rows[i][0].ToString()));
                        }
                        else
                        {
                            Drivers.Add(new Driver()
                            {
                                Name = csvTable.Rows[i][3].ToString(),
                                Number = csvTable.Rows[i][2].ToString(),
                                Laps = Int32.Parse(csvTable.Rows[i][4].ToString()),
                                LapsLed = Int32.Parse(csvTable.Rows[i][5].ToString()),
                                Points = Int32.Parse(csvTable.Rows[i][6].ToString()),
                                DNF = csvTable.Rows[i][7].ToString() == "Running" ? 0 : 1,
                                Wins = csvTable.Rows[i][0].ToString() != "1" ? 0 : 1,
                                Top5 = Int32.Parse(csvTable.Rows[i][0].ToString()) <= 5 ? 1 : 0,
                                Top10 = Int32.Parse(csvTable.Rows[i][0].ToString()) <= 10 ? 1 : 0,
                                Pole = csvTable.Rows[i][1].ToString() != "1" ? 0 : 1,
                                Starts = 1,
                                Finishes = new List<int>() { Int32.Parse(csvTable.Rows[i][0].ToString()) }
                            });
                        }
                    }

                }
            }

            if(Drivers.Count > 0) {
                return new JsonResult(Drivers.OrderByDescending(d => d.Points).Take(10));
            } else {
                return new JsonResult(Drivers);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetStandings(string dir)
        {
            List<Driver> Drivers = new List<Driver>();

            string[] files = Directory.GetFiles(dir);

            foreach (string f in files)
            {
                var csvTable = new DataTable();
                using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(f)), true))
                {
                    csvTable.Load(csvReader);

                    for (int i = 0; i < csvTable.Rows.Count; i++)
                    {
                        if (Drivers.Any(d => d.Name == csvTable.Rows[i][3].ToString()))
                        {
                            var driver = Drivers.Where(d => d.Name == csvTable.Rows[i][3].ToString()).First();
                            driver.Laps += Int32.Parse(csvTable.Rows[i][4].ToString());
                            driver.LapsLed += Int32.Parse(csvTable.Rows[i][5].ToString());
                            driver.Points += Int32.Parse(csvTable.Rows[i][6].ToString());
                            driver.DNF += csvTable.Rows[i][7].ToString() == "Running" ? 0 : 1;
                            driver.Wins += csvTable.Rows[i][0].ToString() != "1" ? 0 : 1;
                            driver.Top5 += Int32.Parse(csvTable.Rows[i][0].ToString()) <= 5 ? 1 : 0;
                            driver.Top10 += Int32.Parse(csvTable.Rows[i][0].ToString()) <= 10 ? 1 : 0;
                            driver.Pole += csvTable.Rows[i][1].ToString() != "1" ? 0 : 1;
                            driver.Starts += 1;
                            driver.Finishes.Add(Int32.Parse(csvTable.Rows[i][0].ToString()));
                        }
                        else
                        {
                            Drivers.Add(new Driver()
                            {
                                Name = csvTable.Rows[i][3].ToString(),
                                Number = csvTable.Rows[i][2].ToString(),
                                Laps = Int32.Parse(csvTable.Rows[i][4].ToString()),
                                LapsLed = Int32.Parse(csvTable.Rows[i][5].ToString()),
                                Points = Int32.Parse(csvTable.Rows[i][6].ToString()),
                                DNF = csvTable.Rows[i][7].ToString() == "Running" ? 0 : 1,
                                Wins = csvTable.Rows[i][0].ToString() != "1" ? 0 : 1,
                                Top5 = Int32.Parse(csvTable.Rows[i][0].ToString()) <= 5 ? 1 : 0,
                                Top10 = Int32.Parse(csvTable.Rows[i][0].ToString()) <= 10 ? 1 : 0,
                                Pole = csvTable.Rows[i][1].ToString() != "1" ? 0 : 1,
                                Starts = 1,
                                Finishes = new List<int>() { Int32.Parse(csvTable.Rows[i][0].ToString()) }
                            });
                        }
                    }
                }
            }

            return new JsonResult(Drivers.OrderByDescending(d => d.Points).ToList());
        }
    }
}
