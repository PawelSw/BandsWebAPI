using System.ComponentModel.DataAnnotations;

namespace BandsWebAPI.Models
{
    public class AlbumForCreationDto
    {
   
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public int DateOfRelease { get; set; }
        public int BandId { get; set; }
    }
}
