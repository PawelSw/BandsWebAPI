using System.ComponentModel.DataAnnotations;

namespace BandsWebAPI.Models
{
    public class AlbumForCreationDto
    {
   
        [Required(ErrorMessage = "You should provide a title value.")]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200)]
        public int DateOfRelease { get; set; }
    }
}
