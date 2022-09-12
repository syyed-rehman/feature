namespace Entities.Exceptions
{
    /// <summary>
    /// Abstract class which serves as base class for all Bad Request type exceptions
    /// </summary>
    public abstract class BadRequestException : Exception
    {
        protected BadRequestException(string message) : base(message)
        {
        }
    }
}
