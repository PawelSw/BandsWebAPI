using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BandsWebAPI.Entities
{
    public class Musician
    {
 
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Role { get; set; }
        public List<Band> Bands { get; set; } = new List<Band>();

    }
}
