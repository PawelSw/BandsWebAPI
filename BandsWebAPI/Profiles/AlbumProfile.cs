using AutoMapper;
using BandsWebAPI.Entities;
using BandsWebAPI.Models;
using NLog.LayoutRenderers.Wrappers;

namespace BandsWebAPI.Profiles
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<Album, AlbumDto>();
            CreateMap<AlbumForCreationDto, Album>();
            CreateMap<List<Album>, List<AlbumDto>>();

        }
    }
}
