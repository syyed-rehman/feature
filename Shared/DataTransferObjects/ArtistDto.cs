namespace Shared.DataTransferObjects
{
    public record ArtistDto
    {
        public int ID { get; init; }       
        public string? Name { get; init; }
    }
}
