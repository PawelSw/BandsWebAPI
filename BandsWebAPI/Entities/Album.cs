using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BandsWebAPI.Entities
{
    public class Album
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public int DateOfRelease { get; set; }
        public Band Band { get; set; }
        public int BandId { get; set; } 
    }
}
