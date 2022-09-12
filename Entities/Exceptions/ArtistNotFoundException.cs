namespace Entities.Exceptions
{
    public sealed class ArtistNotFoundException :NotFoundException
    {
        public ArtistNotFoundException(string name): base($"The artist with name: {name} doesn't exist.")
        {                
        }

        public ArtistNotFoundException(int id) : base($"The artist with id: {id} doesn't exist.")
        {
        }
    }
}
