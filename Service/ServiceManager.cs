using AutoMapper;
using Repository.Contracts;
using Service.Contracts;

namespace Service
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IArtistService> _artistService;
        private readonly Lazy<ISongService> _songService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _artistService = new Lazy<IArtistService>(() => new ArtistService(repositoryManager, mapper));
            _songService = new Lazy<ISongService>(() => new SongService(repositoryManager, mapper));
        }

        public IArtistService ArtistService => _artistService.Value;
        public ISongService SongService => _songService.Value;
    }
}
