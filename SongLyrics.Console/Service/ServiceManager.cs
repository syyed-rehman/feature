using SongLyrics.Console.Contract;

namespace SongLyrics.Console.Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IArtistService> _artistService;
        private readonly Lazy<ISongService> _songService;
        private readonly Lazy<IArtistAndSongService> _artistAndSongService;

        public ServiceManager(IHttpClientFactory clientFactory)
        {
            _artistService = new Lazy<IArtistService>(() => new ArtistService(clientFactory));
            _songService = new Lazy<ISongService>(() => new SongService(clientFactory));
            _artistAndSongService = new Lazy<IArtistAndSongService>(() => new ArtistAndSongService());
        }

        public IArtistService ArtistService => _artistService.Value;
        public ISongService SongService => _songService.Value;
        public IArtistAndSongService ArtistAndSongService => _artistAndSongService.Value;
    }
}
