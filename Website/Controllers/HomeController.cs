using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Website.Models;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using System.Data;
using Website.racing;
using Website.CachingLayer;

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
            IndexViewModel ivm = new IndexViewModel();
            var results = StaticCache.GetResults();
            var schedules = StaticCache.GetSchedules();
            var rand = new Random();
            var lastEventId = results.OrderByDescending(r => r.RowId).First().EventId;
            var LatestRace = results.Where(r =>
                r.EventId == lastEventId).Where(r =>
                            r.Finish == 1).First();

            ivm.CurrentYear = schedules.Where(s => s.IsActive == 1).First()?.Year ?? 
                schedules.Where(s => s.Year == schedules.Max(sc => sc.Year)).First().Year;

            ivm.SetHeadlineDriver(StaticCache.GetDrivers().Where(d => 
                d.DriverId == LatestRace.DriverId).First(), LatestRace.Number);

            ivm.HeadlineEvent = StaticCache.GetEvents().Where(e => e.EventId == LatestRace.EventId).First();
            ivm.HeadlineTrack = StaticCache.GetTracks().Where(t => t.TrackId == ivm.HeadlineEvent.TrackId).First().Name;
            ivm.HeadlineRace = StaticCache.GetRaces().Where(r => r.RaceId == ivm.HeadlineEvent.RaceId).First().Name;
            string winDescriptor = "";

            switch (LatestRace.Led)
            {
                case int led when LatestRace.Led == 1:
                    winDescriptor = "leads the only lap that matters in the";
                    break;
                case int led when (float)LatestRace.Led > (float)LatestRace.Laps * .5:
                    winDescriptor = "dominates the";
                    break;
                default:
                    winDescriptor = "wins the";
                    break;
            }

            ivm.MainHeadline = ivm.HeadlineDriver.Name + " " + winDescriptor + " " + ivm.HeadlineRace + " at " + ivm.HeadlineTrack;

            switch (rand.Next(2, 5))
            {
                case (2):
                    break;
                case (3):
                    break;
                case (4):
                    break;
                case (5):
                    break;
            }

            if (ivm.HeadlineEvent.Schedule.Year != ivm.CurrentYear)
            {
                ivm.Top10 = GetStandingsInternal(ivm.CurrentYear - 1, StaticCache.GetEvents().Where(e => e.EventId == StaticCache.GetEvents().Where(ev => ev.Schedule.Year == (ivm.CurrentYear - 1)).Max(ev => ev.RaceNum)).First().RaceNum, 10);
            }
            else
            {
                ivm.Top10 = GetStandingsInternal(ivm.CurrentYear,
                    ivm.HeadlineEvent.RaceNum,
                    10);
            }
            return View(ivm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Standings()
        {
            List<string[]> pageModel = new List<string[]>();
            List<string> years = new List<string>(); 
            foreach (var s in StaticCache.GetSchedules().ToList())
            {                
                years.Add(s.Year.ToString());
            }
            years.Sort();
            int activeYear = StaticCache.GetSchedules().Where(s => s.IsActive == 1).First().Year;
            var _weeks = StaticCache.GetEvents().Where(e => e.ScheduleId == StaticCache.GetSchedules().First(s => s.Year == activeYear).ScheduleId);
            List<string> weeks = new List<string>();
            foreach (var w in _weeks)
            {
                weeks.Add(w.RaceNum.ToString());
            }            
   
            pageModel.Add(years.ToArray());
            pageModel.Add(weeks.ToArray());

            int activeWeek = _weeks.Where(w => w.Results.Count == 0).First().RaceNum - 1;
            ViewData["ActiveYear"] = activeYear;
            ViewData["ActiveWeek"] = activeWeek;
            ViewData["PlayoffsSystem"] = StaticCache.GetSchedules().Where(s => s.ScheduleId == _weeks.First().ScheduleId).First().PlayoffSystemId;
            
            return View(pageModel);
        }

        public IActionResult RaceResults(string year = "0", int showResults = 0)
        {
            RaceResultsViewModel rvm = new RaceResultsViewModel();
            rvm.ShowRaceModal = showResults;
            var results = StaticCache.GetResults();
            var schedules = StaticCache.GetSchedules();
            Website.racing.Schedule s;

            if (year == "0")
            {
                s = schedules.Where(s => s.IsActive == 1).First();
            } else
            {
                s = schedules.Where(s => s.Year == int.Parse(year)).First();
            }
            
            var events = StaticCache.GetEvents().Where(e => e.ScheduleId == s.ScheduleId).OrderBy(e => e.RaceNum).ToList();

            foreach (var e in events)
            {
                var new_race = new RaceViewModel();
                new_race.RaceNum = e.RaceNum.ToString();
                new_race.Name = e.Race.Name;
                new_race.Track = e.Track.Name;
                new_race.Year = s.Year.ToString();
                new_race.EventId = e.EventId;
                if (results.Where(r => r.EventId == e.EventId).Any())
                {
                    new_race.HasResults = true;
                    var result_set = results.Where(r => r.EventId == e.EventId).ToList();
                    new_race.Pole = result_set.Where(r => r.Start == 1).First().Driver.Name;
                    new_race.Winner = result_set.Where(r => r.Finish == 1).First().Driver.Name;
                } else
                {
                    new_race.HasResults = false;
                }
                rvm.Events.Add(new_race);
            }

            ViewBag.Year = s.Year.ToString();
            return View(rvm);
        }

        public IActionResult Drivers()
        {
            DriversViewModel model = new DriversViewModel();
            var driverData = StaticCache.GetDrivers().ToList();
            var resultData = StaticCache.GetResults().ToList();
            
            foreach(var d in driverData)
            {
                model.drivers.Add(new Models.Driver()
                {
                    Name = d.Name,
                    Starts = d.Results.Count,
                    Wins = d.Results.Where(r => r.Finish == 1).Count(),
                    Top10 = d.Results.Where(r => r.Finish <= 10).Count(),
                    Top5 = d.Results.Where(r => r.Finish <= 5).Count(),
                    DNF = d.Results.Where(r => r.Status != "Running").Count(),
                    Pole = d.Results.Where(r => r.Start == 1).Count(),
                    LapsLed = d.Results.Sum(r => r.Led),
                    Laps = d.Results.Sum(r => r.Laps)
                });
            }

            model.drivers = model.drivers.OrderBy(d => d.Name.Split(' ')[1]).ToList();

            return View(model);
        }

        public IActionResult Driver(string driver)
        {
            DriverViewModel dvm = new DriverViewModel();
            List<racing.Event> events = StaticCache.GetEvents();
            List<racing.Track> tracks = StaticCache.GetTracks();
            dvm.Driver = StaticCache.GetDrivers().Where(d => d.Name == driver).FirstOrDefault();

            if (dvm.Driver == null)
            {
                return Error();
            }

            dvm.Results = StaticCache.GetResults().Where(r => r.DriverId == dvm.Driver.DriverId).OrderBy(r => r.EventId).ToList();
            events = (from e in events where dvm.Results.Select(r => r.EventId).Distinct().Contains(e.EventId) select e).ToList();

            foreach(var t in tracks)
            {
                var _events = events.Where(e => e.TrackId == t.TrackId);
                float _avg = 0;
                float _avgStart = 0;
                int poles = 0;
                int laps = 0;
                int led = 0;
                int best = 0;
                int appearances = 0;
                int DNFs = 0;
                int wins = 0;

                foreach (var e in _events)
                {
                    var result = e.Results.Where(r => r.DriverId == dvm.Driver.DriverId).First();
                    _avg += result.Finish;
                    _avgStart += result.Start;
                    laps += result.Laps;
                    led += result.Led;
                    if (result.Start == 1)
                    {
                        poles++;
                    }
                    if (best == 0)
                    {
                        best = result.Finish;
                    }
                    else
                    {
                        best = best >= result.Finish ? result.Finish : best;
                    }
                    if (result.Finish == 1)
                    {
                        wins++;
                    }
                    appearances++;
                    if (result.Status != "Running")
                    {
                        DNFs++;
                    }
                }

                _avg = _avg != 0 ? (float)(_avg / appearances) : 0;
                _avgStart = _avgStart != 0 ? (float)(_avgStart / appearances) : 0;
                if (appearances > 0)
                {
                    dvm.TrackStats.Add(new DriverTrackStats()
                    {
                        Track = t,
                        AverageFinish = _avg,
                        BestFinish = best,
                        Races = appearances,
                        Poles = poles,
                        AverageStart = _avgStart,
                        Laps = laps,
                        LapsLed = led,
                        DNFs = DNFs,
                        Wins = wins
                    });
                }
            }

            foreach(var y in dvm.Results.Select(r => r.Event.Schedule).Distinct().OrderBy(x => x.Year).ToList())
            {
                var res = GetStandingsInternal(y.Year, events.Where(s => s.Schedule.ScheduleId == y.ScheduleId).Select(e => e.RaceNum).Max());
                dvm.rank.Add(y.Year, res.OrderByDescending(r => r.Points).ToList().FindIndex(d => d.Name == driver) + 1);
            }


            return View(dvm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult TrackStats()
        {
            TrackStatsViewModel model = new TrackStatsViewModel();
            racingContext context = new racingContext();
            var Tracks = StaticCache.GetTracks();
            var Results = StaticCache.GetResults();

                foreach (var track in Tracks)
            {
                try
                {
                    var _events = StaticCache.GetEvents().Where(e => e.TrackId == track.TrackId).Where(e => e.Cautions != null).OrderBy(e => e.EventId).ToList();
                    var PreviousWinner = Results.Where(r => r.EventId == _events.Last().EventId).Where(r => r.Finish == 1).First().Driver.Name;
                    var winners = Results.Where(r => r.Finish == 1 && r.Event.TrackId == track.TrackId).ToList();
                    var leaders = Results.Where(r => r.Led != 0 && r.Event.TrackId == track.TrackId).ToList();
                    List<AllTimeLeaders> AllTimeLeader = new List<AllTimeLeaders>();
                    List<AllTimeWinner> AllTimeWinner = new List<AllTimeWinner>();
                    if (winners.Count != 0)
                    {
                        var AllTimeWinners = (from w in winners
                                              group w by w.DriverId into grp
                                              orderby grp.Count() descending
                                              select grp).ToList();
                        AllTimeWinner.Add(new AllTimeWinner()
                        {
                            Driver = AllTimeWinners.First().First().Driver,
                            WinCount = AllTimeWinners.First().Count()
                        });
                        var _atw = AllTimeWinners.Where(w => w.Any(y => y.DriverId != AllTimeWinner.First().Driver.DriverId && w.Count() == AllTimeWinner.First().WinCount)).ToList();
                        foreach (var atw in _atw)
                        {
                            AllTimeWinner.Add(new Models.AllTimeWinner()
                            {
                                Driver = atw.First().Driver,
                                WinCount = AllTimeWinners.First().Count()
                            });
                        }
                    }
                    if (leaders.Count != 0)
                    {
                        var AllTimeLeaders = (from l in leaders
                                              group l by l.DriverId into grp
                                              select new
                                              {
                                                  Driver = grp.Key,
                                                  LapsLed = grp.Sum(x => x.Led)
                                              }).OrderByDescending(l => l.LapsLed);
                        AllTimeLeader.Add(new Models.AllTimeLeaders()
                        {
                            Driver = StaticCache.GetDrivers().Where(d => d.DriverId == AllTimeLeaders.First().Driver).First(),
                            LapCount = AllTimeLeaders.First().LapsLed
                        });
                        var _atl = AllTimeLeaders.Where(l => l.Driver != AllTimeLeader.First().Driver.DriverId && l.LapsLed == AllTimeLeader.First().LapCount).ToList();
                        foreach (var atl in _atl)
                        {
                            AllTimeLeader.Add(new Models.AllTimeLeaders()
                            {
                                Driver = StaticCache.GetDrivers().Where(d => d.DriverId == atl.Driver).First(),
                                LapCount = atl.LapsLed
                            });
                        }
                    }
                    model.trackList.Add(new TrackStatsViewModel.TSVTrack()
                    {
                        Track = track,
                        PreviousWinner = PreviousWinner,
                        AllTimeWinner = AllTimeWinner,
                        AllTimeLeader = AllTimeLeader,
                        RaceCount = _events.Where(e => e.Cautions != null).Count()
                    });
                } catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message + ": " + track);
                }
                }

            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetWeeks(string year)
        {            
            List<int> weeks = StaticCache.GetEvents().Where(ev => ev.ScheduleId == StaticCache.GetSchedules().Where(s => s.Year == int.Parse(year)).First().ScheduleId).Select(e => e.RaceNum).Distinct().ToList();
            weeks.Sort();
            return new JsonResult(weeks);
        }

        [HttpGet]
        public async Task<JsonResult> GetRaceResults(int eventId)
        {
            List<ResultsEntry> retValue = new List<ResultsEntry>();
            var results = StaticCache.GetResults().Where(r => r.EventId == eventId).ToList();
            foreach (var result in results)
            {
                string fileName = "/Data/" + result.Event.Schedule.Year.ToString() + "/RaceResults/" +
                    result.Event.Schedule.Year.ToString().Substring(2) + result.Event.RaceNum.ToString("00") + "." +
                    result.Event.Race.Name + ".html";
                
                retValue.Add(new ResultsEntry()
                {
                    DriverName = result.Driver.Name,
                    Status = result.Status,
                    Number = result.Number,
                    Laps = result.Laps,
                    Points = result.Points,
                    Led = result.Led,
                    Start = result.Start,
                    Finish = result.Finish,
                    HtmlFile = fileName,
                    RaceName = result.Event.Schedule.Year.ToString() + " " + result.Event.Race.Name
                });
            }
            return new JsonResult(retValue);
        }

        [HttpGet]
        public async Task<JsonResult> GetYears()
        {            
            List<int> years = StaticCache.GetSchedules().Select(s => s.Year).ToList();
            years.Sort();
            return new JsonResult(years);
        }

        /*[HttpGet]
        public async Task<JsonResult> GetHeadlines(string year)
        {
            List<string> ret_value = new List<string>();
            try
            {
                string headline_file = "./wwwroot/Data/" + year + "/Headlines/headlines.csv";
                var csvTable = new DataTable();
                using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(headline_file)), true))
                {
                    csvTable.Load(csvReader);

                    for (int i = 0; i < csvTable.Rows.Count; i++)
                    {
                        ret_value.Add(csvTable.Rows[i][0].ToString());
                    }
                }

                return new JsonResult(ret_value);
            } catch (FileNotFoundException e)
            {
                return new JsonResult(new List<string>() { "No headlines to report" });
            }
        }
        */

        [HttpGet]
        public async Task<JsonResult> GetTop10(string year)
        {
            try
            {
                int schedule = StaticCache.GetSchedules().Where(s => s.Year == int.Parse(year)).First().ScheduleId;
                int raceNum = StaticCache.GetEvents().Where(e => e.ScheduleId == schedule).OrderBy(ev => ev.RaceNum).Last().RaceNum;
                return await GetStandings(int.Parse(year), raceNum, 10);
            } catch (Exception e)
            {
                return new JsonResult(e.Message);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetStandings(int year = 0, int raceNum = 0, int maxCount = 0)
        {
            List<Website.Models.Driver> Drivers = GetStandingsInternal(year, raceNum, maxCount);

            return new JsonResult(Drivers.OrderByDescending(d => d.Points).ToList());
        }

        [HttpGet]
        public async Task<JsonResult> GetUpcomingSchedule(string year)
        {        
            return new JsonResult(UpcomingSchedule(year).Take(5));
        }

        [HttpGet]
        public async Task<JsonResult> GetDriverTrackStats(int driverId, int trackId)
        {
            try
            {
                List<TrackPerformanceStats> trackPerformanceStats = new List<TrackPerformanceStats>();
                var results = StaticCache.GetResults().Where(r => r.DriverId == driverId && r.Event.TrackId == trackId).ToList();

                foreach(var r in results)
                {
                    trackPerformanceStats.Add(new TrackPerformanceStats()
                    {
                        RaceYearNum = r.Event.Schedule.Year.ToString() + " - " + r.Event.RaceNum.ToString(),
                        Start = r.Start,
                        Finish = r.Finish,
                        Laps = r.Laps,
                        Led = r.Led,
                        Status = r.Status,
                        TrackIcon = r.Event.Track.Icon,
                        TrackLayout = r.Event.Track.Layout,
                        TrackName = r.Event.Track.Name
                    }) ;
                }

                return new JsonResult(trackPerformanceStats.OrderBy(tps => tps.RaceYearNum.Split("-")[0]).ToList());
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetDriverSeasonStats(int driverId, int seasonId, int year = 0)
        {
            try
            {
                List<SeasonPerformanceStats> seasonPerformanceStats = new List<SeasonPerformanceStats>();               
                if (year != 0)
                {
                    seasonId = StaticCache.GetSchedules().Where(y => y.Year == year).First().ScheduleId;
                }
                var events = StaticCache.GetEvents().Where(e => e.ScheduleId == seasonId).OrderBy(e => e.RaceNum).ToList();                
                var results = StaticCache.GetResults().Where(r => r.DriverId == driverId).ToList();

                foreach(var e in events)
                {
                    try
                    {
                        seasonPerformanceStats.Add(new SeasonPerformanceStats()
                        {
                            RaceName = e.Race.Name,
                            Track = e.Track.Name,
                            trackID = e.Track.TrackId,
                            Start = results.Where(r => r.EventId == e.EventId).First().Start,
                            Finish = results.Where(r => r.EventId == e.EventId).First().Finish,
                            Laps = results.Where(r => r.EventId == e.EventId).First().Laps,
                            Led = results.Where(r => r.EventId == e.EventId).First().Led,
                            Status = results.Where(r => r.EventId == e.EventId).First().Status,
                            RaceNum = e.RaceNum
                        });
                    } catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                return new JsonResult(seasonPerformanceStats);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private List<Website.Models.Track> UpcomingSchedule(string year)
        {
            List<Models.Track> upcoming = new List<Models.Track>();
            var events = StaticCache.GetEvents().Where(e => 
                e.ScheduleId == StaticCache.GetSchedules().Where(s => 
                    s.Year == int.Parse(year)).First().ScheduleId).OrderBy(e => 
                        e.RaceNum).ToList();

            foreach (var ev in events)
            {
                if(StaticCache.GetResults().Where(r => r.EventId == ev.EventId).Count() == 0)
                {
                    upcoming.Add(new Models.Track()
                    {
                        RaceNum = ev.RaceNum,
                        Name = ev.Track.Name,
                        RaceName = ev.Race.Name
                    });
                }
            }

            return upcoming.OrderBy(d => d.RaceNum).ToList();
        }

        [HttpGet]
        public async Task<JsonResult> GetUpcomingTrackStats(string year)
        {
            var upcomingTrack = UpcomingSchedule(year)[0].Name;
            NextTrackViewModel model = new NextTrackViewModel();
            var track = StaticCache.GetTracks().Where(t => t.Name == upcomingTrack).First();
            int trackId = track.TrackId;
            var races = StaticCache.GetRaces().Where(r => r.TrackId == trackId).ToList();
            var drivers = StaticCache.GetDrivers();
            var results = StaticCache.GetResults();
            var events = StaticCache.GetEvents().Where(e => e.TrackId == trackId).Where(e => e.Cautions != null).OrderBy(e => e.EventId).ToList();
            model.image = track.Icon;
            model.laps = races.First().Laps;
            model.trackLength = track.Length.Value;
            model.trackType = track.Type;
            model.previousWinner = results.Where(r => r.EventId == events.Last().EventId).Where(r => r.Finish == 1).First().Driver.Name;
            Dictionary<int, int> driverLapsLed = new Dictionary<int, int>();
            Dictionary<int, int> driverWins = new Dictionary<int, int>();

            foreach(var ev in events)
            {
                var resultSet = results.Where(r => r.EventId == ev.EventId && r.Led != 0);
                foreach(var result in resultSet)
                {
                    if(driverLapsLed.ContainsKey(result.DriverId))
                    {
                        driverLapsLed[result.DriverId] += result.Led;
                    } else
                    {
                        driverLapsLed.Add(result.DriverId, result.Led);
                    }

                    if(result.Finish == 1)
                    {
                        if(driverWins.ContainsKey(result.DriverId))
                        {
                            driverWins[result.DriverId] += 1;
                        } else
                        {
                            driverWins.Add(result.DriverId, 1);
                        }
                    }
                }
            }
            var mostLed = driverLapsLed.OrderByDescending(d => d.Value).First();
            var leadingestDriveres = driverLapsLed.Where(d => d.Value == mostLed.Value);
            foreach (var driver in leadingestDriveres)
            {
                if (model.mostLed == null)
                {
                    model.mostLed = drivers.Where(d => d.DriverId == driver.Key).First().Name;
                } else
                {
                    model.mostLed += ", " + drivers.Where(d => d.DriverId == driver.Key).First().Name;
                }
            }
            model.mostLed += ": " + mostLed.Value.ToString();
            var mostWins = driverWins.OrderByDescending(d => d.Value).First();
            var winningestDrivers = driverWins.Where(d => d.Value == mostWins.Value);
            foreach (var driver in winningestDrivers)
            {
                if (model.mostWins == null)
                {
                    model.mostWins = drivers.Where(d => d.DriverId == driver.Key).First().Name;
                } else
                {
                    model.mostWins += ", " + drivers.Where(d => d.DriverId == driver.Key).First().Name;
                }
            }
            model.mostWins += ": " + mostWins.Value.ToString();

            return new JsonResult(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetHeadlines()
        {
            List<string> retValue = new List<string>();
            var LastRace = StaticCache.GetResults().ToList().Last();
            var RaceResults = StaticCache.GetResults().Where(r => r.EventId == LastRace.EventId).ToList();
            var upcomingTrack = UpcomingSchedule(RaceResults[0].Event.Schedule.Year.ToString()).FirstOrDefault()?.Name;
            Random rnd = new Random();

            try
            {
                if (upcomingTrack == null)
                {
                    var champ = GetStandingsInternal(RaceResults.First().Event.Schedule.Year, RaceResults.First().Event.RaceNum, 1).First();
                    retValue.Add(champ.Name + " wins the " + RaceResults.First().Event.Schedule.Year.ToString() + " championship");
                }

                string secondHeadline = "";
                secondHeadline = RaceResults.Where(r => r.Finish == 2).First().Driver.Name + " finishes 2nd";
                secondHeadline += RaceResults.Where(r => r.Finish == 2).First().Led > 0 ? " after leading " + RaceResults.Where(r => r.Finish == 2).First().Led + " laps" : "";
                retValue.Add(secondHeadline);

                int top10Spot = rnd.Next(6, 10);
                string top10Headline = "Solid top 10 day for " + RaceResults.Where(r => r.Finish == top10Spot).First().Driver.Name;
                if (upcomingTrack != null)
                {
                    top10Headline += "; looks to continue momentum at " + upcomingTrack;
                }
                retValue.Add(top10Headline);

                if (RaceResults.Where(r => r.Status != "Running" && r.Status != "Accident").Any())
                {
                    var result = RaceResults.Where(r => r.Status != "Running" && r.Status != "Accident").First();
                    if (result.Driver.Name == "C Barron")
                    {
                        retValue.Add(result.Driver.Name + " after " + result.Status + " issues: \"I just hate it for my guys\"");
                    }
                    else
                    {
                        retValue.Add(result.Driver.Name + " has " + result.Status + " issues; scores DNF at " + RaceResults.First().Event.Track.Name);
                    }
                }

                if (RaceResults.Where(r => r.Status == "Accident").Any())
                {
                    var crashes = RaceResults.Where(r => r.Status == "Accident" || r.Status == "Retired").GroupBy(r => r.Laps);
                    var biggestCrash = GetBiggestCrash(crashes);
                    string crashReport = "Crash at " + biggestCrash[0].Event.Track.Name + " ends the day early for ";
                    if(biggestCrash.Count > 1)
                    {
                        crashReport += biggestCrash[0].Driver.Name + ", " + biggestCrash[1].Driver.Name;
                    } else
                    {
                        crashReport += biggestCrash[0].Driver.Name;
                    }
                    retValue.Add(crashReport);
                }

                retValue.Add(RaceResults.Where(r => r.Start == 1).First().Driver.Name + " gets the pole for the " + RaceResults.First().Event.Race.Name + " at " + RaceResults.First().Event.Track.Name);

            } catch (Exception ex)
            {
                retValue.Add(ex.Message);
            }

            return new JsonResult(retValue);
        }

        [HttpGet]
        public async Task<JsonResult> GetTrackHistory(int trackId)
        {
            var model = new TrackHistoryViewModel();
            var tracks = StaticCache.GetTracks().Where(t => t.TrackId == trackId).ToList();
            var events = StaticCache.GetEvents().Where(e => e.TrackId == trackId && e.Cautions != null).ToList();
            var results = new List<racing.Results>();
            foreach (var e in events)
            {
                results.AddRange(StaticCache.GetResults().Where(r => r.EventId == e.EventId && (r.Finish == 1 || r.Start == 1)));
            }
            var _races = new List<RaceViewModel>();

            foreach (var rgrp in results.GroupBy(r => r.EventId))
            {
                _races.Add(new RaceViewModel()
                {
                    Name = rgrp.First().Event.Race.Name,
                    Pole = rgrp.Where(g => g.Start == 1).First().Driver.Name,
                    Winner = rgrp.Where(g => g.Finish == 1).First().Driver.Name,
                    RaceNum = rgrp.First().Event.RaceNum.ToString(),
                    Year = rgrp.First().Event.Schedule.Year.ToString(),
                    Track = rgrp.First().Event.Track.Name,
                    Cautions = rgrp.First().Event.Cautions.Value,
                    EventId = rgrp.First().EventId
                });
            }
            model.TrackIcon = tracks.First().Icon;
            model.TrackLayout = tracks.First().Layout;

            model.races.AddRange(_races.OrderBy(r => r.Year));
            
            return new JsonResult(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetPlayoffsSystem(int year)
        {
            racingContext context = new racingContext();
            return new JsonResult(new { playoffId = StaticCache.GetSchedules().Where(s => s.Year == year).First().PlayoffSystemId });
        }

        private List<Website.Models.Driver> GetStandingsInternal(int year = 0, int raceNum = 0, int maxCount = 0)
        {
            List<Models.Driver> Drivers = new List<Models.Driver>();
            var schedule = StaticCache.GetSchedules().FirstOrDefault(s => s.Year == year);
            List<Event> events = schedule != null ? StaticCache.GetEvents().Where(e => e.ScheduleId == schedule.ScheduleId && e.RaceNum <= raceNum).ToList() : null;
            List<racing.Driver> _drivers = StaticCache.GetDrivers().ToList();
            List<Results> _results = new List<Results>();
            foreach (var e in events)
            {
                _results.AddRange(StaticCache.GetResults().Where(r => r.EventId == e.EventId));
            }

            if (events != null)
            {
                foreach (Event e in events)
                {
                    var results = _results.Where(r => r.EventId == e.EventId).ToList();
                    foreach (Results r in results)
                    {
                        if (Drivers.Any(d => d.Name == _drivers.First(dr => dr.DriverId == r.DriverId).Name))
                        {
                            var driver = Drivers.Where(d => d.Name == r.Driver.Name).First();
                            driver.Laps += r.Laps;
                            driver.LapsLed += r.Led;
                            driver.Points += r.Points;
                            driver.DNF += r.Status == "Running" ? 0 : 1;
                            driver.Wins += r.Finish != 1 ? 0 : 1;
                            driver.Top5 += r.Finish <= 5 ? 1 : 0;
                            driver.Top10 += r.Finish <= 10 ? 1 : 0;
                            driver.Pole += r.Start == 1 ? 1 : 0;
                            driver.Starts += 1;
                            driver.Finishes.Add(r.Finish);
                            driver.PrimaryColor = r.Driver.PrimaryColor;
                            driver.SecondaryColor = r.Driver.SecondaryColor;
                            driver.DriverId = r.DriverId;
                        }
                        else
                        {
                            Drivers.Add(new Models.Driver()
                            {
                                Name = _drivers.Where(d => d.DriverId == r.DriverId).First().Name,
                                Number = r.Number,
                                Laps = r.Laps,
                                LapsLed = r.Led,
                                Points = r.Points,
                                DNF = r.Status == "Running" ? 0 : 1,
                                Wins = r.Finish != 1 ? 0 : 1,
                                Top5 = r.Finish <= 5 ? 1 : 0,
                                Top10 = r.Finish <= 10 ? 1 : 0,
                                Pole = r.Start != 1 ? 0 : 1,
                                Starts = 1,
                                Finishes = new List<int>() { r.Finish }
                            });
                        }
                    }

                    // Calculate Chase points
                    if (schedule.PlayoffSystemId == 1)
                    {
                        if (e.RaceNum == 26)
                        {
                            Drivers = Drivers.OrderByDescending(d => d.Points).ToList();
                            for (int i = 0; i < 10; i++)
                            {
                                int chasePoints = 5050 - (5 * i);
                                Drivers[i].Points = chasePoints;
                            }
                        }
                    }
                }
            }

            if (maxCount != 0)
            {
                if (Drivers.Count() == 0)
                {
                    Drivers = GetStandingsInternal(year - 1, raceNum, maxCount);
                    return Drivers.OrderByDescending(d => d.Points).ToList().GetRange(0, maxCount);
                } else
                {
                    return Drivers.OrderByDescending(d => d.Points).ToList().GetRange(0, maxCount);
                }
            }

            return Drivers.OrderByDescending(d => d.Points).ToList();
        }

        private List<Results> GetBiggestCrash(IEnumerable<IGrouping<int, Results>> crashes)
        {
            List<Results> biggestCrash = new List<Results>();

            foreach (var crash in crashes)
            {
                if(crash.Count() > biggestCrash.Count)
                {
                    biggestCrash = crash.ToList();
                }
            }

            return biggestCrash;
        }
    }
}
