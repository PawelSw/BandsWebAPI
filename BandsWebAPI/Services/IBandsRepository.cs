
using BandsWebAPI.Entities;

public interface IBandRepository
{
    Task<IEnumerable<Band>> GetBandsAsync();
    Task<Band?> GetBandAsync(int bandId);
    Task<bool> BandExistsAsync(int bandId);


}