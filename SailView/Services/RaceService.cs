using Microsoft.EntityFrameworkCore;
using SailView.Data;
using SailView.Data.Models;

namespace SailView.Services
{
    public class RaceService
    {
        private readonly IDbContextFactory<SailAppDbContext> _dbContextFactory;

        public RaceService(IDbContextFactory<SailAppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        //METHODS
        public List<Races> GetAllRaces()  //list of races
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                // Query related data from the database
                var races = context.Race.Include(r => r.BoatRaces).ThenInclude(br => br.BoatDetails).ToList<Races>();
                if (races == null)
                {
                    throw new ArgumentException("No races in database");
                }
                return races;
            }
        }

        //async version of above
        public async Task<List<Races>> GetAllRacesAsync()  //list of races
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                // Query related data from the database
                var races = await context.Race.Include(r => r.BoatRaces).ThenInclude(br => br.BoatDetails).ToListAsync<Races>();
                if (races == null)
                {
                    throw new ArgumentException("No races in database");
                }
                return races;
            }
        }


        public void NewRace(Races race) //add race
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Race.Add(race);
                context.SaveChanges();
            }
        }

        public Races GetRaceByName(string name) //unused
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var raceResults = context.Race.FirstOrDefault(x => x.RaceId == name);
                return raceResults;
            }
        }

        public BoatRaces GetRaceById(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var raceResults = context.BoatRace.FirstOrDefault(x => x.RaceId == id);
                return raceResults;
            }
        }

        public void UpdateRaceById(int id) //causes crash
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var raceToUpdate = GetRaceById(id);
                if (raceToUpdate != null)
                {
                    context.Update(context.Race);
                    context.SaveChanges();
                }
            }
        }


        public void EditRaceByID(BoatRaces boatRace)
        {
            if (_dbContextFactory != null)
            {
                using var context = _dbContextFactory.CreateDbContext();
                if (boatRace != null && boatRace.Races != null)
                {
                    var raceToUpdate = context.BoatRace.Include(x => x.BoatDetails).ThenInclude(x => x.BoatRaces).SingleOrDefault(x => x.RaceId == boatRace.RaceId);
                    if (raceToUpdate != null)
                    {
                        raceToUpdate.TimingRecord = boatRace.TimingRecord;
                        raceToUpdate.Position = boatRace.Position;
                        raceToUpdate.FinishingStatus = boatRace.FinishingStatus;

                        // Detach the existing entity from the change tracker
                        context.Entry(raceToUpdate).State = EntityState.Detached;

                        // Attach the updated entity and set its state to Modified
                        context.Attach(boatRace);
                        context.Entry(boatRace).State = EntityState.Modified;

                        context.SaveChanges();
                    }
                }
            }
        }

        //async version of above
        //public async Task EditRaceByIDAsync(BoatRaces boatRace)
        //{
        //    if (_dbContextFactory != null)
        //    {
        //        using var context = _dbContextFactory.CreateDbContext();
        //        if (boatRace != null && boatRace.Races != null)
        //        {
        //            var raceToUpdate = await context.BoatRace.Include(x => x.BoatDetails).ThenInclude(x => x.BoatRaces).SingleOrDefaultAsync(x => x.RaceId == boatRace.RaceId);
        //            if (raceToUpdate != null)
        //            {
        //                raceToUpdate.TimingRecord = boatRace.TimingRecord;
        //                raceToUpdate.Position = boatRace.Position;
        //                raceToUpdate.FinishingStatus = boatRace.FinishingStatus;

        //                context.Entry(raceToUpdate).State = EntityState.Detached;

        //                context.Attach(boatRace);
        //                context.Entry(boatRace).State = EntityState.Modified;

        //                await context.SaveChangesAsync();
        //            }
        //        }
        //    }
        //}
        public async Task EditRaceByIDAsync(Races race, BoatRaces boatRace)
        {
            if (_dbContextFactory != null)
            {
                using var context = _dbContextFactory.CreateDbContext();
                if (race != null && boatRace != null && boatRace.Races != null)
                {
                    // Update the Races table
                    var raceToUpdate = await context.Race.FindAsync(race.Id);
                    if (raceToUpdate != null)
                    {
                        // Update race fields
                        raceToUpdate.Id = race.Id;
                        raceToUpdate.RaceId = race.RaceId;
                        raceToUpdate.CreatedDate = race.CreatedDate;

                        context.Entry(raceToUpdate).State = EntityState.Modified;
                    }

                    // Update the BoatRaces table
                    var boatRaceToUpdate = await context.BoatRace.Include(x => x.BoatDetails).ThenInclude(x => x.BoatRaces).SingleOrDefaultAsync(x => x.RaceId == boatRace.RaceId);
                    if (boatRaceToUpdate != null)
                    {
                        boatRaceToUpdate.TimingRecord = boatRace.TimingRecord;
                        boatRaceToUpdate.Position = boatRace.Position;
                        boatRaceToUpdate.FinishingStatus = boatRace.FinishingStatus;

                        context.Entry(boatRaceToUpdate).State = EntityState.Modified;
                    }

                    await context.SaveChangesAsync();
                }
            }
        }


        public void DeleteRaceById(int id)  //unused
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var raceToDelete = GetRaceById(id);
                if (raceToDelete != null)
                {
                    context.Remove(raceToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}
