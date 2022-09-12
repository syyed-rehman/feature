using SongLyrics.Console.Models;

namespace SongLyrics.Console.Contract
{
    public interface ISongService
    {
        Task<IEnumerable<SongDto>> GetSongsAsync(int artistId);        
        Task<int> GetAverageWordsInSong(string lyrics);
    }
}
