using Entities.Models;
using Repository.Contracts;

namespace Repository
{
    internal sealed class ArtistRepository : IArtistRepository
    {

        public async Task<Artist> GetArtistAsync(int id) =>
           await Task.Run(() => Artists().FirstOrDefault(a => a.ID.Equals(id)));
        public async Task<Artist> GetArtistAsync(string name) =>
            await Task.Run(() => Artists().FirstOrDefault(a => a.Name.ToLower() == name.ToLower()));        

        private static IEnumerable<Artist> Artists()
        {
            return new List<Artist>()
            {
                new Artist
                {
                    ID=1,
                    Name="Michael Jackson"
                },
                new Artist
                {
                    ID=2,
                    Name="Justin Bieber"
                },
                new Artist
                {
                    ID=3,
                    Name="Taylor Swift"
                }
            };
        }

        
    }
}
