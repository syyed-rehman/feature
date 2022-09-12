using SongLyrics.Console.Contract;
using SongLyrics.Console.Models;
using SongLyrics.Console.Models.Exceptions;
using System.Text.Json;

namespace SongLyrics.Console.Service
{
    public class SongService : ISongService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SongService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<int> GetAverageWordsInSong(string lyrics)
        {
            if (string.IsNullOrWhiteSpace(lyrics))
                throw new SongLyricsNullException($"Song lyrics cannot be null.");

            return await CountWordsInLyrics(lyrics);
        }

        public async Task<IEnumerable<SongDto>> GetSongsAsync(int artistId)
        {
            var httpClient = _httpClientFactory.CreateClient("APIClient");

            var response = await httpClient.GetAsync($"api/artists/{artistId}/songs").ConfigureAwait(false);

            response.EnsureSuccessStatusCode();

            var songsString = await response.Content.ReadAsStringAsync();

            var songs = JsonSerializer.Deserialize<IEnumerable<SongDto>>(songsString,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return songs;
        }       

        private static Task<int> CountWordsInLyrics(string lyrics)
        {
            int character = 0;
            int word = 0;

            while (character <= lyrics.Length - 1)
            {
                if (lyrics[character] == ' ' || lyrics[character] =='\n' || lyrics[character] == '\t' || lyrics[character] == '?')
                    word++;

                character++;
            }
            return Task.FromResult(word);
        }       
    }
}
