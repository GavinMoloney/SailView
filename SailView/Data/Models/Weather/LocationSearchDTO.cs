using System.ComponentModel.DataAnnotations;

namespace SailView.Data.Models.Weather
{
    public class LocationSearchDTO
    {
        [Required]
        public string? Location { get; set; }
    }
}
