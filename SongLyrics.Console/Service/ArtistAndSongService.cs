using Microsoft.Extensions.DependencyInjection;
using SongLyrics.Console.Contract;
using System.Text;

namespace SongLyrics.Console.Service
{
    public class ArtistAndSongService : IArtistAndSongService
    {
        public async Task<string> GetArtistSongsAndCountLyrics(string artistName, IServiceProvider services)
        {
            var managerService = services.GetService<IServiceManager>();
            var artist = await managerService.ArtistService.GetArtistAsync(artistName);            
            var songs = await managerService.SongService.GetSongsAsync(artistId: artist.Id);

            var sb = new StringBuilder();
            sb.Append($"\n\tArtist Name : {artist.Name}\n\t--------------------------------\n\tTitle\t\t\tWords\n\t--------------------------------\n");

            foreach (var song in songs)
            {
                var totalWords = await managerService.SongService.GetAverageWordsInSong(song.Lyrics);
                sb.Append($"\t{song.Title}\t\t{totalWords}\n");
            }

            return sb.ToString();
        }
    }
}
