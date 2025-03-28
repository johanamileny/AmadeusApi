namespace AMADEUSAPI.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public string Attraction { get; set; } = string.Empty;
        public string Food { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
    }
}