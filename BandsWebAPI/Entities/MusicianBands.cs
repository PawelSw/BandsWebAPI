using Music_Bands.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BandsWebAPI.Entities
{
    public class MusicianBands
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MusicianBandsId { get; set; }
        public Musician Musician { get; set; }
        public int MusicianId { get; set; }
        public Band Band { get; set; }
        public int BandId { get; set;}

    }
}
