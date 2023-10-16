using AutoMapper;
using BandsWebAPI.DbContexts;
using BandsWebAPI.Entities;
using BandsWebAPI.Exceptions;
using BandsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BandsWebAPI.Services
{
    public interface IAlbumService
    {
        int CreateAlbum(int bandId, AlbumForCreationDto albumForCreationDto);
        AlbumDto GetAlbumById(int bandId, int albumId);
        List<AlbumDto> GetAllAlbumsForOneBand(int bandId);
    }
    public class AlbumService : IAlbumService
    {
        private readonly BandsContext _bandsContext;
        private readonly IMapper _mapper;
        public AlbumService(BandsContext bandsContext, IMapper mapper)
        {
            _bandsContext = bandsContext;
            _mapper = mapper;
            
        }
        public int CreateAlbum(int bandId, AlbumForCreationDto albumForCreationDto)
        {
            var band =_bandsContext.Bands.FirstOrDefault(x => x.Id == bandId);
            if (band == null) 
            {
                throw new NotFoundException("Band not found.");

            }
            var albumEntity = _mapper.Map<Album>(albumForCreationDto);
            //band.Albums.Add(albumEntity);

            albumEntity.BandId = bandId;
     
            _bandsContext.Add(albumEntity);
            _bandsContext.SaveChanges();
            return albumEntity.Id;

        }

        public AlbumDto GetAlbumById(int bandId, int albumId)
        {
            var band = _bandsContext.Bands.FirstOrDefault(x =>x.Id == bandId);
            if (band == null) 
            {
                throw new NotFoundException("Band not found.");
            }

            var albumEntity = _bandsContext.Albums.FirstOrDefault(x => x.Id == albumId);
            if (albumEntity == null || albumEntity.BandId != bandId)
            { 
                throw new NotFoundException("Album not found.");
            }

            //var albumEntity = band.Albums.FirstOrDefault(x => x.Id == albumId);
            //if (albumEntity == null)
            //{
            //    throw new NotFoundException("Album not found.");
            //}

            var albumDto = _mapper.Map<AlbumDto>(albumEntity);
            return albumDto;

        }

        public List<AlbumDto> GetAllAlbumsForOneBand(int bandId)
        {
            var band = _bandsContext.Bands
                .Include(d => d.Albums)
                .FirstOrDefault(x => x.Id == bandId);
            if (band == null)
            {
                throw new NotFoundException("Band not found.");
            }

            var allBands = band.Albums.ToList();
            var allBandDto = _mapper.Map<List<AlbumDto>>(allBands);
            return allBandDto;

        }
    }
}
