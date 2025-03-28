namespace AMADEUSAPI.Contracts
{
    public class UpdateDestinationRequest
    {
        public string? Combination { get; set; }
        public int FirstCityId { get; set; }
        public int SecondCityId { get; set; }
    }
}