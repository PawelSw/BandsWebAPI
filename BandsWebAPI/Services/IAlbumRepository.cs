using BandsWebAPI.Entities;

namespace BandsWebAPI.Services
{
    public interface IAlbumRepository
    {
        Task<Album?> GetAlbumForBandAsync(int bandId, int albumId);
        Task<IEnumerable<Album>> GetAlbumsForBandAsync(int bandId);
        Task AddAlbumForBandAsync(int bandId, Album albumForCreation);
        Task<bool> SaveChangesAsync();
    }
}
