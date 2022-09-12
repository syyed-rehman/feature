using System.Text.Json;

namespace Entities.ErrorModel
{
    /// <summary>
    /// Custom class to produce Error details.
    /// </summary>
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        /// <summary>
        /// Overriding To String method to get Json string.
        /// </summary>
        /// <returns>A Json string representation of value.</returns>
        public override string ToString() => JsonSerializer.Serialize(this);

    }
}