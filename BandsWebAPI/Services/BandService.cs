using AutoMapper;
using BandsWebAPI.DbContexts;
using BandsWebAPI.Entities;
using BandsWebAPI.Exceptions;
using BandsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BandsWebAPI.Services
{
    public class BandService : IBandService
    {
        private readonly BandsContext _bandsContext;
        private readonly IMapper _mapper;
        private readonly ILogger<BandService> _logger;

        public BandService(BandsContext bandsContext, IMapper mapper, ILogger<BandService> logger)
        {
            _bandsContext = bandsContext;
            _mapper = mapper;
            _logger = logger;

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
                throw new NotFoundException("Band not found");

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

        public void Delete(int bandId)
        {
            _logger.LogError($"Band with id {bandId} deleting action invoked.");
            var bandToDelete = _bandsContext.Bands.Where(x => x.Id == bandId).FirstOrDefault(); 
            if (bandToDelete == null) 
            {
                throw new NotFoundException("Band not found");
            }
            _bandsContext.Bands.Remove(bandToDelete);
            _bandsContext.SaveChanges();
         
    
        }

        public void Update(UpdateBandDto dto, int bandId)
        {
            var bandEntity = _bandsContext.Bands.Where(x => x.Id == bandId).FirstOrDefault();
            if (bandEntity == null) 
            {
                throw new NotFoundException("Band not found");
            }
            bandEntity.Name = dto.Name;
            bandEntity.DateOfFoundation = dto.DateOfFoundation;
            _bandsContext.SaveChanges();
    


        }

        
    }
}
