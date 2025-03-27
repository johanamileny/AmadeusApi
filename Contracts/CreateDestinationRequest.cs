namespace AMADEUSAPI.Contracts 
{
    public class CreateDestinationRequest
    {
        public List<int> QuestionOptionIds { get; set; } = new List<int>();
        public int FirstCityId { get; set; }
        public int SecondCityId { get; set; }
    }
}