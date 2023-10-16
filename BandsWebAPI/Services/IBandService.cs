using BandsWebAPI.Models;

namespace BandsWebAPI.Services
{
    public interface IBandService
    {
        int Create(CreateBandDto dto);
        BandDto GetBandById(int bandId);
        IEnumerable<BandDto> GetBands();
        void Delete(int bandId);
        void Update(UpdateBandDto dto, int bandId);
    }
}