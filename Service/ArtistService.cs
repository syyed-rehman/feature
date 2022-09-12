using AutoMapper;
using Entities.Exceptions;
using Entities.Models;
using Repository.Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class ArtistService :IArtistService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ArtistService(IRepositoryManager repository,IMapper mapper)
        {
           _repository = repository;
           _mapper = mapper;
        }

        public async Task<ArtistDto> GetArtistAsync(string name)
        {
            var artist = await GetArtistAndCheckIfItExists(name);

            var artistDto = _mapper.Map<ArtistDto>(artist);
            return artistDto;
        }

        private async Task<Artist> GetArtistAndCheckIfItExists(string name)
        {
            var artist = await _repository.Artist.GetArtistAsync(name);
            if (artist is null)
                throw new ArtistNotFoundException(name);

            return artist;
        }
    }
}
