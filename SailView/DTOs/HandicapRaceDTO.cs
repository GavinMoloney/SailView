using SailView.Data.Models;
using SailView.Pages;
using System.ComponentModel.DataAnnotations;
using static MudBlazor.CategoryTypes;

namespace SailView.DTOs
{
    public class HandicapRaceDTO
    {
        [Required(ErrorMessage = "Please Enter Boat Name")]
        public string? BoatName { get; set; }

        [Required(ErrorMessage = "Please Enter Sail Number")]
        public string? SailNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Type of Boat")]
        public string? BoatType { get; set; }

        [Required, Range(typeof(TimeSpan), "00:00:30", "10:00:00", ErrorMessage = "Please Enter Valid Time")]
        public TimeSpan TimingRecord { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please Enter Finishing Position Greater Than 0")]
        public int Position { get; set; }

        [Required(ErrorMessage = "Please Enter Finishing Status")]
        public string? FinishingStatus { get; set; }
        public int Points { get; set; }
        public double BoatLength { get; set; }
        public double CorrectedTime { get; set; }
        public double Rating { get; set; }
        public double CalculateCorrectedTime()
        {
            double correctedTime = TimeSpan.FromSeconds(TimingRecord.TotalSeconds * (1000.0 / Rating)).TotalMinutes;
            CorrectedTime = correctedTime;
            return correctedTime;
        }
    }

    public class PortsMouthYardstickCalculator
    {
        public static double CalculateRating(HandicapRaceDTO boat)
        {
            if (boat.BoatType == "Sloop")
            {
                boat.BoatLength = 5.6;
            }
            else
            {
                boat.BoatLength = 8.0;
            }
            double rating = (double)1000 * Math.Pow(boat.BoatLength / 100, 0.333);
            boat.Rating = Math.Round(rating, 2);
            return boat.Rating;
        }
    }

}


