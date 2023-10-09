using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Music_Bands.Entities
{
    public class Band
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BandId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public int DateOfFoundation { get; set; }
        [Required]
        public bool IsActive { get; set; } 
        public Description Description { get; set; }
        public List<Album> Albums { get; set; } = new List<Album>();
        public List<Musician> Musicians { get; set;} = new List<Musician>();



    }
}
