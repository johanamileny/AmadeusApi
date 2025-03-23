using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMADEUSAPI.Models
{
    [Table("destination")]
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Combination { get; set; } = string.Empty;

        [Required]
        public int FirstCityId { get; set; }

        [Required]
        public int SecondCityId { get; set; }
    }
}