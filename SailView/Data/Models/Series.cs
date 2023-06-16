namespace SailView.Data.Models
{
    public class Series
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Races> Races { get; set; }
        public int Discards { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
