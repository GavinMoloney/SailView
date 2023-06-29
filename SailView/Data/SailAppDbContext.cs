using Microsoft.EntityFrameworkCore;
using SailView.Data.Models;

namespace SailView.Data
{
    public class SailAppDbContext : DbContext
    {
        public SailAppDbContext(DbContextOptions<SailAppDbContext> options) : base(options)
        {
        }
        public DbSet<BoatDetails> BoatDetail { get; set; }
        public DbSet<Races> Race { get; set; }
        public DbSet<BoatRaces> BoatRace { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<RaceResults> RaceResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=sql_server;User Id=sa;Password=Corneli*s2023");
        }

        // one entry needed to be hardcoded for connection to db to work    
        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<BoatDetails>().HasData(
                new
                {
                    Id = 1,
                    BoatName = "Asterix",
                    SailNumber = "IRL123",
                    BoatType = "1720",
                    CreatedDate = DateTime.Now,
                }
                );
        }
        */

        //Relating data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoatDetails>(entity => { entity.HasIndex(e => e.SailNumber).IsUnique(); });
            modelBuilder.Entity<BoatRaces>().HasKey(br => new { br.BoatId, br.RaceId });
            modelBuilder.Entity<BoatRaces>().HasOne(br => br.Races).WithMany(b => b.BoatRaces).HasForeignKey(br => br.RaceId);
            modelBuilder.Entity<BoatRaces>().HasOne(br => br.BoatDetails).WithMany(c => c.BoatRaces).HasForeignKey(bc => bc.BoatId);
            modelBuilder.Entity<Races>().HasOne(br => br.Series).WithMany(c => c.Races);
        }

    }
}
