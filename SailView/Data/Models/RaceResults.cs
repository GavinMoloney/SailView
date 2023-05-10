namespace SailView.Data.Models
{
    public class RaceResults
    {
        public int Id { get; set; }
        public DateTime RaceDate { get; set; }
        public int Position { get; set; }
        public double ElapsedTime { get; set; }
        public double CorrectedTime { get; set; }

        public int BoatDetailsId { get; set; }
        public virtual BoatDetails? BoatDetails { get; set; }
    }
}
