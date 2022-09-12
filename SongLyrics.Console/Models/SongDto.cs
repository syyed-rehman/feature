namespace SongLyrics.Console.Models
{
    public record SongDto
    {
        public int ArtistID { get; init; }
        public string? Title { get; init; }
        public string? Lyrics { get; init; }     
       
    }
}
