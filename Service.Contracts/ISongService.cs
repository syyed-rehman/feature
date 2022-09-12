using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface ISongService
    {
        Task<IEnumerable<SongDto>> GetSongsAsync(int artistId);
    }
}
