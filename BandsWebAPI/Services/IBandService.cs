using BandsWebAPI.Models;

namespace BandsWebAPI.Services
{
    public interface IBandService
    {
        int Create(CreateBandDto dto);
        BandDto GetBandById(int bandId);
        IEnumerable<BandDto> GetBands();
        bool Delete(int bandId);
        bool Update(UpdateBandDto dto, int bandId);
    }
}