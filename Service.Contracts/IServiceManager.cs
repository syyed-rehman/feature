namespace Service.Contracts
{
    public interface IServiceManager
    {
        IArtistService ArtistService { get; }
        ISongService SongService { get; }
    }
}
