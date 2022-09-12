using Entities.Models;

namespace Repository.Contracts
{
    public interface IArtistRepository
    {
        Task<Artist> GetArtistAsync(int id);
        Task<Artist> GetArtistAsync(string name);
    }
}
