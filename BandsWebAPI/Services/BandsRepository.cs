


using BandsWebAPI.DbContexts;
using BandsWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

public class BandsRepository : IBandRepository
{
    private readonly BandsContext _bandsContext;
    public BandsRepository(BandsContext bandsContext)
    {
        _bandsContext = bandsContext;

    }

    public async Task<bool> BandExistsAsync(int bandId)
    {
        return await _bandsContext.Bands.AnyAsync(c => c.Id == bandId);
    }

    public async Task<Band?> GetBandAsync(int bandId)
    {

        return await _bandsContext.Bands.Include(x => x.Description).Include(x => x.Albums).
            Include(x => x.Musicians).Where(x => x.Id == bandId).FirstOrDefaultAsync();
    }
  
    public async Task<IEnumerable<Band>> GetBandsAsync()
    {
        return await _bandsContext.Bands.OrderBy(x => x.Name).ToListAsync();
    }
}