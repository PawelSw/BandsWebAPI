using AutoMapper;
using BandsWebAPI.Entities;
using BandsWebAPI.Models;

namespace BandsWebAPI.Profiles
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<Album, AlbumDto>();
            CreateMap<AlbumForCreationDto, Album>();

        }
    }
}
