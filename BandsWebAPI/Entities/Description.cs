using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Music_Bands.Entities
{
    public class Description
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DescriptionId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Genres { get; set; }
        public Band Band { get; set; }
        public int BandId { get; set; }
    }
}
