using AutoMapper;
using BandsWebAPI.DbContexts;
using BandsWebAPI.Entities;
using BandsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BandsWebAPI.Services
{
    public class BandService : IBandService
    {
        private readonly BandsContext _bandsContext;
        private readonly IMapper _mapper;

        public BandService(BandsContext bandsContext, IMapper mapper)
        {
            _bandsContext = bandsContext;
            _mapper = mapper;
        }

        public IEnumerable<BandDto> GetBands()
        {
            var bands = _bandsContext.Bands
                .Include(x => x.Albums)
                .Include(x => x.Musicians)
                .Include(x => x.Description)
                .ToList();

            var bandsDto = _mapper.Map<List<BandDto>>(bands);
            return bandsDto;

        }

        public BandDto GetBandById(int bandId)
        {
            var bandEntity = _bandsContext.Bands
                .Include(x => x.Albums)
                .Include(x => x.Musicians)
                .Include(x => x.Description)
                .Where(x => x.Id == bandId)
                .FirstOrDefault();

            if (bandEntity == null)
            {
                return null;

            }

            var bandDto = _mapper.Map<BandDto>(bandEntity);
            return bandDto;
        }

        public int Create(CreateBandDto dto)
        {
            var band = _mapper.Map<Band>(dto);
            _bandsContext.Bands.Add(band);
            _bandsContext.SaveChanges();
            return band.Id;

        }

        public bool Delete(int bandId)
        {
            var bandToDelete = _bandsContext.Bands.Where(x => x.Id == bandId).FirstOrDefault(); 
            if (bandToDelete == null) 
            {
                return false;
            }
            _bandsContext.Bands.Remove(bandToDelete);
            _bandsContext.SaveChanges();
            return true;
    
        }

        public bool Update(UpdateBandDto dto, int bandId)
        {
            var bandEntity = _bandsContext.Bands.Where(x => x.Id == bandId).FirstOrDefault();
            if (bandEntity == null) 
            {
                return false;
            }
            bandEntity.Name = dto.Name;
            bandEntity.DateOfFoundation = dto.DateOfFoundation;
            _bandsContext.SaveChanges();
            return true;


        }

        
    }
}
