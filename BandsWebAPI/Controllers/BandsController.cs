using AutoMapper;
using BandsWebAPI.DbContexts;
using BandsWebAPI.Entities;
using BandsWebAPI.Models;
using BandsWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BandsWebAPI.Controllers
{
    [ApiController]
    [Route("api/bands")]
    public class BandsController : ControllerBase
    {
        private readonly IBandService _bandService;
   

        public BandsController(IBandService bandService)
        {
            _bandService = bandService;
  
        }
        [HttpGet]
        public ActionResult<IEnumerable<BandDto>> GetAllBands()
        {
            var result = _bandService.GetBands();
            return Ok(result);
      
        }

        [HttpGet("{id}")]
        public ActionResult<BandDto> GetById([FromRoute] int id)
        {
            var band = _bandService.GetBandById(id);
  
            return Ok(band);

        }

        [HttpPost]
        public ActionResult CreateBand([FromBody] CreateBandDto createBandDto)
        {
            int bandId = _bandService.Create(createBandDto);
            return Created($"/api/bands/ {bandId}",null);
               
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _bandService.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult Update ([FromBody] UpdateBandDto updateBandDto, [FromRoute] int id)
        { 
            _bandService.Update(updateBandDto, id);   
    
            return Ok();
        
        }

    }
}
