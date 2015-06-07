using System.Threading.Tasks;

namespace SevenDigital.Client
{
    public interface ISevenDigitalClient
    {
        Task<Chart> GetReleaseChartAsync();
        Task<Release> GetReleaseDetailsAsync(int releaseId);
        Task<Artist> GetArtistDetailsAsync(int artistId);
    }
}