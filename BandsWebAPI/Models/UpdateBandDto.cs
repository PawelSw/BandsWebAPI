using AutoMapper;
using BandsWebAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace BandsWebAPI.Models
{
    public class UpdateBandDto
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public int DateOfFoundation { get; set; }



    }

}
