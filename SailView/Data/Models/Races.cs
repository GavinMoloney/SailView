using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SailView.Data.Models
{
    public class Races
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Race Identifier is Required")]
        public string? RaceId { get; set; }
        public int RacePosition { get; set; }
        public TimeSpan RaceTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? BoatDetailsID { get; set; }
        public Series? Series { get; set; }
        public int? SeriesId { get; set; }
        
        private string? _raceComment;
        public string? RaceComment
        {
            get { return _raceComment; }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    _raceComment = "No comments";
                }
                else
                {
                    _raceComment = value;
                }
            }
        }
        
        [NotMapped]
        public bool ShowBoatDetails { get; set; } = false;

        public virtual ICollection<BoatRaces>? BoatRaces { get; set; } = new List<BoatRaces>();

        public override string ToString()
        {
            return RaceId;
        }


    }
    
}
