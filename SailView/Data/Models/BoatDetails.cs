using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SailView.Data.Models
{
    public class BoatDetails
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please Enter Boat Name")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Boat Name must be between 2 and 40 characters")]
        [Remote("IsAlreadyExist", "Home", HttpMethod = "POST", ErrorMessage = "Sail Number Already Exists")]
        public string? BoatName { get; set; }

        [Required(ErrorMessage = "Please Enter Sail Number")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Sail Number must be between 3 and 20 characters")]
        public string? SailNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Boat Type")]
        public string? BoatType { get; set; }

        public DateTime CreatedDate { get; set; }

        // Navigation Properties
        public virtual ICollection<BoatRaces>? BoatRaces { get; set; }
        public virtual ICollection<RaceResults>? RaceResults { get; set; }

    }
}
