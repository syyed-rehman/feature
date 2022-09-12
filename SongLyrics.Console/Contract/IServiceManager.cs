namespace SongLyrics.Console.Contract
{
    public interface IServiceManager
    {
        IArtistService ArtistService { get; }
        ISongService SongService { get; }
        IArtistAndSongService ArtistAndSongService { get; } 
    }
}
