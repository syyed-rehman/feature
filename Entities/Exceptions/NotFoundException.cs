namespace Entities.Exceptions
{
    /// <summary>
    /// Abstract class which serves as base class for all Not Found type exceptions
    /// </summary>
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message) : base(message)
        {
        }
    }
}
