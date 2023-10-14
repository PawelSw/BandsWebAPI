using AutoMapper;
using BandsWebAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace BandsWebAPI.Models
{
    public class CreateBandDto
    {
 
        public string Name { get; set; }
        [Required]
        [MaxLength(10)]
        public int DateOfFoundation { get; set; }
        public bool IsActive { get; set; }
        public string Genres { get; set; }


    }

}
