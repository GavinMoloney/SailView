using System.ComponentModel.DataAnnotations;
namespace SailView.DTOs
{
    public class SelectBoatDTO
    {
        [Required]
        public string? BoatName { get; set; }
        public string? SailNumber { get; set; }
        public string? BoatType { get; set; }
    }
}
