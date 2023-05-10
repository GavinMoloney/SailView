
using Microsoft.EntityFrameworkCore;
using SailView.Data;
using SailView.Data.Models;
using SailView.DTOs;

namespace SailView.Services
{
    public class BoatResultService
    {
        private readonly IDbContextFactory<SailAppDbContext> _dbContextFactory;

        public BoatResultService(IDbContextFactory<SailAppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task PopulateRaceResultsAsync()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var boatRaces = await context.BoatRace
                    .Include(br => br.Races)
                    .Include(br => br.BoatDetails)
                    .ToListAsync();

                bool dataAdded = false;
                bool dataUpdated = false;

                foreach (var boatRace in boatRaces)
                {
                    var existingRaceResult = context.RaceResults
                        .FirstOrDefault(rr => rr.BoatDetailsId == boatRace.BoatId && rr.RaceDate == boatRace.Races.CreatedDate);

                    if (existingRaceResult == null)
                    {
                        var raceResult = new RaceResults
                        {
                            RaceDate = boatRace.Races.CreatedDate,
                            Position = boatRace.Position,
                            ElapsedTime = boatRace.TimingRecord.TotalSeconds,
                            CorrectedTime = CalculateCorrectedTime(boatRace),
                            BoatDetailsId = boatRace.BoatId
                        };

                        context.RaceResults.Add(raceResult);
                        dataAdded = true;
                    }
                    else
                    {
                        double correctedTime = CalculateCorrectedTime(boatRace);

                        if (existingRaceResult.Position != boatRace.Position ||
                            existingRaceResult.ElapsedTime != boatRace.TimingRecord.TotalSeconds ||
                            existingRaceResult.CorrectedTime != correctedTime)
                        {
                            existingRaceResult.Position = boatRace.Position;
                            existingRaceResult.ElapsedTime = boatRace.TimingRecord.TotalSeconds;
                            existingRaceResult.CorrectedTime = correctedTime;

                            context.RaceResults.Update(existingRaceResult);
                            dataUpdated = true;
                        }
                    }
                }

                if (dataAdded || dataUpdated)
                {
                    await context.SaveChangesAsync();
                }
            }
        }


        private double CalculateCorrectedTime(BoatRaces boatRace)
        {
            string boatType = boatRace.BoatDetails.BoatType;
            TimeSpan timingRecord = boatRace.TimingRecord;
            double pyNumber;

            switch (boatType)
            {
                case "Sloop":
                    pyNumber = 1300;
                    break;
                case "1720":
                    pyNumber = 850;
                    break;
                default:
                    throw new ArgumentException($"Unknown boat type: {boatType}");
            }

            double elapsedTimeInSeconds = timingRecord.TotalSeconds;
            double correctedTimeInSeconds = elapsedTimeInSeconds * 1000 / pyNumber;

            return correctedTimeInSeconds;
        }


        public List<RaceResults> GetRaceResults()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var results = context.RaceResults.ToList();
                if (results == null)
                {
                    throw new ArgumentException("No results");
                }
                return results;
            }
        }

        public async Task<List<BoatWithRaceResultsDTO>> GetBoatsWithRaceResultsAsync()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var boatsWithBoatRaces = await context.BoatDetail
                    .Include(b => b.RaceResults)
                    .Include(b => b.BoatRaces)
                        .ThenInclude(br => br.Races)
                    .ToListAsync();

                var boatWithRaceResultsDTOs = boatsWithBoatRaces.Select(b => new BoatWithRaceResultsDTO
                {
                    BoatID = b.Id,
                    BoatName = b.BoatName,
                    SailNumber = b.SailNumber,
                    BoatType = b.BoatType,
                    RaceResults = b.RaceResults.ToList()
                    //DebugInfo = $"RaceResults Count: {b.RaceResults.Count}, BoatRaces Count: {b.BoatRaces.Count}"
                }).OrderBy(dto => dto.BoatName).ToList();

                return boatWithRaceResultsDTOs;
            }
        }



    }
}
