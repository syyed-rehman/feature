using Entities.Models;

namespace Repository.Contracts
{
    public interface ISongRepository
    {
        Task<IEnumerable<Song>> GetSongsAsync(int artistId);
    }
}
