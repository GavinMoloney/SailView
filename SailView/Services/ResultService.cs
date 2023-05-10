using Microsoft.EntityFrameworkCore;
using SailView.Data;
using SailView.Data.Models;

namespace SailView.Services
{
    public class ResultService
    {
        private readonly IDbContextFactory<SailAppDbContext> _dbContextFactory;

        public ResultService(IDbContextFactory<SailAppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public List<BoatRaces> GetBoatRaces()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var raceResults = context.BoatRace.Include(r => r.Races).ThenInclude(br => br.BoatDetailsID).ToList<BoatRaces>();
                if (raceResults == null || raceResults.Count == 0)
                {
                    throw new ArgumentException("Empty");
                }
                return raceResults;
            }
        }
        public BoatRaces GetRaceByRaceId(string name) // currently used
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var race = context.BoatRace.FirstOrDefault(x => x.Races.RaceId == name);
                if (race == null)
                {
                    throw new ArgumentException("No races");
                }
                return race;
            }
        }

        public void CreateSeries(Series series)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                List<Races> races = new List<Races>();
                races.AddRange(series.Races);
                series.Races.Clear();
                context.Series.Add(series);
                context.SaveChanges();
                foreach (var r in races)
                {
                    var race = context.Race.FirstOrDefault(x => x.Id == r.Id);
                    if (race != null)
                    {
                        race.SeriesId = series.Id;
                    }
                }
                context.SaveChanges();
            }
        }

        public List<Series> SeriesList()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var race = context.Series.Include(s => s.Races).ThenInclude(r => r.BoatRaces).ThenInclude(b => b.BoatDetails).ToList();
                return race;
            }
        }

        public Series GetSeriesByName(string seriesName)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Series.FirstOrDefault(s => s.Name == seriesName);
            }
        }
    }
}
