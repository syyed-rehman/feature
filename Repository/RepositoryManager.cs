using Repository.Contracts;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IArtistRepository> _artistRepository;
        private readonly Lazy<ISongRepository> _songRepository;
        public RepositoryManager()
        {
            _artistRepository = new Lazy<IArtistRepository>(() => new ArtistRepository());
            _songRepository = new Lazy<ISongRepository>(() => new SongRepository());
        }
        public IArtistRepository Artist => _artistRepository.Value;
        public ISongRepository Song => _songRepository.Value;
    }
}
