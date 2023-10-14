using BandsWebAPI.DbContexts;
using BandsWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BandsWebAPI.Services
{
    public class MusicianRepository : IMusicianRepository
    {
        private readonly BandsContext _bandsContext;
        public MusicianRepository(BandsContext bandsContext)
        {
            _bandsContext = bandsContext;

        }
        public async Task<IEnumerable<Musician?>> GetAllMusiciansFromAllBandsAsync()
        {
           return await _bandsContext.Musicians.ToListAsync();
        }

  
    }
}
