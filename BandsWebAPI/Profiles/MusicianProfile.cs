using AutoMapper;
using BandsWebAPI.Entities;
using BandsWebAPI.Models;

namespace BandsWebAPI.Profiles
{
    public class MusicianProfile : Profile
    {
        public MusicianProfile()
        {
            CreateMap<Musician, MusicianDto>();
        }
    }
}
