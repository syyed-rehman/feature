using SongLyrics.Console.Contract;
using SongLyrics.Console.Models;
using System.Text.Json;

namespace SongLyrics.Console.Service
{
    public sealed class ArtistService : IArtistService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ArtistService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ArtistDto> GetArtistAsync(string name)
        {
            var httpClient = _httpClientFactory.CreateClient("APIClient"); 

            var response = await httpClient.GetAsync($"api/artists/{name}").ConfigureAwait(false);
            
            response.EnsureSuccessStatusCode(); 
            
            var artistString = await response.Content.ReadAsStringAsync();
            
            var artist = JsonSerializer.Deserialize<ArtistDto>(artistString, 
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return artist;
        }
    }
}
