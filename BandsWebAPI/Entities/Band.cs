using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BandsWebAPI.Entities
{
    public class Band
    {
       
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public int DateOfFoundation { get; set; }
     
        public bool IsActive { get; set; }

        public Description Description { get; set; }
        public int DescriptionId { get; set; }
        public List<Album> Albums { get; set; } = new List<Album>();

        public List<Musician> Musicians { get; set;} = new List<Musician>();



    }
}
