namespace CapstoneV2.Models.Data
{
    public class Venue
    {
        public int VenueId { get; set; }
        public string Name { get; set; }
        public string ImgPath { get; set; }
        public ContactInfo Contact { get; set; }
    }
}