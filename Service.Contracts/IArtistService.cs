using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IArtistService
    {
        Task<ArtistDto> GetArtistAsync(string name);
    }
}
