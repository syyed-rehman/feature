namespace SongLyrics.Console.Contract
{
    public interface IArtistAndSongService
    {
        Task<string> GetArtistSongsAndCountLyrics(string artistName, IServiceProvider services);
    }
}
