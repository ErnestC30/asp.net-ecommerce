namespace backend.Exceptions;

public class UnsupportedFileTypeException : Exception
{
    public UnsupportedFileTypeException(string message) : base(message) { }
}
