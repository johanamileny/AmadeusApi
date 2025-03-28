using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMADEUSAPI.Models
{
    public class Destination
    {
        public int Id { get; set; }

        public string Combination { get; set; } = string.Empty;

        public int FirstCityId { get; set; }

        public int SecondCityId { get; set; }
    }
}