using System.Text.Json;

namespace SongLyrics.Console.Models
{
    public record ArtistDto
    {
        public int Id { get; init; }
        public string? Name { get; init; }

        public ArtistDto()
        {

        }
        public override string ToString() => JsonSerializer.Serialize(this);
        
    }
}
