//using AutoMapper;
//using BandsWebAPI.Entities;
//using BandsWebAPI.Models;
//using BandsWebAPI.Services;
//using Microsoft.AspNetCore.Mvc;
//using System.Linq;

//namespace BandsWebAPI.Controllers
//{
//    [ApiController]
//    [Route("api/musicians")]
//    public class MusiciansController : ControllerBase
//    {
//        private readonly IMusicianRepository _musicianRepository;
      

//        private readonly IMapper _mapper;
//        public MusiciansController(IMusicianRepository musicianRepository, IMapper mapper) 
//        {
//            _musicianRepository = musicianRepository;
//            _mapper = mapper;
        
        
//        }
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<MusicianDto>>> GetAllMusicians()
//        {
    
//            var musicians = await _musicianRepository.GetAllMusiciansFromAllBandsAsync();
    
//            return Ok(_mapper.Map<IEnumerable<MusicianDto>>(musicians));

//        }

       


//    }
//}
