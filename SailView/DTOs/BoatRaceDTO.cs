using System.ComponentModel.DataAnnotations;

namespace SailView.DTOs
{
    public class BoatRaceDTO
    {
        [Required(ErrorMessage = "Please Enter Boat Name")]
        public string? BoatName { get; set; }

        [Required(ErrorMessage = "Please Enter Sail Number")]
        public string? SailNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Type of Boat")]
        public string? BoatType { get; set; }

        [Required(ErrorMessage = "Please Enter a Helm")]
        public string? HelmName { get; set; }
        
        [Required, Range(typeof(TimeSpan), "00:00:30", "10:00:00", ErrorMessage = "Please Enter Valid Time")]
        public TimeSpan TimingRecord { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please Enter Finishing Position Greater Than 0")]
        public int Position { get; set; }

        [Required(ErrorMessage = "Please Enter Finishing Status")]
        public string? FinishingStatus { get; set; }
        public int Points { get; set; }
    }
}
