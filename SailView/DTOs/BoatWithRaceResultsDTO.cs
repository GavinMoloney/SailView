﻿using SailView.Data.Models;

namespace SailView.DTOs
{
    public class BoatWithRaceResultsDTO
    {
        public int BoatID { get; set; }
        public string BoatName { get; set; }
        public string SailNumber { get; set; }
        public string BoatType { get; set; }
        public List<RaceResults> RaceResults { get; set; }
        public string RaceId { get; set; }
        public int FirstPlaceFinishes { get; set; }
        public BoatStatistics Statistics { get; set; }

    }

    public class BoatStatistics
    {
        public int BestPosition { get; set; }
        public double TotalElapsedTime { get; set; }
        public double TotalCorrectedTime { get; set; }
    }
}
