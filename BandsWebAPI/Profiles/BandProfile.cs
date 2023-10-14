using AutoMapper;
using BandsWebAPI.Entities;
using BandsWebAPI.Models;
using System.Net;

namespace BandsWebAPI.Profiles
{
    public class BandProfile : Profile
    {
        public BandProfile() 
        {
            CreateMap<Band,BandDtoWithoutLists>();
            CreateMap<Band, BandDto>();
            CreateMap<CreateBandDto, Band>()
                .ForMember(x => x.Description,
                c => c.MapFrom(dto => new Description()
                { Genres = dto.Genres}));

            CreateMap<UpdateBandDto, Band>();
        }
    }
}
