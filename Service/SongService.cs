using AutoMapper;
using Entities.Exceptions;
using Repository.Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class SongService : ISongService
    {
        private readonly IRepositoryManager _repository;        
        private readonly IMapper _mapper;
        public SongService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;          
            _mapper = mapper;
        }
        public async Task<IEnumerable<SongDto>> GetSongsAsync(int artistId)
        {
            await CheckIfArtistExists(artistId);

            var songs = await _repository.Song.GetSongsAsync(artistId);
            
            var songsDto = _mapper.Map<IEnumerable<SongDto>>(songs);

            return songsDto;
        }

        private async Task CheckIfArtistExists(int artistId)
        {
            var artist = await _repository.Artist.GetArtistAsync(artistId);
            if (artist is null)
                throw new ArtistNotFoundException(artistId);
        }
       
    }
}
