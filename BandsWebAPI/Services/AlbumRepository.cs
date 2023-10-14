using BandsWebAPI.DbContexts;
using BandsWebAPI.Entities;
using BandsWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BandsWebAPI.Services
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly BandsContext _bandsContext;
        public AlbumRepository(BandsContext bandsContext) 
        {
            _bandsContext = bandsContext;
        
        }
        public async Task<Album?> GetAlbumForBandAsync(int bandId, int albumId)
        {
            return await _bandsContext.Albums.Where(x => x.Id == albumId && x.BandId == bandId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Album>> GetAlbumsForBandAsync(int bandId)
        {
            return await _bandsContext.Albums.Where(x => x.BandId == bandId).ToListAsync();
        }
        public async Task AddAlbumForBandAsync(int bandId, Album albumForCreation)
        {

            var band = await _bandsContext.Bands.Where(x => x.Id == bandId).FirstOrDefaultAsync();
            if (band != null)
            {
                band.Albums.Add(albumForCreation);
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _bandsContext.SaveChangesAsync() >= 0);
        }
    }
}
