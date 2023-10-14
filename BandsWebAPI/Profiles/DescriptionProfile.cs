using AutoMapper;
using BandsWebAPI.Entities;
using BandsWebAPI.Models;

namespace BandsWebAPI.Profiles
{
    public class DescriptionProfile : Profile
    {
        public DescriptionProfile()
        {
            CreateMap<Description, DescriptionDto>();

        }

    }
}
