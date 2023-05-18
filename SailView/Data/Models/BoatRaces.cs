using System.ComponentModel.DataAnnotations.Schema;

namespace SailView.Data.Models
{
    public class BoatRaces
    {
        public int RaceId { get; set; }
        public Races Races { get; set; }
        public int BoatId { get; set; }
        public BoatDetails BoatDetails { get; set; }
        public TimeSpan TimingRecord { get; set; }
        public int Position { get; set; }
        public string? HelmName { get; set; }
        
        [NotMapped]
        public int Points { get; set; }
        public string? FinishingStatus { get; set; }
    }
}
