using Microsoft.EntityFrameworkCore;
using SailView.Data;
using SailView.Data.Models;

namespace SailView.Services
{
    public class BoatService
    {
        private readonly IDbContextFactory<SailAppDbContext> _dbContextFactory;

        public BoatService(IDbContextFactory<SailAppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public BoatService()
        {
        }

        //Functions in use
        public List<BoatDetails> GetAllBoats()  //using
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var boats = context.BoatDetail.ToList();
                if (boats == null)
                {
                    throw new ArgumentException("No boats in database");
                }
                return boats;
            }
        }
        public void AddBoat(BoatDetails boatDetails) // add boat to db - using
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var boat = context.BoatDetail.FirstOrDefault(x => x.SailNumber == boatDetails.SailNumber);
                if (boat != null)
                {
                    throw new ArgumentException("Boat already exists");
                }
                context.BoatDetail.Add(boatDetails);
                context.SaveChanges();

            }
        }

        public void IsAlreadyExist(BoatDetails boatDetails) // check if boat already exists in db - using
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var boat = context.BoatDetail.Any(x => x.SailNumber == boatDetails.SailNumber);
                if (boat != null)
                {
                    throw new ArgumentException("Boat already exists");
                }
            }
        }
        public BoatDetails GetBoatById(int id) // currently used
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var boatDetail = context.BoatDetail.FirstOrDefault(x => x.Id == id);
                return boatDetail;
            }
        }

        public void UpdateBoat(BoatDetails boatDetails) //used
        {
            if (_dbContextFactory != null)
            {
                using var context = _dbContextFactory.CreateDbContext();
                if (boatDetails != null)
                {
                    var boatToUpdate = context.BoatDetail.SingleOrDefault(x => x.Id == boatDetails.Id);
                    if (boatToUpdate != null)
                    {
                        boatToUpdate.BoatName = boatDetails.BoatName;
                        boatToUpdate.SailNumber = boatDetails.SailNumber;
                        boatToUpdate.BoatType = boatDetails.BoatType;
                        boatToUpdate.CreatedDate = boatDetails.CreatedDate;
                        context.Update(boatToUpdate);
                        context.SaveChanges();
                    }
                }

            }
        }


        // NOT IN USE
        public void UpdateBoatById(int id) //unused
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var boatToUpdate = GetBoatById(id);
                if (boatToUpdate != null)
                {
                    context.Update(boatToUpdate);
                    context.SaveChanges();
                }
            }
        }
        public void RemoveBoatById(int id)  //works, not currently used
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var boatToDelete = GetBoatById(id);
                if (boatToDelete != null)
                {
                    context.Remove(boatToDelete);
                    context.SaveChanges();
                }
            }
        }


        //unused, keeping for possible future reference, will delete later
        public BoatDetails GetBoatByName(string name) //test if saving in db
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var boatDetail = context.BoatDetail.FirstOrDefault(x => x.BoatName == name);
                return boatDetail;
            }
        }
        public void UpdateBoatByBoatName(string name, string sailNumber)  //not used
        {
            var boatDetail = GetBoatByName(name);
            if (boatDetail != null)
            {
                throw new ArgumentException("Boat does not exist");
            }
            boatDetail.SailNumber = sailNumber;
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Update(boatDetail);

                context.SaveChanges();
            }
        }
        public void DeleteBoat(string name)  //currently unused
        {
            var boatDetail = GetBoatByName(name);
            if (boatDetail != null)
            {
                throw new ArgumentException("Boat does not exist");
            }
            boatDetail.BoatName = name;
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Remove(boatDetail);
                context.SaveChanges();
            }
        }
        public void RemoveBoat(string name)  //currently unused
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var boatToDelete = GetBoatByName(name);
                if (boatToDelete != null)
                {
                    context.Remove(boatToDelete);
                    context.SaveChanges();
                }
            }
        }

    }
}
