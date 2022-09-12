using SongLyrics.Console.Models;

namespace SongLyrics.Console.Contract
{
    public interface IArtistService
    {
        Task<ArtistDto> GetArtistAsync(string name);
    }
}
