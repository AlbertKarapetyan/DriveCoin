namespace Common
{
    public class DriveException : Exception
    {
        public DriveException(string? message) : base(message)
        {
        }

        public DriveException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
