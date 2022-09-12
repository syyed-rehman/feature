using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;

namespace SongLyrics.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Artist, ArtistDto>();
            CreateMap<Song, SongDto>();     
        }
    }
}
