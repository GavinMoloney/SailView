namespace SailView.DTOs
{
    public class ResultDTO
    {
        public int Position { get; set; }
        public string? Name { get; set; }
        public int Points { get; set; }
        public TimeSpan TotalRaceTime { get; set; }
        public TimeSpan UnofficialTime { get; set; }
        public string? SailNumber { get; set; }
        public string? BoatType { get; set; }
        public string HelmName { get; set; }
        public TimeSpan CorrectedTime { get; set; }
        public string? FinishingStatus { get; set; }
        public List<int> Scores { get; set; }
        public double Total { get; set; } // Total of all scores
        public double NetTotal { get; set; } // Net total after discards
    }

}
