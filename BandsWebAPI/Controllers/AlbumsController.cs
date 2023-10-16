using AutoMapper;
using BandsWebAPI.Entities;
using BandsWebAPI.Models;
using BandsWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BandsWebAPI.Controllers
{
    [ApiController]
    [Route("api/band/{bandId}/album")]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumsController(IAlbumService albumService)
        {
            _albumService = albumService;

        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<AlbumDto>>> GetAllAlbums(int bandId)
        //{
        //    if (!await _bandRepository.BandExistsAsync(bandId))
        //    {
        //        return NotFound();
        //    }
        //    var albums = await _albumRepository.GetAlbumsForBandAsync(bandId);

        //    return Ok(_mapper.Map<IEnumerable<AlbumDto>>(albums));

        //}

        //[HttpGet("{albumId}", Name = "GetAlbum")]
        //public async Task<ActionResult<AlbumDto>> GetAlbumById(int bandId, int albumId)
        //{
        //    if (!await _bandRepository.BandExistsAsync(bandId))
        //    {
        //        return NotFound();
        //    }

        //    var album = await _albumRepository.GetAlbumForBandAsync(bandId, albumId);
        //    if (album == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(_mapper.Map<AlbumDto>(album));

        //}
        //[HttpPost]
        //public async Task<ActionResult<AlbumDto>> CreateAlbum( int bandId,
        // AlbumForCreationDto albumForCreationDto)
        //{
        //    if (!await _bandRepository.BandExistsAsync(bandId))
        //    {
        //        return NotFound();
        //    }

        //    var finalAlbum = _mapper.Map<Album>(albumForCreationDto);

        //    await _albumRepository.AddAlbumForBandAsync(
        //        bandId, finalAlbum);


        //    await _albumRepository.SaveChangesAsync();

        //    var createdAlbumToReturn =
        //        _mapper.Map<AlbumDto>(finalAlbum);

        //    return CreatedAtRoute("GetAlbum",
        //         new
        //         {
        //             Id = bandId,
        //             albumId = createdAlbumToReturn.Id
        //         },
        //         createdAlbumToReturn);
        //}
        [HttpPost]
        public ActionResult Create([FromRoute] int bandId,
         [FromBody] AlbumForCreationDto albumForCreationDto)
        {
            var newAlbumId = _albumService.CreateAlbum(bandId, albumForCreationDto);
            return Created($"/api/band/{bandId}/album/{newAlbumId}", null);

        }

        [HttpGet("{albumId}")]
        public ActionResult<AlbumDto> GetAlbumById([FromRoute] int bandId, [FromRoute] int albumId)
        {
            var album =  _albumService.GetAlbumById(bandId, albumId);
            return Ok(album);

        }

        [HttpGet]
        public ActionResult<List<AlbumDto>> GetAll([FromRoute] int bandId)
        {
           var albums = _albumService.GetAllAlbumsForOneBand(bandId);
           return Ok(albums);

        }

    }
}
