using BandsWebAPI.Entities;

namespace BandsWebAPI.Services
{
    public interface IMusicianRepository
    {
        Task<IEnumerable<Musician?>> GetAllMusiciansFromAllBandsAsync();
       
    }
}
