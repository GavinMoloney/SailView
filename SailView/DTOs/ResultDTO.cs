namespace SailView.DTOs
{
    public class ResultDTO
    {
        public int Position { get; set; }
        public string? Name { get; set; }
        public int Points { get; set; }
        public TimeSpan TotalRaceTime { get; set; }
        public string? SailNumber { get; set; }
        public string? BoatType { get; set; }
        public TimeSpan CorrectedTime { get; set; }
        public string? FinishingStatus { get; set; }
    }

}
