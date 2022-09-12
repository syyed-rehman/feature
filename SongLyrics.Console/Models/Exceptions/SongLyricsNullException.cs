namespace SongLyrics.Console.Models.Exceptions
{
    public sealed class SongLyricsNullException : CannotBeNull
    {
        public SongLyricsNullException(string message):base(message)
        {

        }
    }
}
