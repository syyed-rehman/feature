namespace Repository.Contracts
{
    public interface IRepositoryManager
    {
        IArtistRepository Artist { get; }
        ISongRepository Song { get; }
    }
}
